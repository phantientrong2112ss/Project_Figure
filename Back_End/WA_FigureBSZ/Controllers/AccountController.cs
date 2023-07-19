using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WA_FigureBSZ.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WA_FigureBSZ.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        modelhandle dbconnect;
        private string Secret;
        public AccountController(IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            string t = configuration["ConnectionStrings:DefaultConnection"];
            dbconnect = new modelhandle(t);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] user model)
        {
            var user = dbconnect.Loginn(model);
            // return null if user not found
            if (user == null)
                return Ok(new { message = "Tài khoản hoặc mật khẩu không đúng" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.full_name.ToString()),
                    new Claim(ClaimTypes.Role, user.email),
                    new Claim(ClaimTypes.DenyOnlyWindowsDeviceGroup, user.password)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tmp);
            return Ok(new { UserId = user.id, Hoten = user.full_name, Taikhoan = user.users_name, Token = token });
        }
    }
}
