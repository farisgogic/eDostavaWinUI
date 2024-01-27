using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Services.Restoran;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDostava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RestoranController : BaseCRUDController<Model.Restoran, RestoranSearchObject, RestoranInsertRequest, RestoranUpdateRequest>
    {

        public RestoranController(IRestoranService restoranService):base(restoranService)
        {
        }
    }
}
