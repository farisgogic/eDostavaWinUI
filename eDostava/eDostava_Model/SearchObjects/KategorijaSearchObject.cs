using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.SearchObjects
{
    public class KategorijaSearchObject : BaseSearchObject
    {
        public string? NazivGT { get; set; }
        public int? RestoranId { get; set; }
    }
}
