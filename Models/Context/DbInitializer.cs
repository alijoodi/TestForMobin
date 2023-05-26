using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Classes;
using System.Security.Cryptography;
using System.Text;

namespace Models.Context
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();
            if (context.Users.Any()) return;

            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(userData);

            var roles = new List<Role> {
            new Role{Name="admin"},
            new Role{Name="supervisor"},
            new Role{Name="client"}
            };

            foreach (var role in roles)
            {
                roleManager.CreateAsync(role).Wait();
            }

            context.Users.RemoveRange(context.Users.Where(x => x.UserName != String.Empty));
            context.SaveChanges();
            //var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                userManager.CreateAsync(user, "1234").Wait();
                switch (user.UserName.ToLower())
                {
                    case "admin":
                        userManager.AddToRoleAsync(user, user.UserName).Wait();
                        break;
                    case "supervisor":
                        userManager.AddToRoleAsync(user, user.UserName).Wait();
                        break;
                    case "client":
                    default:
                        userManager.AddToRoleAsync(user, "client").Wait();
                        break;
                }
            }
            //context.Users.AddRange(users);

            //context.SaveChanges();
        }
    }
}
