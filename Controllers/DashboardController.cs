using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.DashboardViewModels;
using MobileManiaAPI.Services;

namespace MobileManiaAPI.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IDashboardService _dashboardService;
        private IMapper _mapper;

        public DashboardController(
            IDashboardService dashboardService,
            IMapper mapper)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;

        }

        [HttpGet("GetAllMobiles")]
        public IActionResult GetAllMobiles()
        {
            try
            {
                var result = _dashboardService.GetAll();
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

        [HttpGet("GetByBrand")]
        public IActionResult GetByBrand([FromQuery] int brandId)
        {
            try
            {
                var result = _dashboardService.GetByBrand(brandId);
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

        [HttpGet("GetByCamera")]
        public IActionResult GetByCamera([FromQuery] int cameraPixal)
        {
            try
            {
                var result = _dashboardService.GetByCamera(cameraPixal);
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

        [HttpGet("GetByNetwork")]
        public IActionResult GetByNetwork([FromQuery] string networkName)
        {
            try
            {
                var result = _dashboardService.GetByNetwork(networkName);
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

        [HttpGet("GetByOS")]
        public IActionResult GetByOS([FromQuery] string osName)
        {
            try
            {
                var result = _dashboardService.GetByOS(osName);
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

        [HttpGet("GetByPrice")]
        public IActionResult GetByPrice([FromQuery] int minPrice, int maxPrice)
        {
            try
            {
                var result = _dashboardService.GetByPrice(minPrice, maxPrice);
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
    }
}
