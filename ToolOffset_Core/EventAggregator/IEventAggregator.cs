using System;

namespace ToolOffset_Core.EventAggregator
{
    public interface IEventAggregator
    {
        void SendMessage<T>(T message);
        void PostMessage<T>(T message);
        Action<T> RegisterHandler<T>(Action<T> eventHandler);
        void UnRegisterHandler<T>(Action<T> eventHandler);
    }
}
