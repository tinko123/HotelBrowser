using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static HotelBrowser.Infrastructure.Constants.Constants;

namespace HotelBrowser.Infrastructure.Data.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(OwnerMaxNameLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(OwnerMaxNameLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;
		public HotelOwner? Owner { get; set; }
    }
}