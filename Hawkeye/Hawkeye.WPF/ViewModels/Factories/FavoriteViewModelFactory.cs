using Hawkeye.WPF.ViewModels.Factories.Abstracts;

namespace Hawkeye.WPF.ViewModels.Factories
{
    public class FavoriteViewModelFactory : IViewModelFactory<FavoriteViewModel>
    {
        public FavoriteViewModel CreateViewModel()
        {
            return new FavoriteViewModel();
        }
    }
}
