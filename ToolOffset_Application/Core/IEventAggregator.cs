using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ToolOffset_Application.Core
{
    public interface IEventAggregator
    {
        void SendMessage<T>(T message);
        void PostMessage<T>(T message);
        Action<T> RegisterHandler<T>(Action<T> eventHandler);
        void UnRegisterHandler<T>(Action<T> eventHandler);
    }
}
