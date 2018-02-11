using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Application.Windows.Main;
using Unity;

namespace ToolOffset_Application.Core
{
    public class BaseWindowViewModel : BaseNotification, IWindowViewModel
    {
        public BaseWindowViewModel(IMainWindow window, IUnityContainer container)
        {
            Window = window;
            Window.DataContext = this;

            Container = container;
        }

        public IWindow Window { get; set; }
        public IView View { get; set; }
        public IUnityContainer Container { get; set; }

        protected void ShowView<T>() where T : IViewModel
        {
            View = Container.Resolve<T>().View;
        }
    }
}
