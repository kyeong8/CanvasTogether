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
using Shapes;

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
        //public List<string> Users = new List<string>();
        public int UserCount = 0;
        public int RoomCount = 0;
        public List<string> roomNames = new List<string>();

        public List<List<Shape>> shapes = new List<List<Shape>>();
        
        //public List<string> Id = new List<string>();
        //public List<string> Pw = new List<string>();

        /* Page members */
        int pages = 1;

        public ServerForm()
        {
            InitializeComponent();
            // 패널 4개를 관리할 shapes 2차원 list 초기화
            shapes.Add(new List<Shape> { });
            shapes.Add(new List<Shape> { });
            shapes.Add(new List<Shape> { });
            shapes.Add(new List<Shape> { });
            lblCurrentPage.Text = 1.ToString();
            //panel2.BackColor = Color.Red;
            //panel3.BackColor = Color.Green;
            //panel4.BackColor = Color.Blue;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            for (int i = 0; i < 5; i++)
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

        public void ResponseUpdate(int ret1, int ret2)
        {
            printChat("[접속인원 재갱신]");
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                {
                    serverThreads[i].SendUpdate(ret1, ret2);
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

        public void ResponseUserUpdate(string roomNumber)
        {
            printChat("[" + roomNumber + "번방 접속인원 재갱신]");
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect && serverThreads[i].roomNumber == roomNumber)
                    serverThreads[i].SendUserUpdate(UserState[Convert.ToInt32(roomNumber)]);
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

        private void prevPageBtn_Click(object sender, EventArgs e)
        {
            int curPage = int.Parse(lblCurrentPage.Text);
            if (curPage == 1)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                lblCurrentPage.Text = 4.ToString();
                panel4.Focus();
            }
            else if (curPage == 2)
            {
                panel2.Visible = false;
                lblCurrentPage.Text = 1.ToString();
                panel1.Focus();
            }
            else if (curPage == 3)
            {
                panel3.Visible = false;
                panel2.Visible = true;
                lblCurrentPage.Text = 2.ToString();
                panel2.Focus();
            }
            else if (curPage == 4) 
            {
                panel4.Visible = false;
                panel3.Visible = true;
                lblCurrentPage.Text = 3.ToString();
                panel3.Focus();
            }
        }

        private void nextPageBtn_Click(object sender, EventArgs e)
        {
            int curPage = int.Parse(lblCurrentPage.Text);
            if (curPage == 1)
            {
                panel2.Visible = true;
                lblCurrentPage.Text = 2.ToString();
                panel2.Focus();
            }
            else if (curPage == 2)
            {
                panel3.Visible = true;
                lblCurrentPage.Text = 3.ToString();
                panel3.Focus();
            }
            else if (curPage == 3)
            {
                panel4.Visible = true;
                lblCurrentPage.Text = 4.ToString();
                panel4.Focus();
            }
            else if (curPage == 4)
            {
                panel4.Visible = false;
                panel3.Visible = false;
                panel2.Visible = false;
                lblCurrentPage.Text = 1.ToString();
                panel1.Focus();
            }
        }

        public void Draw()
        {
            this.Invoke(new Action(delegate ()
            {
                panel1.Invalidate(false);
                panel1.Update();
                panel2.Invalidate(false);
                panel2.Update();
                panel3.Invalidate(false);
                panel3.Update();
                panel4.Invalidate(false);
                panel4.Update();
            }));
        }

        public void all_Send_Freepen(int x1, int y1, int x2, int y2, int thick, int Argb, string roomNumber)
        {
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect && serverThreads[i].roomNumber == roomNumber)
                    serverThreads[i].Send_Freepen(x1, y1, x2, y2, thick, Argb);
            }
        }

        public void all_Send_Line(int x1, int y1, int x2, int y2, int thick, int Argb, string roomNumber)
        {
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect && serverThreads[i].roomNumber == roomNumber)
                    serverThreads[i].Send_Line(x1, y1, x2, y2, thick, Argb);
            }
        }

        public void all_Send_Rectangle(int x1, int y1, int x2, int y2, int thick, int Argb, string roomNumber)
        {
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect && serverThreads[i].roomNumber == roomNumber)
                    serverThreads[i].Send_Rectangle(x1, y1, x2, y2, thick, Argb);
            }
        }

        public void all_Send_Circle(int x1, int y1, int x2, int y2, int thick, int Argb, string roomNumber)
        {
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect && serverThreads[i].roomNumber == roomNumber)
                    serverThreads[i].Send_Circle(x1, y1, x2, y2, thick, Argb);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                foreach (var item in shapes[0])
                    item.DrawShape(e);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                foreach (var item in shapes[1])
                    item.DrawShape(e);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                foreach (var item in shapes[2])
                    item.DrawShape(e);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                foreach (var item in shapes[3])
                    item.DrawShape(e);
            }
            catch (Exception)
            {
                return;
            }
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
        private string existUser = null;
        private string visibility = null;

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

                    int ret1 = serverForm.UserCount;
                    int ret2 = serverForm.RoomCount;
                    serverForm.ResponseUpdate(ret1, ret2);
                    serverForm.ResponseRoomUpdate();

                    // TODO, shapes 배열이 처음에 null이라서 오류 뜸.

                    //if (serverForm.shapes[int.Parse(this.roomNumber) - 1].Count > 0)
                    //{
                    //    foreach (var item in serverForm.shapes[int.Parse(this.roomNumber) - 1])
                    //    {
                    //        if (item.GetName() == "Line")
                    //        {
                    //            MyLines temLine = (MyLines)item;
                    //            m_Write.WriteLine("Line");
                    //            m_Write.WriteLine(temLine.getPoint1().X);
                    //            m_Write.WriteLine(temLine.getPoint1().Y);
                    //            m_Write.WriteLine(temLine.getPoint2().X);
                    //            m_Write.WriteLine(temLine.getPoint2().Y);
                    //            m_Write.WriteLine(temLine.getThick());
                    //            m_Write.WriteLine(temLine.GetPen().Color.ToArgb());
                    //            m_Write.Flush();
                    //        }
                    //        else if (item.GetName() == "Circle")
                    //        {
                    //            MyCircle temCircle = (MyCircle)item;
                    //            m_Write.WriteLine("Circle");
                    //            m_Write.WriteLine(temCircle.getRectC().X);
                    //            m_Write.WriteLine(temCircle.getRectC().Y);
                    //            m_Write.WriteLine(temCircle.getRectC().Width);
                    //            m_Write.WriteLine(temCircle.getRectC().Height);
                    //            m_Write.WriteLine(temCircle.getThick());
                    //            m_Write.WriteLine(temCircle.GetPen().Color.ToArgb());
                    //            m_Write.Flush();
                    //        }
                    //        else if (item.GetName() == "Rectangle")
                    //        {
                    //            MyRect temRect = (MyRect)item;
                    //            m_Write.WriteLine("Rectangle");
                    //            m_Write.WriteLine(temRect.getRect().X);
                    //            m_Write.WriteLine(temRect.getRect().Y);
                    //            m_Write.WriteLine(temRect.getRect().Width);
                    //            m_Write.WriteLine(temRect.getRect().Height);
                    //            m_Write.WriteLine(temRect.getThick());
                    //            m_Write.WriteLine(temRect.GetPen().Color.ToArgb());
                    //            m_Write.Flush();
                    //        }
                    //    }
                    //}
                    
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
                    
                    enteredUser = m_Read.ReadLine();
                    roomNumber = m_Read.ReadLine();
                    if(!serverForm.UserState[Convert.ToInt32(roomNumber)].Contains(enteredUser))
                    {
                        serverForm.RoomCount += 1;
                        serverForm.UserState[Convert.ToInt32(roomNumber)].Add(enteredUser);
                    }
                    serverForm.ResponseMessage(enteredUser + "이(가) " + roomNumber + "번 방에 입장하였습니다.", roomNumber);
                    serverForm.ResponseUpdate(serverForm.UserCount, serverForm.RoomCount);
                }
                else if (Request.Equals("Update"))
                {
                    serverForm.ResponseUpdate(serverForm.UserCount, serverForm.RoomCount);
                }
                else if (Request.Equals("Room"))
                {
                    serverForm.ResponseRoomUpdate();
                }
                else if (Request.Equals("User"))
                {
                    roomNumber = m_Read.ReadLine();
                    existUser = m_Read.ReadLine();
                    serverForm.ResponseUserUpdate(roomNumber);
                }
                else if (Request.Equals("Out"))
                {
                    roomNumber = m_Read.ReadLine();
                    existUser = m_Read.ReadLine();

                    if (Convert.ToInt32(roomNumber) != 0)
                    {
                        if (serverForm.UserState[Convert.ToInt32(roomNumber)].Contains(existUser))
                        {
                            if (serverForm.RoomCount > 0)
                            {
                                serverForm.RoomCount -= 1;
                                serverForm.UserState[Convert.ToInt32(roomNumber)].Remove(enteredUser);
                            }
                        }
                        else
                            if (serverForm.UserCount > 0) serverForm.UserCount -= 1;
                    }

                    serverForm.ResponseUserUpdate(roomNumber);
                }
                else if (Request.Equals("Disconnect"))
                {
                    roomNumber = m_Read.ReadLine();
                    existUser = m_Read.ReadLine();

                    if (Convert.ToInt32(roomNumber) != 0)
                    {
                        if (serverForm.UserState[Convert.ToInt32(roomNumber)].Contains(existUser))
                        {
                            if (serverForm.RoomCount > 0) serverForm.RoomCount -= 1;
                            if (serverForm.UserCount > 0) serverForm.UserCount -= 1;
                            serverForm.UserState[Convert.ToInt32(roomNumber)].Remove(enteredUser);
                        }
                        else
                            if (serverForm.UserCount > 0) serverForm.UserCount -= 1;
                    }

                    serverForm.printChat(connectedClient + "이(가) 퇴장했습니다.");
                    
                    serverForm.ResponseUserUpdate(roomNumber);

                    m_bConnect = false;

                    serverForm.ResponseUpdate(serverForm.UserCount, serverForm.RoomCount);

                    return;
                }
                //else if(Request.Equals("Freepen"))
                //{
                //    int x = int.Parse(m_Read.ReadLine());
                //    int y = int.Parse(m_Read.ReadLine());
                //    int thick = int.Parse(m_Read.ReadLine());
                //    int Argb = int.Parse(m_Read.ReadLine());
                //    MyFreePen myFreePen = new MyFreePen();
                //    myFreePen.setRectF(new Point(x, y), new Pen(Color.FromArgb(Argb), thick), new SolidBrush(Color.FromArgb(Argb)), thick);
                //    Shape shape = myFreePen;
                //    serverForm.shapes[int.Parse(roomNumber)-1].Add(shape);
                //    serverForm.Draw();

                //    //serverForm.all_Send_Freepen(x, y, thick, Argb);
                //}
                else if (Request.Equals("Freepen"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int x2 = int.Parse(m_Read.ReadLine());
                    int y2 = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyLines myLine = new MyLines(2);
                    myLine.setPoint(new Point(x1, y1), new Point(x2, y2), new Pen(Color.FromArgb(Argb), thick), thick);
                    Shape shape = myLine;
                    serverForm.shapes[int.Parse(roomNumber) - 1].Add(shape);
                    serverForm.Draw();

                    serverForm.all_Send_Freepen(x1, y1, x2, y2, thick, Argb, roomNumber);
                }
                else if(Request.Equals("Line"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int x2 = int.Parse(m_Read.ReadLine());
                    int y2 = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyLines myLine = new MyLines(1);
                    myLine.setPoint(new Point(x1, y1), new Point(x2, y2), new Pen(Color.FromArgb(Argb), thick), thick);
                    Shape shape = myLine;
                    serverForm.shapes[int.Parse(roomNumber) - 1].Add(shape);
                    serverForm.Draw();

                    serverForm.all_Send_Line(x1, y1, x2, y2, thick, Argb, roomNumber);
                }
                else if(Request.Equals("Rectangle"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int wid = int.Parse(m_Read.ReadLine());
                    int hei = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyRect myRect = new MyRect();
                    myRect.setRect(new Point(x1, y1), new Point(x1 + wid, y1 + hei), new Pen(Color.FromArgb(Argb), thick), thick);
                    Shape shape = myRect;
                    serverForm.shapes[int.Parse(roomNumber) - 1].Add(shape);
                    serverForm.Draw();

                    serverForm.all_Send_Rectangle(x1, y1, wid, hei, thick, Argb, roomNumber);
                }
                else if(Request.Equals("Circle"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int wid = int.Parse(m_Read.ReadLine());
                    int hei = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyCircle myCircle = new MyCircle();
                    myCircle.setRectC(new Point(x1, y1), new Point(x1 + wid, y1 + hei), new Pen(Color.FromArgb(Argb), thick), thick);
                    Shape shape = myCircle;
                    serverForm.shapes[int.Parse(roomNumber) - 1].Add(shape);
                    serverForm.Draw();

                    serverForm.all_Send_Circle(x1, y1, wid, hei, thick, Argb, roomNumber);
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

        public void SendUpdate(int totalCount, int roomCount)
        {
            m_Write.WriteLine("Update");
            //MessageBox.Show(totalCount.ToString() + " " + roomCount.ToString());
            m_Write.WriteLine(roomCount.ToString());
            m_Write.WriteLine(totalCount.ToString());
            //MessageBox.Show(message.ToString());
            //serverForm.printChat("현재 접속인원 : " + message.ToString());
            m_Write.Flush();
        }

        public void SendUserUpdate(List<string> userState)
        {
            m_Write.WriteLine("User");
            m_Write.WriteLine(userState.Count.ToString());
            foreach (string name in userState)
                m_Write.WriteLine(name);
            //serverForm.printChat("현재 활성화 된 방 : " + message.ToString());
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

        public void Send_Freepen(int x1, int y1, int x2, int y2, int thick, int Argb)
        {
            m_Write.WriteLine("Freepen");
            m_Write.WriteLine(x1);
            m_Write.WriteLine(y1);
            m_Write.WriteLine(x2);
            m_Write.WriteLine(y2);
            m_Write.WriteLine(thick);
            m_Write.WriteLine(Argb);
            m_Write.Flush();
        }

        public void Send_Line(int x1, int y1, int x2, int y2, int thick, int Argb)
        {
            m_Write.WriteLine("Line");
            m_Write.WriteLine(x1);
            m_Write.WriteLine(y1);
            m_Write.WriteLine(x2);
            m_Write.WriteLine(y2);
            m_Write.WriteLine(thick);
            m_Write.WriteLine(Argb);
            m_Write.Flush();
        }

        public void Send_Circle(int x1, int y1, int wid, int hei, int thick, int Argb)
        {
            m_Write.WriteLine("Circle");
            m_Write.WriteLine(x1);
            m_Write.WriteLine(y1);
            m_Write.WriteLine(wid);
            m_Write.WriteLine(hei);
            m_Write.WriteLine(thick);
            m_Write.WriteLine(Argb);
            m_Write.Flush();
        }

        public void Send_Rectangle(int x1, int y1, int wid, int hei, int thick, int Argb)
        {
            m_Write.WriteLine("Rectangle");
            m_Write.WriteLine(x1);
            m_Write.WriteLine(y1);
            m_Write.WriteLine(wid);
            m_Write.WriteLine(hei);
            m_Write.WriteLine(thick);
            m_Write.WriteLine(Argb);
            m_Write.Flush();
        }

        public class DoubleBufferPanel : Panel
        {
            public DoubleBufferPanel()
            {
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint, true);
                this.UpdateStyles();
            }
        }
    }
}