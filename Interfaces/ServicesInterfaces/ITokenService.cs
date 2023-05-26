using Models.Classes;

namespace Interfaces.ServicesIntefraces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
