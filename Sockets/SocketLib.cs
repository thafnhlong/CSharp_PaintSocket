using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Do_An_3.Sockets
{
    public class SocketLib
    {
        public Socket MySocket = null;

        public SocketLib()
        {
            Host = "127.0.0.1"; Port = 1234;
            Init();
        }

        public SocketLib(string _Host, int _Port)
        {
            Host = _Host;
            Port = _Port;
            Init();
        }
        public void Init()
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Host);
                IPA = ipHostInfo.AddressList[0];
                IPEP = new IPEndPoint(IPA, Port);
                MySocket = new Socket(IPA.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Initialization");
            }
        }
        public bool MakeServer()
        {
            try
            {
                MySocket.Bind(IPEP);
                MySocket.Listen(100);
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Listen");
                return false;
            }
            return true;
        }
        public bool ConnectServer()
        {
            try
            {
                MySocket.Connect(IPEP);
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Connect");
                return false;
            }
            return true;
        }
        public void Release()
        {
            try
            {
                MySocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception) { }
            MySocket.Close();
        }

        protected string Host;
        protected int Port;
        protected IPAddress IPA;
        protected IPEndPoint IPEP;
    }
}
