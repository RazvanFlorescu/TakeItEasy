using System;
using System.Collections.Generic;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Vacations
{
    public class GetVacationsByUserIdQuery : IQuery<IList<VacationDto>>
    {
        public Guid UserId { get; private set; }

        public GetVacationsByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
