using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventDrivenSimpleOrder.SalesOrders;

namespace EventDrivenSimpleOrder.Core
{
    public class Client
    {
        private readonly IPublisher<int> intPublisher;
        private readonly Subscriber<int> intSubscriber1;
        private readonly Subscriber<int> intSubscriber2;
       
        public Client()
        {
            intPublisher = new Publisher<int>();

            intSubscriber1 = new Subscriber<int>(intPublisher);
            intSubscriber1.Publisher.DataPublisher += publisher_DataPublisher1;

            intSubscriber2 = new Subscriber<int>(intPublisher);
            intSubscriber2.Publisher.DataPublisher += publisher_DataPublisher2;

            intPublisher.PublishData(10);
        }


        void publisher_DataPublisher1(object sender, MessageArgument<int> e)
        {
            Console.WriteLine("Subscriber 1: " + e.Message);
        }

        void publisher_DataPublisher2(object sender, MessageArgument<int> e)
        {
            Console.WriteLine("Subscriber 2: " + e.Message);
        }
    }
}