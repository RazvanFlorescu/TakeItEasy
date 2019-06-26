using System;
using System.Linq;
using BusinessLogicReader.CqrsCore.Queries.Users;
using BusinessLogicReader.CqrsCore.Queries.Vacations;
using BusinessLogicReader.CqrsCore.Queries.WishList;
using BusinessLogicWriter.CqrsCore;
using BusinessLogicWriter.CqrsCore.Commands.Email;
using BusinessLogicWriter.CqrsCore.Commands.Notifications;
using CommonTypes;
using GeoCoordinatePortable;
using Models;

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
            NotifyAllEndDaysFromToday();
            NotifyWishItemsInCaseThatTheyExists();
        }

        public void NotifyAllStartDaysFromToday()
        {
            GetAllVacationsQuery query = new GetAllVacationsQuery();
            var allVacation = _dispatcher.Dispatch(query);

            foreach (var vacation in allVacation)
            {
                if (vacation.StartDate.Year == DateTime.Now.Year && vacation.StartDate.Month == DateTime.Now.Month && vacation.StartDate.Day == DateTime.Now.Day)
                {
                    var queryAllUsersByVacationId = new GetAllUsersByVacationIdQuery(vacation.EntityId);
                    var users = _dispatcher.Dispatch(queryAllUsersByVacationId);
                    if (users.Count() == 0)
                    {
                        continue;
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
                                 new Guid("01BAED71-9258-42B5-997F-4831FB06EEDB"),
                                 userIdParsed,
                                 $"Let's start the travel. Today {vacation.StartDate.ToShortDateString()}, we are starting our trip \"{vacation.Title}\". Enjoy it!",
                                 NotificationType.StartVacation);
                            _dispatcher.Dispatch(pushNotification);

                            SendEmailCommand sendEmailCommand = new SendEmailCommand("takeItEasy@gmail.com", user.Email, pushNotification.Text, user.FirstName, user.LastName);
                            _dispatcher.Dispatch(sendEmailCommand);
                        }
                    }
                } 
            }
        }

        public void NotifyAllEndDaysFromToday()
        {
            GetAllVacationsQuery query = new GetAllVacationsQuery();
            var allVacation = _dispatcher.Dispatch(query);

            foreach (var vacation in allVacation)
            {
                if (vacation.EndDate.Year == DateTime.Now.Year && vacation.EndDate.Month == DateTime.Now.Month &&
                    vacation.EndDate.Day == DateTime.Now.Day)
                {
                    var queryAllUsersByVacationIdQuery = new GetAllUsersByVacationIdQuery(vacation.EntityId);
                    var usersEndDate = _dispatcher.Dispatch(queryAllUsersByVacationIdQuery);
                    if (usersEndDate.Count() == 0)
                    {
                       continue;
                    }
                    else
                    {
                        foreach (var user in usersEndDate)
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
                                new Guid("01BAED71-9258-42B5-997F-4831FB06EEDB"),
                                userIdParsed,
                                $"Today {vacation.StartDate.ToShortDateString()}, your vacation \"{vacation.Title}\", it's over. Hope to see you next time for another trip!",
                                NotificationType.EndVacation);
                            _dispatcher.Dispatch(pushNotification);

                            SendEmailCommand sendEmailCommand = new SendEmailCommand("takeItEasy@gmail.com", user.Email,
                                pushNotification.Text, user.FirstName, user.LastName);
                            _dispatcher.Dispatch(sendEmailCommand);
                        }
                    }
                }
            }
        }

        public void NotifyWishItemsInCaseThatTheyExists()
        {
            var queryAllUsers = new GetAllUsersQuery();
            var users = _dispatcher.Dispatch(queryAllUsers);
            if (users.Count() == 0)
            {
                return;
            }

            var queryGetAllVacations = new GetAllPublicVacationsQuery();
            var vacations = _dispatcher.Dispatch(queryGetAllVacations);

            foreach (var user in users)
            {
                Guid userIdParsed;
                if (!Guid.TryParse(user.EntityId, out userIdParsed))
                {
                    return;
                }

                GetWishListByUserIdQuery getWishListByQuery = new GetWishListByUserIdQuery(userIdParsed);
                var wishList = _dispatcher.Dispatch(getWishListByQuery);
                foreach (WishItemDto wishItem in wishList)
                {
                    foreach (var vacation in vacations)
                    {
                        Guid vacationIdParsed;
                        if (!Guid.TryParse(vacation.EntityId, out vacationIdParsed))
                        {
                            return;
                        }

                        Guid wishItemIdParsed;
                        if (!Guid.TryParse(wishItem.EntityId, out wishItemIdParsed))
                        {
                            return;
                        }

                        GetLocationsByVacationIdQuery getLocationsByVacationIdQuery = new GetLocationsByVacationIdQuery(vacationIdParsed);
                        var locations = _dispatcher.Dispatch(getLocationsByVacationIdQuery);

                        GetLocationsByVacationIdQuery getLocationsByWishItemIdQuery = new GetLocationsByVacationIdQuery(wishItemIdParsed);
                        var wishItemLocation = _dispatcher.Dispatch(getLocationsByWishItemIdQuery);
                        wishItem.Location = wishItemLocation.First(p=>p.LocationType==LocationType.WishPoint);

                        var descriptionAddress =
                            locations.FirstOrDefault(x => x.LocationType == LocationType.Destination).Address;
                        if (descriptionAddress.Contains(wishItem.Location.Address) ||
                            AreMinumum15KmBetween(locations.FirstOrDefault(x => x.LocationType == LocationType.Destination), wishItem.Location))
                        {
                            PushNotificationCommand pushNotification = new PushNotificationCommand(Guid.NewGuid(),
                                vacationIdParsed,
                                new Guid("01BAED71-9258-42B5-997F-4831FB06EEDB"),
                                userIdParsed,
                                $"We found a vacation that probably interest you.",
                                NotificationType.WishItem);
                            _dispatcher.Dispatch(pushNotification);

                            SendEmailCommand sendEmailCommand = new SendEmailCommand("takeItEasy@gmail.com", user.Email, pushNotification.Text, user.FirstName, user.LastName);
                            _dispatcher.Dispatch(sendEmailCommand);
                        }
                    }
                }

            }
        }


        public bool AreMinumum15KmBetween(LocationDto start, LocationDto end)
        {
            var sCoord = new GeoCoordinate(double.Parse(start.Latitude, System.Globalization.CultureInfo.InvariantCulture), 
                double.Parse(start.Longitude, System.Globalization.CultureInfo.InvariantCulture));
            var eCoord = new GeoCoordinate(double.Parse(end.Latitude, System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(end.Longitude, System.Globalization.CultureInfo.InvariantCulture));

            return sCoord.GetDistanceTo(eCoord)/1000 <= 15;
        }
        
    }
}
