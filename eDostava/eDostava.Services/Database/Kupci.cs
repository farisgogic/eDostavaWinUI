using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class Kupci
    {
        public Kupci()
        {
            Narudzbe = new HashSet<Narudzba>();
            Favoriti = new HashSet<Favoriti>();
        }

        [Key]
        public int KupacId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;

        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
        public virtual ICollection<Favoriti> Favoriti { get; set; }
        public virtual ICollection<Narudzba> Narudzbe { get; set; }
    }
}
