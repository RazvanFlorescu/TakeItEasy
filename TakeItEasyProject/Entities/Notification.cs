using CommonTypes;
using System;

namespace Entities
{
    public class Notification : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid VacationId { get; set; }
        public string Text { get; set; }
        public bool? IsViewed { get; set; }
        public NotificationType? NotificationType { get; set; }
    }
}
