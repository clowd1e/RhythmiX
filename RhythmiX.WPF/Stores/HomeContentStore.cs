using RhythmiX.Storage.Models.Interfaces;

namespace RhythmiX.WPF.Stores
{
    public class HomeContentStore
    {
        private List<IHomeObservable> content;
        public List<IHomeObservable> Content
        {
            get => content;
            set
            {
                content = value;
                OnContentChanged();
            }
        }

        public event Action ContentChanged;

        private void OnContentChanged()
        {
            ContentChanged?.Invoke();
        }
    }
}
