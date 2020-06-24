using AutoMapper;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.EntityFrameworkCore.Models;
using ResourceManager.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUser(string guid)
        {
            var user = await _userRepository.GetByGuid(guid);

            return _mapper.Map<UserDto>(user);
        }

        public async Task AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            user.Guid = Guid.NewGuid();
            user.CreationDate = DateTime.Now;
            user.IsEmailVerified = false;

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var user = await _userRepository.GetByGuid(userDto.Guid.ToString());

            if (user == null)
            {
                throw new KeyNotFoundException($"Cannot update user. User with guid {user.Guid} does not exist");
            }

            _mapper.Map(userDto, user);

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUser(string guid)
        {
            var user = await _userRepository.GetByGuid(guid);

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task VerifyEmail(string guid)
        {
            var user = await _userRepository.GetByGuid(guid);
            user.IsEmailVerified = true;

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
