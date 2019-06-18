using System;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Notifications;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Notifications
{
    public class UpdateNotificationCommandHandler : ICommandHandler<UpdateNotificationCommand>
    {
        private readonly IRepository _repository;

        public UpdateNotificationCommandHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public void Handle(UpdateNotificationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var notification = new Notification()
            {
                EntityId = command.EntityId,
                AuthorId = command.AuthorId,
                IsViewed = command.IsViewed,
                ReceiverId = command.ReceiverId,
                Text = command.Text,
                NotificationType = command.Type,
                LastChangedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                VacationId = command.VacationId
            };

            _repository.Update(notification);
            _repository.Save();
        }
    }
}
