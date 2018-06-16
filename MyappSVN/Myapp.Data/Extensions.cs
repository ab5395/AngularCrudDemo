using System;
using System.Linq;
using System.Security.Claims;

namespace Myapp.Data
{
    public static class Extensions
    {
    }

    /**Get Current User id**/
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            //return principal.FindFirstValue(ClaimTypes.NameIdentifier);
            return principal.Identities.FirstOrDefault().Name;
        }
    }
}
