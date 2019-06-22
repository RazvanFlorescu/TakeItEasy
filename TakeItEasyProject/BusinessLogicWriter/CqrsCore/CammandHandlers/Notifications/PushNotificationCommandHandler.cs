using System;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Email;
using BusinessLogicWriter.CqrsCore.Commands.Notifications;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Notifications
{
    public class PushNotificationCommandHandler : ICommandHandler<PushNotificationCommand>
    {
        private readonly IRepository _repository;
        private readonly Dispatcher _dispatcher;
        public PushNotificationCommandHandler(IRepository repository, Dispatcher dispatcher)
        {
            EnsureArg.IsNotNull(repository);
            EnsureArg.IsNotNull(dispatcher);

            _repository = repository;
            _dispatcher = dispatcher;
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

            var user = _repository.GetLastByFilter<User>(f => f.EntityId == command.ReceiverId);
            SendEmailCommand sendEmailCommand = new SendEmailCommand("takeItEasy@gmail.com", user.Email, command.Text, user.FirstName, user.LastName);
            _dispatcher.Dispatch(sendEmailCommand);

            _repository.Insert(notification);
            _repository.Save();
        }
    }
}
