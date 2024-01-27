using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class Uloga
    {
        public Uloga()
        {
            KorisnikUloga = new HashSet<KorisnikUloga>();
        }

        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}
