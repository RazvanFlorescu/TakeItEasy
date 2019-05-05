using System.Collections.Generic;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.User
{
    public class GetAllUsersQuery : IQuery<IList<UserDto>>
    {
    }
}
