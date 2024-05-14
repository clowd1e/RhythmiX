using System.Windows;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage.Entities;

namespace RhythmiX.WPF.Commands
{
    public class ChangeWindowCommand : CommandBase
    {
        private readonly Window _window;
        private readonly Type _type;
        private readonly UserDto? _userDto;
        private readonly User? _user;

        public ChangeWindowCommand(Window window, Type type, UserDto user)
        {
            _window = window;
            _type = type;
            _userDto = user;
        }
        
        public ChangeWindowCommand(Window window, Type type, User user)
        {
            _window = window;
            _type = type;
            _user = user;
        }

        public ChangeWindowCommand(Window window, Type type)
        {
            _window = window;
            _type = type;
            _userDto = null;
        }

        public override void Execute(object? parameter)
        {
            ChangeWindow();
        }

        private void ChangeWindow()
        {
            if (_user is not null)
                _window.DataContext = Activator.CreateInstance(_type, _user);
            else
            {
                _window.DataContext = _userDto is null ?
                    Activator.CreateInstance(_type)
                    : Activator.CreateInstance(_type, _userDto);
            }

            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = _window;
            _window.Show();
        }
    }
}
