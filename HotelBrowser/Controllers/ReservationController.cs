using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models.Reservation;
using HotelBrowser.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBrowser.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly IHotelService hotelService;

        public ReservationController(IReservationService _reservationService,
            IHotelService _hotelService)
        {
            reservationService = _reservationService;
            hotelService = _hotelService;
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
        [HttpGet]
        public IActionResult CustomerInformation()
        {
            var model = new CustomerInfoViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerInformation(CustomerInfoViewModel model)
        {
            await reservationService.CreateAsync(model);
            return RedirectToAction(nameof(YourReservationIsMade));
        }
        [HttpGet]
        public IActionResult YourReservationIsMade()
        {
            return View();
        }
    }
}
