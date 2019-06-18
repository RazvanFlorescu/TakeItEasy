using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Notifications
{
    public class GetNotificationsByReceiverIdQuery : IQuery<IList<NotificationDto>>
    {
        public Guid ReceiverId { private set; get; }

        public GetNotificationsByReceiverIdQuery(Guid receiverId)
        {
            ReceiverId = receiverId;
        }
    }
}
