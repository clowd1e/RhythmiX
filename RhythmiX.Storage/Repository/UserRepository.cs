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

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<bool> IsPasswordCorrectAsync(string username, string password)
        {
            return _context.Users.Any(u => u.Username == username && u.Password == password);
        }

        public async Task<bool> IsUserExistsAsync(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginUserAsync(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
