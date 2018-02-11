using ToolOffset_Application.Core;

namespace ToolOffset_Application.Events
{
    public class NavigationRequest
    {
        public IViewModel ViewModel { get; }

        public NavigationRequest(IViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
