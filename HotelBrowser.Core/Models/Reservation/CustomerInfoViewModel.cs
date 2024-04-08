using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBrowser.Core.Models.Reservation
{
    public class CustomerInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int HowManyPeople { get; set; }
        public int HowManyRooms { get; set; }
        public int HowManyNights { get; set; }
    }
}
