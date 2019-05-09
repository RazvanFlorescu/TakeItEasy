﻿using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.User;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.User
{
    public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly IRepository _repository;

        public GetUserByEmailQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public UserDto Handle(GetUserByEmailQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQueryFirstOrDefault<UserDto>(UserQueryBuilder.GetByEmail(query.Email));

            return result;
        }
    }
}
