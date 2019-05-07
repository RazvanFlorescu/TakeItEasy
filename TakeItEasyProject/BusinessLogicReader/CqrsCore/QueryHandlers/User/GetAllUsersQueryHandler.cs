using System.Collections.Generic;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.User;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.User
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

            var result = _repository.ExecuteQuery<UserDto>(UserQueryBuilder.GetAll());

            return result;
        }
    }
}
