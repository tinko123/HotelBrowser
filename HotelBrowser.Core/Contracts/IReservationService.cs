using HotelBrowser.Core.Models.Hotel;
using HotelBrowser.Core.Models.Reservation;

namespace HotelBrowser.Core.Contracts
{
    public interface IReservationService
    {
        Task<ReservationViewModel?> GetReservationModel(int id);
        Task<int> CreateAsync(CustomerInfoViewModel model);


    }
}
