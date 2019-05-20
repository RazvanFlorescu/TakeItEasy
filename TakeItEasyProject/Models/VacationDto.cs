using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class VacationDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LocationDto StartPoint { get; set; }
        public LocationDto Destination { get; set; }
        public string Image { get; set; }
    }

    public class LocationDto
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
