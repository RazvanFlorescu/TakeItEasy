using System.Collections.Generic;
using System.Linq;
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
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IList<UserDto>>
    {
        private readonly IRepository _repository;

        public GetAllUsersQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<UserDto> Handle(GetAllUsersQuery query)
        {
            EnsureArg.IsNotNull(query);

            IList<User> result = _repository.ExecuteQuery<User>(UserQueryBuilder.GetAll());
            IList<UserDto> users = Mapper.Map<IList<User>, IList<UserDto>>(result);

            return users;
        }
    }
}
