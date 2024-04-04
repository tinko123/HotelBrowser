using HotelBrowser.Core.Models.Hotel;

namespace HotelBrowser.Core.Contracts
{
    public interface IHotelService
    {
        Task<IEnumerable<AllHotelsViewModel>> AllHotelsAsync();
		Task AddAsync(AllHotelsViewModel model);
        Task<IEnumerable<HotelIndexServiceModel>> FirstThreeHotels();
        Task<IEnumerable<WorkCategoryViewModel>> AllCategories();
	}
}
