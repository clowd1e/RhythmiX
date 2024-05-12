namespace RhythmiX.WPF.Commands
{
    public class CompositeCommand : CommandBase
    {
        private readonly IEnumerable<CommandBase> commands;

        public CompositeCommand(IEnumerable<CommandBase> commands)
        {
            this.commands = commands;
        }

        public override void Execute(object parameter)
        {
            foreach (var command in commands)
            {
                command.Execute(parameter);
            }
        }
    }
}
