using System;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Notifications;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Notifications
{
    public class PushNotificationCommandHandler : ICommandHandler<PushNotificationCommand>
    {
        private readonly IRepository _repository;
  
        public PushNotificationCommandHandler(IRepository repository, Dispatcher dispatcher)
        {
            EnsureArg.IsNotNull(dispatcher);

            _repository = repository;
        }

        public void Handle(PushNotificationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var notification = new Notification()
            {
                EntityId = command.EntityId,
                AuthorId = command.AuthorId,
                LastChangedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                IsViewed = false,
                ReceiverId = command.ReceiverId,
                Text = command.Text,
                NotificationType = command.Type,
                VacationId = command.VacationId
            };

            _repository.Insert(notification);
            _repository.Save();
        }
    }
}
