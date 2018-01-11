using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRecordService
    {
        IEnumerable<Record> ImportRecords();

        void OutputRecords(string sortBy, IEnumerable<Record> records , bool reverse = false);

        bool ExportRecord(ExportRecord record);
    }
}
