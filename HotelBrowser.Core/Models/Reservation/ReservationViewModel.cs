using HotelBrowser.Core.Models.Hotel;

namespace HotelBrowser.Core.Models.Reservation
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int FreeRooms { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
