using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDrivenSimpleOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var x= new EventDrivenSimpleOrder.Core.Client();

            var order = new EventDrivenSimpleOrder.SalesOrders.SalesOrderClient();
        }
    }
}
