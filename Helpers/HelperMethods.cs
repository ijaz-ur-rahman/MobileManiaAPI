using Azure;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace MobileManiaAPI.Helpers
{
    public static class HelperMethods
    {
        public static bool IsBetween(this int? value, int? minimum, int? maximum)
        {
            if (value == null || minimum == null || maximum == null)
                return false;
            return value >= minimum && value <= maximum;
        }

        public static bool IsBetween(this decimal? value, decimal? minimum, decimal? maximum)
        {
            if (value == null || minimum == null || maximum == null)
                return false;
            return value >= minimum && value <= maximum;
        }
        public static bool IsBetween(this string value, params string[] param)
        {
            return param.Any(m => m.Equals(value));
        }

        public static int ToInt32(this int? value)
        {
            return Convert.ToInt32(value);
        }
        public static decimal ToDecimal(this decimal? value)
        {
            return Convert.ToDecimal(value);
        }
        public static bool IsEqual(this bool? value1, bool? value2)
        {
            if (value1 == null || value2 == null)
                return false;
            return value1.Equals(value2);
        }
    }

}
