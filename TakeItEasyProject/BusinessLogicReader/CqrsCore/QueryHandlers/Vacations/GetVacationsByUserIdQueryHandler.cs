using AutoMapper;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.Vacations;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Entities;
using Models;
using System.Collections.Generic;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.Vacations
{
    public class GetVacationsByUserIdQueryHandler : IQueryHandler<GetVacationsByUserIdQuery, IList<VacationDto>>
    {
        private readonly IRepository _repository;

        public GetVacationsByUserIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<VacationDto> Handle(GetVacationsByUserIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<Vacation>(VacationQueryBuilder.GetByUserId(query.UserId));
            var vacation = Mapper.Map<IList<Vacation>, IList<VacationDto>>(result);

            return vacation;
        }
    }
}
