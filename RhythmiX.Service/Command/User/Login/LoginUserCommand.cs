namespace RhythmiX.Service.Command.User.Login
{
    public class LoginUserCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
