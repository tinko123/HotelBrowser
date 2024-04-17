using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models.Home;
using HotelBrowser.Core.Models.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelBrowser.Controllers
{
    public class HomeController : BaseController
    {
		private readonly IHotelService hotelService;
		public HomeController(IHotelService _hotelService)
		{
			hotelService = _hotelService;
		}
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			if (User?.Identities != null && User.Identity.IsAuthenticated)
			{
				return RedirectToAction("AllHotels", "Hotel");
			}
			var hotel = await hotelService.FirstThreeHotelsAsync();
			return View(hotel);
		}

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 400)
			{
				return View("Error400");
			}
			if (statusCode == 401)
			{
				return View("Error401");
			}

			return View();
		}
	}
}
