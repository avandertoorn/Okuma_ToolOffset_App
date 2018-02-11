using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToolOffset_Application.Windows.Main;
using Unity;

namespace ToolOffset_Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer container;
        private IMainWindowViewModel window;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Bootstrapper bootstrapper = new Bootstrapper();
            container = bootstrapper.Bootstrap();
            window = container.Resolve<IMainWindowViewModel>();
            var MainWindow = (MainWindow)window.Window;
            MainWindow.ShowDialog();
        }
    }
}
