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
    public class GetLocationsByVacationIdQueryHandler : IQueryHandler<GetLocationsByVacationIdQuery, IList<LocationDto>>
    {
        private readonly IRepository _repository;

        public GetLocationsByVacationIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<LocationDto> Handle(GetLocationsByVacationIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<Location>(LocationQueryBuilder.GetByVacationId(query.VacationId));
            var location = Mapper.Map<IList<Location>, IList<LocationDto>>(result);

            return location;
        }
    }
}
