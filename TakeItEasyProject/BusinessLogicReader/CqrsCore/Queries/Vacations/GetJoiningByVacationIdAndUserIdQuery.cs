using System;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Vacations
{
    public class GetJoiningByVacationIdAndUserIdQuery : IQuery<VacationJoiningDto>
    {
        public Guid VacationId { get; private set; }
        public Guid UserId { get; private set; }

        public GetJoiningByVacationIdAndUserIdQuery(Guid vacationId, Guid userId)
        {
            VacationId = vacationId;
            UserId = userId;
        }
    }
}
