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
	/// Description of Subscriber.
	/// </summary>
	public class Subscriber
	{
		Subscription<MyMessage> myMessageToken;
		Subscription<int> intToken;
		EventAggregator eventAggregator;
		
		public Subscriber(EventAggregator eventAggregator)
		{
			this.eventAggregator= eventAggregator;
			eventAggregator.Subscribe<MyMessage>(this.Test);
			eventAggregator.Subscribe<int>(this.IntTest);
		}
		
		private void IntTest(int obj)
		{
			Console.WriteLine(obj);
			eventAggregator.UnSubscribe(intToken);
		}
		
		public void Test(MyMessage test)
		{
			Console.WriteLine(test.ToString());
			eventAggregator.UnSubscribe(myMessageToken);
		}
	}
}
