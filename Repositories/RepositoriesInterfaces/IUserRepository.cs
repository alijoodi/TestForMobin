using Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.UserDtos;

namespace Repositories.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExistsAsync(string username);
        Task<User> FindUserAsync(string username);
        Task<bool> UserPasswordCheckAsync(User user, string password);
        Task<User> Add(RegisterDto user);
    }
}
