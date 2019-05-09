using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.User
{
    public class GetUserByEmailQuery : IQuery<UserDto>
    {
        public string Email { set; get; }
    }
}
