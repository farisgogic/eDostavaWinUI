using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class NarudzbaStavke
    {
        public int NarudzbaStavkeId { get; set; }
        public int NarudzbaId { get; set; }
        public int JeloId { get; set; }
        public int Kolicina { get; set; }
        
        public virtual Narudzba Narudzba { get; set; }
        public virtual Jelo Jelo { get; set; }
    }
}
