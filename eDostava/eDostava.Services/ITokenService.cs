using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services
{
    public interface ITokenService
    {
        string GenerateToken(Model.Kupci kupac);
        string GenerateToken(Model.Dostavljac dostavljac);
    }
}
