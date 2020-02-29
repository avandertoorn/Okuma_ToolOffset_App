using ToolOffset_Application.Core;

namespace ToolOffset_Application.Events.Navigation
{
    public class WindowRegionNavigationRequest : NavigationRequest
    {

        public WindowRegionNavigationRequest(IViewModel viewModel)
            : base(viewModel)
        {

        }
    }
}
