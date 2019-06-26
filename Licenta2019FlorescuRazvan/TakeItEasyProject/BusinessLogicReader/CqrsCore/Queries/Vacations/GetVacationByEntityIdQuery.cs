using BusinessLogicCommon.CqrsCore.Queries;
using Models;
using System;

namespace BusinessLogicReader.CqrsCore.Queries.Vacations
{
    public class GetVacationByEntityIdQuery : IQuery<VacationDto>
    {
        public Guid EntityId { get; private set; }

        public GetVacationByEntityIdQuery(Guid entityId)
        {
            EntityId = entityId;
        }
    }
}
