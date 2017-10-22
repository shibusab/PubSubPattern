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

namespace EventAggregatorPattern.Core
{
	/// <summary>
	/// Used by EventAggregator to reserve subscription.
	/// </summary>
	public class Subscription<Tmessage> :IDisposable
	{
		public Action<Tmessage> Action {get; private set;}
		private readonly EventAggregator EventAggregator;
		private bool isDisposed;
		public Subscription(Action<Tmessage> action, EventAggregator eventAggregator)
		{
			Action=action;
			EventAggregator=eventAggregator;
			isDisposed=false;
		}
		
		~Subscription()
		{
			if(!isDisposed)
			{
				Dispose();
			}
		}
		
		public void Dispose()
		{
			EventAggregator.UnSubscribe(this);
			isDisposed=true;
		}
	}
}
