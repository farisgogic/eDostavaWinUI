using eDostava.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public class JeloKategorija
    {
        public int JeloKategorijaId { get; set; }
        public int JeloId { get; set; }
        public int KategorijaId { get; set; }

        public virtual Jelo Jelo { get; set; } = null!;
        public virtual Kategorija Kategorija { get; set; } = null!;
    }
}
