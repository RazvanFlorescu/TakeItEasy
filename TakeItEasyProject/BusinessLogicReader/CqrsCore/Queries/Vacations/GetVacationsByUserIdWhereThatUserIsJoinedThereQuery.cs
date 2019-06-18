using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Vacations
{
    public class GetVacationsByUserIdWhereThatUserIsJoinedThereQuery : IQuery<IList<VacationDto>>
    {
        public Guid UserId { get; private set; }

        public GetVacationsByUserIdWhereThatUserIsJoinedThereQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
