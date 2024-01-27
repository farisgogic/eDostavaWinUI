using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Model
{
    public class UserException : Exception
    {
        public UserException(string poruka) : base(poruka)
        {

        }
    }
}
