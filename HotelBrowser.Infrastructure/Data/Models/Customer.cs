using System.ComponentModel.DataAnnotations;
using static HotelBrowser.Infrastructure.Constants.Constants;


namespace HotelBrowser.Infrastructure.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(OwnerMaxNameLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(HotelMaxPhoneLength)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int HowManyPeople { get; set; }
        [Required]
        public int HowManyRooms { get; set; }
        [Required]
        public int HowManyNights { get; set; }
    }
}
