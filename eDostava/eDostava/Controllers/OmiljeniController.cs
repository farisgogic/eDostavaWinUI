using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services;
using eDostava.Services.Omiljeni;
using eDostava.Services.Services.Korisnik;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDostava.Controllers
{
    [AllowAnonymous]
    public class OmiljeniController : BaseCRUDController<Model.Favoriti, OmiljeniSearchObject, OmiljeniUpsertRequest, OmiljeniUpsertRequest>
    {
        public IOmiljeniService OmiljeniService { get; set; }
        public OmiljeniController(IOmiljeniService omiljeniService):base(omiljeniService)
        {
            OmiljeniService = omiljeniService;
        }


        [HttpDelete("RemoveJeloFromOmiljeniList/{kupacId}/{jeloId}/{restoranId}")]
        public IActionResult RemoveJeloFromOmiljeniList(int kupacId, int jeloId, int restoranId)
        {
            try
            {
                OmiljeniService.RemoveJeloFromOmiljeniList(kupacId, jeloId, restoranId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
 