using System;
using System.Text;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Image;
using BusinessLogicWriter.CqrsCore.Commands.Locations;
using BusinessLogicWriter.CqrsCore.Commands.Vacations;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Vacations
{
    public class ProposeVacationCommandHandler : ICommandHandler<ProposeVacationCommand>
    {
        private readonly IRepository _repository;
        private readonly Dispatcher _dispatcher;

        public ProposeVacationCommandHandler(IRepository repository, Dispatcher dispatcher)
        {
            EnsureArg.IsNotNull(repository);
            EnsureArg.IsNotNull(dispatcher);

            _repository = repository;
            _dispatcher = dispatcher;
        }

        public void Handle(ProposeVacationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var vacation = new Vacation
            {
                AuthorId = command.AuthorId,
                Title = command.Title,
                Description = command.Description,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                EntityId = command.EntityId,
                LastChangedDate = DateTime.Now,
                AvailableMode = command.AvailableMode,
                Id = Guid.NewGuid(),
            };

            foreach (var vacationPoint in command.VacationPoints)
            {
                var addLocationCommand = new AddLocationCommand(Guid.NewGuid(), vacation.EntityId,
                    vacationPoint.Latitude, vacationPoint.Longitude, vacationPoint.LocationType, vacationPoint.Address);

                _dispatcher.Dispatch(addLocationCommand);
            }

            if (!string.IsNullOrEmpty(command.Image))
            {
                var addImageCommand = new AddImageCommand(vacation.EntityId, Encoding.UTF8.GetBytes(command.Image));
                _dispatcher.Dispatch(addImageCommand);
            }

            _repository.Insert(vacation);
            _repository.Save();

        }
    }
}
