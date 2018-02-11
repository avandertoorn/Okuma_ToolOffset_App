using ToolOffset_Application.Core;
using ToolOffset_Application.Events;
using ToolOffset_Application.Views.BlockLibrary;
using ToolOffset_Application.Views.ToolLibrary;
using ToolOffset_Application.Views.TurretContainer;
using Unity;

namespace ToolOffset_Application.Views.Navigation
{
    public class NavigationViewModel : BaseViewModel, INavigationViewModel
    {
        public NavigationViewModel()
        {

        }

        public NavigationViewModel(INavigationView view, IUnityContainer container, IEventAggregator eventAggregator)
        : base(view, container)
        {
            _eventAggregator = eventAggregator;
            TurretViewNavigation = new DelegateCommand<object>(OnTurretViewNavigation);
            BlockViewNavigation = new DelegateCommand<object>(OnBlockViewNavigation);
            ToolViewNavigation = new DelegateCommand<object>(OnToolViewNavigation);
        }

        private void OnToolViewNavigation(object obj)
        {
            _eventAggregator.PostMessage(new NavigationRequest(Container.Resolve<IToolLibraryViewModel>()));
        }

        private void OnBlockViewNavigation(object obj)
        {
            _eventAggregator.PostMessage(new NavigationRequest(Container.Resolve<IBlockLibraryViewModel>()));
        }

        private void OnTurretViewNavigation(object obj)
        {
            _eventAggregator.PostMessage(new NavigationRequest(Container.Resolve<ITurretContainerViewModel>()));
        }

        private readonly IEventAggregator _eventAggregator;

        public DelegateCommand<object> TurretViewNavigation { get; }
        public DelegateCommand<object> BlockViewNavigation { get; }
        public DelegateCommand<object> ToolViewNavigation { get; }

    }
}
