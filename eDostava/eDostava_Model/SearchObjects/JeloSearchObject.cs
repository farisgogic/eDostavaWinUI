using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.SearchObjects
{
    public class JeloSearchObject : BaseSearchObject
    {
        public string? NazivGT { get; set; }

        public bool IncludeKategorija { get; set; }
        public int? RestoranId { get; set; }
        public int? KategorijaId { get; set; }

    }
}
