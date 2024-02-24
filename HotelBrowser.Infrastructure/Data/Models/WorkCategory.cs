using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HotelBrowser.Infrastructure.Data.Models.Constants;

namespace HotelBrowser.Infrastructure.Data.Models
{
    public class WorkCategory
    {
        [Key]
        [Comment("WorkCategory id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(WorkCategoryMaxNameLength)]
        [Comment("WorkCategory name")]
        public string Name { get; set; } = string.Empty;
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}