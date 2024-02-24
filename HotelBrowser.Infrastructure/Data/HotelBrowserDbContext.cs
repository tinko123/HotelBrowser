using HotelBrowser.Infrastructure.Data.Models;
using HotelBrowser.Infrastructure.Data.SeedDb;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WorkCategoryConfiguration());
            base.OnModelCreating(builder);
        }
        public DbSet<Hotel> Hotels { get; set; } = null!;
        public DbSet<WorkCategory> WorkCategories { get; set; } = null!;
    }
}
