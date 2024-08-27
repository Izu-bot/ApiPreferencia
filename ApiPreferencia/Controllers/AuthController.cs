using ApiPreferencia.Model;
using ApiPreferencia.Services;
using ApiPreferencia.VIewModel.AuthVM;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiPreferencia.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService service, IMapper mapper)
        {
            _authService = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            var authenticate = _authService.Authenticate(login.Username, login.Password);

            if (authenticate == null) return Unauthorized();

            var token = GenerateJWT(authenticate);

            return Ok(new { Token = token });
        }

        private string GenerateJWT(UserModel model)
        {
            byte[] secret = Encoding.ASCII.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi");
            var security = new SymmetricSecurityKey(secret);
            var credentials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);

            JwtSecurityTokenHandler jwtSecurityToken = new();

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.UserEmail),
                    new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = "fiap",
                SigningCredentials = new(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            SecurityToken securityToken = jwtSecurityToken.CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}
