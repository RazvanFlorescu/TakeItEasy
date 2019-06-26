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
    public class GetPublicVacationsByUserIdQueryHandler : IQueryHandler<GetPublicVacationsByUserIdQuery, IList<VacationDto>>
    {
        private readonly IRepository _repository;

        public GetPublicVacationsByUserIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<VacationDto> Handle(GetPublicVacationsByUserIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<Vacation>(VacationQueryBuilder.GetPublicByUserId(query.UserId));
            var vacation = Mapper.Map<IList<Vacation>, IList<VacationDto>>(result);

            return vacation;
        }
    }
}
