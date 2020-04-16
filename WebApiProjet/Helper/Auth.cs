using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace WebApiProjet.Helper
{
    public class Auth : Attribute, IAuthenticationFilter
    {
       // private UserService _userService = new UserService();
        private VerifService _verif = new VerifService();
        private readonly string realm;
        private readonly string _domaine;
        public bool AllowMultiple { get { return false; } }
        public Auth()
        {
            
        }
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            try
            {
                HttpRequestMessage req = context.Request;
                if (req.Headers.Authorization == null || !req.Headers.Authorization.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
                {
                    throw new UnauthorizedAccessException();
                }
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string credentials = encoding.GetString(Convert.FromBase64String(req.Headers.Authorization.Parameter));
                string[] parts = credentials.Split(':');
                string login = parts[0].Trim();
                string password = parts[1].Trim();
                if (!_verif.CheckHost(req.Headers.Host) || !_verif.Check(login, password))
                {
                    throw new UnauthorizedAccessException();
                }
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,login)
            };
                var id = new ClaimsIdentity(claims, "Basic");
                var principal = new ClaimsPrincipal(new[] { id });
                context.Principal = principal;

            }
            catch (UnauthorizedAccessException ex)
            {
                context.ErrorResult = new UnauthorizedResult(
                     new AuthenticationHeaderValue[0],
                                          context.Request);
            }
            return Task.FromResult(0);


        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new ResultWithChallenge(context.Result, realm);
            return Task.FromResult(0);
        }
    }
}