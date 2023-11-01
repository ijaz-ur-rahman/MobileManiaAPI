using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.DashboardViewModels;
using MobileManiaAPI.Models.MobileViewModels;
using MobileManiaAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileManiaAPI.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class MobileDetailsController : ControllerBase
    {
        private IMobileDetailService _mobileDetailService;
        private IMapper _mapper;

        public MobileDetailsController(
            IMobileDetailService mobileDetailService,
            IMapper mapper)
        {
            _mobileDetailService = mobileDetailService;
            _mapper = mapper;

        }

        // GET: api/<MobileDetailsController>
        [HttpGet("GetMobilesByChecks")]
        public IActionResult GetMobilesByChecks([FromQuery] GetMobileByChecks model)
        {
            try
            {
                var result = _mobileDetailService.FilterMobileByChecks(model);
                if (result.success)
                {
                    return Ok(new
                    {
                        Status = GeneralMessage.StatusSuccess,
                        Data = result.data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = GeneralMessage.StatusFail,
                        Message = GeneralMessage.RecordNotFound
                    });
                }
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
        // GET: api/<MobileDetailsController>
        [HttpGet("GetMobilesByValue")]
        public IActionResult GetMobilesByValue([FromQuery] GetMobileByValue model)
        {
            try
            {
                var result = _mobileDetailService.FilterMobileByValue(model);
                if (result.success)
                {
                    return Ok(new
                    {
                        Status = GeneralMessage.StatusSuccess,
                        Data = result.data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = GeneralMessage.StatusFail,
                        Message = GeneralMessage.RecordNotFound
                    });
                }
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
        // GET: api/<MobileDetailsController>
        [HttpGet("GetMobilesByRange")]
        public IActionResult GetMobilesByRange([FromQuery] GetMobileByRange model)
        {
            try
            {
                var result = _mobileDetailService.FilterMobileByRange(model);
                if (result.success)
                {
                    return Ok(new
                    {
                        Status = GeneralMessage.StatusSuccess,
                        Data = result.data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = GeneralMessage.StatusFail,
                        Message = GeneralMessage.RecordNotFound
                    });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }

        // GET api/<MobileDetailsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _mobileDetailService.GetById(id);
            if (result.success)
            {
                return Ok(new
                {
                    Status = GeneralMessage.StatusSuccess,
                    Data = result.data
                });
            }
            else
            {
                return Ok(new
                {
                    Status = GeneralMessage.StatusFail,
                    Message = GeneralMessage.RecordNotFound
                });
            }
        }

        // POST api/<MobileDetailsController>
        [HttpPost]
        public IActionResult Post([FromForm] AddUpdateMobile model)
        {
            var result = _mobileDetailService.Create(model);
            if (result.success)
            {
                return Ok(new
                {
                    Status = GeneralMessage.StatusSuccess,
                    Data = result.data
                });
            }
            else
            {
                return Ok(new
                {
                    Status = GeneralMessage.StatusFail,
                    Message = GeneralMessage.RecordNotFound
                });
            }
        }

        // PUT api/<MobileDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] AddUpdateMobile model)
        {
        }

        // DELETE api/<MobileDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
