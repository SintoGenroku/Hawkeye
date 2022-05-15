using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;
using Hawkeye.Foundation.Services;
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
    public class AddCommentCommand : ICommand
    {
        private readonly IAuthenticator authenticator;
        private readonly IRepository<Comment> commentRepository;
        private CurrentFilmViewModel _currentFilmViewModel;
        private User _currentUser => authenticator.CurrentUser;

        public AddCommentCommand( CurrentFilmViewModel currentFilmViewModel, IAuthenticator authenticator, IRepository<Comment> commentRepository)
        {
            _currentFilmViewModel = currentFilmViewModel;
            this.authenticator = authenticator;
            this.commentRepository = commentRepository;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                if (_currentFilmViewModel.CommentText != null)
                {
                    commentRepository.CreateAsync(new Comment()
                    {
                        Film = FilmStorage.Film,
                        User = _currentUser,
                        CommentText = _currentFilmViewModel.CommentText,
                    });
                    _currentFilmViewModel.CommentText = "";
                }
                else
                {
                    throw new Exception("Поле комментария не должно быть пустым");
                }
            }
            catch (Exception ex)
            {
                _currentFilmViewModel.ErrorMessage = ex.Message;
            }

        }
    }
}
