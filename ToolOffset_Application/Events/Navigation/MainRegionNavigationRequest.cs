using ToolOffset_Application.Core;

namespace ToolOffset_Application.Events.Navigation
{
    public class MainRegionNavigationRequest : NavigationRequest
    {
        public MainRegionNavigationRequest(IViewModel viewModel)
            : base(viewModel)
        {

        }
    }
}
