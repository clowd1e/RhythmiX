
namespace RhythmiX.WPF.Commands
{
    public class AsyncRelayCommand : AsyncCommandBase
    {
        private readonly Func<object, Task> _executeAsync;

        public AsyncRelayCommand(Func<object, Task> executeAsync)
        {
            _executeAsync = executeAsync;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            await _executeAsync(parameter);
        }
    }
}
