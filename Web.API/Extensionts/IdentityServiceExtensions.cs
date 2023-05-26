using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Models.Classes;
using Models.Context;
using System.Text;

namespace Web.API.Extensionts
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration _config)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
             {
                 opt.Password.RequireDigit = false;
                 opt.Password.RequireNonAlphanumeric = false;
                 opt.Password.RequireUppercase = false;
                 opt.Password.RequireLowercase = false;
                 opt.Password.RequiredLength = 4;
             });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                                 x => x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                                 {
                                     ValidateIssuerSigningKey = true,
                                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes((_config.GetValue<string>("TokenKey")))),
                                     ValidateIssuer = false,
                                     ValidateAudience = false

                                 });

            services.AddMvc(option =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                option.Filters.Add(new AuthorizeFilter(policy));
            });

            return services;
        }
    }
}
