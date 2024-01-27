using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.Request
{
    public class NarudzbaUpdateRequest
    {
        public int StatusNarudzbeId { get; set; }
        public int? DostavljacId { get; set; }
    }
}
