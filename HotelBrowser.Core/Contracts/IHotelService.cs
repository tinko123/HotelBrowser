using HotelBrowser.Core.Models.Hotel;

namespace HotelBrowser.Core.Contracts
{
    public interface IHotelService
    {
        Task<IEnumerable<AllHotelsViewModel>> AllHotelsAsync();
		Task AddAsync(AllHotelsViewModel model);
        Task<IEnumerable<HotelIndexServiceModel>> FirstThreeHotelsAsync();
        Task<IEnumerable<WorkCategoryViewModel>> AllCategoriesAsync();
        Task<bool> CategoryExistAsync(int id);
        Task<int> CreateAsync(AddAndEditHotelsViewModel model, int idOwner);
 	}
}
