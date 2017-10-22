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

namespace EventAggregatorPattern.SalesOrders.Messages
{
	/// <summary>
	/// Description of MyMessage.
	/// </summary>
	public class MyMessage
	{
		public MyMessage()
		{
		}
		
		public string Code{get;set;}
		public string Description {get;set;}
	}
}
