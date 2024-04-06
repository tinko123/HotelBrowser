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

		public async Task<IEnumerable<WorkCategoryViewModel>> AllCategoriesAsync()
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
                    //Owner = h.Owner.User.UserName,
                    Price = h.Price,
                    Phone = h.Phone

                })
                .AsNoTracking()
                .ToListAsync();
        }

		public async Task<bool> CategoryExistAsync(int id)
		{
            return await repository.AllReadOnly<WorkCategory>().AnyAsync(w => w.Id == id);
		}

		public async Task<int> CreateAsync(AddAndEditHotelsViewModel model,int idOwner)
		{
            Hotel hotel = new Hotel
            {
                Name = model.Name,
                Location = model.Location,
                Image = model.Image,
                Description = model.Description,
                FreeRooms = model.FreeRooms,
                Price = model.Price,
                OwnerId = idOwner,
                Phone = model.Phone,
                WorkCategoryId = model.WorkCategoryId
            };
            await repository.AddAsync(hotel);
            await repository.SaveChangesAsync();
            return hotel.Id;
		}

		public async Task<IEnumerable<HotelIndexServiceModel>> FirstThreeHotelsAsync()
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
