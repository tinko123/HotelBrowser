using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBrowser.Infrastructure.Constants
{
    public static class Constants
    {
        public const int HotelMaxNameLength = 100;
        public const int HotelMinNameLength = 3;
        public const int HotelMaxPhoneLength = 15;
        public const int HotelMinPhoneLength = 5;
        public const int OwnerMaxNameLength = 100;
        public const int OwnerMinNameLength = 3;
        public const int DecriptionMaxLength = 1500;
        public const int DecriptionMinLength = 20;
        public const int LocationMaxLength = 70;
        public const int LocationMinLength = 3;
        public const int ImageMaxLength = 1500;
        public const int WorkCategoryMaxNameLength = 15;
        public const string RequiredField = "The field {0} is required!";
        public const string StringLengthField = "The field {0} must be between {2} and {1} long.";
        public const string ImageErrorMessage = "The field {0} can not be more than {1}";
        public const string LocationErrorMessage = "The field {0} must be in format ul/bul. StreetNameNumber";
        public const int OwnerPhoneMaxLength = 15;
        public const int OwnerPhoneMinLength = 7;
        public const string MaxPriceForOneNight = "800.00";
        public const string MinPriceForOneNight = "0.00";
        public const string PriceErrorMessage = "Price for one night must be a positive number and less then {2} leva.";
    }
}
