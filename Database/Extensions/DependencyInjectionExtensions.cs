using Database.Collections;
using Domain.Donation;
using Domain.User;
using Domain.Wallet;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services)
        {
            services.AddScoped<IWalletCollection, WalletCollection>();
            services.AddScoped<IDonationCollection, DonationCollection>();
            services.AddScoped<IUserCollection, UserCollection>();

            return services;
        }
    }
}