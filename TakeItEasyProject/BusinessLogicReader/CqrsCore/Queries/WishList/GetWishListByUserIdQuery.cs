using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Queries;
using Models;

namespace BusinessLogicReader.CqrsCore.Queries.WishList
{
    public class GetWishListByUserIdQuery : IQuery<IList<WishItemDto>>
    {
        public Guid UserId { get; private set; }

        public GetWishListByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
