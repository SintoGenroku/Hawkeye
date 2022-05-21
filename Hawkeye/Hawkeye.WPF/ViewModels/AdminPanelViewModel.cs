using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hawkeye.WPF.ViewModels
{
    public class AdminPanelViewModel : ViewModelBase
    {
        private ICommentRepository commentRepository;
        public ICommand DeleteCommentCommand { get; set; }
        public ObservableCollection<Comment> AllComments { get; set; }

        public AdminPanelViewModel(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
            DeleteCommentCommand = new DeleteCommentCommand(this, commentRepository);
            AllComments = new ObservableCollection<Comment>();

            var result =  commentRepository.GetAllCommentsAsync();
            foreach(var comment in result)
            {
                AllComments.Add(comment);
            }
        }

    }
}
