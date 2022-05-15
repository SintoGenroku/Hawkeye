using Hawkeye.Domain.Models;
using Hawkeye.Foundation.Services;
using Hawkeye.Foundation.Services.Abstracts;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using System;
using System.Threading.Tasks;

namespace Hawkeye.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAccountService _accountService;
        private User _currentUser;
        public event Action StateChanged;

        public User CurrentUser 
        {
            get 
            {
                return _currentUser;
            }
            set 
            {
                _currentUser = value;
                StateChanged?.Invoke();
            } 
        }

        public bool isLoggedIn => CurrentUser != null;

        public Authenticator(IAccountService accountService)
        {
            _accountService = accountService;
        }



        public async Task Login(string username, string password)
        {
            CurrentUser = await _accountService.Login(username, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword)
        {
            return await _accountService.RegisterAsync(username, password, confirmPassword);    
        }
    }
}
