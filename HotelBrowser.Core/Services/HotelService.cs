using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models;
using HotelBrowser.Infrastructure.Data;
using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using System.Security.Claims;

namespace HotelBrowser.Core.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelBrowserDbContext data;
        private readonly ILogger _logger;
        public HotelService(HotelBrowserDbContext context, ILogger<HotelService> logger)
        {
            data = context;
            _logger = logger;
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
    }
}
