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
        ServiceResponse<List<GetMobile>> GetAll();
        ServiceResponse<List<GetMobile>> FilterMobileByChecks(GetMobileByChecks model);
        ServiceResponse<List<GetMobile>> FilterMobileByValue(GetMobileByValue model);
        ServiceResponse<List<GetMobile>> FilterMobileByRange(GetMobileByRange model);
        ServiceResponse<GetMobile> GetById(int id);
        ServiceResponse<string> Create(AddUpdateMobile model);
        ServiceResponse<GetMobile> Update(int id, AddUpdateMobile model);
        ServiceResponse<string> Delete(int id);
    }
    public class MobileDetailService : IMobileDetailService
    {
        private ServiceResponse<List<GetMobile>> response;
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
            response = new ServiceResponse<List<GetMobile>>();
            _environment = environment;
        }
        public ServiceResponse<string> Create(AddUpdateMobile model)
        {
            try
            {
                var response = new ServiceResponse<string>();

                var mobileDetails = _mapper.Map<MobileDetail>(model);

                string folderName = FilePaths.MobileImagesPath;
                string FilePath = Path.Combine(_environment.WebRootPath, folderName);

                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);

                foreach (var file in model.SmallImages!)
                {
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(FilePath, imageName);

                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                    }
                    mobileDetails.MobileImageS = string.IsNullOrEmpty(mobileDetails.MobileImageS) ? folderName + "\\" + imageName : " || " + folderName + "\\" + imageName;
                }

                foreach (var file in model.LargeImages!)
                {
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(FilePath, imageName);

                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                    }
                    mobileDetails.MobileImageL = string.IsNullOrEmpty(mobileDetails.MobileImageL) ? folderName + "\\" + imageName : " || " + folderName + "\\" + imageName;
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

        public ServiceResponse<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<GetMobile>> FilterMobileByChecks(GetMobileByChecks model)
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
                        MobileName = x.MobileName,
                        MobilePrice = x.MobilePrice,
                        MobilePriceInDollors = x.MobilePriceInDollors,
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
                        MobileImageS = SetImagePath(x.MobileImageS!),
                        MobileImageL = SetImagePath(x.MobileImageL!),
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
        public ServiceResponse<List<GetMobile>> FilterMobileByValue(GetMobileByValue model)
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
                        MobileName = x.MobileName,
                        MobilePrice = x.MobilePrice,
                        MobilePriceInDollors = x.MobilePriceInDollors,
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
                        MobileImageS = SetImagePath(x.MobileImageS!),
                        MobileImageL = SetImagePath(x.MobileImageL!),
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
        public ServiceResponse<List<GetMobile>> FilterMobileByRange(GetMobileByRange model)
        {
            try
            {
                var data = _context.MobileDetail.ToList()
                    .Where(m => m.MobilePrice.IsBetween(model.MinMobilePrice, model.MaxMobilePrice)
                    || m.MobilePriceInDollors.IsBetween(model.MinMobilePriceInDollors, model.MaxMobilePriceInDollors)
                    || m.ScreenSizeInInches.IsBetween(model.MinScreenSize, model.MaxScreenSize)
                    || model.TalktimeRange!.Contains(m.Talktime!)
                    || model.PrimaryCameraRange!.Contains(m.PrimaryCamera!)
                    || model.SecondaryCameraRange!.Contains(m.SecondaryCamera!)
                    || model.InternalMemoryRange!.Contains(m.InternalMemory!)
                    || model.BatteryStandbyRange!.Contains(m.BatteryStandby!))
                    .Select(x => new GetMobile
                    {
                        MobileId = x.MobileId,
                        MobileName = x.MobileName,
                        MobilePrice = x.MobilePrice,
                        MobilePriceInDollors = x.MobilePriceInDollors,
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
                        MobileImageS = SetImagePath(x.MobileImageS!),
                        MobileImageL = SetImagePath(x.MobileImageL!),
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
                    MobileImageS = SetImagePath(x.MobileImageS!),
                    MobileImageL = SetImagePath(x.MobileImageL!),
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

        public ServiceResponse<GetMobile> GetById(int id)
        {
            try
            {
                var response = new ServiceResponse<GetMobile>();
                var mobileDetails = _context.MobileDetail.Where(m => m.MobileId == id).Select(x => new GetMobile
                {
                    MobileId = x.MobileId,
                    MobileName = x.MobileName,
                    MobilePrice = x.MobilePrice,
                    MobilePriceInDollors = x.MobilePriceInDollors,
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
                    MobileImageS = SetImagePath(x.MobileImageS!),
                    MobileImageL = SetImagePath(x.MobileImageL!),
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

        public ServiceResponse<GetMobile> Update(int id, AddUpdateMobile model)
        {
            throw new NotImplementedException();
        }
        public static string[]? SetImagePath(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value.Split("||");
            }
            return null;
        }
    }
}
