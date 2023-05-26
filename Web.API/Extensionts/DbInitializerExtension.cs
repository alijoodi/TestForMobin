using Microsoft.AspNetCore.Identity;
using Models.Classes;
using Models.Context;

namespace Web.API.Extensionts
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationContext>();
                var userManger = services.GetRequiredService<UserManager<User>>();
                var roleManger = services.GetRequiredService<RoleManager<Role>>();
                DbInitializer.Initialize(context, userManger,roleManger);
            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
}
