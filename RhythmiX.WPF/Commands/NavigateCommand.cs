using RhythmiX.WPF.Stores;
using RhythmiX.WPF.ViewModels;

namespace RhythmiX.WPF.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigateStore;
        private readonly ViewModelBase _viewModel;
        private readonly MainWindowModel _mainWindowModel;

        public NavigateCommand(NavigationStore navigationStore, ViewModelBase viewModel, MainWindowModel mainWindowModel)
        {
            _navigateStore = navigationStore;
            _viewModel = viewModel;
            _mainWindowModel = mainWindowModel;
        }

        public override void Execute(object? parameter)
        {
            if (_viewModel is MusicControlViewModel)
                _mainWindowModel.IsPlayerBarShown = true;
            else
                _mainWindowModel.IsPlayerBarShown = false;

            _navigateStore.CurrentViewModel = _viewModel;
        }
    }
}
