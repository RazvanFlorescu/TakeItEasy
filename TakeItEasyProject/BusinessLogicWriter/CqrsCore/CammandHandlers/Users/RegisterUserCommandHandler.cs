using System;
using System.Text;
using AutoMapper;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Image;
using BusinessLogicWriter.CqrsCore.Commands.Users;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Users
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IRepository _repository;
        private readonly Dispatcher _dispatcher;

        public RegisterUserCommandHandler(IRepository repository, Dispatcher dispatcher)
        {
            EnsureArg.IsNotNull(repository);
            EnsureArg.IsNotNull(dispatcher);

            _repository = repository;
            _dispatcher = dispatcher;
        }

        public void Handle(RegisterUserCommand command)
        {
            EnsureArg.IsNotNull(command);

            User entity = new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
                EntityId = command.EntityId,
                LastChangedDate = DateTime.Now,
                Id = Guid.NewGuid()
            };

            entity.Id = Guid.NewGuid();
            entity.LastChangedDate = DateTime.Now;

            if (!string.IsNullOrEmpty(command.Image))
            {
                var addImageCommand = new AddImageCommand(entity.EntityId, Encoding.UTF8.GetBytes(command.Image));
                _dispatcher.Dispatch(addImageCommand);
            }

            _repository.Insert(entity);
            _repository.Save();
        }
    }
}
