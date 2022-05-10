using Hawkeye.Domain.Models;
using Hawkeye.Foundation.Services;
using Hawkeye.Foundation.Services.Abstracts;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAccountService _accountService;

        public User CurrentUser { get; private set; }

        public bool isLoggedIn => CurrentUser != null;

        public Authenticator(IAccountService accountService)
        {
            _accountService = accountService;
        }



        public async Task<bool> Login(string username, string password)
        {
            bool success = true;
            try
            {
                CurrentUser = await _accountService.Login(username, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
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
