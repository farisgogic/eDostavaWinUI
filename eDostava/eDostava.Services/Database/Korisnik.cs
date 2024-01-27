using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            KorisnikUloga = new HashSet<KorisnikUloga>();
            Narudzba = new HashSet<Narudzba>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool? Status { get; set; }

        public Restoran Restoran { get; set; }
        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
        public ICollection<Narudzba> Narudzba { get; set; }
    }
}
