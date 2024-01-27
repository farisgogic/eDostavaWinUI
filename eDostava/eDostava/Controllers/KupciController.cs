using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services;
using eDostava.Services.Kupci;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace eDostava.Controllers
{
    [AllowAnonymous]
    public class KupciController : BaseCRUDController<Model.Kupci, KupciSearchObject, KupciInsertRequest, KupciUpdateRequest>
    {
        private readonly IKupciService kupciService;
        private readonly ITokenService tokenService;

        public KupciController(IKupciService KupciService, ITokenService tokenService):base(KupciService)
        {
            this.kupciService = KupciService;
            this.tokenService = tokenService;
        }

        [AllowAnonymous]
        public override Kupci Insert([FromBody] KupciInsertRequest insert)
        {
            return base.Insert(insert);
        }

        public override Kupci Update(int id, [FromBody] KupciUpdateRequest update)
        {
            return base.Update(id, update);
        }

        [HttpPost("login")]
        public ActionResult<Model.Kupci> Login([FromBody] LoginRequest loginRequest)
        {
            var kupac = kupciService.Login(loginRequest.Username, loginRequest.Password);
            if (kupac == null)
            {
                return Unauthorized();
            }

            var token = tokenService.GenerateToken(kupac);

            var response = new LoginResponse()
            {
                Kupac = kupac,
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
