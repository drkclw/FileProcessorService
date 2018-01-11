using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Results;

namespace FileProcessorService.Controllers
{
    public class RecordsController : ApiController
    {
        IRecordService _recordService;

        public RecordsController()
        {

        }

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }
         
        [HttpGet]
        public IHttpActionResult Gender()
        {            
            IEnumerable<Record> records = _recordService.ImportRecords();
            return Json(records.OrderBy(record => record.Gender));
        }

        [HttpGet]
        public IHttpActionResult BirthDate()
        {            
            IEnumerable<Record> records = _recordService.ImportRecords();
            return Json(records.OrderBy(record => record.DateOfBirth));
        }

        [HttpGet]
        public IHttpActionResult Name()
        {            
            IEnumerable<Record> records = _recordService.ImportRecords();            
            return Json(records.OrderBy(record => record.FirstName));
        }
        
        public void Post([FromBody] ExportRecord record)
        {
            bool exported = _recordService.ExportRecord(record);
        }              
    }
}
