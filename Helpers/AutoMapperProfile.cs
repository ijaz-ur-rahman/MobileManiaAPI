using AutoMapper;
using MobileManiaAPI.Entities;
using MobileManiaAPI.Models.MobileManufacturersViewModels;
using MobileManiaAPI.Models.MobileViewModels;

namespace MobileManiaAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateRequest->User
            CreateMap<Manufacturer, AddManufacturer>().ReverseMap();
            CreateMap<Manufacturer, UpdateManufacturer>().ReverseMap();
            CreateMap<MobileDetail, AddUpdateMobile>().ReverseMap();
            CreateMap<MobileDetail, GetMobile>().ReverseMap();

            //// UpdateRequest -> User
            //CreateMap<UpdateRequest, User>()
            //    .ForAllMembers(x => x.Condition(
            //        (src, dest, prop) =>
            //        {
            //            // ignore both null & empty string properties
            //            if (prop == null) return false;
            //            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            //            // ignore null role
            //            if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

            //            return true;
            //        }
            //    ));
        }
    }
}
