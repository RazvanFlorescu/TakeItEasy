using CommonTypes;
using System;

namespace Entities
{
    public class VacationJoining : BaseEntity
    {
        public Guid VacationId { get; set; }
        public Guid UserId { get; set; }
        public StatusJoining  StatusJoining { get; set; }
    }
}
