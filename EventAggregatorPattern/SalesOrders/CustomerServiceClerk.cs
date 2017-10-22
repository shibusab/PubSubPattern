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
	///  Customer Service Clerk takes Sales Order and Publishes It.
    ///  Billing Clerk is subscribed to Customer Service Clerk
  	///  Shipping Clerk is subscribed to Customer Service Clerk
    ///
  	///  Shipping Clerk Notifies Billing Clerk when Order is Processed
	/// </summary>
	public class CustomerServiceClerk
	{
		private readonly EventAggregator eventAggregator ;
		public CustomerServiceClerk(EventAggregator eventAggregator )
		{
			this.eventAggregator= eventAggregator;
			ManageSubscriptions();
		}
		
		public void ManageSubscriptions()
		{
			eventAggregator.Subscribe<SalesOrder>(ReceiveOrder);
			eventAggregator.Subscribe<ShippedOrderMessage>(OrderShipped);
			eventAggregator.Subscribe<BilledOrderMessage>(OrderBilled);
		}
		
		public void CreateOrder()
		{
			var salesOrder = new SalesOrder { CustomerCode="CUST01", OrderDate= "10-OCT-2017", OrderNumber="1", OrderQty=1 };
			eventAggregator.Publish(salesOrder);
		}
		
		public void  ReceiveOrder(SalesOrder salesOrder)
		{
			salesOrder.OrderStatus="Customer Service:Order Received";
			Console.BackgroundColor= ConsoleColor.DarkGreen;
			Console.WriteLine(DateTime.Now.ToString() + " " + salesOrder.ToString());
		}
		
		public void  OrderShipped(ShippedOrderMessage order)
		{
			order.OrderStatus="Customer Service:OrderShipped";
			Console.BackgroundColor=ConsoleColor.Yellow;
			Console.WriteLine(DateTime.Now.ToString() + " " + order.ToString());
		}
		
		public void  OrderBilled(BilledOrderMessage order)
		{
			order.OrderStatus="Customer Service:OrderBilled";
			Console.BackgroundColor=ConsoleColor.Yellow;
			Console.WriteLine(DateTime.Now.ToString() + " " + order.ToString());
		}
	}
}
