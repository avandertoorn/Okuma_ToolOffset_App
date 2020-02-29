using ToolOffset_Core.EventAggregator;

namespace ToolOffset_Application.Events.Navigation
{
    public class NavigationEventAggregator : EventAggregator, INavigationEventAggregator
    {
        public NavigationEventAggregator() : base() { }
    }
}
