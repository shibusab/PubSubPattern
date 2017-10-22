/*
 * Created by SharpDevelop.
 * User: shibu
 * Date: 10/21/2017
 *
 * 
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE.txt', which is part of this source code package.
 */
using System;

namespace EventAggregatorPattern.SalesOrders.Messages
{
	/// <summary>
	/// Description of SalesOrder.
	/// </summary>
	public class SalesOrder
    {
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public double OrderQty { get; set; }
        public string CustomerCode { get; set; }
        public string OrderStatus {get;set;}

        public override string ToString()
        {
            return string.Format("Status:{4}, OrderNumber:{0}, OrderDate:{1}, OrderQty:{2}, CustomerCode:{3}", OrderNumber, OrderDate, OrderQty, CustomerCode, OrderStatus);
        }
    }
}
