using System.Collections.Generic;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.Images;
using BusinessLogicReader.CqrsCore.Queries.Users;
using BusinessLogicReader.CqrsCore.Queries.Vacations;
using BusinessLogicReader.CqrsCore.QueryHandlers.Images;
using BusinessLogicReader.CqrsCore.QueryHandlers.Users;
using BusinessLogicReader.CqrsCore.QueryHandlers.Vacations;
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
            services.AddScoped<IQueryHandler<GetUserByEntityIdQuery, UserDto>, GetUserByEntityIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetRegisteredUserQuery, UserDto>, GetRegisteredUserQueryHandler>();
            services.AddScoped<IQueryHandler<GetUserByEmailQuery, UserDto>, GetUserByEmailQueryHandler>();
            services.AddScoped<IQueryHandler<GetVacationsByUserIdQuery, IList<VacationDto>>, GetVacationsByUserIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetLocationsByVacationIdQuery, IList<LocationDto>>,
                    GetLocationsByVacationIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetImageByEntityIdQuery, ImageDto>, GetImageByEntityIdQueryHandler>();

            services.AddScoped<Dispatcher>();
        }
    }
}
