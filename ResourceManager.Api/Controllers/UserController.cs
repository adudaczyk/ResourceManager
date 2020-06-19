using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.BusinessLogic.Services;

namespace ResourceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var allUsers = await _userService.GetUsers();

            return allUsers;
        }
        
        [HttpGet("{guid}")]
        public async Task<UserDto> GetUser(string guid)
        {
            var user = await _userService.GetUser(guid);

            return user;
        }
        
        [HttpPost]
        public async Task AddUser([FromBody] UserDto userDto)
        {
            await _userService.AddUser(userDto);
        }
        
        [HttpPut("{guid}")]
        public async Task UpdateUser(string guid, [FromBody] UserDto userDto)
        {
            userDto.Guid = new Guid(guid);
            await _userService.UpdateUser(userDto);
        }
        
        [HttpDelete("{guid}")]
        public async Task DeleteUser(string guid)
        {
            await _userService.DeleteUser(guid);
        }

        [HttpPut("VerifyEmail/{guid}")]
        public async Task VerifyEmail(string guid)
        {
            await _userService.VerifyEmail(guid);
        }
    }
}
