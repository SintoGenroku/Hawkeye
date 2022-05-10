namespace Hawkeye.WPF.ViewModels.Factories.Abstracts
{
    public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
