using BusinessLogicReader.CqrsCore.Queries.Notifications;
using BusinessLogicWriter.CqrsCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BusinessLogicCommon.Resources;
using BusinessLogicWriter.CqrsCore.Commands.Notifications;

namespace TakeItEasyProject.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public NotificationController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost("pushNotification")]
        public IActionResult PushNotification([FromBody] NotificationDto notification)
        {
            Guid vacationIdParsed;
            if (!Guid.TryParse(notification.VacationId, out vacationIdParsed))
            {
                return BadRequest();
            }

            Guid authorIdParsed;
            if (!Guid.TryParse(notification.AuthorId, out authorIdParsed))
            {
                return BadRequest();
            }

            Guid receiverIdParsed;
            if (!Guid.TryParse(notification.ReceiverId, out receiverIdParsed))
            {
                return BadRequest();
            }

            PushNotificationCommand command = new PushNotificationCommand(
                Guid.NewGuid(), 
                vacationIdParsed,
                authorIdParsed,
                receiverIdParsed,
                notification.Text,
                notification.NotificationType
            );

            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpPut("updateNotification")]
        public IActionResult UpdateNotification([FromBody] NotificationDto notification)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(notification.EntityId, out entityIdParsed))
            {
                return BadRequest();
            }

            Guid vacationIdParsed;
            if (!Guid.TryParse(notification.VacationId, out vacationIdParsed))
            {
                return BadRequest();
            }

            Guid authorIdParsed;
            if (!Guid.TryParse(notification.AuthorId, out authorIdParsed))
            {
                return BadRequest();
            }

            Guid receiverIdParsed;
            if (!Guid.TryParse(notification.ReceiverId, out receiverIdParsed))
            {
                return BadRequest();
            }

            UpdateNotificationCommand command = new UpdateNotificationCommand(
                entityIdParsed,
                vacationIdParsed,
                authorIdParsed,
                receiverIdParsed,
                notification.Text,
                notification.NotificationType,
                notification.IsViewed
            );

            _dispatcher.Dispatch(command);

            return Ok();
        }

        [HttpGet("{receiverId}")]
        public IActionResult GetNotificationsByUserId(string receiverId)
        {
            Guid entityIdParsed;
            if (!Guid.TryParse(receiverId, out entityIdParsed))
            {
                return BadRequest();
            }

            GetNotificationsByReceiverIdQuery query = new GetNotificationsByReceiverIdQuery(entityIdParsed);
            IList<NotificationDto> notifications = _dispatcher.Dispatch(query);

            if (notifications == null)
            {
                return BadRequest(ResponseMessage.VacationNotFound);
            }

            return Ok(notifications);
        }
    }
}
