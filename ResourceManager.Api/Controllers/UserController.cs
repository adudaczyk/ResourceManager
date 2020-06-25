using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.BusinessLogic.Services;

namespace ResourceManager.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto userDto)
        {
            var user = await _userService.Authenticate(userDto.Email, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["SecretToken"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Email = user.Email,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            try
            {
                await _userService.AddUser(userDto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var allUsers = await _userService.GetUsers();

            return Ok(allUsers);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetUser(string guid)
        {
            var user = await _userService.GetUser(guid);

            return Ok(user);
        }
        
        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateUser(string guid, [FromBody] UserDto userDto)
        {
            userDto.Guid = new Guid(guid);
            try
            {
                await _userService.UpdateUser(userDto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteUser(string guid)
        {
            try
            {
                await _userService.DeleteUser(guid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("VerifyEmail/{guid}")]
        public async Task<IActionResult> VerifyEmail(string guid)
        {
            try
            {
                await _userService.VerifyEmail(guid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
