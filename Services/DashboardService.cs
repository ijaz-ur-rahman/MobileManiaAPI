using AutoMapper;
using Azure;
using Microsoft.IdentityModel.Tokens;
using MobileManiaAPI.Entities;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.DashboardViewModels;
using MobileManiaAPI.Models.MobileViewModels;
using Microsoft.AspNetCore.Http.Extensions;

namespace MobileManiaAPI.Services
{
    public interface IDashboardService
    {
        ServiceResponse<List<GetMobile>> GetAll();
        ServiceResponse<List<GetMobile>> GetByBrand(int brandId);
        ServiceResponse<List<GetMobile>> GetByPrice(int minPrice, int maxPrice);
        ServiceResponse<List<GetMobile>> GetByOS(string osName);
        ServiceResponse<List<GetMobile>> GetByNetwork(string networkName);
        ServiceResponse<List<GetMobile>> GetByCamera(int cameraPixal);
    }
    public class DashboardService : IDashboardService
    {
        private ServiceResponse<List<GetMobile>> response;
        private DataContext _context;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _environment;

        public DashboardService(
        DataContext context,
        IMapper mapper,
        IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            response = new ServiceResponse<List<GetMobile>>();
            _environment = environment;
        }

        public ServiceResponse<List<GetMobile>> GetAll()
        {
            try
            {
                var mobileList = _context.MobileDetail.Select(x => new GetMobile
                {
                    MobileId = x.MobileId,
                    MobileName = x.MobileName,
                    MobilePrice = x.MobilePrice,
                    MobilePriceInDollors = x.MobilePriceInDollors,
                    ManufacturerId = x.ManufacturerId,
                    ManufacturerName = _context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == x.ManufacturerId)!.ManufacturerName,
                    Os = x.Os,
                    Bluetooth = x.Bluetooth,
                    BatteryStandby = x.BatteryStandby,
                    BatteryType = x.BatteryType,
                    Browser = x.Browser,
                    Camera = x.Camera,
                    CameraPixels = x.CameraPixels,
                    CameraVideo = x.CameraVideo,
                    CardSlot = x.CardSlot,
                    Colors = x.Colors,
                    Cpu = x.Cpu,
                    Dimensions = x.Dimensions,
                    DisplayAtHomePage = x.DisplayAtHomePage,
                    DisplayOrder = x.DisplayOrder,
                    Edge = x.Edge,
                    Entertainment = x.Entertainment,
                    FeaturesOfCamera = x.FeaturesOfCamera,
                    Games = x.Games,
                    Gprs = x.Gprs,
                    Gps = x.Gps,
                    Gpu = x.Gpu,
                    InternalMemory = x.InternalMemory,
                    Is3G = x.Is3G,
                    Is4G = x.Is4G,
                    Is5G = x.Is5G,
                    IsAndroidPhone = x.IsAndroidPhone,
                    IsLatest = x.IsLatest,
                    IsSmartPhone = x.IsSmartPhone,
                    IsSymbianPhone = x.IsSymbianPhone,
                    IsWindowsPhone = x.IsWindowsPhone,
                    Java = x.Java,
                    Messaging = x.Messaging,
                    PrimaryCamera = x.PrimaryCamera,
                    Radio = x.Radio,
                    ScreenSize = x.ScreenSize,
                    ScreenSizeInInches = x.ScreenSizeInInches,
                    SecondaryCamera = x.SecondaryCamera,
                    Sim = x.Sim,
                    Speed = x.Speed,
                    Talktime = x.Talktime,
                    Tourch = x.Tourch,
                    TwoGnetwork = x.TwoGnetwork,
                    Type = x.Type,
                    Usb = x.Usb,
                    Weight = x.Weight,
                    WhatsNew = x.WhatsNew,
                    Wlan = x.Wlan,
                    _3gband = x._3gband,
                    _4gband = x._4gband,
                    _5gband = x._5gband,
                    Ratings = _context.Ratings.Where(m => m.MobileId == x.MobileId).ToList(),
                    Comments = _context.Comments.Where(m => m.MobileId == x.MobileId).ToList(),
                    MobileImageS = SetImagePath(x.MobileImageS!),
                    MobileImageL = SetImagePath(x.MobileImageL!),
                }).OrderBy(x => x.MobileId).ToList();

                response.success = true;
                response.data = mobileList;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ServiceResponse<List<GetMobile>> GetByBrand(int brandId)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => m.ManufacturerId == brandId)
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
                        MobileName = x.MobileName,
                        MobilePrice = x.MobilePrice,
                        MobilePriceInDollors = x.MobilePriceInDollors,
                        ManufacturerId = x.ManufacturerId,
                        ManufacturerName = _context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == x.ManufacturerId)!.ManufacturerName,
                        Os = x.Os,
                        Bluetooth = x.Bluetooth,
                        BatteryStandby = x.BatteryStandby,
                        BatteryType = x.BatteryType,
                        Browser = x.Browser,
                        Camera = x.Camera,
                        CameraPixels = x.CameraPixels,
                        CameraVideo = x.CameraVideo,
                        CardSlot = x.CardSlot,
                        Colors = x.Colors,
                        Cpu = x.Cpu,
                        Dimensions = x.Dimensions,
                        DisplayAtHomePage = x.DisplayAtHomePage,
                        DisplayOrder = x.DisplayOrder,
                        Edge = x.Edge,
                        Entertainment = x.Entertainment,
                        FeaturesOfCamera = x.FeaturesOfCamera,
                        Games = x.Games,
                        Gprs = x.Gprs,
                        Gps = x.Gps,
                        Gpu = x.Gpu,
                        InternalMemory = x.InternalMemory,
                        Is3G = x.Is3G,
                        Is4G = x.Is4G,
                        Is5G = x.Is5G,
                        IsAndroidPhone = x.IsAndroidPhone,
                        IsLatest = x.IsLatest,
                        IsSmartPhone = x.IsSmartPhone,
                        IsSymbianPhone = x.IsSymbianPhone,
                        IsWindowsPhone = x.IsWindowsPhone,
                        Java = x.Java,
                        Messaging = x.Messaging,
                        PrimaryCamera = x.PrimaryCamera,
                        Radio = x.Radio,
                        ScreenSize = x.ScreenSize,
                        ScreenSizeInInches = x.ScreenSizeInInches,
                        SecondaryCamera = x.SecondaryCamera,
                        Sim = x.Sim,
                        Speed = x.Speed,
                        Talktime = x.Talktime,
                        Tourch = x.Tourch,
                        TwoGnetwork = x.TwoGnetwork,
                        Type = x.Type,
                        Usb = x.Usb,
                        Weight = x.Weight,
                        WhatsNew = x.WhatsNew,
                        Wlan = x.Wlan,
                        _3gband = x._3gband,
                        _4gband = x._4gband,
                        _5gband = x._5gband,
                        Ratings = _context.Ratings.Where(m => m.MobileId == x.MobileId).ToList(),
                        Comments = _context.Comments.Where(m => m.MobileId == x.MobileId).ToList(),
                        MobileImageS = SetImagePath(x.MobileImageS!),
                        MobileImageL = SetImagePath(x.MobileImageL!),
                    }).OrderBy(x => x.MobileId).ToList();

                response.success = true;
                response.data = mobileList;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ServiceResponse<List<GetMobile>> GetByPrice(int minPrice, int maxPrice)
        {
            try
            {
                var mobileList = _context.MobileDetail.ToList()
                    .Where(m => m.MobilePrice >= minPrice && m.MobilePrice <= maxPrice)
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
                        MobileName = x.MobileName,
                        MobilePrice = x.MobilePrice,
                        MobilePriceInDollors = x.MobilePriceInDollors,
                        ManufacturerId = x.ManufacturerId,
                        ManufacturerName = _context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == x.ManufacturerId)!.ManufacturerName,
                        Os = x.Os,
                        Bluetooth = x.Bluetooth,
                        BatteryStandby = x.BatteryStandby,
                        BatteryType = x.BatteryType,
                        Browser = x.Browser,
                        Camera = x.Camera,
                        CameraPixels = x.CameraPixels,
                        CameraVideo = x.CameraVideo,
                        CardSlot = x.CardSlot,
                        Colors = x.Colors,
                        Cpu = x.Cpu,
                        Dimensions = x.Dimensions,
                        DisplayAtHomePage = x.DisplayAtHomePage,
                        DisplayOrder = x.DisplayOrder,
                        Edge = x.Edge,
                        Entertainment = x.Entertainment,
                        FeaturesOfCamera = x.FeaturesOfCamera,
                        Games = x.Games,
                        Gprs = x.Gprs,
                        Gps = x.Gps,
                        Gpu = x.Gpu,
                        InternalMemory = x.InternalMemory,
                        Is3G = x.Is3G,
                        Is4G = x.Is4G,
                        Is5G = x.Is5G,
                        IsAndroidPhone = x.IsAndroidPhone,
                        IsLatest = x.IsLatest,
                        IsSmartPhone = x.IsSmartPhone,
                        IsSymbianPhone = x.IsSymbianPhone,
                        IsWindowsPhone = x.IsWindowsPhone,
                        Java = x.Java,
                        Messaging = x.Messaging,
                        PrimaryCamera = x.PrimaryCamera,
                        Radio = x.Radio,
                        ScreenSize = x.ScreenSize,
                        ScreenSizeInInches = x.ScreenSizeInInches,
                        SecondaryCamera = x.SecondaryCamera,
                        Sim = x.Sim,
                        Speed = x.Speed,
                        Talktime = x.Talktime,
                        Tourch = x.Tourch,
                        TwoGnetwork = x.TwoGnetwork,
                        Type = x.Type,
                        Usb = x.Usb,
                        Weight = x.Weight,
                        WhatsNew = x.WhatsNew,
                        Wlan = x.Wlan,
                        _3gband = x._3gband,
                        _4gband = x._4gband,
                        _5gband = x._5gband,
                        Ratings = _context.Ratings.Where(m => m.MobileId == x.MobileId).ToList(),
                        Comments = _context.Comments.Where(m => m.MobileId == x.MobileId).ToList(),
                        MobileImageS = SetImagePath(x.MobileImageS!),
                        MobileImageL = SetImagePath(x.MobileImageL!),
                    }).OrderBy(x => x.MobilePrice).ToList();

                response.success = true;
                response.data = mobileList;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ServiceResponse<List<GetMobile>> GetByOS(string osName)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => m.Os!.Contains(osName))
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
                        MobileName = x.MobileName,
                        MobilePrice = x.MobilePrice,
                        MobilePriceInDollors = x.MobilePriceInDollors,
                        ManufacturerId = x.ManufacturerId,
                        ManufacturerName = _context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == x.ManufacturerId)!.ManufacturerName,
                        Os = x.Os,
                        Bluetooth = x.Bluetooth,
                        BatteryStandby = x.BatteryStandby,
                        BatteryType = x.BatteryType,
                        Browser = x.Browser,
                        Camera = x.Camera,
                        CameraPixels = x.CameraPixels,
                        CameraVideo = x.CameraVideo,
                        CardSlot = x.CardSlot,
                        Colors = x.Colors,
                        Cpu = x.Cpu,
                        Dimensions = x.Dimensions,
                        DisplayAtHomePage = x.DisplayAtHomePage,
                        DisplayOrder = x.DisplayOrder,
                        Edge = x.Edge,
                        Entertainment = x.Entertainment,
                        FeaturesOfCamera = x.FeaturesOfCamera,
                        Games = x.Games,
                        Gprs = x.Gprs,
                        Gps = x.Gps,
                        Gpu = x.Gpu,
                        InternalMemory = x.InternalMemory,
                        Is3G = x.Is3G,
                        Is4G = x.Is4G,
                        Is5G = x.Is5G,
                        IsAndroidPhone = x.IsAndroidPhone,
                        IsLatest = x.IsLatest,
                        IsSmartPhone = x.IsSmartPhone,
                        IsSymbianPhone = x.IsSymbianPhone,
                        IsWindowsPhone = x.IsWindowsPhone,
                        Java = x.Java,
                        Messaging = x.Messaging,
                        PrimaryCamera = x.PrimaryCamera,
                        Radio = x.Radio,
                        ScreenSize = x.ScreenSize,
                        ScreenSizeInInches = x.ScreenSizeInInches,
                        SecondaryCamera = x.SecondaryCamera,
                        Sim = x.Sim,
                        Speed = x.Speed,
                        Talktime = x.Talktime,
                        Tourch = x.Tourch,
                        TwoGnetwork = x.TwoGnetwork,
                        Type = x.Type,
                        Usb = x.Usb,
                        Weight = x.Weight,
                        WhatsNew = x.WhatsNew,
                        Wlan = x.Wlan,
                        _3gband = x._3gband,
                        _4gband = x._4gband,
                        _5gband = x._5gband,
                        Ratings = _context.Ratings.Where(m => m.MobileId == x.MobileId).ToList(),
                        Comments = _context.Comments.Where(m => m.MobileId == x.MobileId).ToList(),
                        MobileImageS = SetImagePath(x.MobileImageS!),
                        MobileImageL = SetImagePath(x.MobileImageL!),
                    }).OrderBy(x => x.MobileId).ToList();

                response.success = true;
                response.data = mobileList;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ServiceResponse<List<GetMobile>> GetByNetwork(string networkName)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => nameof(m.Is3G) == networkName || nameof(m.Is4G) == networkName || nameof(m.Is5G) == networkName)
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
                        MobileName = x.MobileName,
                        MobilePrice = x.MobilePrice,
                        MobilePriceInDollors = x.MobilePriceInDollors,
                        ManufacturerId = x.ManufacturerId,
                        ManufacturerName = _context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == x.ManufacturerId)!.ManufacturerName,
                        Os = x.Os,
                        Bluetooth = x.Bluetooth,
                        BatteryStandby = x.BatteryStandby,
                        BatteryType = x.BatteryType,
                        Browser = x.Browser,
                        Camera = x.Camera,
                        CameraPixels = x.CameraPixels,
                        CameraVideo = x.CameraVideo,
                        CardSlot = x.CardSlot,
                        Colors = x.Colors,
                        Cpu = x.Cpu,
                        Dimensions = x.Dimensions,
                        DisplayAtHomePage = x.DisplayAtHomePage,
                        DisplayOrder = x.DisplayOrder,
                        Edge = x.Edge,
                        Entertainment = x.Entertainment,
                        FeaturesOfCamera = x.FeaturesOfCamera,
                        Games = x.Games,
                        Gprs = x.Gprs,
                        Gps = x.Gps,
                        Gpu = x.Gpu,
                        InternalMemory = x.InternalMemory,
                        Is3G = x.Is3G,
                        Is4G = x.Is4G,
                        Is5G = x.Is5G,
                        IsAndroidPhone = x.IsAndroidPhone,
                        IsLatest = x.IsLatest,
                        IsSmartPhone = x.IsSmartPhone,
                        IsSymbianPhone = x.IsSymbianPhone,
                        IsWindowsPhone = x.IsWindowsPhone,
                        Java = x.Java,
                        Messaging = x.Messaging,
                        PrimaryCamera = x.PrimaryCamera,
                        Radio = x.Radio,
                        ScreenSize = x.ScreenSize,
                        ScreenSizeInInches = x.ScreenSizeInInches,
                        SecondaryCamera = x.SecondaryCamera,
                        Sim = x.Sim,
                        Speed = x.Speed,
                        Talktime = x.Talktime,
                        Tourch = x.Tourch,
                        TwoGnetwork = x.TwoGnetwork,
                        Type = x.Type,
                        Usb = x.Usb,
                        Weight = x.Weight,
                        WhatsNew = x.WhatsNew,
                        Wlan = x.Wlan,
                        _3gband = x._3gband,
                        _4gband = x._4gband,
                        _5gband = x._5gband,
                        Ratings = _context.Ratings.Where(m => m.MobileId == x.MobileId).ToList(),
                        Comments = _context.Comments.Where(m => m.MobileId == x.MobileId).ToList(),
                        MobileImageS = SetImagePath(x.MobileImageS!),
                        MobileImageL = SetImagePath(x.MobileImageL!),
                    }).OrderBy(x => x.MobileId).ToList();

                response.success = true;
                response.data = mobileList;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ServiceResponse<List<GetMobile>> GetByCamera(int cameraPixal)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => m.CameraPixels == cameraPixal)
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
                        MobileName = x.MobileName,
                        MobilePrice = x.MobilePrice,
                        MobilePriceInDollors = x.MobilePriceInDollors,
                        ManufacturerId = x.ManufacturerId,
                        ManufacturerName = _context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == x.ManufacturerId)!.ManufacturerName,
                        Os = x.Os,
                        Bluetooth = x.Bluetooth,
                        BatteryStandby = x.BatteryStandby,
                        BatteryType = x.BatteryType,
                        Browser = x.Browser,
                        Camera = x.Camera,
                        CameraPixels = x.CameraPixels,
                        CameraVideo = x.CameraVideo,
                        CardSlot = x.CardSlot,
                        Colors = x.Colors,
                        Cpu = x.Cpu,
                        Dimensions = x.Dimensions,
                        DisplayAtHomePage = x.DisplayAtHomePage,
                        DisplayOrder = x.DisplayOrder,
                        Edge = x.Edge,
                        Entertainment = x.Entertainment,
                        FeaturesOfCamera = x.FeaturesOfCamera,
                        Games = x.Games,
                        Gprs = x.Gprs,
                        Gps = x.Gps,
                        Gpu = x.Gpu,
                        InternalMemory = x.InternalMemory,
                        Is3G = x.Is3G,
                        Is4G = x.Is4G,
                        Is5G = x.Is5G,
                        IsAndroidPhone = x.IsAndroidPhone,
                        IsLatest = x.IsLatest,
                        IsSmartPhone = x.IsSmartPhone,
                        IsSymbianPhone = x.IsSymbianPhone,
                        IsWindowsPhone = x.IsWindowsPhone,
                        Java = x.Java,
                        Messaging = x.Messaging,
                        PrimaryCamera = x.PrimaryCamera,
                        Radio = x.Radio,
                        ScreenSize = x.ScreenSize,
                        ScreenSizeInInches = x.ScreenSizeInInches,
                        SecondaryCamera = x.SecondaryCamera,
                        Sim = x.Sim,
                        Speed = x.Speed,
                        Talktime = x.Talktime,
                        Tourch = x.Tourch,
                        TwoGnetwork = x.TwoGnetwork,
                        Type = x.Type,
                        Usb = x.Usb,
                        Weight = x.Weight,
                        WhatsNew = x.WhatsNew,
                        Wlan = x.Wlan,
                        _3gband = x._3gband,
                        _4gband = x._4gband,
                        _5gband = x._5gband,
                        Ratings = _context.Ratings.Where(m => m.MobileId == x.MobileId).ToList(),
                        Comments = _context.Comments.Where(m => m.MobileId == x.MobileId).ToList(),
                        MobileImageS = SetImagePath(x.MobileImageS!),
                        MobileImageL = SetImagePath(x.MobileImageL!),
                    }).OrderBy(x => x.MobileId).ToList();
                response.success = true;
                response.data = mobileList;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<string>? SetImagePath(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                List<string> images = new();
                foreach (var item in value.Split("||"))
                {
                    images.Add(Path.Combine(HelperMethods.BaseUrl() + "/GetImage?imageName=", item));
                }
                return images;
            }
            return null;
        }
    }
}
