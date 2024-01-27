using eDostava.Services;
using eDostava.Services.Services.Korisnik;
using eDostava.Services.Services.Restoran;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDostava.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [Authorize]

    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IService<T, TSearch> Service { get; set; }
        public BaseController(IService<T, TSearch> service)
        { 
            Service = service;
        }

        [HttpGet]
        public IEnumerable<T> Get([FromQuery]TSearch search = null) 
        {
            return Service.Get(search);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return Service.GetById(id);
        }
    }
}
