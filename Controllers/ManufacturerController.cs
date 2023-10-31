using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Services;

namespace MobileManiaAPI.Controllers
{
    [ApiController]
    [Route("[controller]"), Authorize]
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
                var result = _manufacturerService.GetAll();
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

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }



    }
}
