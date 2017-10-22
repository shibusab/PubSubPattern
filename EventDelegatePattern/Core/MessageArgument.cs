﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDrivenSimpleOrder.Core
{
    public class MessageArgument<T> :EventArgs
    {
        public T Message { get; set; }
        public MessageArgument(T message)
        {
            Message = message;
        }
    }
}
