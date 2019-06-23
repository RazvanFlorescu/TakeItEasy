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
    public class GetAllPublicVacationsQueryHandler : IQueryHandler<GetAllPublicVacationsQuery, IList<VacationDto>>
    {
        private readonly IRepository _repository;

        public GetAllPublicVacationsQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<VacationDto> Handle(GetAllPublicVacationsQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<Vacation>(VacationQueryBuilder.GetAllPublic());
            var vacation = Mapper.Map<IList<Vacation>, IList<VacationDto>>(result);

            return vacation;
        }
    }
}
