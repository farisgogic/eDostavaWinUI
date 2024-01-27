using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model
{
    public partial class NarudzbaStavka
    {
        public int NarudzbaStavkaId { get; set; }
        public int NarudzbaId { get; set; }
        public int JeloId { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
        public string Naziv { get; set; }

        public void IzracunajCijenu()
        {
            Cijena = Cijena * Kolicina;
        }

    }
}
