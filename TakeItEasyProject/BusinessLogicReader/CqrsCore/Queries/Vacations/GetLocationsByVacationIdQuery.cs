using System;
using System.Collections.Generic;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Vacations
{
    public class GetLocationsByVacationIdQuery : IQuery<IList<LocationDto>>
    {
        public Guid VacationId { get; private set; }

        public GetLocationsByVacationIdQuery(Guid vacationId)
        {
            VacationId = vacationId;
        }
    }
}
