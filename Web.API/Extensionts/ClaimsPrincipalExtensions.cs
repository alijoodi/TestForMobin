using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Web.API.Extensionts
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
