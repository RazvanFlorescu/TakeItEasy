using System;


namespace BusinessLogicReader.QueryBuilders
{
    public static class VacationQueryBuilder
    {
        private const string GetAllQuery = "SELECT * FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from Vacations  group by EntityId) m JOIN Vacations u on " +
                                           "m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null";

        public static string GetAll()
        {
            return GetAllQuery;
        }

        public static string GetByEntityId(Guid id)
        {
            return GetAllQuery + $" and u.EntityId = '{id}'";
        }

        public static string GetByUserId(Guid id)
        {
            return GetAllQuery + $" and u.AuthorId = '{id}'";
        }
    }
}
