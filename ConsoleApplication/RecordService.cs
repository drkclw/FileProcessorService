using IdComLog.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class RecordService : IRecordService
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

                foreach (string file in pipeDelimitedFiles)
                {
                    using (TextReader reader = File.OpenText(file))
                    {
                        var pipeDelimitedReader = new CsvReader<Record>(reader, null, '|');
                        while (pipeDelimitedReader.Read())
                        {
                            records.Add(pipeDelimitedReader.CurrentObject.Value);
                        }
                    }
                }

                foreach (string file in spaceDelimitedFiles)
                {
                    using (TextReader reader = File.OpenText(file))
                    {

                        var spaceDelimitedReader = new CsvReader<Record>(reader, null, ' ');
                        while (spaceDelimitedReader.Read())
                        {
                            records.Add(spaceDelimitedReader.CurrentObject.Value);
                        }
                    }
                }
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

        public void OutputRecords(string sortBy, IEnumerable<Record> records, bool reverse = false)
        {
            Console.WriteLine(string.Format("{0, -15} {1, -15} {2, -10} {3, -15} {4, -10}", "First name", "Last name", "Gender", "Favorite Color", "Date of birth"));            
            var sortedRecords = records.Sort(sortBy, reverse);
            foreach (Record record in sortedRecords)
            {
                Console.WriteLine(record.ToString());
            }
        }
    }
}
