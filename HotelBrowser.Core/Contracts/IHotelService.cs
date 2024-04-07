using HotelBrowser.Core.Enumerables;
using HotelBrowser.Core.Models.Home;
using HotelBrowser.Core.Models.Hotel;

namespace HotelBrowser.Core.Contracts
{
    public interface IHotelService
    {
        Task<IEnumerable<AllHotelsViewModel>> AllHotelsAsync();
		//Task AddAsync(AllHotelsViewModel model);
        Task<IEnumerable<HotelIndexServiceModel>> FirstThreeHotelsAsync();
        Task<IEnumerable<WorkCategoryViewModel>> AllCategoriesAsync();
        Task<bool> CategoryExistAsync(int id);
        Task<int> CreateAsync(AddAndEditHotelsViewModel model, int idOwner);
        Task<HotelQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            PeopleSorting peopleSorting = PeopleSorting.onePerson,
            RoomsSorting roomsSorting = RoomsSorting.oneRoom,
            HotelsSorting hotelsSorting = HotelsSorting.Newest,
            int currentPage = 1,
            int hotelsPerPage = 1);
        Task<IEnumerable<string>> AllWorkCategoriesAsync();
        Task<IEnumerable<HotelServiceModel>> AllHotelsByOwnerAsync(int ownerId);
        Task<IEnumerable<HotelServiceModel>> AllHotelsByUserAsync(string userId);
    }
}
