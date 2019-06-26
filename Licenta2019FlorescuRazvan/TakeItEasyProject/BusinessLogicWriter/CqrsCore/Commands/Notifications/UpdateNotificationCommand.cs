using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Commands;
using CommonTypes;

namespace BusinessLogicWriter.CqrsCore.Commands.Notifications
{
    public class UpdateNotificationCommand : ICommand
    {
        public Guid EntityId { get; }
        public Guid VacationId { get; }
        public Guid AuthorId { get; }
        public Guid ReceiverId { get; }
        public string Text { get; }
        public NotificationType? Type { get; }
        public bool? IsViewed { get; }

        public UpdateNotificationCommand(Guid entityId, Guid vacationId, Guid authorId, Guid receiverId, string text, NotificationType? notificationType, bool? isViewed)
        {
            EntityId = entityId;
            VacationId = vacationId;
            AuthorId = authorId;
            Text = text;
            ReceiverId = receiverId;
            Type = notificationType;
            IsViewed = isViewed;
        }
    }
}
