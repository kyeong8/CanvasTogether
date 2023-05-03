using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace CanvasTogether
{
    public partial class ServerForm : Form
    {
        public static string ip, port, name, exitFlag;
        public Thread m_thServer = null;

        TcpListener m_listener;
        bool m_bStop;
        int index = 0;
        //public List<ServerThread> serverThreads = new List<ServerThread>();
        public ServerThread[] serverThreads = new ServerThread[10];

        public ServerForm()
        {
            InitializeComponent();

            ConnectModal connectModal = new ConnectModal();
            connectModal.ShowDialog();

            if (exitFlag == "Exit") this.Close();

            for (int i = 0; i < 10; i++)
                serverThreads[i] = new ServerThread(this);

            this.m_thServer = new Thread(new ThreadStart(ServerStart));
            this.m_thServer.Start();
        }

        public void ServerStart()
        {
            m_listener = new TcpListener(IPAddress.Any, 7777);
            m_listener.Start();

            m_bStop = true;

            while (m_bStop)
            {
                TcpClient hClient = m_listener.AcceptTcpClient();
                if (hClient.Connected)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (!serverThreads[i].m_bConnect)
                        {
                            index = i; break;
                        }
                    }
                    serverThreads[index].m_bConnect = true;
                    serverThreads[index].m_Stream = hClient.GetStream();
                    serverThreads[index].m_Read = new StreamReader(serverThreads[index].m_Stream);
                    serverThreads[index].m_Write = new StreamWriter(serverThreads[index].m_Stream);

                    serverThreads[index].m_thReader = new Thread(new ThreadStart(serverThreads[index].Receive));
                    serverThreads[index].m_thReader.Start();
                }
            }
        }

        public void printChat(string str)
        {
            this.Invoke(new Action(delegate ()
            {
                txtChat.AppendText(str + "\r\n");
            }));
        }

        public void Receive_Message(string message)
        {
            printChat(message);
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                    serverThreads[i].SendMessage(message);
            }
        }

        public void ServerThreadExit(ServerThread st)
        {
            if (!st.m_bConnect)
                return;

            st.m_Read.Close();
            st.m_Write.Close();

            st.m_Stream.Close();
            st.m_thReader.Abort();
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_listener.Stop();
            m_thServer.Abort();

            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                {
                    serverThreads[i].m_Read.Close();
                    serverThreads[i].m_Write.Close();

                    serverThreads[i].m_Stream.Close();
                    serverThreads[i].m_thReader.Abort();
                }
            }

            this.Close();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                {
                    serverThreads[i].m_Write.WriteLine("Message");
                    serverThreads[i].m_Write.WriteLine(name + " : " + txtInput.Text);
                    serverThreads[i].m_Write.Flush();
                }
            }
            printChat(name + " : " + txtInput.Text);

            txtInput.Clear();

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                {
                    serverThreads[i].m_Write.WriteLine("Message");
                    serverThreads[i].m_Write.WriteLine(name + " : " + txtInput.Text);
                    serverThreads[i].m_Write.Flush();
                }
            }
            printChat(name + " : " + txtInput.Text);

            txtInput.Clear();
        }

    }

    public class ServerThread
    {
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        public bool m_bConnect = false;
        private ServerForm serverForm;
        public Thread m_thReader = null;
        private string connectedClient;

        public ServerThread(ServerForm serverForm)
        {
            this.serverForm = serverForm;
        }

        public void Receive()
        {
            string Request;
            while (m_bConnect)
            {
                Request = m_Read.ReadLine();
                if (Request.Equals("New Client"))
                {
                    connectedClient = m_Read.ReadLine();
                    serverForm.printChat(connectedClient + "이(가) 입장했습니다.");
                }
                else if (Request.Equals("Message"))
                {
                    serverForm.Receive_Message(m_Read.ReadLine());
                }
                else if (Request.Equals("Disconnect"))
                {
                    serverForm.printChat(connectedClient + "이(가) 퇴장했습니다.");
                    m_bConnect = false;
                    return;
                }
            }
            serverForm.ServerThreadExit(this);
        }

        public void SendMessage(string message)
        {
            m_Write.WriteLine("Message");
            m_Write.WriteLine(message);
            m_Write.Flush();
        }
    }
}
