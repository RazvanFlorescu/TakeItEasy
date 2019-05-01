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
        private IRepository _repository;

        public RegisterUserCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(RegisterUserCommand command)
        {
            EnsureArg.IsNotNull(command);
            User entity = Mapper.Map<UserDto, User>(command.User);
            entity.Id = Guid.NewGuid();
            entity.EntityId = Guid.NewGuid();
            entity.LastChangedDate = DateTime.Now;

            _repository.Insert(entity);
            _repository.Save();
        }
    }
}
