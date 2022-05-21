using Hawkeye.Domain.Models;
using Hawkeye.WPF.Commands;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hawkeye.WPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly IAuthenticator authenticator;
        
        public User LoggedUser => authenticator.CurrentUser;
        public int FavoriteFilmsCount { get; set; }
        public int PlaylistsCount { get; set; }
        public int CommentsCount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICommand LogoutCommand { get; set; }
        
        
        public ProfileViewModel(IAuthenticator authenticator, INavigator _navigator, IViewModelFactory _viewModelFactory)
        {
            LogoutCommand = new LogoutCommand(_viewModelFactory, authenticator, _navigator);

            this.authenticator = authenticator;
            if(LoggedUser.FavoriteFilms == null)
            {
                LoggedUser.FavoriteFilms = new ObservableCollection<Film>();
            }
            if (LoggedUser.Playlists == null)
            {
                LoggedUser.Playlists = new ObservableCollection<Playlist>();
            }
            if (LoggedUser.Comments == null)
            {
                LoggedUser.Comments = new ObservableCollection<Comment>();
            }
            FavoriteFilmsCount = LoggedUser.FavoriteFilms.Count;
            PlaylistsCount = LoggedUser.Playlists.Count;
            CommentsCount = LoggedUser.Comments.Count;
            RegistrationDate = LoggedUser.RegistrationDate;


        }
    }
}
