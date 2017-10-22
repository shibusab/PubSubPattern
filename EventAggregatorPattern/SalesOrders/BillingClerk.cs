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
	/// Description of BillingClerk.
	/// </summary>
	public class BillingClerk
	{
		private readonly EventAggregator eventAggregator ;
		public BillingClerk(EventAggregator eventAggregator )
		{
			this.eventAggregator= eventAggregator;
			ManageSubscriptions();
		}
		
		public void ManageSubscriptions()
		{
			eventAggregator.Subscribe<SalesOrder>(ReceiveOrder);
			eventAggregator.Subscribe<ShippedOrderMessage>(OrderShipped);
		}
		
		public void  ReceiveOrder(SalesOrder salesOrder)
		{
			salesOrder.OrderStatus="BILLING:Order Received";
			Console.BackgroundColor= ConsoleColor.DarkGreen;
			Console.WriteLine(DateTime.Now.ToString() + " " + salesOrder.ToString());
		}
		
		
		public void  OrderShipped(SalesOrder salesOrder)
		{
			salesOrder.OrderStatus="BILLING:Order Shipped ";
			Console.BackgroundColor= ConsoleColor.DarkGreen;
			Console.WriteLine(DateTime.Now.ToString() + " " + salesOrder.ToString());
			ProcessAndSendBill(salesOrder);
			
		}

		void ProcessAndSendBill(SalesOrder salesOrder)
		{
			salesOrder.OrderStatus="BILLING:Creating And Sending Invoice";
			Console.BackgroundColor= ConsoleColor.DarkGreen;
			Console.WriteLine(DateTime.Now.ToString() + " "+ salesOrder.ToString());
			//System.Threading.Thread.Sleep(100);
			var billedOrder =  new BilledOrderMessage(salesOrder);
			eventAggregator.Publish<BilledOrderMessage>(billedOrder);
		}
	}
}
