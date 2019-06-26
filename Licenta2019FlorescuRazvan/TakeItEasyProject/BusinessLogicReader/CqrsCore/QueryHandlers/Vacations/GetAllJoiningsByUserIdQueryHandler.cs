using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.Vacations;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Entities;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.Vacations
{
    public class GetAllJoiningsByUserIdQueryHandler : IQueryHandler<GetAllJoiningsByUserIdQuery, IList<VacationJoiningDto>>
    {
        private readonly IRepository _repository;

        public GetAllJoiningsByUserIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<VacationJoiningDto> Handle(GetAllJoiningsByUserIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<VacationJoining>(VacationJoiningsQueryBuilder.GetByUserId(query.UserId));
            var vacationJoining = Mapper.Map<IList<VacationJoining>, IList<VacationJoiningDto>>(result);

            return vacationJoining;
        }
    }
}
