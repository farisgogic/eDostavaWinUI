using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.Request
{
    public class DostavljacInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }


        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }


        [MinLength(4)]
        [Required(AllowEmptyStrings = false)]
        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }

        public string LozinkaPotvrda { get; set; }


        public List<int> UlogeIdList { get; set; } = new List<int> { };

    }
}
