using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services;
using eDostava.Services.Dostavljac;
using eDostava.Services.Kupci;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace eDostava.Controllers
{
    [AllowAnonymous]
    public class DostavljacController : BaseCRUDController<Model.Dostavljac, DostavljacSearchObject, DostavljacInsertRequest, DostavljacUpdateRequest>
    {
        private readonly IDostavljacService dostavljacService;
        private readonly ITokenService tokenService;

        public DostavljacController(IDostavljacService DostavljacService, ITokenService tokenService):base(DostavljacService)
        {
            this.dostavljacService = DostavljacService;
            this.tokenService = tokenService;
        }

        [AllowAnonymous]
        public override Dostavljac Insert([FromBody] DostavljacInsertRequest insert)
        {
            return base.Insert(insert);
        }

        public override Dostavljac Update(int id, [FromBody] DostavljacUpdateRequest update)
        {
            return base.Update(id, update);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<Model.Dostavljac> Login([FromBody] LoginRequest loginRequest)
        {
            var dostavljac = dostavljacService.Login(loginRequest.Username, loginRequest.Password);
            if (dostavljac == null)
            {
                return Unauthorized();
            }

            var token = tokenService.GenerateToken(dostavljac);

            var response = new LoginResponseDostavljac()
            {
                Dostavljac = dostavljac,
                Token = token
            };

            return Ok(response);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic "))
            {
                var token = authHeader.Substring("Basic ".Length);
                Response.Cookies.Delete("jwt");
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
