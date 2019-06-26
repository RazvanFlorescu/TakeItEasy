using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Vacations;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Vacations
{
    public class UpdateStatusJoinVacationCommandHandler : ICommandHandler<UpdateStatusJoinVacationCommand>
    {
        private readonly IRepository _repository;

        public UpdateStatusJoinVacationCommandHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }
        public void Handle(UpdateStatusJoinVacationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var joinVacation = new VacationJoining
            {
                EntityId = command.EntityId,
                StatusJoining = command.StatusJoining,
                LastChangedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                UserId = command.UserId,
                VacationId = command.VacationId
            };

            _repository.Update(joinVacation);
            _repository.Save();
        }
    }
}
