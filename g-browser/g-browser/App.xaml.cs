using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace g_browser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += App_Start;

        }

        private void App_Start(object sender, StartupEventArgs e)
        {
            g_browser.MainWindow.Instance.Show();
        }
    }
}
