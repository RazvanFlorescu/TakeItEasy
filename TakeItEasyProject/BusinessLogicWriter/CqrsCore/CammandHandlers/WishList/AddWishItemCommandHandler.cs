using System;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Locations;
using BusinessLogicWriter.CqrsCore.Commands.WishList;
using CommonTypes;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.WishList
{
    public class AddWishItemCommandHandler : ICommandHandler<AddWishItemCommand>
    {
        private readonly IRepository _repository;
        private readonly Dispatcher _dispatcher;

        public AddWishItemCommandHandler(IRepository repository, Dispatcher dispatcher)
        {
            EnsureArg.IsNotNull(repository);
            EnsureArg.IsNotNull(dispatcher);

            _repository = repository;
            _dispatcher = dispatcher;
        }

        public void Handle(AddWishItemCommand command)
        {
            EnsureArg.IsNotNull(command);

            var wishItem = new WishItem
            {
                AuthorId = command.AuthorId,
                EntityId = Guid.NewGuid(),
                LastChangedDate = DateTime.Now,
                Id = Guid.NewGuid()
            };

            var addLocationCommand = new AddLocationCommand(Guid.NewGuid(), wishItem.EntityId, command.Location.Latitude,
                command.Location.Longitude, LocationType.WishPoint, command.Location.Address);

            _dispatcher.Dispatch(addLocationCommand);

            _repository.Insert(wishItem);
            _repository.Save();
        }
    }
}
