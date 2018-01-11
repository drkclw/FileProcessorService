using DataAccess;
using IdComLog.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FileProcessorService.Models
{
    public class ApiRecordService : RecordService
    {
        public override void OutputRecords(string sortBy, IEnumerable<Record> records, bool reverse = false)
        {
            throw new NotImplementedException();
        }

        public override bool ExportRecord(ExportRecord record)
        {
            string file;

            if (record.Delimiter == ",")
            {
                string[] commaDelimitedFiles = Directory.GetFiles(ConfigurationManager.AppSettings["commaDelimitedLocation"]);
                file = commaDelimitedFiles[0];
                File.AppendAllText(file, "\n" + record.LastName + "," + record.FirstName + "," + record.Gender + "," + record.FavoriteColor + "," + record.DateOfBirth);
            }else if (record.Delimiter == "|")
            {
                string[] pipeDelimitedFiles = Directory.GetFiles(ConfigurationManager.AppSettings["pipeDelimitedLocation"]);
                file = pipeDelimitedFiles[0];
                File.AppendAllText(file, "\n" + record.LastName + "|" + record.FirstName + "|" + record.Gender + "|" + record.FavoriteColor + "|" + record.DateOfBirth);
            }
            else
            {
                string[] spaceDelimitedFiles = Directory.GetFiles(ConfigurationManager.AppSettings["spaceDelimitedLocation"]);
                file = spaceDelimitedFiles[0];
                File.AppendAllText(file, "\n" + record.LastName + " " + record.FirstName + " " + record.Gender + " " + record.FavoriteColor + " " + record.DateOfBirth);
            }            

            return true;
        }
    }
}