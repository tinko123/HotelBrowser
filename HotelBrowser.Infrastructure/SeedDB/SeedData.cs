using HotelBrowser.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBrowser.Infrastructure.SeedDB
{
    internal class SeedData
    {
        public WorkCategory AllYear { get; set; }

        public WorkCategory Summer { get; set; }

        public WorkCategory Winter { get; set; }
        public SeedData() 
        {
            SeedWorkCategories();
        }
        private void SeedWorkCategories()
        {
            AllYear = new WorkCategory()
            {
                Id = 1,
                Name = "All-Year"
            };

            Summer = new WorkCategory()
            {
                Id = 2,
                Name = "Summer"
            };

            Winter = new WorkCategory()
            {
                Id = 3,
                Name = "Winter"
            };
        }
    }
}
