using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models.Owner;
using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Controllers
{
    public class OwnerController : BaseController
    {
        private readonly IOwnerService ownerService;
        public OwnerController(IOwnerService _ownerService)
        {
            ownerService = _ownerService;
        }
        public IActionResult Become(BecomeOwnerViewModel owner)
        {
            return RedirectToAction(nameof(HotelController.AllHotels),"Hotels");
        }
    }
}
