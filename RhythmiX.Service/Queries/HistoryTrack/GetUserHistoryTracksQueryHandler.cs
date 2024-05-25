using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using Entity = RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Queries.HistoryTrack
{
    public class GetUserHistoryTracksQueryHandler : IQueryHandler<GetUserHistoryTracksQuery, IEnumerable<Track>>
    {
        private readonly IMusicRepository _repository;
        private readonly Entity.User _user;

        public GetUserHistoryTracksQueryHandler(IMusicRepository repository, Entity.User user)
        {
            _repository = repository;
            _user = user;
        }

        public async Task<IEnumerable<Track>> HandleAsync(GetUserHistoryTracksQuery query)
        {
            return await _repository.GetUserHistoryTracksAsync(_user.Id);
        }
    }
}
