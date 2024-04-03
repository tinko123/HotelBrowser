using System.ComponentModel.DataAnnotations;
using static HotelBrowser.Infrastructure.Constants.Constants;

namespace HotelBrowser.Core.Models.Owner
{
    public class BecomeOwnerViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        [StringLength(OwnerPhoneMaxLength,
                       MinimumLength = OwnerPhoneMinLength,
                       ErrorMessage = StringLengthField)]
        [Display(Name = "Phone Number")]
        [Phone]

        public string phoneNumber { get; set; } = null!;
    }
}
