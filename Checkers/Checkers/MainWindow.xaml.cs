using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace Checkers
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Connect_Click(object sender, RoutedEventArgs e)
        {
            SendAndReceiveUserInfo();
        }

        //BFT TODO: Put this in another class
        public void SendAndReceiveUserInfo()
        {
            const int portNumber = 7777;
            const string serverIP = "10.2.20.16";
            ListBoxItem connectedUser = new ListBoxItem();
            try
            {
                TcpClient checkersGameClient = new TcpClient(serverIP, portNumber);
                NetworkStream outgoingStream = checkersGameClient.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(EnterName.Text);
                outgoingStream.Write(bytesToSend, 0, bytesToSend.Length);

                NetworkStream incomingStream = checkersGameClient.GetStream();
                byte[] bytesToRead = new byte[checkersGameClient.ReceiveBufferSize];
                int bytesRead = incomingStream.Read(bytesToRead, 0, checkersGameClient.ReceiveBufferSize);
                connectedUser.Content = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                UsersOnline.Items.Add(connectedUser);
                checkersGameClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
    }
}