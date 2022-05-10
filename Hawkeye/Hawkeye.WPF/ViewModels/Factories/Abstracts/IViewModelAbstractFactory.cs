using Hawkeye.WPF.State.Navigators;

namespace Hawkeye.WPF.ViewModels.Factories.Abstracts
{
    public interface IViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
