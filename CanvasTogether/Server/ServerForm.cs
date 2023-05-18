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
        public Thread m_thServer = null;

        TcpListener m_listener;
        bool m_bStop;
        int index = 0;
        //public List<ServerThread> serverThreads = new List<ServerThread>();
        public ServerThread[] serverThreads = new ServerThread[10];
        public List<List<string>> UserState = new List<List<string>>();
        public List<string> Users = new List<string>();
        public int UserCount = 0;
        public List<string> roomNames = new List<string>();
        public List<string> Id = new List<string>();
        public List<string> Pw = new List<string>();

        public ServerForm()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++)
                UserState.Add(new List<string>());

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

        public void ResponseMessage(string message, string roomNumber)
        {
            printChat("[" + roomNumber + "번방]" + message);
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect && serverThreads[i].roomNumber == roomNumber)
                    serverThreads[i].SendMessage(message);
            }
        }

        public void ResponseUpdate(int ret)
        {
            printChat("[접속인원 재갱신]");
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                {
                    serverThreads[i].SendUpdate(ret);
                }
            }
        }

        public void ResponseRoomUpdate()
        {
            printChat("[활성화 된 방 재갱신]");
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                {
                    serverThreads[i].SendRoomUpdate(roomNames);
                }
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

    }

    public class ServerThread
    {
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        public bool m_bConnect = false;
        private ServerForm serverForm;
        public Thread m_thReader = null;
        private string connectedClient = null;
        private string enteredUser = null;
        public string roomNumber = null;
        private string roomName = null;
        private bool isExist = false;
        private string existUser = null;

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
                    serverForm.UserCount += 1;
                    serverForm.printChat(connectedClient + "이(가) 접속했습니다.");

                    int ret = serverForm.UserCount;
                    serverForm.ResponseUpdate(ret);
                    serverForm.ResponseRoomUpdate();
                }
                else if (Request.Equals("Message"))
                {
                    serverForm.ResponseMessage(m_Read.ReadLine(), roomNumber);
                }
                else if (Request.Equals("Generate"))
                {
                    roomName = m_Read.ReadLine();
                    serverForm.roomNames.Add(roomName);
                    serverForm.ResponseRoomUpdate();
                    serverForm.printChat(roomName + "이(가) 생성되었습니다.");
                }
                else if (Request.Equals("Enter"))
                {
                    serverForm.UserCount += 100;
                    enteredUser = m_Read.ReadLine();
                    roomNumber = m_Read.ReadLine();
                    serverForm.UserState[Convert.ToInt32(roomNumber)].Add(enteredUser);
                    serverForm.ResponseMessage(enteredUser + "이(가) " + roomNumber + "번 방에 입장하였습니다.", roomNumber);
                    serverForm.ResponseUpdate(serverForm.UserCount);
                }
                else if (Request.Equals("Update"))
                {
                    int ret = serverForm.UserCount;
                    SendUpdate(ret);
                }
                else if (Request.Equals("Disconnect"))
                {
                    m_bConnect = false;

                    existUser = m_Read.ReadLine();
                    foreach (List<string> row in serverForm.UserState)
                    {
                        if (row.Contains(existUser))
                        {
                            isExist = true;
                            break;
                        }
                    }

                    if (isExist)
                    {
                        if (serverForm.UserCount - 100 > -1) serverForm.UserCount -= 100;
                        if (serverForm.UserCount > 0) serverForm.UserCount -= 1;
                    }
                    else
                        if (serverForm.UserCount > 0) serverForm.UserCount -= 1;

                    serverForm.printChat(connectedClient + "이(가) 퇴장했습니다.");

                    int ret = serverForm.UserCount;
                    serverForm.ResponseUpdate(ret);

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

        public void SendUpdate(int message)
        {
            m_Write.WriteLine("Update");
            m_Write.WriteLine((message / 100).ToString());
            m_Write.WriteLine((message % 100).ToString());
            //MessageBox.Show(message.ToString());
            //serverForm.printChat("현재 접속인원 : " + message.ToString());
            m_Write.Flush();
        }

        public void SendRoomUpdate(List<string> names)
        {
            m_Write.WriteLine("Room");
            m_Write.WriteLine(names.Count.ToString());
            foreach (string name in names)
                m_Write.WriteLine(name);
            //serverForm.printChat("현재 활성화 된 방 : " + message.ToString());
            m_Write.Flush();
        }
    }
}
