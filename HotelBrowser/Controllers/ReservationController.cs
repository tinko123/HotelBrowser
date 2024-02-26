using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult MakeReservation()
        {
            return View();
        }
    }
}
