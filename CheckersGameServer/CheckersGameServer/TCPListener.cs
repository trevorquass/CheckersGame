using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CheckersGameServer
{
    class TCPListener
    {
        const int portNumber = 7777;
        const string serverIP = "10.2.20.16";
        public void Listen()
        {
            IPAddress IP = IPAddress.Parse(serverIP);
            TcpListener checkersGameServer = new TcpListener(IP, portNumber);
            Console.WriteLine("***Game Server Started***");
            checkersGameServer.Start();

            TcpClient client = checkersGameServer.AcceptTcpClient();

            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: " + dataReceived);

            Console.WriteLine("Sending To Client: " + dataReceived);
            nwStream.Write(buffer, 0, bytesRead);
            client.Close();
            checkersGameServer.Stop();
            Console.ReadLine();
        }
    }
}
