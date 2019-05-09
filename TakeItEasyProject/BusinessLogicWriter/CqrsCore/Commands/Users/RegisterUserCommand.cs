using System;

namespace BusinessLogicWriter.CqrsCore.Commands.Users
{
    public class RegisterUserCommand : BaseUserCommand
    {

        public RegisterUserCommand(string firstName, string lastName, string email, 
            string password, string image, Guid entityId): base(firstName, lastName, email, password, image, entityId)
        {
        }
    }
}
