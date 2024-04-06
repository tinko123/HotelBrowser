using HotelBrowser.Attributes;
using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models.Hotel;
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
	public class HotelController : BaseController
    {
        private readonly IHotelService hotelService;
        private readonly IOwnerService ownerService;
        private readonly HotelBrowserDbContext data;
        public HotelController(IHotelService _hotelService,
            HotelBrowserDbContext context,
            IOwnerService _ownerService)
        {
            data = context;
            hotelService = _hotelService;
            ownerService = _ownerService;
        }
        public async Task<IActionResult> AllHotels()
        
        {
            IEnumerable<AllHotelsViewModel> model = await hotelService.AllHotelsAsync();
            return View(model);
        }
        [HttpGet]
        [MustBeOwner]
        public async Task<IActionResult> Add()
        {
			var model = new AddAndEditHotelsViewModel()
            {
               WorkCategories = await hotelService.AllCategoriesAsync()
            };
			return View(model);
		}
        [HttpPost]
        [MustBeOwner]
        public async Task<IActionResult> AddAsync(AddAndEditHotelsViewModel model)
        {

            if(await hotelService.CategoryExistAsync(model.WorkCategoryId) == false)
            {
				ModelState.AddModelError(nameof(model.WorkCategoryId), "Category does not exist.");
			}
            if (!ModelState.IsValid)
            {
				model.WorkCategories = await hotelService.AllCategoriesAsync();
				return View(model);
			}
			int? ownerId = await ownerService.GetOwnerIdAsync(User.Id());
			int newHotel = await hotelService.CreateAsync(model,ownerId ?? 0);
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
                Price = hotel.Price,
                WorkCategoryId = hotel.WorkCategoryId,
                WorkCategories = await GetWorkCategories()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddAndEditHotelsViewModel model, int id)
        {

            return RedirectToAction(nameof(AllHotels));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //var hotel = await data.Hotels.FindAsync(id);
            //if (hotel == null)
            //{
            //    return BadRequest();
            //}
            //if (hotel.OwnerId != GetUserId())
            //{
            //    return Unauthorized();
            //}
            //var model = new DeleteViewModel
            //{
            //    Id = hotel.Id,
            //    Name = hotel.Name
            //};
            // return View(model);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteViewModel model)
        {
            //var hotel = await data.Hotels.FindAsync(model.Id);
            //if (hotel == null)
            //{
            //    return BadRequest();
            //}
            //if (hotel.OwnerId != GetUserId())
            //{
            //    return Unauthorized();
            //}
            //data.Hotels.Remove(hotel);
            //await data.SaveChangesAsync();
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
