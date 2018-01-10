using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public interface IRecordService
    {
        IEnumerable<Record> ImportRecords();

        void OutputRecords(string sortBy, IEnumerable<Record> records , bool reverse = false);
    }
}
