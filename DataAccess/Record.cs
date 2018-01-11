using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Record
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public string FavoriteColor { get; set; }

        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return string.Format("{0, -15} {1, -15} {2, -10} {3, -15} {4:M/d/yyyy}", FirstName.Trim(), LastName.Trim(), Gender.Trim(), FavoriteColor.Trim(), DateOfBirth);
        }
    }
}
