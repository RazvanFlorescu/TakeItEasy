using System;

namespace BusinessLogicReader.QueryBuilders
{
    public static class LocationQueryBuilder
    {
        private const string GetAllQuery = "SELECT * FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from Locations  group by EntityId) m JOIN Locations u on " +
                                           "m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null";

        public static string GetAll()
        {
            return GetAllQuery;
        }

        public static string GetByEntityId(Guid id)
        {
            return GetAllQuery + $" and u.EntityId = '{id}'";
        }

        public static string GetByVacationId(Guid id)
        {
            return GetAllQuery + $" and u.VacationId = '{id}'";
        }
    }
}
