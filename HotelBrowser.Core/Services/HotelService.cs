using HotelBrowser.Core.Contracts;
using HotelBrowser.Infrastructure.Data;
using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using System.Security.Claims;
using HotelBrowser.Core.Models.Hotel;
using HotelBrowser.Infrastructure.Data.Common;

namespace HotelBrowser.Core.Services
{
	public class HotelService : IHotelService
    {
        private readonly IRepository repository;
        public HotelService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task AddAsync(AllHotelsViewModel model)
        {
            throw new NotImplementedException();
        }

		public async Task<IEnumerable<WorkCategoryViewModel>> AllCategories()
		{
            return await repository.AllReadOnly<WorkCategory>()
				.Select(w => new WorkCategoryViewModel
                {
					Id = w.Id,
					Name = w.Name
				})
				.ToListAsync();
		}

		public  async Task<IEnumerable<AllHotelsViewModel>> AllHotelsAsync()
        {
            return await repository.All<Hotel>()
                .Select(h => new AllHotelsViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Image = h.Image,
                    Description = h.Description,
                    FreeRooms = h.FreeRooms, 
                    Price = h.Price,
                    Owner = h.Owner.UserName,
                    Phone = h.Phone

                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<HotelIndexServiceModel>> FirstThreeHotels()
        {
            return await repository
                .AllReadOnly<Hotel>()
                .OrderByDescending(h => h.Id)
                .Take(3)
                .Select(h => new HotelIndexServiceModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    ImageURL = h.Image
                })
                .ToListAsync();
        }
    }
}
