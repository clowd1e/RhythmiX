using RhythmiX.Service.API.Models.Interfaces;

namespace RhythmiX.WPF.Stores
{
    public class MusicGroupStore<THomeObservable>
        where THomeObservable : IHomeObservable
    {
        public string Title { get; set; }
        public IEnumerable<THomeObservable> Items { get; set; }
        public MusicGroupStore(string title, IEnumerable<THomeObservable> items)
        {
            Title = title;
            Items = items;
        }
    }
}
