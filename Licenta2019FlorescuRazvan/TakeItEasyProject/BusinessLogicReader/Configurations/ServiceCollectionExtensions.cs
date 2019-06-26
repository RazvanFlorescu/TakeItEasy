using System.Collections.Generic;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.Images;
using BusinessLogicReader.CqrsCore.Queries.Notifications;
using BusinessLogicReader.CqrsCore.Queries.Users;
using BusinessLogicReader.CqrsCore.Queries.Vacations;
using BusinessLogicReader.CqrsCore.Queries.WishList;
using BusinessLogicReader.CqrsCore.QueryHandlers.Images;
using BusinessLogicReader.CqrsCore.QueryHandlers.Notifications;
using BusinessLogicReader.CqrsCore.QueryHandlers.Users;
using BusinessLogicReader.CqrsCore.QueryHandlers.Vacations;
using BusinessLogicReader.CqrsCore.QueryHandlers.WishList;
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
            services
                .AddScoped<IQueryHandler<GetNotificationsByReceiverIdQuery, IList<NotificationDto>>,
                    GetNotificationsByReceiverIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetAllVacationsQuery, IList<VacationDto>>,
                    GetAllVacationsQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllJoiningsByUserIdQuery, IList<VacationJoiningDto>>, GetAllJoiningsByUserIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllJoiningsByVacationIdQuery, IList<VacationJoiningDto>>, GetAllJoiningsByVacationIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetJoiningByVacationIdAndUserIdQuery, VacationJoiningDto>, GetJoiningByVacationIdAndUserIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetVacationByEntityIdQuery, VacationDto>, GetVacationByEntityIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetMostWantedQuery, IList<VacationDto>>, GetMostWantedQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetVacationsByUserIdWhereThatUserIsJoinedThereQuery, IList<VacationDto>>,
                    GetVacationsByUserIdWhereThatUserIsJoinedThereQueryHandler>();
            services.AddScoped 
                  <IQueryHandler<GetAllUsersByVacationIdQuery, IList<UserDto>>, GetAllUsersByVacationIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetWishListByUserIdQuery, IList<WishItemDto>>, GetWishListByUserIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetAllPublicVacationsQuery, IList<VacationDto>>,
                    GetAllPublicVacationsQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetPublicVacationsByUserIdQuery, IList<VacationDto>>,
                    GetPublicVacationsByUserIdQueryHandler>();

            services.AddScoped<Dispatcher>();
        }
    }
}
