using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelBrowser.Infrastructure.Constants.Constants;

namespace HotelBrowser.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class HotelOwner
    {
        [Key]
        [Comment("Agent identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(OwnerPhoneMaxLength)]
        [Comment("Owner's phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; } = null!;

        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
