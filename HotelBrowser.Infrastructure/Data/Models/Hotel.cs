using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelBrowser.Infrastructure.Data.Models.Constants;

namespace HotelBrowser.Infrastructure.Data.Models
{
    public class Hotel
    {
        [Key]
        [Comment("Hotel id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(HotelMaxNameLength)]
        [Comment("Hotel name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Comment("Hotel receptionis's phone fo booking")]
        [MaxLength(HotelMaxPhoneLength)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [Comment("WorkCategory identifier")]
        public int WorkCategoryId { get; set; }
        [ForeignKey(nameof(WorkCategoryId))]
        public WorkCategory WorkCategory { get; set; } = null!;
        [Required]
        [MaxLength(OwnerMaxNameLength)]
        [Comment("Owner of the hotel")]
        public IdentityUser Owner { get; set; } = null!;
        [Required]
        [Comment("How many rooms are free to use")]
        public int FreeRooms { get; set; }
        [Required]
        [MaxLength(DecriptionMaxLength)]
        [Comment("Hotel's description")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(LocationMaxLength)]
        [Comment("Hotel's location")]
        public string Location { get; set; } = string.Empty;
        [Required]
        [MaxLength(ImageMaxLength)]
        [Comment("Hotel's image url")]
        public string Image { get; set; } = string.Empty;
        [Comment("Hotel's owner identifier")]
        public string? OwnerId { get; set; }
    }
}
