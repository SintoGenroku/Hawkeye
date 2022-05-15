using Hawkeye.WPF.ViewModels;
using System;

namespace Hawkeye.WPF.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
