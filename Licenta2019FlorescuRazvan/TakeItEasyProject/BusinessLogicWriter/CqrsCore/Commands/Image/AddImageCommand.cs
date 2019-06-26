using System;
using BusinessLogicCommon.CqrsCore.Commands;

namespace BusinessLogicWriter.CqrsCore.Commands.Image
{
    public class AddImageCommand : ICommand
    {
        public Guid EntityId { get; }
        public byte[] Image { get; }

        public AddImageCommand(Guid entityId, byte[] image)
        {
            EntityId = entityId;
            Image = image;
        }
    }
}
