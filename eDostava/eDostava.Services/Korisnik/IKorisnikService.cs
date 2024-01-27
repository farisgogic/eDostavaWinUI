using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Services.Korisnik
{
    public interface IKorisnikService : ICRUDService<eDostava.Model.Korisnik, KorisnikSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        Model.Korisnik Login(string username, string password);
    }
}
