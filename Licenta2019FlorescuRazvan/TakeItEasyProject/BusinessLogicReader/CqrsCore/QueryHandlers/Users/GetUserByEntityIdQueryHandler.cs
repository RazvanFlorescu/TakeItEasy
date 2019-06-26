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
    public class GetUserByEntityIdQueryHandler : IQueryHandler<GetUserByEntityIdQuery, UserDto>
    {
        private readonly IRepository _repository;

        public GetUserByEntityIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public UserDto Handle(GetUserByEntityIdQuery query)
        {
            EnsureArg.IsNotNull(query);

             var result = _repository.ExecuteQueryFirstOrDefault<User>(UserQueryBuilder.GetByEntityId(query.EntityId));
             var user = Mapper.Map<User, UserDto>(result);

             return user;
        }
    }
}
