using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ch.hsr.wpf.gadgeothek_UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var screen = new SplashScreen("resources/start.png");
            screen.Show(false);

            Thread.Sleep(2000);

            screen.Close(TimeSpan.FromMilliseconds(500));
        }
    }
}
