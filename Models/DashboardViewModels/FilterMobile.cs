namespace MobileManiaAPI.Models.DashboardViewModels
{
    public class GetMobileByChecks
    {

        public bool? Camera { get; set; }

        public bool? Tourch { get; set; }

        public bool? DisplayAtHomePage { get; set; }

        public bool? IsSmartPhone { get; set; }

        public bool? IsWindowsPhone { get; set; }

        public bool? IsAndroidPhone { get; set; }

        public bool? IsSymbianPhone { get; set; }

        public bool? IsLatest { get; set; }

        public bool? Is3G { get; set; }

        public bool? Is4G { get; set; }
        public bool? Is5G { get; set; }
    }
    public class GetMobileByValue
    {
        public List<string> Colors { get; set; } = new List<string>();
        public List<string> Os { get; set; } = new List<string>();
        public List<int> Manufacturers { get; set; } = new List<int>();
    }
    public class GetMobileByRange
    {
        public int? MinMobilePrice { get; set; }
        public int? MaxMobilePrice { get; set; }
        public decimal? MinMobilePriceInDollors { get; set; }
        public decimal? MaxMobilePriceInDollors { get; set; }        
        public decimal? MinScreenSize { get; set; }
        public decimal? MaxScreenSize { get; set; }
        public List<string> InternalMemoryRange { get; set; } = new List<string>();
        public List<string> PrimaryCameraRange { get; set; } = new List<string>();
        public List<string> SecondaryCameraRange { get; set; } = new List<string>();
        public List<string> BatteryStandbyRange { get; set; } = new List<string>();
        public List<string> TalktimeRange { get; set; } = new List<string>();
    }
}
