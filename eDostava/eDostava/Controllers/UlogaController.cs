using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Uloga;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDostava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UlogaController : BaseCRUDController<Model.Uloga, UlogaSearchObject, UlogaUpsertRequest, UlogaUpsertRequest>
    {
        public UlogaController(IUlogaService ulogaService):base(ulogaService)
        {}
    }
}
