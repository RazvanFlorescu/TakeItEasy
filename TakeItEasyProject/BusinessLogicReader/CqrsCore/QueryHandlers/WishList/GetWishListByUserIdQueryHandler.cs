using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.WishList;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Entities;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.WishList
{
    public class GetWishListByUserIdQueryHandler : IQueryHandler<GetWishListByUserIdQuery, IList<WishItemDto>>
    {
        private readonly IRepository _repository;

        public GetWishListByUserIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<WishItemDto> Handle(GetWishListByUserIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<WishItem>(WishListQueryBuilder.GetByUserId(query.UserId));
            var wishlist = Mapper.Map<IList<WishItem>, IList<WishItemDto>>(result);

            return wishlist;
        }
    }
}
