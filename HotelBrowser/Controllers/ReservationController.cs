using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Controllers
{
    public class ReservationController : BaseController
    {
        public IActionResult MakeReservation()
        {
            return View();
        }
    }
}
