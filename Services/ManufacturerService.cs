using AutoMapper;
using Azure;
using Microsoft.IdentityModel.Tokens;
using MobileManiaAPI.Entities;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.MobileManufacturersViewModels;

namespace MobileManiaAPI.Services
{
    public interface IManufacturerService
    {
        ServiceResponse<object> GetAll();
        ServiceResponse<object> GetById(int Id);
        ServiceResponse<string> Create(AddManufacturer model);
        ServiceResponse<string> Update(int id, UpdateManufacturer model);
        ServiceResponse<string> Delete(int id);
    }
    public class ManufacturerService : IManufacturerService
    {
        private ServiceResponse<object> response;
        private DataContext _context;
        private readonly IMapper _mapper;
        public ManufacturerService(
        DataContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            response = new ServiceResponse<object>();
        }
        public ServiceResponse<string> Create(AddManufacturer model)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<object> GetAll()
        {
            try
            {

                var taskData = _context.Manufacturers.ToList().Select(x => new
                {
                    x.ManufacturerId,
                    x.ManufacturerName
                }).ToList().OrderBy(x => x.ManufacturerId);

                response.success = true;
                response.data = taskData;
                return response;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ServiceResponse<object> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<string> Update(int id, UpdateManufacturer model)
        {
            throw new NotImplementedException();
        }
    }
}
