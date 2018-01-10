using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public static class SortExtension
    {
        public static IEnumerable Sort(this IEnumerable collection, string sortBy, bool reverse = false)
        {
            return collection.OrderBy(sortBy + (reverse ? " descending" : ""));
        }
    }
}
