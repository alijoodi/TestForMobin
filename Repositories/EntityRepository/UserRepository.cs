using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Classes;
using Models.Context;
using Repositories.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.UserDtos;

namespace Repositories.EntityRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        public async Task<bool> UserPasswordCheckAsync(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<User> Add(RegisterDto user)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(user.UserName);
            if (userWithSameUserName != null)
            {
                throw new Exception("Duplicate Username ");
            }

            var userInUserManager = new User
            {
                UserName = user.UserName,
            };

            var result = await _userManager.CreateAsync(userInUserManager, user.Password);
            if (result.Succeeded)
            {
                return userInUserManager;
            }
            else
            {
                throw new Exception(result.Errors.FirstOrDefault().ToString());
            }
        }

        public async Task<User> FindUserAsync(string username)
        {
            return await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == username.ToLower());
        }
    }
}
