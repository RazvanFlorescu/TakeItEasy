using System;

namespace Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public DateTime LastChangedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
