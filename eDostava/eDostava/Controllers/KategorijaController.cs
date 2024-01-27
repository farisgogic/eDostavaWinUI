using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services;
using eDostava.Services.Jelo;
using eDostava.Services.Kategorija;
using eDostava.Services.Services.Restoran;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDostava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class KategorijaController : BaseCRUDController<Model.Kategorija, KategorijaSearchObject, KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
        public IKategorijaService KategorijaService { get; set; }
        public KategorijaController(IKategorijaService kategorijaService) : base(kategorijaService)
        {
            KategorijaService = kategorijaService;
        }
    } 
}
