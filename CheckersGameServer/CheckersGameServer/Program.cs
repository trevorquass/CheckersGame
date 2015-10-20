using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CheckersGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                TCPListener tcpListener = new TCPListener();
                tcpListener.Listen();
            }
        }
    }
}
