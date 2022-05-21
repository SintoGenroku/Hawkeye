using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.State.Navigators.Abstracts;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hawkeye.WPF.Commands
{
    internal class LogoutCommand : AsyncCommandBase
    {

        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ICommand _udpateCurrentViewModelCommand;

        public LogoutCommand(IViewModelFactory viewModelFactory, IAuthenticator authenticator, INavigator navigator)
        {
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _navigator = navigator;
            _udpateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, viewModelFactory);
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _authenticator.Logout();
            _udpateCurrentViewModelCommand.Execute(ViewType.Login);

        }


    }
}
