using System;
using BusinessLogicCommon.CqrsCore.Commands;
using CommonTypes;

namespace BusinessLogicWriter.CqrsCore.Commands.Notifications
{
    public class PushNotificationCommand : ICommand
    {
        public Guid EntityId { get; }
        public Guid AuthorId { get; }
        public Guid ReceiverId { get; }
        public string Text { get; }
        public NotificationType? Type { get; }
        public Guid VacationId { get; }

        public PushNotificationCommand(Guid entityId, Guid vacationId, Guid authorId, Guid receiverId, string text, NotificationType? notificationType)
        {
            EntityId = entityId;
            VacationId = vacationId;
            AuthorId = authorId;
            Text = text;
            ReceiverId = receiverId;
            Type = notificationType;
        }
    }
}
