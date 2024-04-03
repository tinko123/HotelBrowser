using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models.Owner;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBrowser.Controllers
{
    public class OwnerController : BaseController
    {
        private readonly IOwnerService ownerService;
        public OwnerController(IOwnerService _ownerService)
        {
            ownerService = _ownerService;
        }
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if(await ownerService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }
            var model = new BecomeOwnerViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Become(BecomeOwnerViewModel owner)
        {
            return RedirectToAction(nameof(HotelController.AllHotels),"Hotels");
        }
    }
}
