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

namespace EventAggregatorPattern.SalesOrders.MvpPattern
{
	/// <summary>
	/// Description of OrderPresenter.
	/// </summary>
	public class OrderPresenter
	{
		private EventAggregator eventAggregator;
		public OrderPresenter(EventAggregator eventAggregator)
		{
			this.eventAggregator=eventAggregator;
		}
	}
}
