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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace EventAggregatorPattern.Core
{
	/// <summary>
	/// Description of EventAggregator.
	/// </summary>
	public class EventAggregator
	{
		private Dictionary<Type,IList> subscriber;
		public EventAggregator()
		{
			subscriber=new Dictionary<Type,IList>();
		}
		
		public void Publish<TMessageType>(TMessageType message)
		{
			Type t= typeof(TMessageType);
			IList actionList;
			if(subscriber.ContainsKey(t))
			{
				actionList= new List<Subscription<TMessageType>>(subscriber[t].Cast<Subscription<TMessageType>>());
				foreach(Subscription<TMessageType> a in actionList)
				{
					a.Action(message);
				}
			}
		}
		
		public Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
		{
			Type t= typeof(TMessageType);
			IList actionList;
			var actionDetail = new Subscription<TMessageType>(action,this);
			if(!subscriber.TryGetValue(t, out actionList))
			{
				actionList= new List<Subscription<TMessageType>>();
				actionList.Add(actionDetail);
				subscriber.Add(t, actionList);
			}
			else
			{
				actionList.Add(actionDetail);
			}
			return actionDetail;
		}
		
		public void UnSubscribe<TMessageType>(Subscription<TMessageType> subscription)
		{
			Type t = typeof(TMessageType);
			if(subscriber.ContainsKey(t))
			{
				subscriber[t].Remove(subscription);
			}
		}
	}
}
