using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class Jelo
    {
        public Jelo()
        {
            JeloKategorijas = new HashSet<JeloKategorija>();
        }

        public int JeloId { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string? Opis { get; set; }
        public byte[]? Slika { get; set; }

        [Range(1,5)]
        public decimal? Ocjena { get; set; }

        public virtual ICollection<JeloKategorija> JeloKategorijas { get; set; }

        public int RestoranId { get; set; }
        public Restoran Restoran { get; set; }
    }
}
