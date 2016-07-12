using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PubSubServicesUnitTest
{
    [TestFixture]
    public class PubSubServicesTest
    {
        [Test]
        public void Run()
        {
            var channelKey = "du";

            PubSubServicesSample.PubSubServices.Instance.Subcribe("subcriber_a", channelKey, s =>
            {
                Console.WriteLine("subcriber_a " + s);
                return true;
            });

            PubSubServicesSample.PubSubServices.Instance.Subcribe("subcriber_b", channelKey, s =>
            {
                Console.WriteLine("subcriber_b " + s);
                return true;
            });

            string channelKey2 = "channelkey2";
            PubSubServicesSample.PubSubServices.Instance.Subcribe("subcriber_e", channelKey2, s =>
            {
                Console.WriteLine("eror " + s);
                return true;
            });


            PubSubServicesSample.PubSubServices.Instance.Publish(channelKey, "hello from cdu " + DateTime.Now);
            PubSubServicesSample.PubSubServices.Instance.Publish(channelKey2, "hello from c2 " + DateTime.Now);

            Thread.Sleep(1000);
        }
    }
}