using Hawkeye.Domain.Models;

namespace Hawkeye.Foundation.Services.Abstracts
{
    public interface IAccountService
    {
        Task<RegistrationResult> RegisterAsync(string username, string password, string confirmPassword);

        Task<User> Login(string username, string password);
    }
}
