using RhythmiX.Storage.Entities;

namespace RhythmiX.Storage.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MusicDbContext _context;
        public UserRepository(MusicDbContext context)
        {
            _context = context;
        }

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsPasswordCorrectAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExistsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUsernameTakenAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task LoginUserAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
