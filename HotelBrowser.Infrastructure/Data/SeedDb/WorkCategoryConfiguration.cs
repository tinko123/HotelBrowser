using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBrowser.Infrastructure.Data.SeedDb
{
    internal class WorkCategoryConfiguration : IEntityTypeConfiguration<WorkCategory>
    {
        public void Configure(EntityTypeBuilder<WorkCategory> builder)
        {
            var data = new SeedData();

            builder.HasData(new WorkCategory[] { data.Year, data.Summer, data.Winter });

        }
    }
}
