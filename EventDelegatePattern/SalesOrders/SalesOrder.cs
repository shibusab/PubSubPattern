using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDrivenSimpleOrder.SalesOrders
{
    public class SalesOrder
    {
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public double OrderQty { get; set; }
        public string CustomerCode { get; set; }
        public string OrderStatus {get;set;}

        public override string ToString()
        {
            return string.Format("OrderNumber:{0}, OrderDate:{1}, OrderQty:{2}, CustomerCode:{3}, Status:{4}", OrderNumber, OrderDate, OrderQty, CustomerCode, OrderStatus);
        }
    }
}
