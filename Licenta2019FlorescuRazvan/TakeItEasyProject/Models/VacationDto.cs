using CommonTypes;
using System;
using System.Collections.Generic;

namespace Models
{
    public class VacationDto : BaseDto
    {
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public IList<LocationDto> VacationPoints { get; set; }
        public AvailableMode AvailableMode { get; set; }
        public DateTime LastChangedDate { get; set; }
    }

    public class LocationDto
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public LocationType? LocationType { get; set; }
        public string Address { get; set; }
    }
}
