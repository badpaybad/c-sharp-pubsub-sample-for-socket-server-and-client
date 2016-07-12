using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubSocketServer
{
    class Program
    {
        private static PubSubServicesSample.SampleSocket.PubSubSocketServer _server;
        static void Main(string[] args)
        {
            _server = new PubSubServicesSample.SampleSocket.PubSubSocketServer("127.0.0.1", 12345);
            _server.Report += _server_Report;
            _server.Start();

            Console.ReadLine();
        }

        private static void _server_Report(string obj)
        {
            Console.WriteLine(obj);
        }
    }
}
