using DataAccessReader.Abstractions;
using DataAccessReader.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessReader.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IRepository, Repository>(serviceProvider => new Repository(connectionString));
        }
    }
}
