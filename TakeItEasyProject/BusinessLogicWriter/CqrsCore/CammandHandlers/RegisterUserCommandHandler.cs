using System;
using AutoMapper;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;
using Models;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IRepository _repository;
        private readonly Dispatcher _dispatcher;

        public RegisterUserCommandHandler(IRepository repository, Dispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }

        public void Handle(RegisterUserCommand command)
        {
            EnsureArg.IsNotNull(command);
            User entity = Mapper.Map<UserDto, User>(command.User);
            entity.Id = Guid.NewGuid();
            entity.EntityId = Guid.NewGuid();
            entity.LastChangedDate = DateTime.Now;

            if (!string.IsNullOrEmpty(command.User.Image))
            {
                var addImageCommand = new AddImageCommand(command.User.EntityId, Convert.FromBase64String(command.User.Image));
                _dispatcher.Dispatch(addImageCommand);
            }

            _repository.Insert(entity);
            _repository.Save();
        }
    }
}
