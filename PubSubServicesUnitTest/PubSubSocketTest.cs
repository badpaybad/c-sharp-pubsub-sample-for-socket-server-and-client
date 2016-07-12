using System;
using System.Threading;
using NUnit.Framework;
using PubSubServicesSample.SampleSocket;

namespace PubSubServicesUnitTest
{
    [TestFixture]
    public class PubSubSocketTest
    {
        string _ipserver = "127.0.0.1";
        int _portserver = 12345;

        private PubSubSocketServer _server;

        [SetUp]
        public void Setup()
        {
            _server = new PubSubSocketServer(_ipserver, _portserver);
            _server.Report += PubSubServer_Report;
            Thread.Sleep(2000); //wait for pubsub server bootup
            _server.Start();
        }

        [Test]
        public void Run()
        {
            PubSubSocketClient client = new PubSubSocketClient(_ipserver, _portserver);
            client.Ping();
            var channelKey = "http://badpaybad.info";
            client.Subcribe(channelKey, (msg) => { Console.WriteLine("Todo smth with msg -> " + msg); });
            var channelKey1 = "helloworld";
            client.Subcribe(channelKey1, (msg) => { Console.WriteLine("Todo smth with msg -> " + msg); });

            client.Publish(channelKey, "badpaybad.info said: sample pubsub with socket");
            client.Publish(channelKey1, "Xin chào bạn: " + DateTime.Now);

            Thread.Sleep(5000);
        }

        private void PubSubServer_Report(string obj)
        {
            Console.WriteLine("server log -> " + obj);
        }

        public void Endup()
        {
            _server.Dispose();
        }
    }
}