using ToolOffset_Core.EventAggregator;

namespace ToolOffset_Application.Events.Selection
{
    public class SelectionEventAggregator : EventAggregator, ISelectionEventAggregator
    {
        public SelectionEventAggregator() : base() { }
    }
}
