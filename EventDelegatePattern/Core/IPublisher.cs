using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDrivenSimpleOrder.Core
{
    public interface IPublisher<T>
    {
        event EventHandler<MessageArgument<T>> DataPublisher;
        void OnDataPublisher(MessageArgument<T> args);
        void PublishData(T data);
    }
}
