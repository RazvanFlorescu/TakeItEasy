using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.WishList;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.WishList
{
    public class AddWishItemCommandHandler : ICommandHandler<AddWishItemCommand>
    {
        public void Handle(AddWishItemCommand command)
        {
        }
    }
}
