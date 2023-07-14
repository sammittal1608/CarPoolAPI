using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        ILoginService _loginService;

        public AuthController(IConfiguration configuration, ILoginService loginService)
        {
            _configuration = configuration;
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpGet("signIn")]
        public IActionResult Login([FromBody] Credentials credentials)
        {
            var result =_loginService.SignIn(credentials);
            if (result != null)
            {
                var token = GenerateJwtToken(credentials.Email);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpGet("signUp")]
        public IActionResult Register([FromBody] Credentials signUp)
        {
            //var token = GenerateJwtToken(signUp.Email);
            //return Ok(new { token });
           var result =  _loginService.Register(signUp);
            return null;
        }
        private string GenerateJwtToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        //public class LoginModel
        //{
        //    public string Username { get; set; }
        //    public string Password { get; set; }
        //}

        //public class RegisterModel
        //{
        //    public string Username { get; set; }
        //    public string Password { get; set; }
        //}
    }
}
