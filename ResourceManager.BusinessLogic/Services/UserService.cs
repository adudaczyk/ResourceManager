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

        public async Task<User> Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = await _userRepository.GetByEmail(email);
            
            if (user == null) return null;
            
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

            return user;
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

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

            user.Guid = Guid.NewGuid();
            user.CreationDate = DateTime.Now;
            user.IsEmailVerified = false;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

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

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(userDto.Password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

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

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
