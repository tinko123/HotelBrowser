using HotelBrowser.Core.Models.Hotel;
using HotelBrowser.Core.Services;
using HotelBrowser.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQuerableHotelExtension
    {
        public static IQueryable<HotelServiceModel> ProjectToHotelServiceModel(this IQueryable<Hotel> hotels)
        {
            return hotels
                .Select(h => new HotelServiceModel
                {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                Location = h.Location,
                PricePerNight = h.Price,
                ImageUrl = h.Image,
                PhoneNumber = h.Phone,
            });
        }
    }
}
