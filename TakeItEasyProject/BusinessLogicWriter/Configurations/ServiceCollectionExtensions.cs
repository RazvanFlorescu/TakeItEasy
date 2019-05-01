using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands;
using BusinessLogicWriter.Helpers;
using DataAccessWriter.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicWriter.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogicWriter(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<ICommandHandler<RegisterUserCommand>, RegisterUserCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveAccountCommand>, RemoveAccountCommandHandler>();
            services.AddScoped<Dispatcher>();
            AutoMapperHelper.IntializeMapper();
        }
    }
}
