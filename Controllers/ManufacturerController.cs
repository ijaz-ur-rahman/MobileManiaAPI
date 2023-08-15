using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Services;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MobileManiaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private IManufacturerService _manufacturerService;
        private IMapper _mapper;
      

        public ManufacturerController(
            IManufacturerService manufacturerService,
            IMapper mapper)
        {
            _manufacturerService = manufacturerService;
            _mapper = mapper;
          
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                

                dynamic result = _manufacturerService.GetAll();
                if (result.success)
                {
                    return Ok(new
                    {
                        Status = GeneralMessage.StatusSuccess,
                        Data = result.data
                    });
                }
                else

                    return Ok(new
                    {
                        Status = GeneralMessage.StatusFail,
                        Message = GeneralMessage.RecordNotFound
                    });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                
            }

        }
           

        
    }
}
