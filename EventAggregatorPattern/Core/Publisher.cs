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
using EventAggregatorPattern.SalesOrders.Messages;

namespace EventAggregatorPattern.Core
{
	/// <summary>
	/// Description of Publisher.
	/// </summary>
	public class Publisher
	{
		EventAggregator eventAggregator;
		public Publisher(EventAggregator eventAggregator)
		{
			this.eventAggregator= eventAggregator;
		}
		
		public void PublishMessage()
		{
			eventAggregator.Publish(new MyMessage());
			eventAggregator.Publish(10);
		}
	}
}
