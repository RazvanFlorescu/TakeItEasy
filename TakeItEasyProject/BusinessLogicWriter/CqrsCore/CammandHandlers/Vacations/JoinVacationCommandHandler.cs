﻿using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Vacations;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Vacations
{
    public class JoinVacationCommandHandler : ICommandHandler<JoinVacationCommand>
    {
        private readonly IRepository _repository;

        public JoinVacationCommandHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public void Handle(JoinVacationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var vacationJoinings = new VacationJoining
            {
                EntityId = command.EntityId,
                UserId = command.UserId,
                VacationId = command.VacationId,
                StatusJoining = command.StatusJoining
            };

            _repository.Insert(vacationJoinings);
            _repository.Save();

        }
    }
}
