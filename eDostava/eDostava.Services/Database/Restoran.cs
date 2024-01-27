using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class Restoran
    {
        public Restoran()
        {
            Jela = new HashSet<Jelo>();
            Kategorija = new HashSet<Kategorija>();
        }

        public int RestoranId { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string RadnoVrijeme { get; set; }
        public string Opis { get; set; }
        public decimal? Ocjena { get; set; }
        public Byte[]? Slika { get; set; }

        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public ICollection<Jelo> Jela { get; set; }
        public ICollection<Kategorija> Kategorija { get; set; }
    }
}
