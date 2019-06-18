using System.Collections.Generic;
using AutoMapper;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.Notifications;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Entities;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.Notifications
{
    public class GetNotificationsByReceiverIdQueryHandler : IQueryHandler<GetNotificationsByReceiverIdQuery, IList<NotificationDto>>
    {
        private readonly IRepository _repository;

        public GetNotificationsByReceiverIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<NotificationDto> Handle(GetNotificationsByReceiverIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<Notification>(NotificationQueryBuilder.GetByReceiverId(query.ReceiverId));
            var notifications = Mapper.Map<IList<Notification>, IList<NotificationDto>>(result);

            return notifications;
        }
    }
}
