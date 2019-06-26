using BusinessLogicCommon.CqrsCore.Commands;
using CommonTypes;
using System;

namespace BusinessLogicWriter.CqrsCore.Commands.Vacations
{
    public class JoinVacationCommand : ICommand
    {
        public Guid EntityId { get; }
        public Guid VacationId { get; }
        public Guid UserId { get; }
        public StatusJoining StatusJoining { get; }

        public JoinVacationCommand(Guid entityId, Guid vacationId, Guid userId, StatusJoining statusJoining)
        {
            EntityId = entityId;
            VacationId = vacationId;
            UserId = userId;
            StatusJoining = statusJoining;
        }
    }
}
