using eDostava.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class Favoriti
    {
        [Key]
        public int FavoritId { get; set; }

        public int KupacId { get; set; }
        public int JeloId { get; set; }
        public int RestoranId { get; set; }


        public Kupci? Kupci { get; set; }
        public Jelo? Jelo { get; set; }
        public Restoran? Restoran { get; set; }
    }
}
