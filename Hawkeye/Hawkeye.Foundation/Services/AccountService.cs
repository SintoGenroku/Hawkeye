using Hawkeye.Domain.Exceptions;
using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework;
using Hawkeye.EntityFramework.Repositories;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services.Abstracts;
using Microsoft.AspNet.Identity;


namespace Hawkeye.Foundation.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AccountService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _UserRepository = userRepository;
            _passwordHasher = passwordHasher;
        }



        public async Task<User> Login(string username, string password)
        {
            User storedUser = await _UserRepository.GetByNameAsync(username);
            
            if (storedUser == null)
            {
                throw new UserNotFoundException(username);
            }
            
            PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

            if(verificationResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }
            return storedUser;
        }

        public async Task<RegistrationResult> RegisterAsync(string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if(password != confirmPassword)
            {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            User accountUsername = await _UserRepository.GetByNameAsync(username);

            if(accountUsername != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if(result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Name = username,
                    PasswordHash = hashedPassword,
                    Role = new RoleRepository(new HawkeyeDbContextFactory().CreateDbContext()).GetByNameAsync("USER").Result
                };
                await _UserRepository.CreateAsync(user);
            }
            return result;
        }
    }
}
