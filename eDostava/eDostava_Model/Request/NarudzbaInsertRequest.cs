using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.Request
{
    public class NarudzbaInsertRequest
    {
        public List<NarudzbaStavka> Items { get; set; } = new List<NarudzbaStavka>();
        public int KupacId { get; set; }
        public int RestoranId { get; set; }

    }
}