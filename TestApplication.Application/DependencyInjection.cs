using Microsoft.Extensions.DependencyInjection;
using TestApplication.Application.Services.Authentication;
using TestApplication.Application.Services.Users;

namespace TestApplication.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
