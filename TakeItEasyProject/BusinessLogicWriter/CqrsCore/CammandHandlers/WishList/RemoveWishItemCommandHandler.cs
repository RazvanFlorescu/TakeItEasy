using System;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.WishList;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.WishList
{
    public class RemoveWishItemCommandHandler : ICommandHandler<RemoveWishItemCommand>
    {
        private readonly IRepository _repository;

        public RemoveWishItemCommandHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public void Handle(RemoveWishItemCommand command)
        {
            EnsureArg.IsNotNull(command);
            var wishItem = new WishItem
            {
                AuthorId = command.AuthorId,
                EntityId = command.EntityId,
                LastChangedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                DeletedDate = DateTime.Now
            };

            _repository.Insert(wishItem);
            _repository.Save();
        }
    }

}
