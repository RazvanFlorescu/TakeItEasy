using BusinessLogicCommon.CqrsCore.Commands;
using CommonTypes;
using System;

namespace BusinessLogicWriter.CqrsCore.Commands.Vacations
{
    public class UpdateStatusJoinVacationCommand : ICommand
    {
        public Guid EntityId { get; }
        public Guid VacationId { get; }
        public Guid UserId { get; }
        public StatusJoining StatusJoining { get; }

        public UpdateStatusJoinVacationCommand(Guid entityId, Guid vacationId, Guid userId, StatusJoining statusJoining)
        {
            EntityId = entityId;
            VacationId = vacationId;
            UserId = userId;
            StatusJoining = statusJoining;
        }
    }
}
