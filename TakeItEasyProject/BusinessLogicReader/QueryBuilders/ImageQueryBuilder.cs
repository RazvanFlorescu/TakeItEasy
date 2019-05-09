using System;

namespace BusinessLogicReader.QueryBuilders
{
    public static class ImageQueryBuilder
    {
        private const string getAllQuery = "SELECT * FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from Images  group by EntityId) m JOIN Images u on " +
                                           "m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null";

        public static string GetAll()
        {
            return getAllQuery;
        }

        public static string GetByEntityId(Guid id)
        {
            return getAllQuery + $" and u.EntityId = '{id}'";
        }
    }
}
