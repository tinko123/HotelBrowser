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
			IEnumerable<AllHotelsViewModel> model = await hotelService.AllHotelsAsync();
			return View(model);
		}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
