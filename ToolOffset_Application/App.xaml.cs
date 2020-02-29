using System.Windows;
using ToolOffset_Application.Windows.Main;
using Unity;

namespace ToolOffset_Application
{
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
