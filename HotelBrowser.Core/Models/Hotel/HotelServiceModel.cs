using System.ComponentModel.DataAnnotations;
using static HotelBrowser.Infrastructure.Constants.Constants;

namespace HotelBrowser.Core.Models.Hotel
{
    public class HotelServiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(HotelMaxNameLength,
            MinimumLength = HotelMinNameLength,
            ErrorMessage = StringLengthField)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = RequiredField)]
        [StringLength(DecriptionMaxLength,
    MinimumLength = DecriptionMinLength,
    ErrorMessage = StringLengthField)]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = RequiredField)]
        [StringLength(LocationMaxLength,
        MinimumLength = LocationMinLength,
        ErrorMessage = StringLengthField)]
        [RegularExpression("(ul|bul)\\.([A-Za-z]|[A-Za-z].[A-Za-z])+\\s?\\d+", ErrorMessage = LocationErrorMessage)]
        public string Location { get; set; } = null!;
        [Required(ErrorMessage = RequiredField)]
        [StringLength(HotelMaxPhoneLength,
                    MinimumLength = HotelMinPhoneLength,
                    ErrorMessage = StringLengthField)]
        [Display(Name = "Reservation Phone")]
        public string PhoneNumber { get; set; } = null!;
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [Range(typeof(decimal),
            MinPriceForOneNight,
            MaxPriceForOneNight,
            ErrorMessage = PriceErrorMessage)]
        [Display(Name = "Price for one night")]
        public  decimal PricePerNight { get; set; }

    }
}