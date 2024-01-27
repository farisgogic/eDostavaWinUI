using System.Collections.Generic;
using System.Linq;

namespace eDostava.Model
{
    public partial class Jelo
    {
        public int JeloId { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public byte[]? Slika { get; set; }

        public decimal Ocjena { get; set; }
        public int RestoranId { get; set; }

        public virtual ICollection<JeloKategorija> JeloKategorijas { get; set; }

        public string KategorijaNames => string.Join(", ", JeloKategorijas?.Select(x => x.Kategorija?.Naziv)?.ToList());
    }
}
