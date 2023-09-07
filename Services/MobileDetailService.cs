using AutoMapper;
using Azure;
using Microsoft.IdentityModel.Tokens;
using MobileManiaAPI.Entities;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.DashboardViewModels;
using MobileManiaAPI.Models.MobileViewModels;
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
                var data = _context.MobileDetail.Where(m => model.Tourch == true ? m.Tourch == model.Tourch : false
                    || model.Is3G == true ? m.Is3G == model.Is3G : false
                    || model.Is4G == true ? m.Is4G == model.Is4G : false
                    || model.Is5G == true ? m.Is5G == model.Is5G : false
                    || model.Camera == true ? m.Camera == model.Camera : false
                    || model.IsLatest == true ? m.IsLatest == model.IsLatest : false
                    || model.IsAndroidPhone == true ? m.IsAndroidPhone == model.IsAndroidPhone : false
                    || model.IsSmartPhone == true ? m.IsSmartPhone == model.IsSmartPhone : false
                    || model.IsSymbianPhone == true ? m.IsSymbianPhone == model.IsSymbianPhone : false
                    || model.IsWindowsPhone == true ? m.IsWindowsPhone == model.IsWindowsPhone : false
                    || model.DisplayAtHomePage == true ? m.DisplayAtHomePage == model.DisplayAtHomePage : false)
                      .OrderBy(m => m.MobileId).ToList();
                response.success = true;
                response.data = data;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ServiceResponse FilterMobileByValue(GetMobileByValue model)
        {
            var data = _context.MobileDetail.ToList();
            throw new NotImplementedException();
        }
        public ServiceResponse FilterMobileByRange(GetMobileByRange model)
        {
            var data = _context.MobileDetail.ToList();
            throw new NotImplementedException();
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
