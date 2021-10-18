using HrApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HrContext _context;
        private readonly SymmetricSecurityKey _key;
        public AuthController(HrContext context)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Our super  secret key@123"));
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> RegisterUser(RegisterUserRequest registerUserRequest)
        {
            if (await _context.AppUsers.AnyAsync(x => x.Username == registerUserRequest.Username.ToLower()))
                return BadRequest("Username is taken!");

            var hmac = new HMACSHA512();
            var appUser = new AppUser
            {
                Username = registerUserRequest.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUserRequest.Password)),
                PasswordSalt = hmac.Key
            };
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();
            return appUser;

        }
        [HttpPost("login")]
        public async Task<ActionResult<LoggedInUser>> LoginUser(LoginUserRequest loginUserRequest)
        {
            var user = await _context.AppUsers.SingleOrDefaultAsync(x => x.Username == loginUserRequest.Username);
            if (user is null) return Unauthorized("Username does not exist!");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUserRequest.Password));
            if (computedHash.Length != user.PasswordHash.Length) return Unauthorized("Invalid Password!");
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password!");
            }
            var loggedInUser = new LoggedInUser
            {
                Username = user.Username,
                Token = CreateToken(user)
            };
            return loggedInUser;


        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Username)
        };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,
                Issuer = "https://localhost:44318/"

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
    public class LoggedInUser
    {

        public string Username { get; set; }

        public string Token { get; set; }
    }
    public class RegisterUserRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginUserRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
