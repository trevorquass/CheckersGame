using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CheckersGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 7777);
            TcpClient client;
            listener.Start();
            Console.WriteLine("***Game Server Started***");
            while (true)
            {
                client = listener.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(ThreadProc, client);
            }
        }
        private static void ThreadProc (object obj)
        {
            var client = (TcpClient)obj;
       
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: " + dataReceived);

            Console.WriteLine("Sending To Client: " + dataReceived);
            nwStream.Write(buffer, 0, bytesRead);
            client.Close();
            Console.ReadLine();
        }
    }
}
