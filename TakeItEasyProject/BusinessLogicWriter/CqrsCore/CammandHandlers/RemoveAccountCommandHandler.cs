using System;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands;
using DataAccessWriter.Abstractions;
using EnsureThat;
using Entities;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers
{
    public class RemoveAccountCommandHandler : ICommandHandler<RemoveAccountCommand>
    {
        private readonly IRepository _repository;

        public RemoveAccountCommandHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public void Handle(RemoveAccountCommand command)
        {
            EnsureArg.IsNotNull(command);

            User user = _repository.GetByFilter<User>(opt => opt.EntityId == command.User.EntityId);

            user.DeletedDate = DateTime.Now;
            user.LastChangedDate = DateTime.Now;

            _repository.Update(user);
            _repository.Save();
        }
    }
}
