using HotelBrowser.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBrowser.Core.Models.Home
{
    public class HotelIndexServiceModel : IHotelModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}
