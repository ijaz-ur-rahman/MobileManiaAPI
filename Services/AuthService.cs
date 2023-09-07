using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using MobileManiaAPI.Helpers;
using MobileManiaAPI.Models.AuthViewModels;
using MobileManiaAPI.Models.MobileManufacturersViewModels;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MobileManiaAPI.Services
{
    public interface IAuthService
    {
        ServiceResponse Login(Login model);
    }
    public class AuthService : IAuthService
    {
        private ServiceResponse response;
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthService(
        DataContext context,
        IMapper mapper,
        IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            response = new ServiceResponse();
            _configuration = configuration;
        }
        public ServiceResponse Login(Login model)
        {
            var userDetails = _context.Users.FirstOrDefault(m => m.UserName!.ToLower() == model.Username!.ToLower() && m.Password!.ToLower() == model.Password!.ToLower());
            if (userDetails != null)
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, userDetails.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, userDetails.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.Now.AddHours(2),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                response.success = true;
                response.data = stringToken;
                return response;
            }
            response.success = false;
            response.data = StatusCodes.Status401Unauthorized;
            return response;

        }
    }
}