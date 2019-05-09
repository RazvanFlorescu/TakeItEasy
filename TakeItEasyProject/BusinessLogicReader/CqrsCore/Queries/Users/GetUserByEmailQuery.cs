using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Users
{
    public class GetUserByEmailQuery : IQuery<UserDto>
    {
        public string Email { set; get; }
    }
}
