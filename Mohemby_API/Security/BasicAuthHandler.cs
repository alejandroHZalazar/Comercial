using Microsoft.AspNetCore.Authentication;
using Mohemby_API.Services;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Claims;

namespace Webapi.Security;

    public class BasicAuthHandler: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserApiService _userApiService;

        public BasicAuthHandler (IOptionsMonitor<AuthenticationSchemeOptions> options,
                                ILoggerFactory logger,
                                UrlEncoder encoder,
                                ISystemClock clock,
                                IUserApiService userApiService
                                ): base(options,logger,encoder,clock)
        {
            _userApiService = userApiService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No viene el encabezado");

                bool result = false;

                try
                {
                    var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                    var creatialBytes = Convert.FromBase64String(authHeader.Parameter);
                    var credential = Encoding.UTF8.GetString(creatialBytes).Split(new[]{':'},2);
                    var usuario = credential[0];
                    var password = credential[1];
                    result = _userApiService.CorrectCredential(usuario,password);
                }
                catch (Exception ex)
                {
                    return AuthenticateResult.Fail(ex.Message);
                }

            if (!result)
            return AuthenticateResult.Fail("Usuario o contraseña inválido");

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,"id"),
                new Claim(ClaimTypes.Name,"user")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal,Scheme.Name);
            return AuthenticateResult.Success(ticket);

        }
    }
