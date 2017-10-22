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
	/// Description of ShippedOrderMessage.
	/// </summary>
	public class ShippedOrderMessage:SalesOrder
	{
		public ShippedOrderMessage()
		{
		}
		
		public ShippedOrderMessage(SalesOrder salesOrder)
		{
			base.CustomerCode= salesOrder.CustomerCode;
			base.OrderDate=salesOrder.OrderDate;
			base.OrderNumber= salesOrder.OrderNumber;
			base.OrderQty=salesOrder.OrderQty;
			base.OrderStatus= salesOrder.OrderStatus;
		}
		
		public override string ToString()
		{
			return base.ToString();
		}
		
	}
}
