using HotelBrowser.Core.Enumerables;
using HotelBrowser.Core.Models.Home;
using HotelBrowser.Core.Models.Hotel;
using HotelBrowser.Infrastructure.Data.Common;
using HotelBrowser.Infrastructure.Data.Models;

namespace HotelBrowser.Core.Contracts
{
    public interface IHotelService
    {
        Task<IEnumerable<AllHotelsViewModel>> AllHotelsAsync();
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
        Task EditAsync(AddAndEditHotelsViewModel model);
        Task<bool> ExistAsync (int id);
        Task<bool> HasOwnerWithIdAsync(int hotelId, string userId);
        Task<AddAndEditHotelsViewModel?> GetHotelAddAndEditModelAsync(int id);
        Task DeleteAsync (int hotelId);
    }
}
