using System.Collections.Generic;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries
{
    public class GetAllUsersQuery : IQuery<IList<UserDto>>
    {
    }
}
