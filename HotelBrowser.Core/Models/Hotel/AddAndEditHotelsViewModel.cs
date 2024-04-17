using System.ComponentModel.DataAnnotations;
using static HotelBrowser.Infrastructure.Constants.Constants;

namespace HotelBrowser.Core.Models.Hotel
{
    public class AddAndEditHotelsViewModel
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
        [Display(Name = "Reservation Phone")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredField)]
        [Range(0, 1000)]
        [Display(Name = "Free Rooms")]
        public int FreeRooms { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(DecriptionMaxLength,
            MinimumLength = DecriptionMinLength,
            ErrorMessage = StringLengthField)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredField)]
        [StringLength(LocationMaxLength,
            MinimumLength = LocationMinLength,
            ErrorMessage = StringLengthField)]
        [RegularExpression("(ul|bul)\\.([A-Za-z]|[A-Za-z].[A-Za-z])+\\s?\\d+", ErrorMessage = LocationErrorMessage)]
        public string Location { get; set; } = string.Empty;
        [Required]
		[Range(typeof(decimal),
            MinPriceForOneNight,
            MaxPriceForOneNight,
			ErrorMessage = "Price for one night must be a positive number and less then {2} leva.")]
        [Display(Name = "Price for one night")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = RequiredField)]
        public string Image { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredField)]
        public int WorkCategoryId { get; set; }
        public IEnumerable<WorkCategoryViewModel> WorkCategories { get; set; } = new List<WorkCategoryViewModel>();

    }
}
