using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Commands;

namespace BusinessLogicWriter.CqrsCore.Commands.WishList
{
    public class RemoveWishItemCommand : ICommand
    {
        public Guid EntityId { get; }
        public Guid AuthorId { get; set; }

        public RemoveWishItemCommand(Guid entityId, Guid authorId)
        {
            EntityId = entityId;
            AuthorId = authorId;
        }
    }
}
