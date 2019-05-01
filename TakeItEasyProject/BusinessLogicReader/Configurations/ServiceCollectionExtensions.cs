using System.Collections.Generic;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries;
using BusinessLogicReader.CqrsCore.QueryHandlers;
using BusinessLogicWriter.CqrsCore;
using DataAccessReader.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace BusinessLogicReader.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogicReader(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<IQueryHandler<GetAllUsersQuery, IList<UserDto>>, GetAllUsersQueryHandler>();
            services.AddScoped<Dispatcher>();
        }
    }
}
