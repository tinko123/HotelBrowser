using System.ComponentModel.DataAnnotations;
using static HotelBrowser.Infrastructure.Constants.Constants;

namespace HotelBrowser.Core.Models.Reservation
{
    public class CustomerInfoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(HotelMaxNameLength,
            MinimumLength = HotelMinNameLength,
            ErrorMessage = StringLengthField)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredField)]
        [StringLength(HotelMaxPhoneLength,
    MinimumLength = HotelMinPhoneLength,
    ErrorMessage = StringLengthField)]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredField)]

        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredField)]

        public int HowManyPeople { get; set; }
        [Required(ErrorMessage = RequiredField)]

        public int HowManyRooms { get; set; }
        [Required(ErrorMessage = RequiredField)]

        public int HowManyNights { get; set; }
    }
}
