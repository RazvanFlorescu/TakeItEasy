using System.Collections.Generic;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers
{
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IList<UserDto>>
    {
        private readonly IRepository _repository;

        public GetAllUsersQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public IList<UserDto> Handle(GetAllUsersQuery query)
        {
            var result = _repository.ExecuteQuery<UserDto>(UserQueryBuilder.GetAll());

            return result;
        }
    }
}
