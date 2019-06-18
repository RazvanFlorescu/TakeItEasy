using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicReader.QueryBuilders
{
    public static class VacationJoiningsQueryBuilder
    {
        private const string GetAllQuery = "SELECT * FROM ( SELECT EntityId, MAX(LastChangedDate) AS HIGHERDATE from VacationJoinings  group by EntityId) m JOIN VacationJoinings u on " +
                                           "m.HIGHERDATE = u.LastChangedDate and m.EntityId = u.EntityId where u.DeletedDate is null";

        public static string GetAll()
        {
            return GetAllQuery;
        }

        public static string GetByVacationId(Guid id)
        {
            return GetAllQuery + $" and u.VacationId = '{id}'";
        }

        public static string GetByUserId(Guid id)
        {
            return GetAllQuery + $" and u.UserId = '{id}'";
        }

        public static string GetByVacationIdAndUserId(Guid vacationId, Guid userId)
        {
            return GetAllQuery + $" and u.VacationId = '{vacationId}' and u.UserId = '{userId}'";
        }
    }
}
