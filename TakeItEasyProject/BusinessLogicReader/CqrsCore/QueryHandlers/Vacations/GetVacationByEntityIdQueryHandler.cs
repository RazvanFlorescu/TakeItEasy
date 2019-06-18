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
    public class GetVacationByEntityIdQueryHandler : IQueryHandler<GetVacationByEntityIdQuery, VacationDto>
    {
        private readonly IRepository _repository;

        public GetVacationByEntityIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public VacationDto Handle(GetVacationByEntityIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQueryFirstOrDefault<Vacation>(VacationQueryBuilder.GetByEntityId(query.EntityId));
            var user = Mapper.Map<Vacation, VacationDto>(result);

            return user;
        }
    }
}
