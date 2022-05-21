using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Microsoft.AspNet.Identity;

namespace Hawkeye.EntityFramework.Services
{
    public static class DataChecker
    {
        public static async void DataInit(IUserRepository userRepository, IRoleRepository roleRepository, IFilmRepository filmRepository)
        {

            var userRole = roleRepository.GetByNameAsync("USER").Result;
            var adminRole = roleRepository.GetByNameAsync("ADMIN").Result;
                
                if (userRole == null)
                {
                    await roleRepository.CreateAsync(
                        new Role()
                        {
                            Id = Guid.NewGuid(),
                            Name = "USER"
                        }
                        );
                }

                if (adminRole == null)
                {
                    await roleRepository.CreateAsync(
                        new Role()
                        {
                            Id = Guid.NewGuid(),
                            Name = "ADMIN"
                        }
                        );
                }
            var admin = userRepository.GetByNameAsync("admin").Result;
            
            if (admin == null)
            {
                IPasswordHasher hasher = new PasswordHasher();
                await userRepository.CreateAsync(
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        PasswordHash = hasher.HashPassword("admin"),
                        Role = roleRepository.GetByNameAsync("ADMIN").Result,
                        RoleId = roleRepository.GetByNameAsync("ADMIN").Result.Id,
                    });
                }

            var films = filmRepository.GetAllAsync().Result;
            if (films.Count == 0)
            {
                 var filmsList = JsonDataStorage.GetFilmsData();
                 foreach (var film in filmsList)
                 {
                     await filmRepository.CreateAsync(film);
                 }

            }
            
            
        }
    }
}
