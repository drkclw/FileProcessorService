using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExportRecord : Record
    {
        //[JsonIgnore]
        public string Delimiter { get; set; }
    }
}
