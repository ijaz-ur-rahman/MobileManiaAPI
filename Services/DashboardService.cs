using AutoMapper;
using Azure;
using Microsoft.IdentityModel.Tokens;
using MobileManiaAPI.Entities;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.DashboardViewModels;
using MobileManiaAPI.Models.MobileViewModels;

namespace MobileManiaAPI.Services
{
    public interface IDashboardService
    {
        ServiceResponse GetAll();
        ServiceResponse GetByBrand(int brandId);
        ServiceResponse GetByPrice(int minPrice, int maxPrice);
        ServiceResponse GetByOS(string osName);
        ServiceResponse GetByNetwork(string networkName);
        ServiceResponse GetByCamera(int cameraPixal);
    }
    public class DashboardService : IDashboardService
    {
        private ServiceResponse response;
        private DataContext _context;
        private readonly IMapper _mapper;
        public DashboardService(
        DataContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            response = new ServiceResponse();
        }

        public ServiceResponse GetAll()
        {
            try
            {
                var mobileList = _context.MobileDetail.Select(x => new GetMobile
                {
                    MobileId = x.MobileId,
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

        public ServiceResponse GetByBrand(int brandId)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => m.ManufacturerId == brandId)
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
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

        public ServiceResponse GetByPrice(int minPrice, int maxPrice)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => m.MobilePrice >= minPrice && m.MobilePrice <= maxPrice)
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
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

        public ServiceResponse GetByOS(string osName)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => m.Os!.Contains(osName))
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
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

        public ServiceResponse GetByNetwork(string networkName)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => nameof(m.Is3G) == networkName || nameof(m.Is4G) == networkName || nameof(m.Is5G) == networkName)
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
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

        public ServiceResponse GetByCamera(int cameraPixal)
        {
            try
            {
                var mobileList = _context.MobileDetail.Where(m => m.CameraPixels == cameraPixal)
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
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
    }
}
