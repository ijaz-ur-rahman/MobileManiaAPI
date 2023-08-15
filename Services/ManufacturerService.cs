using AutoMapper;
using Azure;
using Microsoft.IdentityModel.Tokens;
using MobileManiaAPI.Entities;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.MobileManufacturers;

namespace MobileManiaAPI.Services
{
    public interface IManufacturerService
    {
        ServiceResponse  GetAll();
        ServiceResponse  GetById(int Id);
        ServiceResponse Create(AddManufacturer model);
        ServiceResponse Update(int id, UpdateManufacturer model);
        ServiceResponse Delete(int id);
    }
    public class ManufacturerService : IManufacturerService
    {
        private ServiceResponse response;
        private DataContext _context;
        private readonly IMapper _mapper;
        public ManufacturerService(
        DataContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            response = new ServiceResponse();
        }
        public ServiceResponse Create(AddManufacturer model)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse  GetAll()
        {
            try {

                var taskData = _context.Manufacturers.ToList().Select(x => new
                {
                    x.ManufacturerId,
                    x.ManufacturerName
                }).ToList().OrderBy(x => x.ManufacturerId);

                response.success = true;
                response.data = new
                {
                    taskData
                };
                return response;

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public ServiceResponse  GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse Update(int id, UpdateManufacturer model)
        {
            throw new NotImplementedException();
        }
    }
}
