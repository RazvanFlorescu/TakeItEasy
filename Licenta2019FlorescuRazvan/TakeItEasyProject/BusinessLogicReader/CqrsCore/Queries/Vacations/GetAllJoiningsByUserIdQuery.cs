using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Vacations
{
    public class GetAllJoiningsByUserIdQuery : IQuery<IList<VacationJoiningDto>>
    {
        public Guid UserId { get; private set; }

        public GetAllJoiningsByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
