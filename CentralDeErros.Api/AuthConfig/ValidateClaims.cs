using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CentralDeErros.Api.AuthConfig
{
    public class ValidateClaims
    {
        public static bool ValidadeClaimsUser(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated && context.User.Claims.Any(x => x.Type == claimName && x.Value.Split(',').Contains(claimValue));
        }
    }
}
