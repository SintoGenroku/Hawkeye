using Hawkeye.WPF.ViewModels.Factories.Abstracts;

namespace Hawkeye.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
    {
        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel();
        }
    }
}
