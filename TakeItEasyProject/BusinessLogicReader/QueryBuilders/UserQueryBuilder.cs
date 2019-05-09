using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicReader.QueryBuilders
{
    public static class UserQueryBuilder
    {
        private const string getAllQuery = "SELECT * FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from Users  group by EntityId) m JOIN Users u on "+
                                           "m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null";

        public static string GetAll()
        {
            return getAllQuery;
        }

        public static string GetByEntityId(Guid id)
        {
            return getAllQuery + $" and u.EntityId = '{id}'";
        }

        public static string GetByEmail(string email)
        {
            return getAllQuery + $" and u.Email = '{email}'";
        }

        public static string GetRegisteredUser(string email, string password)
        {
            return getAllQuery + $" and u.Email = '{email}' and u.Password = '{password}'";
        }
    }
}
