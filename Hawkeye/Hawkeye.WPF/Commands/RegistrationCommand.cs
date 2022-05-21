using Hawkeye.Foundation.Services;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators.Abstracts;
using Hawkeye.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Hawkeye.WPF.Commands
{
    public class RegistrationCommand : AsyncCommandBase
    {
        private readonly RegistrationViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public RegistrationCommand(RegistrationViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;

            _registerViewModel.PropertyChanged += RegistrationViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult registrationResult = await _authenticator.Register(
                       _registerViewModel.Username,
                       _registerViewModel.Password,
                       _registerViewModel.ConfirmPassword);

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Renavigate();
                        break;
                    case RegistrationResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Пароли не совпадают.";
                        break;

                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        _registerViewModel.ErrorMessage = "Аккаунт с таким именем уже существует.";
                        break;
                    default:
                        _registerViewModel.ErrorMessage = "Ошибка регистрации.";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Ошибка регистрации.";
            }
        }

        private void RegistrationViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegistrationViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
       
    }
}
