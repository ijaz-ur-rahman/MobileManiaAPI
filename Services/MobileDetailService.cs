using AutoMapper;
using Azure;
using Microsoft.IdentityModel.Tokens;
using MobileManiaAPI.Entities;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.DashboardViewModels;
using MobileManiaAPI.Models.MobileViewModels;
using Newtonsoft.Json.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MobileManiaAPI.Services
{
    public interface IMobileDetailService
    {
        ServiceResponse GetAll();
        ServiceResponse FilterMobileByChecks(GetMobileByChecks model);
        ServiceResponse FilterMobileByValue(GetMobileByValue model);
        ServiceResponse FilterMobileByRange(GetMobileByRange model);
        ServiceResponse GetById(int id);
        ServiceResponse Create(AddUpdateMobile model);
        ServiceResponse Update(int id, AddUpdateMobile model);
        ServiceResponse Delete(int id);
    }
    public class MobileDetailService : IMobileDetailService
    {
        private ServiceResponse response;
        private DataContext _context;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _environment;
        public MobileDetailService(
        DataContext context,
        IMapper mapper,
        IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            response = new ServiceResponse();
            _environment = environment;
        }
        public ServiceResponse Create(AddUpdateMobile model)
        {
            try
            {
                var mobileDetails = _mapper.Map<MobileDetail>(model);

                string FilePath = Path.Combine(_environment.WebRootPath, "UploadedImages");

                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);

                foreach (var file in model.SmallImages!)
                {
                    var filePath = Path.Combine(FilePath, Guid.NewGuid().ToString() + Path.GetExtension(file.Name));

                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                    }
                    mobileDetails.MobileImageS = string.IsNullOrEmpty(mobileDetails.MobileImageS) ? filePath : " || " + filePath;
                }

                foreach (var file in model.LargeImages!)
                {
                    var filePath = Path.Combine(FilePath, Guid.NewGuid().ToString() + Path.GetExtension(file.Name));

                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                    }
                    mobileDetails.MobileImageL = string.IsNullOrEmpty(mobileDetails.MobileImageL) ? filePath : " || " + filePath;
                }

                _context.MobileDetail.Add(mobileDetails);
                _context.SaveChanges();

                response.success = true;
                response.message = GeneralMessage.RecordAdded;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ServiceResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse FilterMobileByChecks(GetMobileByChecks model)
        {
            try
            {
                var data = _context.MobileDetail.ToList()
                    .Where(m => m.Tourch.IsEqual(model.Tourch)
                    || m.Is3G.IsEqual(model.Is3G)
                    || m.Is4G.IsEqual(model.Is4G)
                    || m.Is5G.IsEqual(model.Is5G)
                    || m.Camera.IsEqual(model.Camera)
                    || m.IsLatest.IsEqual(model.IsLatest)
                    || m.IsAndroidPhone.IsEqual(model.IsAndroidPhone)
                    || m.IsSmartPhone.IsEqual(model.IsSmartPhone)
                    || m.IsSymbianPhone.IsEqual(model.IsSymbianPhone)
                    || m.IsWindowsPhone.IsEqual(model.IsWindowsPhone)
                    || m.DisplayAtHomePage.IsEqual(model.DisplayAtHomePage))
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
                    }).OrderBy(m => m.MobileId).ToList();
                response.success = true;
                response.data = data;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ServiceResponse FilterMobileByValue(GetMobileByValue model)
        {
            try
            {
                var data = _context.MobileDetail.ToList()
                    .Where(m => model.Colors.Any(n => m.Colors!.ToString().Contains(n))
                    || model.Os.Any(n => m.Os!.ToString().Contains(n))
                    || model.Manufacturers.Contains(m.ManufacturerId.ToInt32()))
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
                    }).OrderBy(m => m.MobileId).ToList();
                response.success = true;
                response.data = data;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ServiceResponse FilterMobileByRange(GetMobileByRange model)
        {
            try
            {
                var data = _context.MobileDetail.ToList()
                    .Where(m => m.MobilePrice.IsBetween(model.MinMobilePrice, model.MaxMobilePrice)
                    || m.MobilePriceInDollors.IsBetween(model.MinMobilePriceInDollors, model.MaxMobilePriceInDollors)
                    || m.ScreenSizeInInches.IsBetween(model.MinScreenSize, model.MaxScreenSize)
                    || model.TalktimeRange!.Contains(m.Talktime!.ToString())
                    || model.PrimaryCameraRange!.Contains(m.PrimaryCamera!.ToString())
                    || model.SecondaryCameraRange!.Contains(m.SecondaryCamera!.ToString())
                    || model.InternalMemoryRange!.Contains(m.InternalMemory!.ToString())
                    || model.BatteryStandbyRange!.Contains(m.BatteryStandby!.ToString()))
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
                    }).OrderBy(m => m.MobileId).ToList();
                response.success = true;
                response.data = data;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
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
            catch (Exception)
            {
                throw;
            }
        }

        public ServiceResponse GetById(int id)
        {
            try
            {
                var mobileDetails = _context.MobileDetail.Select(x => new GetMobile
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
                }).FirstOrDefault();

                response.success = true;
                response.data = mobileDetails!;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ServiceResponse Update(int id, AddUpdateMobile model)
        {
            throw new NotImplementedException();
        }
    }
}
