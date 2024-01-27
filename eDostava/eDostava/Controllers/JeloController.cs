using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services;
using eDostava.Services.Jelo;
using eDostava.Services.Services.Korisnik;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDostava.Controllers
{
     [AllowAnonymous]
    public class JeloController : BaseCRUDController<Model.Jelo, JeloSearchObject, JeloUpsertRequest, JeloUpsertRequest>
    {
        public IJeloService JeloService { get; set; }
        public JeloController(IJeloService jeloService):base(jeloService)
        {
            JeloService = jeloService;
        }

        public override Jelo Update(int id, [FromBody] JeloUpsertRequest update)
        {
            return base.Update(id, update);
        }

        [AllowAnonymous]
        [HttpGet("{kupacId}/{restoranId}/Recommend")]
        public List<Jelo> Recommend(int kupacId, int restoranId)
        {
            var result = JeloService.GetRecommendedJela(kupacId, restoranId);

            return result;
        }

    }
}
 