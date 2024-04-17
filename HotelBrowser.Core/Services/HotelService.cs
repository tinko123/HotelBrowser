using HotelBrowser.Core.Contracts;
using HotelBrowser.Infrastructure.Data;
using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using System.Security.Claims;
using HotelBrowser.Core.Models.Hotel;
using HotelBrowser.Infrastructure.Data.Common;
using HotelBrowser.Core.Enumerables;
using HotelBrowser.Core.Models.Home;

namespace HotelBrowser.Core.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository repository;
        public HotelService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<HotelQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            PeopleSorting peopleSorting = PeopleSorting.onePerson,
            RoomsSorting roomsSorting = RoomsSorting.oneRoom,
            HotelsSorting hotelsSorting = HotelsSorting.Newest,
            int currentPage = 1,
            int hotelsPerPage = 1)
        {
            var hotelsQuery = repository.AllReadOnly<Hotel>();
            if(category!= null)
            {
                hotelsQuery = hotelsQuery.Where(h => h.WorkCategory.Name == category);
            }
            if(searchTerm != null)
            {
                hotelsQuery = hotelsQuery.Where(h => (h.Name.Contains(searchTerm)||
                                                    h.Description.Contains(searchTerm)||
                                                    h.Location.Contains(searchTerm)));
            }
            hotelsQuery = peopleSorting switch
            {
                PeopleSorting.onePerson => hotelsQuery.Where(h => h.FreeRooms >= 1),
                PeopleSorting.twoPeople => hotelsQuery.Where(h => h.FreeRooms >= 2),
                PeopleSorting.threePeople => hotelsQuery.Where(h => h.FreeRooms >= 3),
                PeopleSorting.fourPlusPeople => hotelsQuery.Where(h => h.FreeRooms >= 4),
                _ => hotelsQuery
            };
            hotelsQuery = roomsSorting switch
            {
                RoomsSorting.oneRoom => hotelsQuery.Where(h => h.FreeRooms >= 1),
                RoomsSorting.twoRooms => hotelsQuery.Where(h => h.FreeRooms >= 2),
                RoomsSorting.threeRooms => hotelsQuery.Where(h => h.FreeRooms >= 3),
                RoomsSorting.fourPlusRooms => hotelsQuery.Where(h => h.FreeRooms >= 4),
                _ => hotelsQuery
            };
            hotelsQuery = hotelsSorting switch
            {
                HotelsSorting.Price => hotelsQuery.OrderBy(h => h.Price),
                _ => hotelsQuery.OrderByDescending(h => h.Id)
            };
            var hotels = await hotelsQuery
                .Skip((currentPage - 1) * hotelsPerPage)
                .Take(hotelsPerPage)
                .ProjectToHotelServiceModel()
                .ToListAsync();
            var totalHotels = await hotelsQuery.CountAsync();
            return new HotelQueryServiceModel
            {
                Hotels = hotels,
                TotalHotelsCount = totalHotels,
            };
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

        public async Task<IEnumerable<AllHotelsViewModel>> AllHotelsAsync()
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
                    Phone = h.Phone

                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<HotelServiceModel>> AllHotelsByOwnerAsync(int ownerId)
        {
            return await repository.AllReadOnly<Hotel>()
                .Where(h => h.OwnerId == ownerId)
                .ProjectToHotelServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<HotelServiceModel>> AllHotelsByUserAsync(string userId)
        {
            return await repository.AllReadOnly<Hotel>()
                .Where(h => h.CustomerId == userId)
                .ProjectToHotelServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllWorkCategoriesAsync()
        {
            return await repository.AllReadOnly<WorkCategory>()
                .Select(w => w.Name)
                .Distinct()
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

        public async Task DeleteAsync(int hotelId)
        {
            await repository.DeleteAsync<Hotel>(hotelId);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(AddAndEditHotelsViewModel model)
        {
            var hotel = await repository.GetByIdAsync<Hotel>(model.Id);
            if(hotel != null)
            {
                hotel.Name = model.Name;
                hotel.Location = model.Location;
                hotel.Image = model.Image;
                hotel.Description = model.Description;
                hotel.FreeRooms = model.FreeRooms;
                hotel.Price = model.Price;
                hotel.Phone = model.Phone;
                hotel.WorkCategoryId = model.WorkCategoryId;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllReadOnly<Hotel>().AnyAsync(h => h.Id == id);
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

        public async Task<AddAndEditHotelsViewModel?> GetHotelAddAndEditModelAsync(int id)
        {
            return await repository.AllReadOnly<Hotel>()
                .Where(h => h.Id == id)
                .Select(h => new AddAndEditHotelsViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Image = h.Image,
                    Description = h.Description,
                    FreeRooms = h.FreeRooms,
                    Phone = h.Phone,
                    Price = h.Price,
                    WorkCategoryId = h.WorkCategoryId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> HasOwnerWithIdAsync(int hotelId, string userId)
        {
            return await repository.AllReadOnly<Hotel>()
                .AnyAsync(h => h.Id == hotelId && h.Owner.UserId == userId);
        }
    }
}
