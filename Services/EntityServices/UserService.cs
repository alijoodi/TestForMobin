using Commons;
using Interfaces.ServicesIntefraces;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ViewModels.UserDtos;

namespace Services.EntityServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _userRepository.FindUserAsync(loginDto.UserName);

            if (user == null) throw new Exception("Invalid username");

            if (!await _userRepository.UserPasswordCheckAsync(user, loginDto.Password))
                throw new Exception("Invalid password");

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user = await _userRepository.Add(registerDto);

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }
    }
}
