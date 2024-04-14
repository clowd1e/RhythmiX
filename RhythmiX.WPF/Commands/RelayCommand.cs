namespace RhythmiX.WPF.Commands
{
    public class RelayCommand : CommandBase
    {
        private readonly Action<object> execute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public override void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
