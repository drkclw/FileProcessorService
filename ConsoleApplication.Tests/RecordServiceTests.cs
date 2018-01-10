using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ConsoleApplication.Tests
{
    [TestClass()]
    public class RecordServiceTests
    {
        private List<Record> records;

        [TestInitialize]
        public void Initialize()
        {
            var commaDelimitedRecord = new Record
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Gender = "Male",
                FavoriteColor = "Black",
                DateOfBirth = "01/01/1985"
            };

            var spaceDelimitedRecord = new Record
            {
                FirstName = "Diana",
                LastName = "Prince",
                Gender = "Female",
                FavoriteColor = "Blue",
                DateOfBirth = "01/10/1985"
            };

            var pipeDelimitedRecord = new Record
            {
                FirstName = "Tony",
                LastName = "Stark",
                Gender = "Male",
                FavoriteColor = "Red",
                DateOfBirth = "01/02/1985"
            };

            records = new List<Record>();

            records.Add(commaDelimitedRecord);
            records.Add(pipeDelimitedRecord);
            records.Add(spaceDelimitedRecord);
        }

        [TestMethod()]
        public void RecordsSortedByGenderAndLastNameTest()
        {            
            IRecordService _recordService = new RecordService();
            _recordService.OutputRecords("Gender, LastName", records);            
        }

        [TestMethod()]
        public void RecordsSortedByBirthDayTest()
        {
            IRecordService _recordService = new RecordService();
            _recordService.OutputRecords("DateOfBirth", records);
        }

        [TestMethod()]
        public void RecordsSortedByLastNameTest()
        {
            IRecordService _recordService = new RecordService();
            _recordService.OutputRecords("LastName", records, true);
        }
    }
}