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
using System.Security.Cryptography.X509Certificates;

namespace Wpfsockets
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class SocketData
        {
            public const int BufferSize = 1024;
            public Socket ClientConnection { get; set; }
            byte[] buffer = new byte[BufferSize];
            public byte[] Buffer
            {
                get { return buffer; }
                set { buffer = value; }
            }
        }
       
        public void OpenServer() 
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint point = new IPEndPoint(IPAddress.Any, 999);
            socket.Bind(point);
            Log.Text = socket.LocalEndPoint.ToString();
            socket.Listen(100);
            socket.Close();
        }

        public void Connect() 
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint point = new IPEndPoint(IPAddress.Any, 999);
            socket.Bind(point);
            socket.Listen(0);
            
            SocketData data = new SocketData();
            string hostString="";

            
                foreach(char c in Log.Text) 
                {
                if(c == ':') { break; }
                hostString += c;
                }

            Log.Text = hostString;
            //serverSocket.Connect(,);
            socket.Close();
        }
        public MainWindow()
        {
            InitializeComponent();
            



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenServer();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Connect();
        }
    }
}
