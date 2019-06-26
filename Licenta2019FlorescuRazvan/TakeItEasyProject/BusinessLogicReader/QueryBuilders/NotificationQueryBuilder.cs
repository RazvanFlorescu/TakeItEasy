using System;

namespace BusinessLogicReader.QueryBuilders
{
    public static class NotificationQueryBuilder
    {
        private const string GetAllQuery = "SELECT * FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from Notifications  group by EntityId) m JOIN Notifications u on " +
                                           "m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null";

        public static string GetAll()
        {
            return GetAllQuery;
        }

        public static string GetByReceiverId(Guid id)
        {
            return GetAllQuery + $" and u.ReceiverId = '{id}' order by LastChangedDate desc";
        }
    }
}
