using IdComLog.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class RecordService : IRecordService
    {        
        public IEnumerable<Record> ImportRecords()
        {
            List<Record> records = new List<Record>();
            try
            {                
                string[] commaDelimitedFiles = Directory.GetFiles(ConfigurationManager.AppSettings["commaDelimitedLocation"]);
                string[] pipeDelimitedFiles = Directory.GetFiles(ConfigurationManager.AppSettings["pipeDelimitedLocation"]);
                string[] spaceDelimitedFiles = Directory.GetFiles(ConfigurationManager.AppSettings["spaceDelimitedLocation"]);

                foreach (string file in commaDelimitedFiles)
                {
                    records.AddRange(IdComLog.Data.Formats.Csv.ReadObjects<Record>(file));                    
                }

                records.AddRange(ParseRecords(pipeDelimitedFiles, '|'));
                records.AddRange(ParseRecords(spaceDelimitedFiles, ' '));                
            }
            catch (NullReferenceException nrex)
            {
                Console.WriteLine(nrex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                            
            return records;
        }

        public abstract void OutputRecords(string sortBy, IEnumerable<Record> records, bool reverse = false);

        public abstract bool ExportRecord(ExportRecord record);

        private IEnumerable<Record> ParseRecords(string[] files, char delimiter)
        {
            List<Record> records = new List<Record>();

            foreach (string file in files)
            {
                using (TextReader reader = File.OpenText(file))
                {

                    var spaceDelimitedReader = new CsvReader<Record>(reader, null, delimiter);
                    while (spaceDelimitedReader.Read())
                    {
                        records.Add(spaceDelimitedReader.CurrentObject.Value);
                    }
                }
            }

            return records;
        }
    }
}
