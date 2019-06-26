using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Users
{
    public class GetAllUsersByVacationIdQuery : IQuery<IList<UserDto>>
    {
        public string VacationId { get; private set; }

        public GetAllUsersByVacationIdQuery(string vacationId)
        {
            VacationId = vacationId;
        }
    }
}
