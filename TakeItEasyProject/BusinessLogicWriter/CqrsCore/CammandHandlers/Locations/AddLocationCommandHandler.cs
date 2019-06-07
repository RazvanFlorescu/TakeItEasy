using System;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Locations;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Locations
{
    public class AddLocationCommandHandler : ICommandHandler<AddLocationCommand>
    {
        private readonly IRepository _repository;
        private readonly Dispatcher _dispatcher;

        public AddLocationCommandHandler(IRepository repository, Dispatcher dispatcher)
        {
            EnsureArg.IsNotNull(repository);
            EnsureArg.IsNotNull(dispatcher);

            _repository = repository;
            _dispatcher = dispatcher;
        }

        public void Handle(AddLocationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var location = new Location
            {
               Id = Guid.NewGuid(),
               EntityId = command.EntityId,
               LocationType = command.LocationType,
               Longitude = command.Longitude,
               Latitude = command.Latitude,
               LastChangedDate = DateTime.Now,
               VacationId = command.VacationId,
               Address = command.Address
               
            };

            _repository.Insert(location);
            _repository.Save();
        }
    }
}
