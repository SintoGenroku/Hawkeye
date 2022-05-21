using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace Hawkeye.WPF.Commands
{
    public class DeleteCommentCommand : ICommand
    {

        private readonly IRepository<Comment> commentRepository;
        private AdminPanelViewModel _adminPanelViewModel;


        public DeleteCommentCommand(AdminPanelViewModel adminPanelViewModel, IRepository<Comment> commentRepository)
        {
            _adminPanelViewModel = adminPanelViewModel;

            this.commentRepository = commentRepository;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {

            var comment = await commentRepository.FindByIdAsync((Guid)parameter);

            _adminPanelViewModel.AllComments.Remove(comment);
            commentRepository.DeleteAsync(comment);

        }
    }
}
