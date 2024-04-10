using RhythmiX.WPF.Stores;
using RhythmiX.WPF.ViewModels;

namespace RhythmiX.WPF.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore navigateStore;
        private readonly ViewModelBase viewModel;

        public NavigateCommand(NavigationStore navigationStore, ViewModelBase viewModel)
        {
            this.navigateStore = navigationStore;
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            navigateStore.CurrentViewModel = viewModel;
        }
    }
}
