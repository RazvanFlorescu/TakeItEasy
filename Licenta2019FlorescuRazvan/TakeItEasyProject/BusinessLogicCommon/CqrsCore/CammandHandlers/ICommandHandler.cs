using BusinessLogicCommon.CqrsCore.Commands;

namespace BusinessLogicCommon.CqrsCore.CammandHandlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
