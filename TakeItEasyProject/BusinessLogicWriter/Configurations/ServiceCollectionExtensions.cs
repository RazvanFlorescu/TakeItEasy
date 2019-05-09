using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicCommon.Helpers;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.CammandHandlers.Image;
using BusinessLogicWriter.CqrsCore.CammandHandlers.Users;
using BusinessLogicWriter.CqrsCore.Commands.Image;
using BusinessLogicWriter.CqrsCore.Commands.Users;
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
            services.AddScoped<ICommandHandler<AddImageCommand>, AddImageCommandHandler>();
            services.AddScoped<Dispatcher>();
            AutoMapperHelper.IntializeMapper();
        }
    }
}
