using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicCommon.CqrsCore.Commands;

namespace BusinessLogicWriter.CqrsCore.Commands
{
    public class RemoveAccountCommand : ICommand
    {
        public RemoveAccountCommand(Guid entityId)
        {
            
        } 
    }
}
