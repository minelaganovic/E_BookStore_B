using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_BookStore_B.Context;
using E_BookStore_B.Helpers;
using E_BookStore_B.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;

namespace E_BookStore_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _authContext;
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _authContext.Users.
                FirstOrDefaultAsync(x => x.email == userObj.email);
            if (user == null)
                return NotFound(new { Message = "Korisnik nepostoji." });
            if (!PasswordHasher.VerifyPassword(userObj.pwd, user.pwd))
            {
                return BadRequest(new { Message = "Lozinka nije ispravna." });
            }

            user.Token = CreateJwtToken(user);

            return Ok(new
            {
                Token = user.Token,
                Message = "Uspešno ste se prijavili!"
            });
        }



        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            //check email
            if (await CheckEmailExistAsync(userObj.email))
                return BadRequest(new
                {
                    Message = " Email već postoji!"
                });
            userObj.pwd = PasswordHasher.HashPassword(userObj.pwd);
            userObj.Role = "user";
            userObj.Token = "";
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Uspešno ste se registrovali!"
            });
        }
        private Task<bool> CheckEmailExistAsync(string email)
            => _authContext.Users.AnyAsync(x => x.email == email);

        private string CreateJwtToken(User user)
        {
            var jwtTokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.id.ToString()),
                new Claim(ClaimTypes.Role, $"{user.Role}"),
                new Claim(ClaimTypes.Name, $"{user.firstName} {user.lastName}"),
                new Claim(ClaimTypes.Name, $"{user.address}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenhandler.CreateToken(tokenDescriptor);
            return jwtTokenhandler.WriteToken(token);
        }
    }
}
