using AutoMapper;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.Users;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Entities;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.Users
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

            var result = _repository.ExecuteQueryFirstOrDefault<User>(UserQueryBuilder.GetByEmail(query.Email));
            UserDto user = Mapper.Map<User, UserDto>(result);

            return user;
        }
    }
}
