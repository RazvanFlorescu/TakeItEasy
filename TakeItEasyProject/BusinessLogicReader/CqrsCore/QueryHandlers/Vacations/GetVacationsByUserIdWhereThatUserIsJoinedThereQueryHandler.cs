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
    public class GetVacationsByUserIdWhereThatUserIsJoinedThereQueryHandler : IQueryHandler<GetVacationsByUserIdWhereThatUserIsJoinedThereQuery, IList<VacationDto>>
    {
        private readonly IRepository _repository;

        public GetVacationsByUserIdWhereThatUserIsJoinedThereQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public IList<VacationDto> Handle(GetVacationsByUserIdWhereThatUserIsJoinedThereQuery query)
        {
            EnsureArg.IsNotNull(query);

            var result = _repository.ExecuteQuery<Vacation>(VacationQueryBuilder.GetVacationsByUserIdWhereThatUserIsJoinedThere(query.UserId));
            var vacations = Mapper.Map<IList<Vacation>, IList<VacationDto>>(result);

            return vacations;
        }
    }
}
