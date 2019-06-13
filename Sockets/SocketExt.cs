using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Do_An_3.Sockets
{
    public class SocketExt
    {
        public class SocketData
        {
            public static int BufferLength = 1024;
            public byte[] Buffer = new byte[BufferLength];
        }
        public class ClientData
        {
            public int ID;
        }
        public class ClientStruct
        {
            public SocketData socketdata = new SocketData();
            public ClientData clientdata = new ClientData();
            public Socket client = null;
            public void Destructor()
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        public delegate void ReceiveDataHandler(string Data);
        public ReceiveDataHandler ReceiveData;
        public delegate void ExitDrawHandler(int index);
        public ExitDrawHandler ExitDraw;
        public delegate void ClientStatusHandler(int count);
        public ClientStatusHandler ClientStatus;

        public int ID = 0;
        public SocketLib sl = null;
        public List<ClientStruct> clientList { get; set; }
        public bool IsDisopose { get; private set; } = false;

        public SocketExt() { sl = new SocketLib(); }
        public SocketExt(string _Host, int _Port, bool MakeSV)
        {
            sl = new SocketLib(_Host, _Port);
        }

        public bool MakeSV()
        {
            ID = -1;
            if (!sl.MakeServer()) return false;
            clientList = new List<ClientStruct>();
            ConnectThread = new Thread(p =>
            {
                while (true)
                {
                    ClientStruct cs = new ClientStruct();
                    cs.client = sl.MySocket.Accept();
                    cs.clientdata.ID = sttid++;
                    clientList.Add(cs);

                    ClientStatus?.Invoke(clientList.Count);

                    try
                    {
                        Send(cs.client, cs.clientdata.ID.ToString());

                        cs.client.BeginReceive(cs.socketdata.Buffer, 0, SocketData.BufferLength, 0,
                            new AsyncCallback(ReceiveCallbackSV), cs);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.ToString() + "\nClient bi xoa");
                        //client bi xoa
                        cs.Destructor();
                        clientList.Remove(cs);
                        ClientStatus?.Invoke(clientList.Count);
                    }
                }
            });
            ConnectThread.Start();
            return true;
        }
        public bool ConnectSV()
        {
            if (!sl.ConnectServer()) return false;
            ClientStruct cs = new ClientStruct();
            cs.client = sl.MySocket;

            try
            {
                int length = cs.client.Receive(cs.socketdata.Buffer);
                ID = int.Parse(UnicodeEncoding.ASCII.GetString(cs.socketdata.Buffer, 0, length));

                cs.client.BeginReceive(cs.socketdata.Buffer, 0, SocketData.BufferLength, 0,
                            new AsyncCallback(ReceiveCallbackCL), cs);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString() + "\nServer dong ket noi");
                //sv dong ket noi
                ExitDraw?.Invoke(-1);
                Release();
            }
            return true;
        }
        public void Release()
        {
            sl.Release();
            if (ConnectThread != null) ConnectThread.Abort();
            if (clientList != null)
            {
                for (int i = clientList.Count - 1; i >= 0; i--)
                {
                    var cl = clientList[i];
                    cl.Destructor();
                    clientList.Remove(cl);
                }
            }
            IsDisopose = true;
        }
        public void Send(Socket cur, string Data)
        {
            cur.Send(UnicodeEncoding.ASCII.GetBytes(Data));
        }

        private static int sttid = 1;
        private Thread ConnectThread;

        private void ReceiveCallbackSV(IAsyncResult ar)
        {
            ClientStruct cs = ar.AsyncState as ClientStruct;

            try
            {
                string gettingdata = UnicodeEncoding.ASCII.GetString(cs.socketdata.Buffer, 0, cs.client.EndReceive(ar));

                ReceiveData?.Invoke(gettingdata);

                cs.client.BeginReceive(cs.socketdata.Buffer, 0, SocketData.BufferLength, 0,
                                new AsyncCallback(ReceiveCallbackSV), cs);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString() + "\nClient bi xoa");
                //client bi xoa
                cs.Destructor();
                clientList.Remove(cs);
                ExitDraw?.Invoke(cs.clientdata.ID);
                ClientStatus?.Invoke(clientList.Count);
            }
        }
        private void ReceiveCallbackCL(IAsyncResult ar)
        {
            ClientStruct cs = ar.AsyncState as ClientStruct;

            try
            {
                string gettingdata = UnicodeEncoding.ASCII.GetString(cs.socketdata.Buffer, 0, cs.client.EndReceive(ar));

                ReceiveData?.Invoke(gettingdata);

                cs.client.BeginReceive(cs.socketdata.Buffer, 0, SocketData.BufferLength, 0,
                                new AsyncCallback(ReceiveCallbackCL), cs);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString() + "\nServer dong ket noi");
                //sv dong ket noi
                ExitDraw?.Invoke(-1);
                Release();
            }

        }
    }

}
