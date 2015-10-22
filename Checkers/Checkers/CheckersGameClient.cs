using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;

namespace Checkers
{
    class CheckersGameClient
    {
        public void SendAndReceiveUserInfo()
        {
            const int portNumber = 7777;
            const string serverIP = "10.2.20.16";
            ListBoxItem connectedUser = new ListBoxItem();
            try
            {
                TcpClient checkersGameClient = new TcpClient(serverIP, portNumber);
                NetworkStream outgoingStream = checkersGameClient.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(((MainWindow)System.Windows.Application.Current.MainWindow).EnterName.Text);
                outgoingStream.Write(bytesToSend, 0, bytesToSend.Length);

                NetworkStream incomingStream = checkersGameClient.GetStream();
                byte[] bytesToRead = new byte[checkersGameClient.ReceiveBufferSize];
                int bytesRead = incomingStream.Read(bytesToRead, 0, checkersGameClient.ReceiveBufferSize);
                connectedUser.Content = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                ((MainWindow)System.Windows.Application.Current.MainWindow).UsersOnline.Items.Add(connectedUser);
                checkersGameClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        public void SendAndReceiveGameInfo(string info)
        {
            const int portNumber = 7777;
            const string serverIP = "10.2.20.16";
            try
            {
                TcpClient checkersGameClient = new TcpClient(serverIP, portNumber);
                NetworkStream outgoingStream = checkersGameClient.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(info);
                outgoingStream.Write(bytesToSend, 0, bytesToSend.Length);
                checkersGameClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
    }
}
