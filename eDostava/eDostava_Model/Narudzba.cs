using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model
{
    public partial class Narudzba
    {
        public int NarudzbaId { get; set; }
        public string BrojNarudzbe { get; set; }
        public int KupacId { get; set; }
        public string? KupacIme { get; set; }
        public int RestoranId { get; set; }
        public string? RestoranNaziv { get; set; }
        public int? DostavljacId { get; set; }
        public string? DostavljacIme { get; set; }

        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public bool? Otkazano { get; set; }

        public int Stanje { get; set; }
        public string StanjeTekst
        {
            get
            {
                switch (Stanje)
                {
                    case 0:
                        return "Na cekanju";
                    case 1:
                        return "U pripremi";
                    case 2:
                        return "Spremna";
                    case 3:
                        return "U procesu isporuke";
                    case 4:
                        return "Isporuceno";
                    default:
                        return "Nepoznato";
                }
            }
        }

        public virtual ICollection<NarudzbaStavka> NarudzbaStavke { get; set; }
    }
}
