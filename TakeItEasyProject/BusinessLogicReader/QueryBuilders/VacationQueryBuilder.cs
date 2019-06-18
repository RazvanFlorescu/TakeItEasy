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

        public static string GetTopFiveMostWantedVacations()
        {
            return
                " Select * from (SELECT Top 5 VacationId FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from VacationJoinings  group by EntityId) m JOIN VacationJoinings u on " +
            " m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null group by VacationId order by count(VacationId) desc)vj join Vacations v on vj.VacationId = v.EntityId";
        }

        public static string GetVacationsByUserIdWhereThatUserIsJoinedThere(Guid userId)
        {
            return
                $"Select * From(SELECT VacationId FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from VacationJoinings  group by EntityId) m JOIN VacationJoinings u on " +
                $"m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null and UserId = '{userId}') as v join " +
                "Vacations as vac on v.VacationId = vac.EntityId";
        }
    }
}
