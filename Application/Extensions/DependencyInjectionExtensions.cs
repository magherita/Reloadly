using Application.Donations;
using Application.Foundations;
using Application.Users;
using Application.Wallets;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IDonationService, DonationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFoundationService, FoundationService>();

            return services;
        }
    }
}