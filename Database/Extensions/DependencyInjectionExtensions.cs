using Database.Collections;
using Domain.Donation;
using Domain.Foundation;
using Domain.User;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services)
        {
            services.AddScoped<IDonationCollection, DonationCollection>();
            services.AddScoped<IFoundationCollection, FoundationCollection>();
            services.AddScoped<IUserCollection, UserCollection>();

            return services;
        }
    }
}