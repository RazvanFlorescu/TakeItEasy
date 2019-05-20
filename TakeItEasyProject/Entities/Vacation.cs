using System;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class Vacation : BaseEntity
    {
        public Guid? ImageId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location StartPoint { get; set; }
        public Location Destination { get; set; }
    }

    [Owned]
    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
