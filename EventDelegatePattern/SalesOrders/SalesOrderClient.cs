using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventDrivenSimpleOrder.Core;

namespace EventDrivenSimpleOrder.SalesOrders
{
    public class SalesOrderClient
    {
        private readonly IPublisher<SalesOrder> customerServiceClerk;
        private readonly Subscriber<SalesOrder> shippingClerk;
        private readonly Subscriber<SalesOrder> billingClerk;


        public SalesOrderClient()
        {
            customerServiceClerk = new Publisher<SalesOrder>();
            
             //Notify to Billing Clerk when Order is Published
            billingClerk = new Subscriber<SalesOrder>(customerServiceClerk);
            billingClerk.Publisher.DataPublisher += billingClerk_OrderReceived;

			//Notify to Shipping Clerk
            shippingClerk = new Subscriber<SalesOrder>(customerServiceClerk);
            shippingClerk.Publisher.DataPublisher +=  shippingClerk_OrderReceived;
            

           
            customerServiceClerk.PublishData(new SalesOrder { CustomerCode="CUST01", OrderDate= "10-OCT-2017", OrderNumber="1", OrderQty=1 });
        }


        public void shippingClerk_OrderReceived(Object sender, MessageArgument<SalesOrder> e)
        {
        	DoOrderReceivingInShipping(sender,e);
        }
        
 		public void shippingClerk_OrderProcessed(Object sender, MessageArgument<SalesOrder> e)
        {
 			DoOrderProcessingInShipping(sender,e);
        }

        
 		public void billingClerk_OrderReceived(Object sender, MessageArgument<SalesOrder> e)
        {
 			DoOrderReceivingInBilling(sender,e);
        }
 		
		public void billingClerk_OrderProcessed(Object sender, MessageArgument<SalesOrder> e)
        {
			DoOrderProcessingInBilling(sender,e);
        }        
        
        //Event Handler Helpers
         void DoOrderReceivingInShipping(Object sender, MessageArgument<SalesOrder> e)
        {
        	e.Message.OrderStatus="Received In Shipping";
        	Console.WriteLine(DateTime.Now.ToString() + " Received Order To Shipping: " + e.Message.ToString());
            shippingClerk_OrderProcessed(sender, e);
        }
         
        void DoOrderProcessingInShipping(Object sender, MessageArgument<SalesOrder> e)
        {
        	e.Message.OrderStatus="Processing In Shipping";
        	Console.WriteLine(DateTime.Now.ToString() + " Received Order To Shipping: " + e.Message.ToString());
            billingClerk_OrderProcessed(sender, e);
        }
        
         void DoOrderReceivingInBilling(Object sender, MessageArgument<SalesOrder> e)
        {
        	e.Message.OrderStatus="Received In Billing";
            Console.WriteLine(DateTime.Now.ToString() + " Received Order To Billing: " + e.Message.ToString());
            //billingClerk_OrderProcessed(sender, e);
        }
         
        void DoOrderProcessingInBilling(Object sender, MessageArgument<SalesOrder> e)
        {
        	e.Message.OrderStatus="Processed In Billing";
            Console.WriteLine(DateTime.Now.ToString() + " Order Processed in Billing: " + e.Message.ToString());
        }
    }
}
