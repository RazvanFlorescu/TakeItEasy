using BusinessLogicCommon.CqrsCore.Commands;
using Models;

namespace BusinessLogicWriter.CqrsCore.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public UserDto User { get; }

        public RegisterUserCommand(UserDto user)
        {
            this.User = user;
        }
    }
}
