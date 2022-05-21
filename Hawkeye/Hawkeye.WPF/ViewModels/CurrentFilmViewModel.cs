using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services;
using Hawkeye.WPF.Commands;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Hawkeye.WPF.ViewModels
{
    public class CurrentFilmViewModel : ViewModelBase
    {
        private IFilmRepository _filmRepository;
        private string _commentText;
        private ObservableCollection<Comment> _filmComments;
        public ICommand AddCommentCommand {get;}
        public ICommand AddFilmToFavoriteCommand { get;}
        
        public string CommentText 
        {
            get { return _commentText; }
            set 
            {
                _commentText = value;
                OnPropertyChanged();
            } 
        }
        public Film Film { get; set; } 
        public ObservableCollection<Comment> FilmComments 
        { 
            get { return _filmComments; }
            set
            {
                _filmComments = value;
                OnPropertyChanged();
            } 
        }
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public CurrentFilmViewModel(IFilmRepository filmRepository, 
                                    IAuthenticator authenticator, 
                                    IRepository<Comment> commentRepository, 
                                    IUserRepository userRepository)
        {
            AddCommentCommand = new AddCommentCommand(this, authenticator, commentRepository);
            AddFilmToFavoriteCommand = new AddFilmToFavoriteCommand(authenticator, filmRepository, userRepository);
            ErrorMessageViewModel = new MessageViewModel();
            _filmRepository = filmRepository;
            FilmComments = new ObservableCollection<Comment>();
            RefreshComments();
        }

        public void RefreshComments()
        {

            Film = _filmRepository.GetByIdWithCommentsAsync().FirstOrDefault(f => f.Id == FilmStorage.Film.Id);
            FilmComments.Clear();
            foreach (var comment in Film.Comments)
            {
                FilmComments.Add(comment);
            }
        }


        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}
