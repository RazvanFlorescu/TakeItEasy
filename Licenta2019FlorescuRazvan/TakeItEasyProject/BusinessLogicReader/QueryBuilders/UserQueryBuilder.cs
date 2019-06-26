using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicReader.QueryBuilders
{
    public static class UserQueryBuilder
    {
        private const string GetAllQuery = "SELECT * FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from Users  group by EntityId) m JOIN Users u on "+
                                           "m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null";

        public static string GetAll()
        {
            return GetAllQuery;
        }

        public static string GetByEntityId(Guid id)
        {
            return GetAllQuery + $" and u.EntityId = '{id}'";
        }

        public static string GetByEmail(string email)
        {
            return GetAllQuery + $" and u.Email = '{email}'";
        }

        public static string GetRegisteredUser(string email, string password)
        {
            return GetAllQuery + $" and u.Email = '{email}' and u.Password = '{password}'";
        }

        public static string GetAllUsersByVacationId(string vacationId)
        {
            return
                $"select*from (select UserId from VacationJoinings where VacationId = '{vacationId}' and StatusJoining = 1)v join Users u on v.UserId = u.EntityId";
        }
    }
}
