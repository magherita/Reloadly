using Database.Collections;
using Domain.Foundation;
using Domain.User;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services)
        {
            // services.AddScoped<IWalletCollection, WalletCollection>();
            services.AddScoped<IFoundationCollection, FoundationCollection>();
            services.AddScoped<IUserCollection, UserCollection>();

            return services;
        }
    }
}