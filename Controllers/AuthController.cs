using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.AuthViewModels;
using MobileManiaAPI.Services;

namespace MobileManiaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IMapper _mapper;

        public AuthController(
            IAuthService authService,
            IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;

        }

        [HttpPost("Login")]
        public IActionResult Post([FromBody] Login model)
        {
            try
            {
                var result = _authService.Login(model);
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
