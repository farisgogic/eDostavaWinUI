using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model
{
    public partial class Korisnik
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public bool? Status { get; set; }
        public string FullName
        {
            get
            {
                return Ime + " " + Prezime;
            }
        }

        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
        public string UlogaIme => string.Join(" ", KorisnikUloga?.Select(x => x.Uloga?.Naziv)?.ToList());

    }
}
