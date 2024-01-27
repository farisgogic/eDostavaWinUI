using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model.Request
{
    public class LoginResponseDostavljac
    {
        public Model.Dostavljac Dostavljac { get; set; }
        public string Token { get; set; }
    }
}
