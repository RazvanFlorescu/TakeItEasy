using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicCommon.Helpers;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.CammandHandlers.Image;
using BusinessLogicWriter.CqrsCore.CammandHandlers.Locations;
using BusinessLogicWriter.CqrsCore.CammandHandlers.Notifications;
using BusinessLogicWriter.CqrsCore.CammandHandlers.Users;
using BusinessLogicWriter.CqrsCore.CammandHandlers.Vacations;
using BusinessLogicWriter.CqrsCore.Commands.Image;
using BusinessLogicWriter.CqrsCore.Commands.Locations;
using BusinessLogicWriter.CqrsCore.Commands.Notifications;
using BusinessLogicWriter.CqrsCore.Commands.Users;
using BusinessLogicWriter.CqrsCore.Commands.Vacations;
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
            services.AddScoped<ICommandHandler<ProposeVacationCommand>, ProposeVacationCommandHandler>();
            services.AddScoped<ICommandHandler<AddLocationCommand>, AddLocationCommandHandler>();
            services.AddScoped<ICommandHandler<PushNotificationCommand>, PushNotificationCommandHandler>();
            services.AddScoped<ICommandHandler<JoinVacationCommand>, JoinVacationCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateNotificationCommand>, UpdateNotificationCommandHandler>();
            services
                .AddScoped<ICommandHandler<UpdateStatusJoinVacationCommand>, UpdateStatusJoinVacationCommandHandler>();
            services.AddScoped<Dispatcher>();
            AutoMapperHelper.IntializeMapper();
        }
    }
}
