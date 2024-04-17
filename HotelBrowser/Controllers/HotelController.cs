using HotelBrowser.Attributes;
using HotelBrowser.Core.Contracts;
using HotelBrowser.Core.Models.Hotel;
using HotelBrowser.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBrowser.Controllers
{
    public class HotelController : BaseController
    {
        private readonly IHotelService hotelService;
        private readonly IOwnerService ownerService;
        public HotelController(IHotelService _hotelService,
            IOwnerService _ownerService)
        {
            hotelService = _hotelService;
            ownerService = _ownerService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllHotels([FromQuery] AllHotelQueryModel query)
        {
            var model = await hotelService.AllAsync(
                query.Category,
                query.SearchTerm,
                query.PeopleSorting,
                query.RoomsSorting,
                query.HotelsSorting,
                query.CurrentPage,
                query.HotelsPerPage);
            query.TotalHotelsCount = model.TotalHotelsCount;
            query.Hotels = model.Hotels;
            query.Categories = await hotelService.AllWorkCategoriesAsync();
            return View(query);
        }
        [HttpGet]
        public async Task<IActionResult> MyHotels() 
        {
            var userId = User.Id();
            IEnumerable<HotelServiceModel> model;
            if(await ownerService.ExistByIdAsync(userId))
            {
                var ownerId = await ownerService.GetOwnerIdAsync(userId);
                model = await hotelService.AllHotelsByOwnerAsync(ownerId ?? 0);
            }
            else
            {
                model = await hotelService.AllHotelsByUserAsync(userId);
            }
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
			await hotelService.CreateAsync(model,ownerId ?? 0);
			return RedirectToAction(nameof(AllHotels));

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(await hotelService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            if(await hotelService.HasOwnerWithIdAsync(id,User.Id()) == false)
            {
                return Unauthorized();
            }
            var model = await hotelService.GetHotelAddAndEditModelAsync(id);
            model.WorkCategories = await hotelService.AllCategoriesAsync();
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddAndEditHotelsViewModel model, int id)
        {
            if (await hotelService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            if (await hotelService.HasOwnerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }
            if (await hotelService.CategoryExistAsync(model.WorkCategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.WorkCategoryId), "Category does not exist.");
            }
            if(!ModelState.IsValid)
            {
                model.WorkCategories = await hotelService.AllCategoriesAsync();
                return View(model);
            }
            await hotelService.EditAsync(model);

            return RedirectToAction(nameof(MyHotels));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(await hotelService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            if(await hotelService.HasOwnerWithIdAsync(id,User.Id()) == false)
            {
                return Unauthorized();
            }
            var hotel = await hotelService.GetHotelAddAndEditModelAsync(id);
            hotel.WorkCategories = await hotelService.AllCategoriesAsync();
            var model = new DeleteViewModel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                Location = hotel.Location,
                ImageUrl = hotel.Image
            };
               
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
            if (await hotelService.ExistAsync(model.Id) == false)
            {
                return BadRequest();
            }
            if (await hotelService.HasOwnerWithIdAsync(model.Id, User.Id()) == false)
            {
                return Unauthorized();
            }
            await hotelService.DeleteAsync(model.Id);
            return RedirectToAction(nameof(AllHotels));
        }
    }
}
