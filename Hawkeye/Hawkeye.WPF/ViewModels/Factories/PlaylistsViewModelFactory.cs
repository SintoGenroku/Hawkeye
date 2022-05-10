using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.WPF.ViewModels.Factories
{
    public class PlaylistsViewModelFactory : IViewModelFactory<PlaylistsViewModel>
    {
        public PlaylistsViewModel CreateViewModel()
        {
            return new PlaylistsViewModel();
        }
    }
}
