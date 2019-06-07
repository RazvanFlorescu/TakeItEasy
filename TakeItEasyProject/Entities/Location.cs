using CommonTypes;
using System;

namespace Entities
{
    public class Location: BaseEntity
    {
        public Guid VacationId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public LocationType? LocationType { get; set; } 
        public string Address { get; set; }
    }
}
