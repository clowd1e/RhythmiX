using RhythmiX.Storage.Entities;

namespace RhythmiX.Web.Services.UserService
{
    public interface IUserService
    {
        long Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        void SetUser(User user);
    }
}
