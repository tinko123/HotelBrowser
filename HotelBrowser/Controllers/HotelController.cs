using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models;
using HotelBrowser.Infrastructure.Data;
using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
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
            var model = new AddAndEditHotelsViewModel();
            model.WorkCategories = await GetWorkCategories();
			return View(model);
		}
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddAndEditHotelsViewModel model)
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await data.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            var model = new AddAndEditHotelsViewModel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Location = hotel.Location,
                Image = hotel.Image,
                Description = hotel.Description,
                FreeRooms = hotel.FreeRooms,
                Phone = hotel.Phone,
                WorkCategoryId = hotel.WorkCategoryId,
                WorkCategories = await GetWorkCategories()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddAndEditHotelsViewModel model, int id)
        {
            int hotelId = id;
            if (!ModelState.IsValid)
            {
                model.WorkCategories = await GetWorkCategories();
                return View(model);
            }
            var hotel = await data.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return BadRequest();
            }
            if (hotel.OwnerId != GetUserId())
            {
                return Unauthorized();
            }
            hotel.Id = model.Id;
            hotel.Name = model.Name;
            hotel.Location = model.Location;
            hotel.Image = model.Image;
            hotel.Description = model.Description;
            hotel.FreeRooms = model.FreeRooms;
            hotel.Phone = model.Phone;
            hotel.WorkCategoryId = model.WorkCategoryId;
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(AllHotels));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await data.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return BadRequest();
            }
            if (hotel.OwnerId != GetUserId())
            {
                return Unauthorized();
            }
            var model = new DeleteViewModel
            {
                Id = hotel.Id,
                Name = hotel.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteViewModel model)
        {
            var hotel = await data.Hotels.FindAsync(model.Id);
            if (hotel == null)
            {
                return BadRequest();
            }
            if (hotel.OwnerId != GetUserId())
            {
                return Unauthorized();
            }
            data.Hotels.Remove(hotel);
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
