namespace RhythmiX.Service.Queries.Dtos
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Email { get; set; }

        public RegisterDto() { }
        public RegisterDto(string username, string password, string repeatPassword, string email)
        {
            Username = username;
            Password = password;
            RepeatPassword = repeatPassword;
            Email = email;
        }
    }
}
