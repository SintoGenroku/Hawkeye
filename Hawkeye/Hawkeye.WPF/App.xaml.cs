using Hawkeye.OmdbAPI.Services;
using Hawkeye.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hawkeye.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            /*            Window window = new Window();
                        window.DataContext = new MainViewModel();
                        window.Show();
                        base.OnStartup(e);*/
            /*var q = new FilmService().GetFilmData(435).Result;
            MessageBox.Show($"{q.NameRu}");*/
        }
    }
}
