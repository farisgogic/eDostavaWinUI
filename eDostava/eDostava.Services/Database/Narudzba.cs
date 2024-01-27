using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public enum StanjeNarudzbe
    {
        NaCekanju,
        UPripremi,
        Spremna,
        UProcesuIsporuke,
        Isporuceno
    }

    public partial class Narudzba
    {
        public Narudzba()
        {
            NarudzbaStavke = new HashSet<NarudzbaStavke>();
        }

        public int NarudzbaId { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public int KupacId { get; set; }
        public int? DostavljacId { get; set; }
        public int RestoranId { get; set; }
        public bool Status { get; set; }
        public bool? Otkazano { get; set; }
        public StanjeNarudzbe Stanje { get; set; }

        public virtual Dostavljac Dostavljac { get; set; }
        public virtual Kupci Kupac { get; set; }
        public virtual Restoran Restoran { get; set; }
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
    }
}
