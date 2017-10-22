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
using EventAggregatorPattern.Core;
using EventAggregatorPattern.SalesOrders.Messages;

namespace EventAggregatorPattern.SalesOrders
{
	/// <summary>
	/// Description of ShippingClerk.
	/// </summary>
	public class ShippingClerk
	{
		private readonly EventAggregator eventAggregator ;
		public ShippingClerk(EventAggregator eventAggregator )
		{
			this.eventAggregator= eventAggregator;
			ManageSubscriptions();
		}
		
		public void ManageSubscriptions()
		{
			eventAggregator.Subscribe<SalesOrder>(ReceiveOrder);
		}
		
		public void ReceiveOrder(SalesOrder salesOrder)
		{
			salesOrder.OrderStatus="SHIPPPING:Received Order";
			Console.BackgroundColor= ConsoleColor.Blue;
			Console.WriteLine(DateTime.Now.ToString() + " " + salesOrder.ToString());
		 	ProcessOrder(salesOrder);
		}
		
		public void  ProcessOrder(SalesOrder salesOrder)
		{
			salesOrder.OrderStatus="SHIPPING:Processing Order";
			Console.BackgroundColor= ConsoleColor.Blue;
			Console.WriteLine(DateTime.Now.ToString() + " "+ salesOrder.ToString());
			//System.Threading.Thread.Sleep(10000);
			var shippedOrder = new ShippedOrderMessage(salesOrder);
			eventAggregator.Publish<ShippedOrderMessage>(shippedOrder);
		}
	}
}
