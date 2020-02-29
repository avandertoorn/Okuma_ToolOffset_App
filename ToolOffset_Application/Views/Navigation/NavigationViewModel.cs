using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Views.BlockLibrary;
using ToolOffset_Application.Views.ToolLibrary;
using ToolOffset_Application.Views.TurretContainer;
using Unity;

namespace ToolOffset_Application.Views.Navigation
{
    public class NavigationViewModel : BaseViewModel, INavigationViewModel
    {
        public NavigationViewModel() { }

        public NavigationViewModel(INavigationView view, IUnityContainer container, INavigationEventAggregator navigationEventAggregator)
        : base(view, container)
        {
            _navigationEventAggregator = navigationEventAggregator;
            TurretViewNavigation = new DelegateCommand<object>(OnTurretViewNavigation);
            BlockViewNavigation = new DelegateCommand<object>(OnBlockViewNavigation);
            ToolViewNavigation = new DelegateCommand<object>(OnToolViewNavigation);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;

        public DelegateCommand<object> TurretViewNavigation { get; }
        public DelegateCommand<object> BlockViewNavigation { get; }
        public DelegateCommand<object> ToolViewNavigation { get; }

        private void OnToolViewNavigation(object obj)
        {
            _navigationEventAggregator.PostMessage(new MainRegionNavigationRequest(Container.Resolve<IToolLibraryViewModel>()));
        }

        private void OnBlockViewNavigation(object obj)
        {
            _navigationEventAggregator.PostMessage(new MainRegionNavigationRequest(Container.Resolve<IBlockLibraryViewModel>()));
        }

        private void OnTurretViewNavigation(object obj)
        {
            _navigationEventAggregator.PostMessage(new MainRegionNavigationRequest(Container.Resolve<ITurretContainerViewModel>()));
        }

    }
}
