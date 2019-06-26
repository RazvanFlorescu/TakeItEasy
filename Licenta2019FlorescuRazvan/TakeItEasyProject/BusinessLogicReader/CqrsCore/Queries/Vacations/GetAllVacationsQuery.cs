using System.Collections.Generic;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Vacations
{
    public class GetAllVacationsQuery : IQuery<IList<VacationDto>>
    {
    }
}
