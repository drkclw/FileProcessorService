using DataAccess;
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
    public class ConsoleRecordService : RecordService
    {        
        public override void OutputRecords(string sortBy, IEnumerable<Record> records, bool reverse = false)
        {
            Console.WriteLine(string.Format("{0, -15} {1, -15} {2, -10} {3, -15} {4, -10}", "First name", "Last name", "Gender", "Favorite Color", "Date of birth"));            
            var sortedRecords = records.Sort(sortBy, reverse);
            foreach (Record record in sortedRecords)
            {
                Console.WriteLine(record.ToString());
            }
        }

        public override bool ExportRecord(ExportRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
