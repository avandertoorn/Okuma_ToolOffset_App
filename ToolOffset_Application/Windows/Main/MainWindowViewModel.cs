using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Views.MainRegion;
using Unity;

namespace ToolOffset_Application.Windows.Main
{
    public class MainWindowViewModel : BaseWindowViewModel, IMainWindowViewModel
    {
        public MainWindowViewModel(IMainWindow window, IUnityContainer container, INavigationEventAggregator navigationEventAggregator)
        : base(window, container)
        {
            ShowView<IMainRegionViewModel>();
            _navigationEventAggregator = navigationEventAggregator;
            _navigationEventAggregator.RegisterHandler<WindowRegionNavigationRequest>(NavigationRequestHandler);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;

        public void NavigationRequestHandler(WindowRegionNavigationRequest message)
        {
            this.View = message.ViewModel.View;
        }
    }
}
