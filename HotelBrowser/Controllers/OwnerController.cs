using HotelBrowser.Core.Models.Owner;
using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Controllers
{
    public class OwnerController : BaseController
    {
        public IActionResult Become(BecomeOwnerViewModel owner)
        {
            return RedirectToAction(nameof(HotelController.AllHotels),"Hotels");
        }
    }
}
