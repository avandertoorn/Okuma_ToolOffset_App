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

        private IView _view;

        public IWindow Window { get; set; }
        public IView View
        {
            get { return _view; }
            set
            {
                _view = value;
                OnPropertyChanged("View");
            }

        }
        public IUnityContainer Container { get; set; }

        protected void ShowView<T>() where T : IViewModel
        {
            View = Container.Resolve<T>().View;
        }
    }
}
