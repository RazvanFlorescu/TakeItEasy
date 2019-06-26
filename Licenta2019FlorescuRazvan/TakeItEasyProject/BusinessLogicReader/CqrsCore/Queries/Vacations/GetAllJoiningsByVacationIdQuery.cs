using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Vacations
{
    public class GetAllJoiningsByVacationIdQuery : IQuery<IList<VacationJoiningDto>>
    {
        public Guid VacationId { get; private set; }

        public GetAllJoiningsByVacationIdQuery(Guid vacationId)
        {
            VacationId = vacationId;
        }
    }
}
