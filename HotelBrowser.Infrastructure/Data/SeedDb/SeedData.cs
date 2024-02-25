using HotelBrowser.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBrowser.Infrastructure.Data.SeedDb
{
    public class SeedData
    {

		public Hotel Hotel1 { get; set; }
		public Hotel Hotel2 { get; set; }
		public Hotel Hotel3 { get; set; }

        public WorkCategory Year { get; set; }
        public WorkCategory Summer { get; set; }
        public WorkCategory Winter { get; set; }

        public SeedData()
        {
            SeedWorkCategories();
			SeedHotels();
        }

        private void SeedWorkCategories()
        {
            Year = new WorkCategory()
            {
                Id = 1,
                Name = "All year"
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
        private void SeedHotels()
        {
			Hotel1 = new Hotel()
            {
				Id = 1,
				Name = "Hotel1",
				Phone = "0888888888",
				WorkCategoryId = 1,
				OwnerId = "1",
				FreeRooms = 10,
				Description = "Hotel1 description",
				Location = "Hotel1 location",
				Image = "Hotel1 image"
			};

			Hotel2 = new Hotel()
            {
				Id = 2,
				Name = "Hotel2",
				Phone = "0888888888",
				WorkCategoryId = 2,
				OwnerId = "2",
				FreeRooms = 10,
				Description = "Hotel2 description",
				Location = "Hotel2 location",
				Image = "Hotel2 image"
			};

			Hotel3 = new Hotel()
            {
				Id = 3,
				Name = "Hotel3",
				Phone = "0888888888",
				WorkCategoryId = 3,
				OwnerId = "3",
				FreeRooms = 10,
				Description = "Hotel3 description",
				Location = "Hotel3 location",
				Image = "Hotel3 image"
			};
		}
    }
}
