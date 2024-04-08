using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService _reservationService)
        {
            reservationService = _reservationService;
        }
        [HttpGet]
        public async Task<IActionResult> MakeReservation(int id)
        {
            var reservation = await reservationService.GetReservationModel(id);
            var model = new ReservationViewModel
            {
                Id = reservation.Id,
                Name = reservation.Name,
                Location = reservation.Location,
                Image = reservation.Image,
                Description = reservation.Description,
                FreeRooms = reservation.FreeRooms,
                Phone = reservation.Phone
            };
            return View(model);

        }
    }
}
