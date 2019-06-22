using System;
using System.Linq;
using BusinessLogicReader.CqrsCore.Queries.Users;
using BusinessLogicReader.CqrsCore.Queries.Vacations;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.Commands.Notifications;
using CommonTypes;

namespace BusinessLogicSynchronize.HangfireDbSynchronizer
{
    public class DbSynchronizer : IDbSynchronizer
    {
        private Dispatcher _dispatcher;

        public DbSynchronizer(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Synchronize()
        {
            NotifyAllStartDaysFromToday();
        }

        public void NotifyAllStartDaysFromToday()
        {
            GetAllVacationsQuery query = new GetAllVacationsQuery();
            var allVacation = _dispatcher.Dispatch(query);

            foreach (var vacation in allVacation)
            {
                if (vacation.StartDate.Year == DateTime.Now.Year && vacation.StartDate.Month == DateTime.Now.Month && vacation.StartDate.Day == DateTime.Now.Day)
                {
                    var queryAllUsersByVacationIdQuery = new GetAllUsersByVacationIdQuery(vacation.EntityId);
                    var users = _dispatcher.Dispatch(queryAllUsersByVacationIdQuery);
                    if (users.Count() == 0)
                    {
                        break;
                    }
                    else
                    {
                        foreach (var user in users)
                        {
                            Guid userIdParsed;
                            if (!Guid.TryParse(user.EntityId, out userIdParsed))
                            {
                                return;
                            }

                            Guid vacationIdParsed;
                            if (!Guid.TryParse(vacation.EntityId, out vacationIdParsed))
                            {
                                return;
                            }

                            Guid authorIdParsed;
                            if (!Guid.TryParse(vacation.AuthorId, out authorIdParsed))
                            {
                                return;
                            }

                            PushNotificationCommand pushNotification = new PushNotificationCommand(Guid.NewGuid(),
                                 vacationIdParsed,
                                 authorIdParsed,
                                 userIdParsed,
                                 $"Let's start the travel. Today {vacation.StartDate}, we are starting our trip \"{vacation.Title}\". Enjoy it!",
                                 NotificationType.StartVacation);
                            _dispatcher.Dispatch(pushNotification);
                        }
                    }
                }
            }
        }
    }
}
