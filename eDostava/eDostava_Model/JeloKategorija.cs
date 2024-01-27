using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model
{
    public partial class JeloKategorija
    {
        public int JeloKategorijaId { get; set; }
        public int JeloId { get; set; }
        public int KategorijaId { get; set; }
        public virtual Kategorija Kategorija { get; set; }
    }
}
