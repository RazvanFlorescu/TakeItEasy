using BusinessLogicCommon.CqrsCore.Commands;
using Models;

namespace BusinessLogicWriter.CqrsCore.Commands
{
    public class RemoveAccountCommand : ICommand
    {
        public RemoveAccountCommand(UserDto user)
        {
            User = user;
        }

        public UserDto User { get; }
    }
}
