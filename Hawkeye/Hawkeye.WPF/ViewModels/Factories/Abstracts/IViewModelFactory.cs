using Hawkeye.Domain.Models;
using Hawkeye.WPF.State.Navigators;

namespace Hawkeye.WPF.ViewModels.Factories.Abstracts
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
