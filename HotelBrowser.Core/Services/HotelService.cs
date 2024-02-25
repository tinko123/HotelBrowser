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
        public HotelService(HotelBrowserDbContext contex, ILogger<HotelService> logger)
        {
            data = contex;
            _logger = logger;
        }

        public Task AddAsync(AllHotelsViewModel model)
        {
            throw new NotImplementedException();
        }

        //public async Task AddAsync(AllHotelsViewModel model)
        //{
        //          var hotel = new Hotel()
        //          {
        //              Name = model.Name,
        //		Location = model.Location,
        //		Image = model.Image,
        //		Description = model.Description,
        //		FreeRooms = model.FreeRooms,
        //		Phone = model.Phone,
        //	};
        //          try
        //          {
        //              await data.Hotels.AddAsync(hotel);
        //		await data.SaveChangesAsync();
        //	}
        //          catch (Exception ex)
        //          {
        //              _logger.LogError(ex, "HotelServide.AddAsync");
        //		throw new ApplicationException("Operation failed. Please, try again");
        //	}
        //}

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
        //private async Task<IEnumerable<WorkCategoryViewModel>> GetWorkCategories()
        //{
        //    return await data.WorkCategories
        //        .AsNoTracking()
        //        .Select(c => new WorkCategoryViewModel
        //        {
        //            Id = c.Id,
        //            Name = c.Name
        //        })
        //        .ToListAsync();
        //}
        //private string GetUserId()
        //{
        //    return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        //}
    }
}
