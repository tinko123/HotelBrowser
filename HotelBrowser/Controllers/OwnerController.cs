using HotelBrowser.Attributes;
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
        [NotOwner]
        public async Task<IActionResult> Become()
        {
            var model = new BecomeOwnerViewModel();
            return View(model);
        }
        [HttpPost]
        [NotOwner]
        public async Task<IActionResult> Become(BecomeOwnerViewModel owner)
        {
            if(await ownerService.UserWithPhoneNumberExistAsync(owner.phoneNumber))
            {
                ModelState.AddModelError(nameof(owner.phoneNumber), "Phone number is already in use.");
            }
            if (!ModelState.IsValid)
            {
                return View(owner);
            }
            await ownerService.CreateAsync(User.Id(), owner.phoneNumber);
            return RedirectToAction(nameof(HotelController.AllHotels),"Hotel");
        }
    }
}
