using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class KorisnikUloga
    {
        public int KorisnikUlogaId { get; set; }
        public int UlogaId { get; set; }
        public int? KorisnikId { get; set; }
        public int? KupciId { get; set; }
        public int? DostavljacId { get; set; }
        public DateTime DatumPromjene { get; set; }

        public Kupci Kupci { get; set; }
        public Dostavljac Dostavljac { get; set; }
        public Korisnik Korisnik { get; set; }
        public Uloga Uloga { get; set; }
    }
}
