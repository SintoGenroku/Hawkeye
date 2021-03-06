using Hawkeye.Domain.Models;
using Hawkeye.Foundation.Services;
using System;
using System.Threading.Tasks;

namespace Hawkeye.WPF.State.Authenticators.Abstracts
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }
        bool isLoggedIn { get; }

        Task<RegistrationResult> Register(string username, string password, string confirmPassword);
        Task Login(string username, string password);
        void Logout();
        event Action StateChanged;
    }
}
