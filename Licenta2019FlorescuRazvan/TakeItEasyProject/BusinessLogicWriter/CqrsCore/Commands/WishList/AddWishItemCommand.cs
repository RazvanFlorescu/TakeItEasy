using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Commands;
using Models;

namespace BusinessLogicWriter.CqrsCore.Commands.WishList
{
    public class AddWishItemCommand : ICommand
    {
        public Guid AuthorId { get; }
        public LocationDto Location { get; }

        public AddWishItemCommand(Guid authorId, LocationDto locationDto)
        {
            AuthorId = authorId;
            Location = locationDto;
        }
    }
}
