using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public class Recenzija
    {
        public int RecenzijaId { get; set; }
        public DateTime Datum { get; set; }
        public int Ocjena { get; set; }
        public string? Komentar { get; set; }
        public int KupacId { get; set; }
        public int? RestoranId { get; set; }
    }
}
