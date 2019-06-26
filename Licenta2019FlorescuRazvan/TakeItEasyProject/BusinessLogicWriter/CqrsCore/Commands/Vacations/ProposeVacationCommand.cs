using System;
using System.Collections.Generic;
using BusinessLogicCommon.CqrsCore.Commands;
using CommonTypes;
using Models;

namespace BusinessLogicWriter.CqrsCore.Commands.Vacations
{
    public class ProposeVacationCommand : ICommand
    {
        public string Image { get; }
        public Guid EntityId { get; }
        public Guid AuthorId { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public IList<LocationDto> VacationPoints { get; }
        public AvailableMode AvailableMode { get; }

        public ProposeVacationCommand(
            Guid entityId, 
            Guid authorId,
            string title,
            string description,
            string image,
            DateTime startDate,
            DateTime endDate,
            IList<LocationDto> vacationPoints,
            AvailableMode availableMode
            )
        {
            Image = image;
            StartDate = startDate;
            EndDate = endDate;
            VacationPoints = vacationPoints;
            AvailableMode = availableMode;
            EntityId = entityId;
            AuthorId = authorId;
            Title = title;
            Description = description;
        }
    }
}
