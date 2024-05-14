using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage.Repository;
using Entity = RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Queries.User
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, Entity.User>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserDto _user;
        public GetUserQueryHandler(IUserRepository userRepository, UserDto user)
        {
            _userRepository = userRepository;
            _user = user;
        }
        public async Task<Entity.User> HandleAsync(GetUserQuery query)
        {
            return await _userRepository.LoginUserAsync(_user.Username, _user.Password);
        }
    }
}
