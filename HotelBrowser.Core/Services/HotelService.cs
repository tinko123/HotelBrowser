using HotelBrowser.Core.Contracts;
using HotelBrowser.Infrastructure.Data;
using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using System.Security.Claims;
using HotelBrowser.Core.Models.Hotel;

namespace HotelBrowser.Core.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelBrowserDbContext data;
        public HotelService(HotelBrowserDbContext context)
        {
            data = context;
        }

        public Task AddAsync(AllHotelsViewModel model)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<AllHotelsViewModel>> AllHotelsAsync()
        {
            return await data.Hotels
                .Select(h => new AllHotelsViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Image = h.Image,
                    Description = h.Description,
                    FreeRooms = h.FreeRooms, 
                    Owner = h.Owner.UserName,
                    Phone = h.Phone

                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<HotelIndexServiceModel>> FirstThreeHotels()
        {
            return data
                .Hotels
                .OrderByDescending(h => h.Id)
                .Select(h => new HotelIndexServiceModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    ImageURL = h.Image
                })
                .Take(3);
        }
    }
}
