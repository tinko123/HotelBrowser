using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Controllers
{
    [Authorize]
	public class HotelController : Controller
    {
        private readonly IHotelService hotelService;
        public HotelController(IHotelService _hotelService)
        {
            hotelService = _hotelService;
        }
        public async Task<IActionResult> AllHotels()
        
        {
            IEnumerable<AllHotelsViewModel> model = await hotelService.AllHotelsAsync();
            return View(model);
        }
    }
}
