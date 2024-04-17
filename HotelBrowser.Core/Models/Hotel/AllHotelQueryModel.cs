using HotelBrowser.Core.Enumerables;
using System.ComponentModel.DataAnnotations;

namespace HotelBrowser.Core.Models.Hotel
{
    public class AllHotelQueryModel
    {
        public int HotelsPerPage { get; } = 3;
        public string Category { get; init; } = null!;
        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;
        public HotelsSorting HotelsSorting { get; init; }
        public PeopleSorting PeopleSorting { get; init; }
        public RoomsSorting RoomsSorting { get; init; }
        public int CurrentPage { get; init; } = 1;
        public int TotalHotelsCount { get; set; }
        public IEnumerable<string> Categories { get; set; } = null!;
        public IEnumerable<HotelServiceModel> Hotels { get; set; } = new List<HotelServiceModel>();


    }
}
