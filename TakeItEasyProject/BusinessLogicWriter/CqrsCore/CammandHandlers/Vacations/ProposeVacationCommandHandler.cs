using System;
using System.Text;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Image;
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
                Title = command.Title,
                StartPoint = new Location
                {
                    Latitude = command.StartPoint.Latitude,
                    Longitude = command.StartPoint.Longitude
                },
                Destination = new Location
                {
                    Latitude = command.Destination.Latitude,
                    Longitude = command.Destination.Longitude
                },
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                EntityId = command.EntityId,
                LastChangedDate = DateTime.Now,
                Id = Guid.NewGuid(),
            };

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
