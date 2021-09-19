using Application.Donations;
using Application.Users;
using Application.Wallets;
using Domain.Donation;
using Domain.Wallet;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDonationService, DonationService>();

            return services;
        }
    }
}