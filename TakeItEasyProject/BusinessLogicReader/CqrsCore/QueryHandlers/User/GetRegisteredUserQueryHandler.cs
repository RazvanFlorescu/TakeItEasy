using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.User;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.User
{
    public class GetRegisteredUserQueryHandler : IQueryHandler<GetRegisteredUserQuery, UserDto>
    {
        private readonly IRepository _repository;

        public GetRegisteredUserQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public UserDto Handle(GetRegisteredUserQuery query)
        {
            var result =
                _repository.ExecuteQueryFirstOrDefault<UserDto>(
                    UserQueryBuilder.GetRegisteredUser(query.Email, query.Password));

            return result;
        }
    }
}
