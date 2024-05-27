namespace RhythmiX.WPF.ViewModels
{
    public class MusicControlViewModel : ViewModelBase
    {
        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
    }
}
