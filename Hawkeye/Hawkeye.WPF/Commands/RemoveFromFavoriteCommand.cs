using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hawkeye.WPF.Commands
{
    public class RemoveFromFavoriteCommand : ICommand
    {
        private readonly IAuthenticator authenticator;
        private readonly IFilmRepository filmRepository;
        private readonly IUserRepository userRepository;
        private User _currentUser => authenticator.CurrentUser;
        private readonly FavoriteViewModel favoriteViewModel;

        public RemoveFromFavoriteCommand(FavoriteViewModel favoriteViewModel, IAuthenticator authenticator, IFilmRepository filmRepository, IUserRepository userRepository)
        {
            this.favoriteViewModel = favoriteViewModel;
            this.authenticator = authenticator;
            this.filmRepository = filmRepository;
            this.userRepository = userRepository;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {

            var likedFilm = await filmRepository.FindByIdAsync((Guid)parameter);

            _currentUser.FavoriteFilms.Remove(likedFilm);
            favoriteViewModel.Favorite.Remove(likedFilm);
            await userRepository.UpdateAsync(_currentUser);


        }
    }
}
