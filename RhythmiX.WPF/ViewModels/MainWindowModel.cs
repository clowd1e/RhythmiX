using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Stores;
using RhythmiX.WPF.ViewModels.MenuViewModels;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels
{
    public class MainWindowModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;


        public ICommand ChangeToHome { get; private set; }
        public ICommand ChangeToExplore { get; private set; }
        public ICommand ChangeToLiked { get; private set; }
        public ICommand ChangeToHistory { get; private set; }
        public ICommand ChangeToPlaylists { get; private set; }
        public ICommand ChangeToAccount { get; private set; }


        public MainWindowModel()
        {
            navigationStore = new NavigationStore();

            InitializeMenuButtons();
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void InitializeMenuButtons()
        {
            ChangeToHome = new NavigateCommand(navigationStore, new HomeViewModel());
            ChangeToExplore = new NavigateCommand(navigationStore, new HomeViewModel());
            ChangeToLiked = new NavigateCommand(navigationStore, new HomeViewModel());
            ChangeToHistory = new NavigateCommand(navigationStore, new HomeViewModel());
            ChangeToPlaylists = new NavigateCommand(navigationStore, new HomeViewModel());
            ChangeToAccount = new NavigateCommand(navigationStore, new HomeViewModel());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
