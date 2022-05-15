using Hawkeye.WPF.Commands;
using Hawkeye.WPF.Models;
using Hawkeye.WPF.ViewModels;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System;
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
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }


        public event Action StateChanged;

    }
}
