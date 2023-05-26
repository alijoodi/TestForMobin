using Interfaces.ServicesIntefraces;
using Interfaces.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.EntityBase;
using Repositories;
using Repositories.EntityRepository;
using Repositories.RepositoriesInterfaces;
using Services;
using Services.EntityServices;
using System.Reflection;

namespace Web.API.Extensionts
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });


            #region Repositories

            //services
            //.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));
            services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IAuthorRepository, AuthorRepository>()
            .AddScoped<IBookService, BookService>()
            .AddScoped<IAuthorService, AuthorService>()
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IUserService, UserService>();

            #endregion

            services.AddTransient<DbInitializer>();
            services.AddScoped<IApplicationRepository<EntityBase>, ApplicationRepository<EntityBase>>();

            return services;
        }
    }
}
