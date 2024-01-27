using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.SearchObjects
{
    public class NarudzbaSearchObject : BaseSearchObject
    {   
        public int? RestoranId { get; set; }
        public string? BrojNarudzbe { get; set; }
        public int? narudzbaId { get; set; }
        public int? kupacId { get; set; }
        public int? stanje { get; set; }

    }
}
