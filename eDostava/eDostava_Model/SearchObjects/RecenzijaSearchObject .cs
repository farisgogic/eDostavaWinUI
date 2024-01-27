using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.SearchObjects
{
    public class RecenzijaSearchObject : BaseSearchObject
    {
        public int? kupacId { get; set; }
        public int? restoranId { get; set; }
    }
}
