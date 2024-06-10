using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using Entities = RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Queries.LikedTrack
{
    public class GetUserLikedTracksQueryHandler : IQueryHandler<GetUserLikedTracksQuery, IEnumerable<Track>>
    {
        private readonly IMusicRepository _musicRepository;
        private readonly long _userId;
        public GetUserLikedTracksQueryHandler(IMusicRepository musicRepository, Entities.User user)
        {
            _musicRepository = musicRepository;
            _userId = user.Id;
        }

        public GetUserLikedTracksQueryHandler(IMusicRepository musicRepository, long userId)
        {
            _musicRepository = musicRepository;
            _userId = userId;
        }

        public async Task<IEnumerable<Track>> HandleAsync(GetUserLikedTracksQuery query)
        {
            return await _musicRepository.GetUserLikedTracksAsync(_userId);
        }
    }
}
