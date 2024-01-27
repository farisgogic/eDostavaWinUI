using eDostava.Services.Services.Korisnik;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

public class BasicAuthentitacionHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public IKorisnikService korisnikService;

    public BasicAuthentitacionHandler(IKorisnikService korisnikService, IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
        this.korisnikService = korisnikService;
    }

    protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing auth header");
        }

        var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
        var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');

        var username = credentials[0];
        var password = credentials[1];

        var user = korisnikService.Login(username, password);

        if(user == null)
        {
            return AuthenticateResult.Fail("Pogresno korisnicko ime ili lozinka");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, username),
            new Claim(ClaimTypes.Name, user.Ime)
        };

        foreach(var uloga in user.KorisnikUloga)
        {
            claims.Add(new Claim(ClaimTypes.Role, uloga.Uloga.Naziv));
        }

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);

        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}