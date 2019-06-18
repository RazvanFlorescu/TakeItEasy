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
    public class GetAllVacationsQueryHandler : IQueryHandler<GetAllVacationsQuery, IList<VacationDto>>
    {
        private readonly IRepository _repository;

        public GetAllVacationsQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<VacationDto> Handle(GetAllVacationsQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<Vacation>(VacationQueryBuilder.GetAll());
            var vacation = Mapper.Map<IList<Vacation>, IList<VacationDto>>(result);

            return vacation;
        }
    }
}
