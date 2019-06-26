using System;
using BusinessLogicCommon.CqrsCore.Commands;
using CommonTypes;

namespace BusinessLogicWriter.CqrsCore.Commands.Locations
{
    public class AddLocationCommand : ICommand
    {
        public Guid EntityId { get; }
        public Guid VacationId { get; }
        public string Latitude { get; }
        public string Longitude { get; }
        public LocationType? LocationType { get; }
        public string Address { get; }

        public AddLocationCommand(
            Guid entityId, 
            Guid vacationId, 
            string latitude, 
            string longitude, 
            LocationType? locationType,
            string address
         )
        {
            EntityId = entityId;
            VacationId = vacationId;
            Latitude = latitude;
            Longitude = longitude;
            LocationType = locationType;
            Address = address;
        }
    }
}
