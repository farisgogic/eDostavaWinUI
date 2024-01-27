using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            JeloKategorijas = new HashSet<JeloKategorija>();
        }

        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public int RestoranId { get; set; }
        public virtual ICollection<JeloKategorija> JeloKategorijas { get; set; }

    }
}
