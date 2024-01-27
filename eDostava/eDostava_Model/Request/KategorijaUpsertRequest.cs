using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.Request
{
    public class KategorijaUpsertRequest
    {
        public string Naziv { get; set; }
        public int RestoranId { get; set; }

    }
}
