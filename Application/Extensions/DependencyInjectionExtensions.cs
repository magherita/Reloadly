using Application.Foundations;
using Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            // services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFoundationService, FoundationService>();

            return services;
        }
    }
}