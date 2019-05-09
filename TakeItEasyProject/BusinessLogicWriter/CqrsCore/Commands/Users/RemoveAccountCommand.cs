using System;

namespace BusinessLogicWriter.CqrsCore.Commands.Users
{
    public class RemoveAccountCommand : BaseUserCommand
    {
        public RemoveAccountCommand(string firstName, string lastName, string email,
            string password, string image, Guid entityId) : base(firstName, lastName, email, password, image, entityId)
        {
        }
    }
}
