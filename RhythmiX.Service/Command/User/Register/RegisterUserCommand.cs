namespace RhythmiX.Service.Command.User.Register
{
    public class RegisterUserCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Email { get; set; }
    }
}
