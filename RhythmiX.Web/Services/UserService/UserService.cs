using RhythmiX.Storage.Entities;

namespace RhythmiX.Web.Services.UserService
{
    public class UserService : IUserService
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public void SetUser(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
        }
    }
}
