using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.Request
{
    public class RestoranUpdateRequest
    {
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string RadnoVrijeme { get; set; }
        public string Opis { get; set; }
        public decimal? Ocjena { get; set; }
        public Byte[]? Slika { get; set; }

    }
}
