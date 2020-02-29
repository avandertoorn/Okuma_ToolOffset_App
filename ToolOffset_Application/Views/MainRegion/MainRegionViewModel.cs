using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Views.Navigation;
using ToolOffset_Application.Views.TurretContainer;
using Unity;

namespace ToolOffset_Application.Views.MainRegion
{
    public class MainRegionViewModel : BaseViewModel, IMainRegionViewModel
    {
        public MainRegionViewModel(IMainRegionView view, IUnityContainer container, INavigationEventAggregator navigationEventAggregator)
            : base(view, container)
        {
            NavigationView = container.Resolve<INavigationViewModel>().View;
            ShowMainView<ITurretContainerViewModel>();
            _navigationEventAggregator = navigationEventAggregator;
            _navigationEventAggregator.RegisterHandler<MainRegionNavigationRequest>(NavigationRequestHandler);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;
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

        private void NavigationRequestHandler(MainRegionNavigationRequest request)
        {
            MainView = request.ViewModel.View;
        }
    }
}
