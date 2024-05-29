using RhythmiX.Storage.Entities;
using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Stores;
using RhythmiX.WPF.ViewModels.MenuViewModels;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels
{
    public class MainWindowModel : ViewModelBase
    {
        private readonly User _user;
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;


        private bool isPlayerBarShown;
        public bool IsPlayerBarShown
        {
            get => isPlayerBarShown;
            set
            {
                isPlayerBarShown = value;
                OnPropertyChanged(nameof(IsPlayerBarShown));
            }
        }

        public ICommand ChangeToHome { get; private set; }
        public ICommand ChangeToExplore { get; private set; }
        public ICommand ChangeToLiked { get; private set; }
        public ICommand ChangeToHistory { get; private set; }
        public ICommand ChangeToPlaylists { get; private set; }
        public ICommand ChangeToAccount { get; private set; }


        public MainWindowModel()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModel = new HomeViewModel();

            InitializeMenuButtons();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        public MainWindowModel(User user)
        {
            _user = user;

            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModel = new HomeViewModel();

            InitializeMenuButtons();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void InitializeMenuButtons()
        {
            ChangeToHome = new NavigateCommand(_navigationStore, new HomeViewModel());
            ChangeToExplore = new NavigateCommand(_navigationStore, new ExploreViewModel());
            ChangeToLiked = new NavigateCommand(_navigationStore, new LikedViewModel(_user));
            ChangeToHistory = new NavigateCommand(_navigationStore, new HistoryViewModel(_user, this, _navigationStore));
            ChangeToPlaylists = new NavigateCommand(_navigationStore, new PlaylistsViewModel());
            ChangeToAccount = new NavigateCommand(_navigationStore, new AccountViewModel());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
