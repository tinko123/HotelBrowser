using HotelBrowser.Core.Models;

namespace HotelBrowser.Core.Contracts
{
	public interface IHotelService
    {
        Task<IEnumerable<AllHotelsViewModel>> AllHotelsAsync();
    }
}
