using ToolOffset_Core.EventAggregator;

namespace ToolOffset_Application.Events.Attach
{
    public class AttachEventAggregator : EventAggregator, IAttachEventAggregator
    {
        public AttachEventAggregator() : base() { }
    }
}
