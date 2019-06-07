using System;
using CommonTypes;

namespace Entities
{
    public class Vacation : BaseEntity
    {
        public Guid? ImageId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AvailableMode AvailableMode { get; set; }
    }
}
