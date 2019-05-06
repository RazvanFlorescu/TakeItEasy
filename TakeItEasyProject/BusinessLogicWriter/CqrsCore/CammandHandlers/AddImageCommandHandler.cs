using System;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands;
using DataAccessWriter.Abstractions;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers
{
    public class AddImageCommandHandler : ICommandHandler<AddImageCommand>
    {
        private readonly IRepository _repository;

        public AddImageCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(AddImageCommand command)
        {
            var image = new Image
            {
                Id = Guid.NewGuid(),
                EntityId = command.EntityId,
                Content = command.Image,
                LastChangedDate = DateTime.Now
            };

            _repository.Insert(image);
        }
    }
}
