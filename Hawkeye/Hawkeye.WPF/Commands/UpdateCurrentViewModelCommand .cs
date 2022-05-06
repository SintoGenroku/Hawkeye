using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hawkeye.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.Films:
                        _navigator.CurrentViewModel = new FilmsViewModel(); 
                        break;
                    case ViewType.Playlists:
                        _navigator.CurrentViewModel = new PlaylistsViewModel();
                        break;
                    case ViewType.Actors:
                        _navigator.CurrentViewModel = new ActorsViewModel();
                        break;
                    case ViewType.Profile:
                        _navigator.CurrentViewModel = new ProfileViewModel();
                        break;
                    case ViewType.Favorite:
                        _navigator.CurrentViewModel = new FavoriteViewModel();
                        break;
                    case ViewType.Login:
                        _navigator.CurrentViewModel = new LoginViewModel();
                        break;
                    case ViewType.Registration:
                        _navigator.CurrentViewModel = new RegistrationViewModel();
                        break;
                }
            }
        }
    }
}
