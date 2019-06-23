using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicReader.QueryBuilders
{
    public static class WishListQueryBuilder
    {
        private const string GetAllQuery = "SELECT * FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from WishItems  group by EntityId) m JOIN WishItems u on " +
                                           "m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null";

        public static string GetAll()
        {
            return GetAllQuery;
        }

        public static string GetByEntityId(string id)
        {
            return GetAllQuery + $" and u.EntityId = '{id}'";
        }

        public static string GetByUserId(Guid id)
        {
            return GetAllQuery + $" and u.AuthorId = '{id}'";
        }
    }
}
