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

namespace EventAggregatorPattern.SalesOrders.MvpPattern
{
	/// <summary>
	/// Description of OrderView.
	/// </summary>
	public class OrderView
	{
		private EventAggregator eventAggregator;
		public OrderView(EventAggregator eventAggregator)
		{
			this.eventAggregator=eventAggregator;
		}
		
		
		public void OnOrderCreated()
		{
			var salesOrder = new SalesOrder { CustomerCode="CUST01", OrderDate= "10-OCT-2017", OrderNumber="1", OrderQty=1 };
			eventAggregator.Publish<SalesOrder>(salesOrder);
		}
	}
}
