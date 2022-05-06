using Hawkeye.WPF.Commands;
using Hawkeye.WPF.Models;
using Hawkeye.WPF.ViewModels;
using System.Windows.Input;

namespace Hawkeye.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator 
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);


    }
}
