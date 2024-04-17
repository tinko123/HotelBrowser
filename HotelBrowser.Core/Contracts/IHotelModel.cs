using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBrowser.Core.Contracts
{
    public interface IHotelModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
