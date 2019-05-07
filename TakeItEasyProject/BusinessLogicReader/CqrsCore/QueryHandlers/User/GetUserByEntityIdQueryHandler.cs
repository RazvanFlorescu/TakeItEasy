using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.User;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.User
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

             var result = _repository.ExecuteQueryFirstOrDefault<UserDto>(UserQueryBuilder.GetByEntityId(query.EntityId));

             return result;
        }
    }
}
