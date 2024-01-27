using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Services.Korisnik;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDostava.Controllers
{
    public class KorisnikController : BaseCRUDController<Model.Korisnik, KorisnikSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        public KorisnikController(IKorisnikService korisnikService):base(korisnikService)
        {
        }

        [AllowAnonymous]
        public override Korisnik Insert([FromBody] KorisniciInsertRequest insert)
        {
            return base.Insert(insert);
        }

        [AllowAnonymous]
        public override Korisnik Update(int id, [FromBody] KorisniciUpdateRequest update)
        {
            return base.Update(id, update);
        }
    }
}
