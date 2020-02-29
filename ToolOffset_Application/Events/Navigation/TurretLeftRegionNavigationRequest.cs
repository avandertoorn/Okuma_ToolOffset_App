using ToolOffset_Application.Core;

namespace ToolOffset_Application.Events.Navigation
{
    public class TurretLeftRegionNavigationRequest : NavigationRequest
    {
        public TurretLeftRegionNavigationRequest(IViewModel viewModel)
        : base(viewModel)
        {

        }
    }
}
