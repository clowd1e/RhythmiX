using RhythmiX.Storage.Entities;

namespace RhythmiX.Storage.Repository
{
    public class UserRepository : IUserRepository
    {
        private const int BCRYPT_WORK_FACTOR = 13;

        private readonly MusicDbContext _context;

        public UserRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password, BCRYPT_WORK_FACTOR);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public async Task<bool> IsPasswordCorrectAsync(string username, string password)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password,
                _context.Users.Single(u => u.Username == username).Password);
        }

        public async Task<bool> IsUserExistsAsync(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public async Task<User> LoginUserAsync(string username, string password)
        {
            User user = _context.Users.SingleOrDefault(u => u.Username == username);
            if (BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
                return user;

            return null;
        }
    }
}
