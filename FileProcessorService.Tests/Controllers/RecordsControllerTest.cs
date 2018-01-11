using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileProcessorService;
using FileProcessorService.Controllers;
using System.Web.Http.Results;
using System.Web.Hosting;
using System.Configuration;
using Moq;
using DataAccess;
using FileProcessorService.Models;

namespace FileProcessorService.Tests.Controllers
{
    [TestClass]
    public class RecordsControllerTest
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
                DateOfBirth = DateTime.Parse("01/01/1985")
            };

            var spaceDelimitedRecord = new Record
            {
                FirstName = "Diana",
                LastName = "Prince",
                Gender = "Female",
                FavoriteColor = "Blue",
                DateOfBirth = DateTime.Parse("01/10/1985")
            };

            var pipeDelimitedRecord = new Record
            {
                FirstName = "Tony",
                LastName = "Stark",
                Gender = "Male",
                FavoriteColor = "Red",
                DateOfBirth = DateTime.Parse("01/02/1985")
            };

            records = new List<Record>();

            records.Add(commaDelimitedRecord);
            records.Add(pipeDelimitedRecord);
            records.Add(spaceDelimitedRecord);
        }

        [TestMethod]
        public void Gender()
        {
            // Arrange                            
            var mockFileProcessor = new Mock<IRecordService>();
            mockFileProcessor.Setup(x => x.ImportRecords()).Returns(records);

            RecordsController controller = new RecordsController(mockFileProcessor.Object);

            // Act
            IHttpActionResult result = controller.Gender();
            var contentResult = result as JsonResult<IOrderedEnumerable<Record>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count());
            Assert.AreEqual("Female", contentResult.Content.ElementAt(0).Gender);
        }
        
        [TestMethod]
        public void BirthDate()
        {
            // Arrange       
            var mockFileProcessor = new Mock<IRecordService>();
            mockFileProcessor.Setup(x => x.ImportRecords()).Returns(records);
            RecordsController controller = new RecordsController(mockFileProcessor.Object);

            // Act
            IHttpActionResult result = controller.BirthDate();
            var contentResult = result as JsonResult<IOrderedEnumerable<Record>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count());
            Assert.AreEqual("01/01/1985", contentResult.Content.ElementAt(0).DateOfBirth);
        }

        [TestMethod]
        public void Name()
        {
            // Arrange                        
            var mockFileProcessor = new Mock<IRecordService>();
            mockFileProcessor.Setup(x => x.ImportRecords()).Returns(records);
            RecordsController controller = new RecordsController(mockFileProcessor.Object);

            // Act
            IHttpActionResult result = controller.Name();
            var contentResult = result as JsonResult<IOrderedEnumerable<Record>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count());
            Assert.AreEqual("Bruce", contentResult.Content.ElementAt(0).FirstName);
        }


        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    RecordsController controller = new RecordsController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}


    }
}
