using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDrivenSimpleOrder.Core
{
    public class Subscriber<T>
    {
        public IPublisher<T> Publisher { get; private set; }
        
        public Subscriber(IPublisher<T> publisher)
        {
            Publisher = publisher;
        }
    }
}
