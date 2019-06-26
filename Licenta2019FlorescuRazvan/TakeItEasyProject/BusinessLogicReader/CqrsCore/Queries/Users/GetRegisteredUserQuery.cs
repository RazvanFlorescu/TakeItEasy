using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.Users
{
    public class GetRegisteredUserQuery : IQuery<UserDto>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public GetRegisteredUserQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
