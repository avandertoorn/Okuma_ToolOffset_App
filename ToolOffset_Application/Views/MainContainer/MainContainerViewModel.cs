using System.Runtime.InteropServices.ComTypes;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events;
using ToolOffset_Application.Views.Navigation;
using ToolOffset_Application.Views.TurretContainer;
using Unity;

namespace ToolOffset_Application.Views.MainContainer
{
    public class MainContainerViewModel : BaseViewModel, IMainContainerViewModel
    {
        public MainContainerViewModel(IMainContainerView view, IUnityContainer container, IEventAggregator eventAggregator)
            : base(view, container)
        {
            NavigationView = container.Resolve<INavigationViewModel>().View;
            ShowMainView<ITurretContainerViewModel>();
            _eventAggregator = eventAggregator;
            _eventAggregator.RegisterHandler<NavigationRequest>(NavigationRequestHandler);
        }

        private readonly IEventAggregator _eventAggregator;
        private IView _navigationView;
        private IView _mainView;

        public IView NavigationView
        {
            get { return _navigationView; }
            set
            {
                if (value != _navigationView)
                {
                    _navigationView = value;
                    OnPropertyChanged("NavigationView");
                }
            }
        }

        public IView MainView
        {
            get { return _mainView; }
            set
            {
                if (value != _mainView)
                {
                    _mainView = value;
                    OnPropertyChanged("MainView");
                }
            }
        }

        public void ShowMainView<T>() where T : IViewModel
        {
            MainView = Container.Resolve<T>().View;
        }

        private void NavigationRequestHandler(NavigationRequest request)
        {
            MainView = request.ViewModel.View;
        }
    }
}
