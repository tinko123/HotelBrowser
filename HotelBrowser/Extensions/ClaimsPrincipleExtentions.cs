using System.Security.Claims;

namespace HotelBrowser.Extensions
{
    public static class ClaimsPrincipleExtentions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
