using CommonTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class NotificationDto : BaseDto
    {
        public string AuthorId { get; set; }
        public string ReceiverId { get; set; }
        public string VacationId { get; set; }
        public string Text { get; set; }
        public bool? IsViewed { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public NotificationType? NotificationType { get; set; } 
    }
}
