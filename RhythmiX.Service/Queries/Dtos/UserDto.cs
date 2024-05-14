namespace RhythmiX.Service.Queries.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserDto() { }
        public UserDto(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
