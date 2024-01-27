using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.Request
{
    public class JelaOcjeneUpsertRequest
    {
        public int Ocjena { get; set; }
        public string? Komentar { get; set; }
        public int KupacId { get; set; }
        public int JeloId { get; set; }

    }
}
