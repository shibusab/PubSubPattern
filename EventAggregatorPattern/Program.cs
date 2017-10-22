/*
 * Created by SharpDevelop.
 * User: shibu
 * Date: 10/20/2017
 *
 * 
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE.txt', which is part of this source code package.
 */
using System;
using EventAggregatorPattern.Core;
using EventAggregatorPattern.SalesOrders;

namespace EventAggregatorPattern
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World! Entering Event Aggregator");
			var eventAggregartor = new EventAggregator();
			Console.WriteLine(" Case 1 ");
  			var publisher = new Publisher(eventAggregartor);
			var subscriber= new Subscriber(eventAggregartor);
			
			publisher.PublishMessage();
			
			Console.WriteLine(" Case 2 ");
			var customerServiceClerk = new CustomerServiceClerk(eventAggregartor);
			var billingClerk = new BillingClerk(eventAggregartor);
			var shippingClerk = new ShippingClerk(eventAggregartor);
			
			customerServiceClerk.CreateOrder();
			Console.BackgroundColor= ConsoleColor.Black;
			//Console.WriteLine(" Case 3 MVP... Building in Progress");
			
			
		}
	}
}