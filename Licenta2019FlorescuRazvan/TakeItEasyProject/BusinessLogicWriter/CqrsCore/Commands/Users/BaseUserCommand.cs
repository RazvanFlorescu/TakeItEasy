using System;
using BusinessLogicCommon.CqrsCore.Commands;

namespace BusinessLogicWriter.CqrsCore.Commands.Users
{
    public class BaseUserCommand : ICommand
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public string Image { get; }
        public Guid EntityId { get; }

        public BaseUserCommand(string firstName, string lastName, string email,
            string password, string image, Guid entityId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Image = image;
            EntityId = entityId;
        }
    }
}
