namespace RhythmiX.Service.Command.User.Login
{
    public class LoginUserCommand : ICommand
    {
        public LoginUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
