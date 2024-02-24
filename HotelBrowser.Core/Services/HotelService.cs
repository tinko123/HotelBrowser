using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models;
using HotelBrowser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Owner = h.Owner,
                    Phone = h.Phone

                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
