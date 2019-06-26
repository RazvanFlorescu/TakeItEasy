using BusinessLogicCommon.CqrsCore.Queries;
using Models;
using System;

namespace BusinessLogicReader.CqrsCore.Queries.Images
{
    public class GetImageByEntityIdQuery : IQuery<ImageDto>
    {
        public Guid EntityId { get; private set; }

        public GetImageByEntityIdQuery(Guid entityId)
        {
            EntityId = entityId;
        }
    }
}
