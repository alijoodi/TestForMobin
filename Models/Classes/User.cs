using Microsoft.AspNetCore.Identity;

namespace Models.Classes
{
    public class User : IdentityUser<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}