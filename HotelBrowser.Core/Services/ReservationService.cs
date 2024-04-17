using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models.Hotel;
using HotelBrowser.Core.Models.Reservation;
using HotelBrowser.Infrastructure.Data.Common;
using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBrowser.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository repository;
        public ReservationService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<int> CreateAsync(CustomerInfoViewModel model)
        {
            Customer customer = new Customer
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                HowManyNights = model.HowManyNights,
                HowManyPeople = model.HowManyPeople,
                HowManyRooms = model.HowManyRooms
            };
            await repository.AddAsync(customer);
            await repository.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<ReservationViewModel?> GetReservationModel(int id)
        {
            return await repository.AllReadOnly<Hotel>()
                .Where(h => h.Id == id)
                .Select(h => new ReservationViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Image = h.Image,
                    Description = h.Description,
                    FreeRooms = h.FreeRooms,
                    Phone = h.Phone,
                })
                .FirstOrDefaultAsync();
        }
    }
}
