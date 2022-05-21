using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Hawkeye.WPF.Commands
{
    public class AddFilmToFavoriteCommand : ICommand
    {
        private readonly IAuthenticator authenticator;
        private readonly IFilmRepository filmRepository;
        private readonly IUserRepository userRepository;
        private User _currentUser => authenticator.CurrentUser;

        public AddFilmToFavoriteCommand( IAuthenticator authenticator, IFilmRepository filmRepository, IUserRepository userRepository)
        {
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
            if(_currentUser.FavoriteFilms == null)
            {
                _currentUser.FavoriteFilms = new List<Film>();
            }
            if (_currentUser.FavoriteFilms.Contains(likedFilm))
            {
                _currentUser.FavoriteFilms.Remove(likedFilm);
                await userRepository.UpdateAsync(_currentUser);
            }
            else
            {
                _currentUser.FavoriteFilms.Add(likedFilm);
                await userRepository.UpdateAsync(_currentUser);
            }

        }
    }
}
