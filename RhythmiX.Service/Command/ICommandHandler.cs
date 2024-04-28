using Cinema.Service;

namespace RhythmiX.Service.Command
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task<Result> HandleAsync(TCommand command);
    }
}
