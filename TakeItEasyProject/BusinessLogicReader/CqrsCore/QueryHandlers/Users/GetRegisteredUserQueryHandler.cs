using System.Text;
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
    public class GetRegisteredUserQueryHandler : IQueryHandler<GetRegisteredUserQuery, UserDto>
    {
        private readonly IRepository _repository;

        public GetRegisteredUserQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public UserDto Handle(GetRegisteredUserQuery query)
        {
            EnsureArg.IsNotNull(query);

            User result =
                _repository.ExecuteQueryFirstOrDefault<User>(
                    UserQueryBuilder.GetRegisteredUser(query.Email, query.Password));

            UserDto user = Mapper.Map<User, UserDto>(result);

            Image imageResult = _repository.ExecuteQueryFirstOrDefault<Image>(
                ImageQueryBuilder.GetByEntityId(result.EntityId));

            user.Image = Encoding.UTF8.GetString(imageResult.Content);

            return user;
        }
    }
}
