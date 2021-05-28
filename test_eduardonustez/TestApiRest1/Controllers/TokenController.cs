using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TestApiRest1.Models;

namespace TestApiRest1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginModel login)
        {
           
            if (login.user == "admin" && login.password == "1234")
            {
                return Ok(new
                {
                    IsAuthenticated = true,
                    Token = GetToken()
                });
            }
            else
            {
                return Ok(new
                {
                    IsAuthenticated = false,
                    Token = ""
                });
            }
        }

        private async Task<string> GetToken()
        {
            var utcNow = DateTime.UtcNow;
            
            var claims = new Claim[]
           {
                        new Claim(JwtRegisteredClaimNames.Sub, "1"),
                        new Claim(JwtRegisteredClaimNames.UniqueName, "John Doe"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
           };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration.GetValue<String>("Tokens:Key")));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddSeconds(this._configuration.GetValue<int>("Tokens:Lifetime")),
                audience: this._configuration.GetValue<String>("Tokens:Audience"),
                issuer: this._configuration.GetValue<String>("Tokens:Issuer")
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);  
        }
    }
}
