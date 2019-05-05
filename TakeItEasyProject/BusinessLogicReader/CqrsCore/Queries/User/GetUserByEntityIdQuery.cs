using System;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.User
{
    public class GetUserByEntityIdQuery : IQuery<UserDto>
    {
        public Guid EntityId { get; private set; }

        public GetUserByEntityIdQuery(Guid entityId)
        {
            EntityId = entityId;
        }
    }
}
