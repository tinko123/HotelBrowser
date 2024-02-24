using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBrowser.Infrastructure.Data
{
    public class HotelBrowserDbContext : IdentityDbContext
    {
        public HotelBrowserDbContext(DbContextOptions<HotelBrowserDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
