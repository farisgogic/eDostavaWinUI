using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.Request
{
    public class DostavljacUpdateRequest
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }


        public string Email { get; set; }

        public string Lozinka { get; set; }

        public string LozinkaPotvrda { get; set; }

    }
}
