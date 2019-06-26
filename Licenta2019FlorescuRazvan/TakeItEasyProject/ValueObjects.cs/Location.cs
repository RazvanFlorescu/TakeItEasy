using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObjects
{
    [Owned]
    public class Location
    {
            public string Latitude { get; set; }
            public string Longitude { get; set; }
    }
}
