using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Controllers
{
    public class OwnerController : BaseController
    {
        public IActionResult Become()
        {
            return View();
        }
    }
}
