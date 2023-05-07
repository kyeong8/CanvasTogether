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
using System.Data.SQLite;
using Server;

namespace CanvasTogether
{
    public partial class ServerForm : Form
    {
        // Variables Declaration =============================
        public static string ip, port, name, exitFlag;
        public Thread m_thServer = null;

        TcpListener m_listener;
        bool m_bStop;
        int index = 0;
        //public List<ServerThread> serverThreads = new List<ServerThread>();
        public ServerThread[] serverThreads = new ServerThread[10];

        int pages = 1;
        int curMode;

        private PictureBox movingPictureBox;

        // Shapes variables
        private bool freePen;
        private bool line;
        private bool rect;
        private bool circle;
        private Point start; // 도형의 시작점
        private Point finish; // 도형의 끝점
        private Pen pen; // 펜
        private int nfreepen; // 저장된 자유펜 개수
        private int nline; // 저장된 선 개수
        private int nrect; // 저장된 사각형 개수
        private int ncircle; // 저장된 원 개수
        private int i;
        private int thick; // 선 두께
        private MyFreePen[] myfreepens;
        private MyLines[] mylines;
        private MyRect[] myrect;
        private MyCircle[] mycircle;

        private void SetupShapeVar()
        {
            i = 0;
            thick = 1;
            freePen = false;
            line = false;
            rect = false;
            circle = false;
            start = new Point(0, 0);
            finish = new Point(0, 0);
            pen = new Pen(Color.Black);
            myfreepens = new MyFreePen[1000];
            mylines = new MyLines[100];
            myrect = new MyRect[100];
            mycircle = new MyCircle[100];
            nfreepen = 0;
            nline = 0;
            nrect = 0;
            ncircle = 0;

            SetupMine();
        }

        private void SetupMine()
        {
            for (int i = 0; i < 1000; i++)
                myfreepens[i] = new MyFreePen();
            for (int i = 0; i < 100; i++)
                mylines[i] = new MyLines();
            for (int i = 0; i < 100; i++)
                myrect[i] = new MyRect();
            for (int i = 0; i < 100; i++)
                mycircle[i] = new MyCircle();
        }

        public ServerForm()
        {
            InitializeComponent();
            SetupShapeVar();

            lblCurrentPage.Text = 1.ToString();
            //panel2.BackColor = Color.MintCream;
            //panel3.BackColor = Color.Red;
            panel2.Visible = false;
            panel3.Visible = false;

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

        private void createPageBtn_Click(object sender, EventArgs e)
        {
            if (pages >= 3)
            {
                MessageBox.Show("최대 3개의 페이지를 만들 수 있습니다.");
                return;
            }
            if (pages == 1)
            {
                panel2.Visible = true;
                panel2.BackColor = Color.MintCream;
                lblCurrentPage.Text = 2.ToString();
                pages++;
            }
            else if (pages == 2)
            {
                panel3.Visible = true;
                panel3.BackColor = Color.Red;
                lblCurrentPage.Text = 3.ToString();
                pages++;
            }
        }

        private void prevPageBtn_Click(object sender, EventArgs e)
        {
            int curPage = int.Parse(lblCurrentPage.Text);
            if (pages == 1)
            {
                return;
            }
            else if (pages == 2)
            {
                if (curPage == 1)
                {
                    panel2.Visible = true;
                    lblCurrentPage.Text = 2.ToString();
                }
                else if (curPage == 2)
                {
                    panel2.Visible = false;
                    lblCurrentPage.Text = 1.ToString();
                }
            }
            else if (pages == 3)
            {
                if (curPage == 1)
                {
                    panel2.Visible = true;
                    panel3.Visible = true;
                    lblCurrentPage.Text = 3.ToString();
                }
                else if (curPage == 2)
                {
                    panel2.Visible = false;
                    lblCurrentPage.Text = 1.ToString();
                }
                else if (curPage == 3)
                {
                    panel3.Visible = false;
                    lblCurrentPage.Text = 2.ToString();
                }
            }
        }

        private void nextPageBtn_Click(object sender, EventArgs e)
        {
            int curPage = int.Parse(lblCurrentPage.Text);
            if (pages == 1)
            {
                return;
            }
            else if (pages == 2)
            {
                if (curPage == 1)
                {
                    panel2.Visible = true;
                    lblCurrentPage.Text = 2.ToString();
                }
                else if (curPage == 2)
                {
                    panel2.Visible = false;
                    lblCurrentPage.Text = 1.ToString();
                }
            }
            else if (pages == 3)
            {
                if (curPage == 1)
                {
                    panel2.Visible = true;
                    lblCurrentPage.Text = 2.ToString();
                }
                else if (curPage == 2)
                {
                    panel3.Visible = true;
                    lblCurrentPage.Text = 3.ToString();
                }
                else if (curPage == 3)
                {
                    panel3.Visible = false;
                    panel2.Visible = false;
                    lblCurrentPage.Text = 1.ToString();
                }
            }
        }

        private void delPageBtn_Click(object sender, EventArgs e)
        {
            if (pages == 1)
            {
                MessageBox.Show("페이지를 삭제할 수 없습니다.");
                return;
            }
            else if (pages == 2)
            {
                pages--;
                panel2.Visible = false;
                lblCurrentPage.Text = 1.ToString();
            }
            else if (pages == 3)
            {
                pages--;
                panel3.Visible = false;
                lblCurrentPage.Text=2.ToString();
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == penButton)
            {
                freePen = true;
                line = false;
                rect = false;
                circle = false;

                this.penButton.Pushed = true;
                this.lineButton.Pushed = false;
                this.rectButton.Pushed = false;
                this.circleButton.Pushed = false;
            }
            if(e.Button == lineButton)
            {
                freePen = false;
                line = true;
                rect = false;
                circle = false;

                this.penButton.Pushed = false;
                this.lineButton.Pushed = true;
                this.rectButton.Pushed = false;
                this.circleButton.Pushed = false;
            }
            if (e.Button == rectButton)
            {
                freePen = false;
                line = false;
                rect = true;
                circle = false;

                this.penButton.Pushed = false;
                this.lineButton.Pushed = false;
                this.rectButton.Pushed = true;
                this.circleButton.Pushed = false;
            }
            if(e.Button == circleButton)
            {
                freePen = false;
                line = false;
                rect = false;
                circle = true;

                this.penButton.Pushed = false;
                this.lineButton.Pushed = false;
                this.rectButton.Pushed = false;
                this.circleButton.Pushed = true;
            }
            if (e.Button == imageButton)
            {
                this.imageButton.Pushed = true;
                this.penButton.Pushed = false;
                this.eraserButton.Pushed = false;
                this.lineButton.Pushed = false;
                this.rectButton.Pushed = false;
                this.circleButton.Pushed = false;
                this.fillButton.Pushed = false;
                this.textButton.Pushed = false;

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG,*.PNG";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PictureBox p = new PictureBox();
                    
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Image = Image.FromFile(dialog.FileName);
                    p.Left = 100;
                    p.Top = 100;
                    p.Width = p.Image.Width;
                    p.Height = p.Image.Height;
                    panel1.Controls.Add(p);

                    p.MouseDown += p_MouseDown;
                    p.MouseMove += p_MouseMove;
                    p.MouseUp += p_MouseUp;
                }
            }
        }
        private void p_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                movingPictureBox = (PictureBox)sender;
            }
        }
        private void p_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && movingPictureBox != null)
            {
                movingPictureBox.Left = e.X + movingPictureBox.Left - movingPictureBox.Width / 2;
                movingPictureBox.Top = e.Y + movingPictureBox.Top - movingPictureBox.Height / 2;
            }
        }

        private void p_MouseUp(object sender, MouseEventArgs e)
        {
            movingPictureBox = null; // PictureBox 객체 초기화
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            start.X = e.X;
            start.Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (start.X == 0 && start.Y == 0)
                return;

            finish.X = e.X;
            finish.Y = e.Y;

            if (freePen == true)
            {
                Point curPoint = panel1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                myfreepens[nfreepen].setRectF(curPoint, thick);
                nfreepen++;
            }
            if (line == true)
            {
                mylines[nline].setPoint(start, finish, thick);
            }
            if (rect == true)
            {
                myrect[nrect].setRect(start, finish, thick);
            }
            if (circle == true)
            {
                mycircle[ncircle].setRectC(start, finish, thick);
            }
            panel1.Invalidate(true);
            panel1.Update();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for(i=0; i<nfreepen; i++)
            {
                pen.Width = myfreepens[i].getThick();
                e.Graphics.DrawEllipse(pen, myfreepens[i].getRectF());
            }

            for (i = 0; i <= nline; i++) 
            {
                pen.Width = mylines[i].getThick();
                e.Graphics.DrawLine(pen, mylines[i].getPoint1(), mylines[i].getPoint2());
            }

            for (i = 0; i <= nrect; i++)
            {
                pen.Width = myrect[i].getThick();
                e.Graphics.DrawRectangle(pen, myrect[i].getRect());
            }

            for (i = 0; i <= ncircle; i++)
            {
                pen.Width = mycircle[i].getThick();
                e.Graphics.DrawEllipse(pen, mycircle[i].getRectC());
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (line == true)
                nline++;
            if (rect == true)
                nrect++;
            if (circle == true)
                ncircle++;

            start.X = 0;
            start.Y = 0;
            finish.X = 0;
            finish.Y = 0;
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
