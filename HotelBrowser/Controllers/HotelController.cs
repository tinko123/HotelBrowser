using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models;
using HotelBrowser.Infrastructure.Data;
using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HotelBrowser.Controllers
{
    [Authorize]
	public class HotelController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly HotelBrowserDbContext data;
        public HotelController(IHotelService _hotelService, HotelBrowserDbContext context)
        {
            data = context;
            hotelService = _hotelService;
        }
        public async Task<IActionResult> AllHotels()
        
        {
            IEnumerable<AllHotelsViewModel> model = await hotelService.AllHotelsAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AllHotelsViewModel();
            model.WorkCategories = await GetWorkCategories();
			return View(model);
		}
        [HttpPost]
        public async Task<IActionResult> AddAsync(AllHotelsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.WorkCategories = await GetWorkCategories();
                return View(model);
            }
            var userId = GetUserId();
            var hotel = new Hotel()
            {
                Name = model.Name,
                Location = model.Location,
                Image = model.Image,
                Description = model.Description,
                FreeRooms = model.FreeRooms,
                Phone = model.Phone,
                WorkCategoryId = model.WorkCategoryId,
                OwnerId = userId
            };
                await data.Hotels.AddAsync(hotel);
                await data.SaveChangesAsync();
                return RedirectToAction(nameof(AllHotels));
        }
        private async Task<IEnumerable<WorkCategoryViewModel>> GetWorkCategories()
        {
            return await data.WorkCategories
                .AsNoTracking()
                .Select(c => new WorkCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
