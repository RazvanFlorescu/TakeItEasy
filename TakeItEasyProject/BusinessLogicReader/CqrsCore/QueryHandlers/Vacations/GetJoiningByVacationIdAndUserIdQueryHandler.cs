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
    public class GetJoiningByVacationIdAndUserIdQueryHandler : IQueryHandler<GetJoiningByVacationIdAndUserIdQuery, VacationJoiningDto>
    {
        private readonly IRepository _repository;

        public GetJoiningByVacationIdAndUserIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public VacationJoiningDto Handle(GetJoiningByVacationIdAndUserIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQueryFirstOrDefault<VacationJoining>(VacationJoiningsQueryBuilder.GetByVacationIdAndUserId(query.VacationId, query.UserId));
            var vacationJoining = Mapper.Map<VacationJoining, VacationJoiningDto>(result);

            return vacationJoining;
        }
    }
}
