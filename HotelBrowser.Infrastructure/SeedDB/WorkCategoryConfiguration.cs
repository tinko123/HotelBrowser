using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBrowser.Infrastructure.Data.Models;

namespace HotelBrowser.Infrastructure.SeedDB
{
    internal class WorkCategoryConfiguration : IEntityTypeConfiguration<WorkCategory>
    {
            public void Configure(EntityTypeBuilder<WorkCategory> builder)
            {
                var data = new SeedData();

                builder.HasData(new WorkCategory[] { data.AllYear, data.Summer, data.Winter });
            }
    }
}
