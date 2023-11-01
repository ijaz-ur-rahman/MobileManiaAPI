namespace MobileManiaAPI.Models.MobileViewModels
{
    public class AddUpdateMobile
    {
        public string? MobileName { get; set; }

        public int? MobilePrice { get; set; }

        public decimal? MobilePriceInDollors { get; set; }

        public int? ManufacturerId { get; set; }

        public string? TwoGnetwork { get; set; }

        public string? Sim { get; set; }

        public string? Dimensions { get; set; }

        public string? Weight { get; set; }

        public string? Type { get; set; }

        public string? ScreenSize { get; set; }

        public string? CardSlot { get; set; }

        public string? InternalMemory { get; set; }

        public string? Gprs { get; set; }

        public string? Edge { get; set; }

        public string? Speed { get; set; }

        public string? Wlan { get; set; }

        public string? Bluetooth { get; set; }

        public string? Usb { get; set; }

        public bool? Camera { get; set; }

        public string? PrimaryCamera { get; set; }

        public string? FeaturesOfCamera { get; set; }

        public string? CameraVideo { get; set; }

        public string? SecondaryCamera { get; set; }

        public string? Os { get; set; }

        public string? Cpu { get; set; }

        public string? Gpu { get; set; }

        public string? Messaging { get; set; }

        public string? Radio { get; set; }

        public string? Browser { get; set; }

        public string? Games { get; set; }

        public string? Gps { get; set; }

        public string? Java { get; set; }

        public string? Colors { get; set; }

        public string? BatteryType { get; set; }

        public string? BatteryStandby { get; set; }

        public string? Talktime { get; set; }

        public bool? Tourch { get; set; }

        public string? Entertainment { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? DisplayAtHomePage { get; set; }

        public bool? IsSmartPhone { get; set; }

        public bool? IsWindowsPhone { get; set; }

        public bool? IsAndroidPhone { get; set; }

        public bool? IsSymbianPhone { get; set; }

        public string? WhatsNew { get; set; }

        public string? _3gband { get; set; }

        public string? _4gband { get; set; }
        public string? _5gband { get; set; }

        public bool? IsLatest { get; set; }

        public bool? Is3G { get; set; }

        public bool? Is4G { get; set; }
        public bool? Is5G { get; set; }

        public decimal? ScreenSizeInInches { get; set; }

        public int? CameraPixels { get; set; }

        public IFormFileCollection? LargeImages { get; set; }
        public IFormFileCollection? SmallImages { get; set; }
    }
}
