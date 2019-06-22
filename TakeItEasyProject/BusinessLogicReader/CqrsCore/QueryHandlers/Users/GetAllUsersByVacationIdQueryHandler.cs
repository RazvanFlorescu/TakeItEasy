using System;
using System.Collections.Generic;
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
    public class GetAllUsersByVacationIdQueryHandler : IQueryHandler<GetAllUsersByVacationIdQuery, IList<UserDto>>
    {
        private readonly IRepository _repository;

        public GetAllUsersByVacationIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<UserDto> Handle(GetAllUsersByVacationIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            IList<User> result = _repository.ExecuteQuery<User>(UserQueryBuilder.GetAllUsersByVacationId(query.VacationId));
            IList<UserDto> users = Mapper.Map<IList<User>, IList<UserDto>>(result);

            return users;
        }
    }
}
