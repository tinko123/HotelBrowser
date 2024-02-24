using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBrowser.Data
{
    public class HotelsBrowserDbContext : IdentityDbContext
    {
        public HotelsBrowserDbContext(DbContextOptions<HotelsBrowserDbContext> options)
            : base(options)
        {
        }
    }
}
