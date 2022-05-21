using Hawkeye.Domain.Exceptions;
using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services.Abstracts;
using Microsoft.AspNet.Identity;


namespace Hawkeye.Foundation.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AccountService(IUserRepository userRepository, IRoleRepository roleRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }



        public async Task<User> Login(string username, string password)
        {
            User storedUser =  _userRepository.GetByNameWithFaforiteAsync().FirstOrDefault(user => user.Name == username);
            
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

            User accountUsername = await _userRepository.GetByNameAsync(username);

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
                    Role = _roleRepository.GetByNameAsync("USER").Result
                };
                await _userRepository.CreateAsync(user);
            }
            return result;
        }
    }
}
