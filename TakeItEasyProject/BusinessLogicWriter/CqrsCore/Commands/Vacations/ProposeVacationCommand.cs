using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Commands;
using Models;

namespace BusinessLogicWriter.CqrsCore.Commands.Vacations
{
    public class ProposeVacationCommand : ICommand
    {
        public string Image { get; }
        public Guid EntityId { get; }
        public string Title { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LocationDto StartPoint { get; set; }
        public LocationDto Destination { get; set; }

        public ProposeVacationCommand(
            Guid entityId, 
            string title,
            string image,
            DateTime startDate,
            DateTime endDate,
            LocationDto startPoint,
            LocationDto destination
            )
        {
            Image = image;
            StartDate = startDate;
            EndDate = endDate;
            StartPoint = startPoint;
            EntityId = entityId;
            Title = title;
            Destination = destination;
        }
    }
}
