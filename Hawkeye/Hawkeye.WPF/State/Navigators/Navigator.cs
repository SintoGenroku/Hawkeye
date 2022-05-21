using Hawkeye.WPF.Models;
using Hawkeye.WPF.ViewModels;
using System;

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
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }


        public event Action StateChanged;

    }
}
