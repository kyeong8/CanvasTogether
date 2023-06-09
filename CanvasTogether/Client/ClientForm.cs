using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Data.Entity.Migrations.Builders;
using Shapes;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace CanvasTogether
{
    public partial class ClientForm : Form
    {
        enum CANVAS_MODE
        {
            PENMODE = 0, // 펜 모드
            LINEMODE = 1, // 선 모드
            RECTMODE = 2, // 사각형 모드
            CIRCLEMODE = 3, // 원 모드
            PAINTMODE = 4, // 채우기 모드
            ERASERMODE = 5, // 지우개 모드
            TEXTMODE = 6, // 텍스트 모드
        }

        NetworkStream m_Stream;
        TcpClient m_Client;
        StreamReader m_Read;
        StreamWriter m_Write;
        BinaryWriter m_bWrite;
        BinaryReader m_bRead;
        private Thread m_thReader;
        bool m_bConnect;
        public static string id;
        public static string name;
        public static string totalCount = "0";
        public static string roomCount = "0";
        public static bool exitFlag = true;
        public static int enterRoomNumber = 0;
        public Lobby lobby = new Lobby();
        public static List<string> userNames = new List<string>();
        public static List<string> roomNames = new List<string>();
        public static bool closeFlag = false;
        public static bool shutdownTrigger = false;
        bool isHolding = false;
        bool holdingFreepen = false;
        bool SaveFreepen = false;
        bool undoing = false;
        bool freepenEnd = false;
        public static bool dead = false;

        delegate void fnSetTextBoxCallback(string contents);
        delegate void fnSetResetTextCallback();

        int pages = 1;
        int curMode;
        int _polygon = 1;
        int _thick = 1;
        int tempX;
        int tempY;

        Color currentColor = Color.Black;   //현재 적용된 컬러(1/2/3)

        // ==========================================

        public List<Point> freepenStore = new List<Point>(); // 점 2개 모일 때마다 서버로 전송
        private Point startF; // freepen의 끝점
        private Point finishF; // freepen의 끝점
        private Point startE; // eraser의 시작점
        private Point finishE; // eraser의 끝점
        private Point start; // 도형의 시작점
        private Point finish; // 도형의 끝점

        private MyLines[] mylines;
        private MyRect[] myrect;
        private MyCircle[] mycircle;
        Pen pen; // 펜
        SolidBrush brush = new SolidBrush(Color.Black);

        Shape shape;
        MyLines myLine;
        MyCircle myCircle;
        MyRect myRect;
        Bitmap bitmap;
        private List<Shape> shapes = new List<Shape>();

        private Bitmap OriginalBmp;
        private Bitmap DrawBmp;
        private Bitmap fpBmp;
        private Bitmap currentBmp;
        private List<Bitmap> BmpList = new List<Bitmap>();
        private List<Bitmap> tmpList = new List<Bitmap>();//undo
        private List<Bitmap> fpList = new List<Bitmap>();
        MemoryStream ms;
        bool firstClick = true;
        Point zero = new Point(0, 0);
        NetworkStream networkStream;
        MemoryStream memoryStream;
        public byte[] buffer = new byte[1024 * 100];
        private void SetupShapeVar()
        {
            start = new Point(0, 0);
            finish = new Point(0, 0);
            pen = new Pen(currentColor);
            brush = new SolidBrush(currentColor);
        }

        private PictureBox movingPictureBox;

        public ClientForm()
        {
            InitializeComponent();
            SetupShapeVar();
            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            panel1.BackgroundImage = new Bitmap(Application.StartupPath + @"\DefaultBackground.png");
            OriginalBmp = (Bitmap)panel1.BackgroundImage;
            BmpList.Add(OriginalBmp);
            fpList.Add(OriginalBmp);
            //tmpList.Add(OriginalBmp);
            //lblCurrentPage.Text = 1.ToString();
            //panel2.BackColor = Color.MintCream;
            //panel3.BackColor = Color.Red;
            //panel2.Visible = false;
            //panel3.Visible = false;


            Login login = new Login();
            login.ShowDialog();

            if (exitFlag)
            {
                this.Close();
                return;
            }

            Connect();

            if (!m_bConnect)
            {
                MessageBox.Show("서버가 구동되고 있지 않습니다.");
                this.Close();
                return;
            }

            exitFlag = true;

            lobby = new Lobby();
            lobby.form2SendEvent += new Lobby.FormSendDataHandler(requestGenerate);
            lobby.form2SendUpdate += new Lobby.FormSendUpdateHandler(requestEnterUpdate);
            lobby.ShowDialog();


            if (exitFlag)
            {
                object sender = null;
                FormClosingEventArgs e = null;
                this.ClientForm_FormClosing(sender, e);
            }
            else
            {
                requestUpdate();
            }

            exitFlag = true;
        }

        public bool getFlag()
        {
            return dead;
        }

        private void Btn_shape_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == item_line)
            {
                btn_shape.Image = item_line.Image;
                _polygon = 0; // line
            }
            else if (e.ClickedItem == item_rect)
            {
                btn_shape.Image = item_rect.Image;
                _polygon = 1; // rect
            }
            else if (e.ClickedItem == item_circle)
            {
                btn_shape.Image = item_circle.Image;
                _polygon = 2; // circle
            }
        }

        private void Btn_thick_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == item_Thick1)
            {
                btn_thick.Image = item_Thick1.Image;
                _thick = 1;
            }
            else if (e.ClickedItem == item_Thick2)
            {
                btn_thick.Image = item_Thick2.Image;
                _thick = 2;
            }
            else if (e.ClickedItem == item_Thick3)
            {
                btn_thick.Image = item_Thick3.Image;
                _thick = 3;
            }
            else if (e.ClickedItem == item_Thick4)
            {
                btn_thick.Image = item_Thick4.Image;
                _thick = 4;
            }
            else if (e.ClickedItem == item_Thick5)
            {
                btn_thick.Image = item_Thick5.Image;
                _thick = 5;
            }
            pen = new Pen(currentColor, _thick);
        }

        private void doFloodFill(Bitmap temBmp, Point startPoint, Color preColor)
        {
            try
            {
                Stack<Point> pixels = new Stack<Point>();
                preColor = temBmp.GetPixel(startPoint.X, startPoint.Y);
                pixels.Push(startPoint);

                while (pixels.Count > 0)
                {
                    Point i = pixels.Pop();
                    if (i.X < temBmp.Width && i.X > 0 && i.Y < temBmp.Height && i.Y > 0)
                    {
                        if (temBmp.GetPixel(i.X, i.Y) == preColor)
                        {
                            temBmp.SetPixel(i.X, i.Y, currentColor);
                            pixels.Push(new Point(i.X - 1, i.Y));
                            pixels.Push(new Point(i.X + 1, i.Y));
                            pixels.Push(new Point(i.X, i.Y - 1));
                            pixels.Push(new Point(i.X, i.Y + 1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void createPageBtn_Click(object sender, EventArgs e)
        //{
        //    if (pages >= 3)
        //    {
        //        MessageBox.Show("최대 3개의 페이지를 만들 수 있습니다.");
        //        return;
        //    }
        //    if (pages == 1)
        //    {
        //        panel2.Visible = true;
        //        panel2.BackColor = Color.MintCream;
        //        lblCurrentPage.Text = 2.ToString();
        //        pages++;
        //    }
        //    else if (pages == 2)
        //    {
        //        panel3.Visible = true;
        //        panel3.BackColor = Color.Red;
        //        lblCurrentPage.Text = 3.ToString();
        //        pages++;
        //    }
        //}

        //private void prevPageBtn_Click(object sender, EventArgs e)
        //{
        //    int curPage = int.Parse(lblCurrentPage.Text);
        //    if (pages == 1)
        //    {
        //        return;
        //    }
        //    else if (pages == 2)
        //    {
        //        if (curPage == 1)
        //        {
        //            panel2.Visible = true;
        //            lblCurrentPage.Text = 2.ToString();
        //        }
        //        else if (curPage == 2)
        //        {
        //            panel2.Visible = false;
        //            lblCurrentPage.Text = 1.ToString();
        //        }
        //    }
        //    else if (pages == 3)
        //    {
        //        if (curPage == 1)
        //        {
        //            panel2.Visible = true;
        //            panel3.Visible = true;
        //            lblCurrentPage.Text = 3.ToString();
        //        }
        //        else if (curPage == 2)
        //        {
        //            panel2.Visible = false;
        //            lblCurrentPage.Text = 1.ToString();
        //        }
        //        else if (curPage == 3)
        //        {
        //            panel3.Visible = false;
        //            lblCurrentPage.Text = 2.ToString();
        //        }
        //    }
        //}

        //private void nextPageBtn_Click(object sender, EventArgs e)
        //{
        //    int curPage = int.Parse(lblCurrentPage.Text);
        //    if (pages == 1)
        //    {
        //        return;
        //    }
        //    else if (pages == 2)
        //    {
        //        if (curPage == 1)
        //        {
        //            panel2.Visible = true;
        //            lblCurrentPage.Text = 2.ToString();
        //        }
        //        else if (curPage == 2)
        //        {
        //            panel2.Visible = false;
        //            lblCurrentPage.Text = 1.ToString();
        //        }
        //    }
        //    else if (pages == 3)
        //    {
        //        if (curPage == 1)
        //        {
        //            panel2.Visible = true;
        //            lblCurrentPage.Text = 2.ToString();
        //        }
        //        else if (curPage == 2)
        //        {
        //            panel3.Visible = true;
        //            lblCurrentPage.Text = 3.ToString();
        //        }
        //        else if (curPage == 3)
        //        {
        //            panel3.Visible = false;
        //            panel2.Visible = false;
        //            lblCurrentPage.Text = 1.ToString();
        //        }
        //    }
        //}

        //private void delPageBtn_Click(object sender, EventArgs e)
        //{
        //    if (pages == 1)
        //    {
        //        MessageBox.Show("페이지를 삭제할 수 없습니다.");
        //        return;
        //    }
        //    else if (pages == 2)
        //    {
        //        pages--;
        //        panel2.Visible = false;
        //        lblCurrentPage.Text = 1.ToString();
        //    }
        //    else if (pages == 3)
        //    {
        //        pages--;
        //        panel3.Visible = false;
        //        lblCurrentPage.Text = 2.ToString();
        //    }
        //}

        // private Cursor LoadCursor()

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


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            txtChat.ResetText();

            //MessageBox.Show(totalCount.ToString() + " " + roomCount.ToString());

            requestOut(false);
            requestRoomUpdate();
            requestUpdate();

            closeFlag = false;
            this.lobby = new Lobby();
            this.lobby.form2SendEvent += new Lobby.FormSendDataHandler(requestGenerate);
            this.lobby.form2SendUpdate += new Lobby.FormSendUpdateHandler(requestEnterUpdate);

            this.lobby.uiUpdate();

            this.lobby.ShowDialog();


            if (exitFlag)
            {
                FormClosingEventArgs er = null;
                this.ClientForm_FormClosing(sender, er);
            }

            exitFlag = true;
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (shutdownTrigger)
            {
                MessageBox.Show("중복 로그인이 감지 되었습니다.");
            }
            else
            {
                dead = true;

                if (!m_bConnect)
                    return;

                //MessageBox.Show(enterRoomNumber.ToString());
                m_Write.WriteLine("Disconnect");
                m_Write.WriteLine(id);
                m_Write.WriteLine(enterRoomNumber.ToString());
                m_Write.Flush();
                requestOut(true);

                FormClosedEventArgs ee = null;
                ClientForm_FormClosed(sender, ee);
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            m_Write.WriteLine("Message");

            m_Write.WriteLine(name + " : " + txtInput.Text.Replace("\r\n", ""));
            m_Write.Flush();
            txtInput.Clear();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }
        private void SetTextboxInput(string contents)
        {
            this.userCnt.Text = contents;
        }
        private void SetResetText()
        {
            this.userNameList.ResetText();
        }

        public void Connect()
        {
            m_Client = new TcpClient();
            try
            {
                m_Client.Connect(IPAddress.Parse("127.0.0.1"), 7777);
            }
            catch
            {
                m_bConnect = false;
                return;
            }
            m_bConnect = true;

            m_Stream = m_Client.GetStream();

            networkStream = m_Stream;

            m_Read = new StreamReader(m_Stream);
            m_Write = new StreamWriter(m_Stream);
            m_bRead = new BinaryReader(m_Stream);
            m_bWrite = new BinaryWriter(m_Stream);
            m_thReader = new Thread(new ThreadStart(Receive));
            m_thReader.Start();
        }

        public void requestUpdate()
        {
            m_Write.WriteLine("Update");
            m_Write.Flush();
        }

        public void requestOut(bool flag)
        {
            m_Write.WriteLine("Out");
            m_Write.WriteLine(enterRoomNumber.ToString());
            m_Write.WriteLine(name);
            if (flag)
                m_Write.WriteLine("true");
            else
                m_Write.WriteLine("false");
            m_Write.Flush();
        }

        public void requestEnterUpdate(bool flag)
        {
            if (!flag)
            {
                this.Visible = true;
                m_Write.WriteLine("Enter");
                m_Write.WriteLine(name);
                m_Write.WriteLine(enterRoomNumber.ToString());
                m_Write.Flush();

                requestUserUpdate(enterRoomNumber.ToString());
            }
        }
        public void requestUserUpdate(string text)
        {
            m_Write.WriteLine("User");
            m_Write.WriteLine(text);
            m_Write.Flush();
        }
        public void requestRoomUpdate()
        {
            m_Write.WriteLine("Room");
            m_Write.Flush();
        }

        public void requestGenerate(string text)
        {
            m_Write.WriteLine("Generate");
            m_Write.WriteLine(text);
            m_Write.Flush();
        }

        private void Receive()
        {
            m_Write.WriteLine("New Client");
            m_Write.WriteLine(name);
            m_Write.WriteLine(id);
            m_Write.Flush();
            string receive;
            while (m_bConnect)
            {

                //this.Invoke(new Action(delegate ()
                //{
                //    txt_Chat.AppendText("dddddddd\r\n");
                //}));
                receive = m_Read.ReadLine();
                if (receive.Equals("Message"))
                {
                    string message = m_Read.ReadLine();
                    this.Invoke(new Action(delegate ()
                    {
                        txtChat.AppendText(message + "\r\n");
                    }));
                }
                else if (receive.Equals("Update"))
                {
                    //if (lobby.IsDisposed)
                    //    continue;

                    if (!closeFlag)
                    {
                        string message = m_Read.ReadLine();
                        roomCount = message;
                        message = m_Read.ReadLine();
                        totalCount = message;

                        //MessageBox.Show("call by update");
                        //MessageBox.Show(totalCount.ToString() + " " + roomCount.ToString());
                        lobby.uiUpdate();
                    }
                }
                else if (receive.Equals("User"))
                {
                    //if (lobby.IsDisposed)
                    //    continue;
                    if (this.userNameList.InvokeRequired)
                    {
                        this.Invoke(new fnSetResetTextCallback(SetResetText), new object[]
                        {
                    });
                    }
                    else
                    {
                        userNameList.ResetText();
                    }

                    userNames = new List<string>();
                    string count = m_Read.ReadLine();

                    for (int i = 0; i < Convert.ToInt32(count); i++)
                    {
                        string message = m_Read.ReadLine();
                        userNames.Add(message);
                        this.Invoke(new Action(delegate ()
                        {
                            userNameList.AppendText(message + "\r\n");
                        }));
                    }
                    if (this.userCnt.InvokeRequired)
                    {
                        this.Invoke(new fnSetTextBoxCallback(SetTextboxInput), new object[]
                        {
                        enterRoomNumber.ToString() + "번 방, 접속인원: " + count
                    });
                    }
                    else
                    {
                        this.userCnt.Text = enterRoomNumber.ToString() + "번 방, 접속인원: " + count;
                    }
                }
                else if (receive.Equals("Room"))
                {
                    //if (lobby.IsDisposed)
                    //    continue;

                    if (!closeFlag)
                    {
                        roomNames = new List<string>();
                        string count = m_Read.ReadLine();

                        for (int i = 0; i < Convert.ToInt32(count); i++)
                        {
                            string message = m_Read.ReadLine();
                            roomNames.Add(message);
                        }

                        this.lobby.uiUpdate();
                    }
                }
                else if (receive.Equals("ShutDown"))
                {
                    shutdownTrigger = true;
                    this.lobby.Close();
                    this.Close();
                    return;
                }
                else if (receive.Equals("Freepen"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int x2 = int.Parse(m_Read.ReadLine());
                    int y2 = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyLines ml = new MyLines(2);
                    ml.setPoint(new Point(x1, y1), new Point(x2, y2), new Pen(Color.FromArgb(Argb), thick), thick);
                    shapes.Add(ml);
                    //DrawBitmap();
                }
                else if (receive.Equals("Line"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int x2 = int.Parse(m_Read.ReadLine());
                    int y2 = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyLines ml = new MyLines(1);
                    ml.setPoint(new Point(x1, y1), new Point(x2, y2), new Pen(Color.FromArgb(Argb), thick), thick);
                    shapes.Add(ml);
                    //DrawBitmap();
                }
                else if (receive.Equals("Rectangle"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int wid = int.Parse(m_Read.ReadLine());
                    int hei = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyRect mr = new MyRect();
                    mr.setRect(new Point(x1, y1), new Point(x1 + wid, y1 + hei), new Pen(Color.FromArgb(Argb), thick), thick);
                    shapes.Add(mr);
                    //DrawBitmap();
                }
                else if (receive.Equals("Circle"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int wid = int.Parse(m_Read.ReadLine());
                    int hei = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyCircle mc = new MyCircle();
                    mc.setRectC(new Point(x1, y1), new Point(x1 + wid, y1 + hei), new Pen(Color.FromArgb(Argb), thick), thick);
                    shapes.Add(mc);
                    //DrawBitmap();
                }
                else if (receive.Equals("Bitmap"))
                {
                    memoryStream = new MemoryStream(m_Client.ReceiveBufferSize);
                    //MessageBox.Show("Bitmap입력받음");
                    //buffer = new byte[m_Client.ReceiveBufferSize];
                    int bytesRead = 0;
                    bytesRead = networkStream.Read(buffer, 0, buffer.Length);

                    foreach (byte b in buffer)
                    {
                        memoryStream.WriteByte(b);
                    }
                    memoryStream.Position = 0;

                    // 수신된 데이터 역직렬화하여 비트맵 이미지로 변환
                    //memoryStream.Seek(0, SeekOrigin.Begin);
                    BinaryFormatter formatter = new BinaryFormatter();
                    currentBmp = (Bitmap)formatter.Deserialize(memoryStream);

                    // 클라이언트에 표시
                    panel1.BackgroundImage = currentBmp;
                    Array.Clear(buffer, (byte)0, buffer.Length);
                    this.Invoke(new Action(delegate ()
                    {

                    }));
                    //NetworkStream networkStream = m_Stream;
                    //MemoryStream memoryStream = new MemoryStream();


                    //int length = int.Parse(m_Read.ReadLine());
                    //byte[] buf = m_bRead.ReadBytes(length);
                    //ms = new MemoryStream(buf);
                    //bitmap = new Bitmap(ms);

                    // 서버로부터 데이터 수신
                    /*NetworkStream networkStream = m_Stream;
                    MemoryStream memoryStream = new MemoryStream();

                    byte[] buffer = new byte[m_Client.ReceiveBufferSize];
                    int bytesRead;
                    while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, bytesRead);
                    }

                    // 수신된 데이터 역직렬화하여 비트맵 이미지로 변환
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    BinaryFormatter formatter = new BinaryFormatter();
                    currentBmp = (Bitmap)formatter.Deserialize(memoryStream);

                    // 클라이언트에 표시
                    panel1.BackgroundImage = currentBmp;
                    //int length = int.Parse(m_Read.ReadLine());
                    //byte[] buf = m_bRead.ReadBytes(length);
                    //ms = new MemoryStream(buf);
                    //bitmap = new Bitmap(ms);
                    ////bitmap.Save("C:/Users/junhwa/source/repos/Application_Software_3rdPractice/Client/bin/Debug/abc.bmp");
                    */
                }
            }
            //DrawBitmap();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == btn_pen)
            {
                curMode = (int)CANVAS_MODE.PENMODE;

                this.btn_pen.BackColor = Color.Orange;
                this.btn_eraser.BackColor = Color.White;
                this.btn_shape.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
                this.btn_fill.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
            }
            if (e.ClickedItem == btn_eraser)
            {
                curMode = (int)CANVAS_MODE.ERASERMODE;

                this.btn_eraser.BackColor = Color.Orange;
                this.btn_pen.BackColor = Color.White;
                this.btn_shape.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
                this.btn_fill.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
            }
            if (e.ClickedItem == btn_text)
            {
                curMode = (int)CANVAS_MODE.TEXTMODE;

                this.btn_eraser.BackColor = Color.White;
                this.btn_pen.BackColor = Color.White;
                this.btn_shape.BackColor = Color.White;
                this.btn_text.BackColor = Color.Orange;
                this.btn_fill.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
            }
            if (e.ClickedItem == btn_fill)
            {
                curMode = (int)CANVAS_MODE.PAINTMODE;

                this.btn_eraser.BackColor = Color.White;
                this.btn_pen.BackColor = Color.White;
                this.btn_shape.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
                this.btn_fill.BackColor = Color.Orange;
                this.btn_text.BackColor = Color.White;
            }
            if (e.ClickedItem == btn_text)
            {
                curMode = (int)CANVAS_MODE.TEXTMODE;

                this.btn_eraser.BackColor = Color.White;
                this.btn_pen.BackColor = Color.White;
                this.btn_shape.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
                this.btn_fill.BackColor = Color.White;
                this.btn_text.BackColor = Color.Orange;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            /*try
            {
                foreach (var sh in shapes)
                    sh.DrawShape(e);
            }
            catch
            {
                return;
            }*/
            shape.DrawShape(e);
        }

        private void makeLabel()
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            freepenEnd = false;
            pen = new Pen(currentColor, _thick);
            brush = new SolidBrush(currentColor);
            isHolding = true;
            freepenStore.Clear();
            //if (holdingFreepen == true)
            //{
            //    SaveFreepen = true;
            //    DrawBitmap();
            //    SaveFreepen = false;
            //}
            //holdingFreepen = false;
            switch (curMode)
            {
                case 0: // 펜
                    Point temp = new Point(e.X, e.Y);
                    freepenStore.Add(temp);
                    break;
                case 1: // 선
                    myLine = new MyLines(1);
                    shape = myLine;
                    start.X = e.X;
                    start.Y = e.Y;
                    break;
                case 2: // 사각형
                    myRect = new MyRect();
                    shape = myRect;
                    start.X = e.X;
                    start.Y = e.Y;
                    break;
                case 3: // 원
                    myCircle = new MyCircle();
                    shape = myCircle;
                    start.X = e.X;
                    start.Y = e.Y;
                    break;
                case 4:
                    Point startPoint = new Point(e.X, e.Y);
                    Bitmap fillTemBmp = (Bitmap)BmpList.Last().Clone();
                    Color preColor = fillTemBmp.GetPixel(startPoint.X, startPoint.Y);
                    doFloodFill(fillTemBmp, startPoint, preColor);
                    BmpList.Add(fillTemBmp);
                    panel1.BackgroundImage = BmpList.Last();
                    break;
                case 5: // 지우개
                    pen = new Pen(Color.White, _thick * 10);
                    Point Etemp = new Point(e.X, e.Y);
                    freepenStore.Add(Etemp);
                    break;
                case 6: // 텍스트

                    break;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isHolding) return;

            switch (curMode)
            {
                case 0: // 펜
                    Point temp = new Point(e.X, e.Y);
                    freepenStore.Add(temp);
                    startF.X = freepenStore[0].X;
                    startF.Y = freepenStore[0].Y;
                    finishF.X = freepenStore[1].X;
                    finishF.Y = freepenStore[1].Y;

                    if (freepenStore.Count == 2)
                    {
                        m_Write.WriteLine("Freepen");
                        m_Write.WriteLine(freepenStore[0].X.ToString());
                        m_Write.WriteLine(freepenStore[0].Y.ToString());
                        m_Write.WriteLine(freepenStore[1].X.ToString());
                        m_Write.WriteLine(freepenStore[1].Y.ToString());
                        m_Write.WriteLine(pen.Width);
                        m_Write.WriteLine(pen.Color.ToArgb());
                        m_Write.Flush();

                        freepenStore.Clear();
                        freepenStore.Add(temp);
                    }
                    //m_Write.WriteLine("Freepen");
                    //m_Write.WriteLine(start.X);
                    //m_Write.WriteLine(start.Y);
                    //m_Write.WriteLine(finish.X);
                    //m_Write.WriteLine(finish.Y);
                    //m_Write.WriteLine(pen.Width);
                    //m_Write.WriteLine(pen.Color.ToArgb());
                    //m_Write.Flush();
                    ////myLine.setPoint(start, finish, pen, _thick);
                    //start = finish;
                    break;
                case 1: // 직선
                    finish.X = e.X;
                    finish.Y = e.Y;
                    myLine.setPoint(start, finish, pen, _thick);
                    break;
                case 2: // 사각형
                    finish.X = e.X;
                    finish.Y = e.Y;
                    myRect.setRect(start, finish, pen, _thick);
                    break;
                case 3: // 원
                    finish.X = e.X;
                    finish.Y = e.Y;
                    myCircle.setRectC(start, finish, pen, _thick);
                    break;
                case 5: // 지우개
                    Point Etemp = new Point(e.X, e.Y);
                    freepenStore.Add(Etemp);
                    startF.X = freepenStore[0].X;
                    startF.Y = freepenStore[0].Y;
                    finishF.X = freepenStore[1].X;
                    finishF.Y = freepenStore[1].Y;

                    if (freepenStore.Count == 2)
                    {
                        m_Write.WriteLine("Freepen");
                        m_Write.WriteLine(freepenStore[0].X.ToString());
                        m_Write.WriteLine(freepenStore[0].Y.ToString());
                        m_Write.WriteLine(freepenStore[1].X.ToString());
                        m_Write.WriteLine(freepenStore[1].Y.ToString());
                        m_Write.WriteLine(pen.Width);
                        m_Write.WriteLine(pen.Color.ToArgb());
                        m_Write.Flush();

                        freepenStore.Clear();
                        freepenStore.Add(Etemp);
                    }
                    break;
            }
            panel1.Invalidate(true);
            panel1.Update();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isHolding = false;
            //if (start.X.Equals(e.X) && start.Y.Equals(e.Y)) return; // 도형을 그리지 않은 경우

            switch (curMode)
            {
                case 0: // 펜

                    Point temp = new Point(e.X, e.Y);
                    freepenStore.Add(temp);
                    startF.X = freepenStore[0].X;
                    startF.Y = freepenStore[0].Y;
                    finishF.X = freepenStore[1].X;
                    finishF.Y = freepenStore[1].Y;

                    if (freepenStore.Count == 2)
                    {
                        holdingFreepen = true;
                        m_Write.WriteLine("Freepen");
                        m_Write.WriteLine(freepenStore[0].X.ToString());
                        m_Write.WriteLine(freepenStore[0].Y.ToString());
                        m_Write.WriteLine(freepenStore[1].X.ToString());
                        m_Write.WriteLine(freepenStore[1].Y.ToString());
                        m_Write.WriteLine(pen.Width);
                        m_Write.WriteLine(pen.Color.ToArgb());
                        m_Write.Flush();

                        freepenStore.Clear();
                    }
                    freepenEnd = true;
                    SaveFreepen = true;
                    //DrawBitmap();
                    SaveFreepen = false;
                    freepenEnd = false;
                    break;
                case 1: // 선                    
                    m_Write.WriteLine("Line");
                    m_Write.WriteLine(myLine.getPoint1().X);
                    m_Write.WriteLine(myLine.getPoint1().Y);
                    m_Write.WriteLine(myLine.getPoint2().X);
                    m_Write.WriteLine(myLine.getPoint2().Y);
                    m_Write.WriteLine(_thick);
                    m_Write.WriteLine(myLine.GetPen().Color.ToArgb());
                    m_Write.Flush();
                    //shapes.Add(myLine);
                    break;
                case 2: // 사각형
                    m_Write.WriteLine("Rectangle");
                    m_Write.WriteLine(myRect.getRect().X);
                    m_Write.WriteLine(myRect.getRect().Y);
                    m_Write.WriteLine(myRect.getRect().Width);
                    m_Write.WriteLine(myRect.getRect().Height);
                    m_Write.WriteLine(_thick);
                    m_Write.WriteLine(myRect.GetPen().Color.ToArgb());
                    m_Write.Flush();
                    //shapes.Add(myRect);
                    break;
                case 3: // 원
                    m_Write.WriteLine("Circle");
                    m_Write.WriteLine(myCircle.getRectC().X);
                    m_Write.WriteLine(myCircle.getRectC().Y);
                    m_Write.WriteLine(myCircle.getRectC().Width);
                    m_Write.WriteLine(myCircle.getRectC().Height);
                    m_Write.WriteLine(_thick);
                    m_Write.WriteLine(myCircle.GetPen().Color.ToArgb());
                    m_Write.Flush();
                    //shapes.Add(myCircle);
                    break;
                case 5: // 지우개
                    Point Etemp = new Point(e.X, e.Y);
                    freepenStore.Add(Etemp);
                    startF.X = freepenStore[0].X;
                    startF.Y = freepenStore[0].Y;
                    finishF.X = freepenStore[1].X;
                    finishF.Y = freepenStore[1].Y;

                    if (freepenStore.Count == 2)
                    {
                        holdingFreepen = true;
                        m_Write.WriteLine("Freepen");
                        m_Write.WriteLine(freepenStore[0].X.ToString());
                        m_Write.WriteLine(freepenStore[0].Y.ToString());
                        m_Write.WriteLine(freepenStore[1].X.ToString());
                        m_Write.WriteLine(freepenStore[1].Y.ToString());
                        m_Write.WriteLine(pen.Width);
                        m_Write.WriteLine(pen.Color.ToArgb());
                        m_Write.Flush();

                        freepenStore.Clear();
                    }
                    freepenEnd = true;
                    SaveFreepen = true;
                    //DrawBitmap();
                    SaveFreepen = false;
                    freepenEnd = false;
                    break;
            }
            //DrawBitmap();
        }
        private void DrawFreepen()
        {
            BmpList.Add(DrawBmp);
            panel1.BackgroundImage = BmpList.Last();
        }
        private void DrawBitmap()
        {
            this.Invoke(new Action(delegate ()
            {
                if (OriginalBmp != null)
                {
                    //if (BmpList.Count() == 0)
                    //{
                    //    DrawBmp = (Bitmap)OriginalBmp.Clone();
                    //}
                    //else
                    //{
                    //    DrawBmp = (Bitmap)BmpList.Last().Clone();
                    //}
                    //DrawBmp = (Bitmap)OriginalBmp.Clone();
                    //if (BmpList.Last() != null) DrawBmp = (Bitmap)BmpList.Last().Clone();
                    if (undoing == true)
                    {
                        tmpList.Clear();
                        //tmpList.Add(OriginalBmp);
                        undoing = false;
                    }
                        

                    if (shapes.Last().GetName() == "Freepen")    //freepen
                    {
                        //fpList.Add(BmpList.Last());
                        //if (fpList.Last() == null && BmpList.Last() != null) fpBmp = (Bitmap)BmpList.Last().Clone();
                        //else if (fpList.Last() != null) fpBmp = (Bitmap)(fpList.Last().Clone());

                        if (!SaveFreepen)
                        {
                            if (!holdingFreepen)
                            {
                                if (BmpList.Last() != null)
                                {
                                    fpList.Add(BmpList.Last());
                                    fpBmp = (Bitmap)fpList.Last().Clone();
                                }
                                //Graphics g1 = Graphics.FromImage(DrawBmp);
                                Graphics g1 = Graphics.FromImage(fpBmp);
                                Point s = new Point(startF.X, startF.Y);
                                Point f = new Point(finishF.X, finishF.Y);
                                g1.DrawLine(pen, s, f);
                                holdingFreepen = true;
                                //Count++;
                            }
                            else
                            {
                                if (fpList.Count > 0) 
                                {
                                    fpBmp = (Bitmap)fpList.Last().Clone();
                                }
                                else
                                {
                                    fpBmp = (Bitmap)BmpList.Last().Clone();
                                }
                                //Graphics g2 = Graphics.FromImage(DrawBmp);
                                Graphics g2 = Graphics.FromImage(fpBmp);
                                Point s = new Point(startF.X, startF.Y);
                                Point f = new Point(finishF.X, finishF.Y);
                                g2.DrawLine(pen, s, f);
                                //Count++;
                            }
                        }

                        if (SaveFreepen && holdingFreepen && freepenEnd)
                        {
                            if (BmpList.Last() != fpBmp)
                            {
                                BmpList.Add(fpList.Last());
                            }
                            panel1.BackgroundImage = BmpList.Last();
                            fpList.Clear();
                        }
                        else if (holdingFreepen)
                        {
                            fpList.Add(fpBmp);
                            panel1.BackgroundImage = fpList.Last();
                        }
                        
                        //BmpList.Add(DrawBmp);
                        //panel1.BackgroundImage = BmpList.Last();
                    }
                    else
                    {
                        DrawBmp = (Bitmap)BmpList.Last().Clone();
                        if (shapes.Last().GetName() == "Line")   //line
                        {
                            Graphics g1 = Graphics.FromImage(DrawBmp);
                            Point s = new Point(start.X, start.Y);
                            Point f = new Point(finish.X, finish.Y);
                            g1.DrawLine(pen, s, f);
                            //myLine.setPoint(start, finish, pen, _thick);
                        }
                        else if (shapes.Last().GetName() == "Rectangle")   //rectangle
                        {
                            Graphics g2 = Graphics.FromImage(DrawBmp);
                            Rectangle r = new Rectangle(Math.Min(start.X, finish.X), Math.Min(start.Y, finish.Y), Math.Abs(finish.X - start.X), Math.Abs(finish.Y - start.Y));
                            g2.DrawRectangle(pen, r);
                            //myRect.setRect(start, finish, pen, _thick);
                        }
                        else if (shapes.Last().GetName() == "Circle")  //circle
                        {
                            Graphics g3 = Graphics.FromImage(DrawBmp);
                            Rectangle r = new Rectangle(Math.Min(start.X, finish.X), Math.Min(start.Y, finish.Y), Math.Abs(finish.X - start.X), Math.Abs(finish.Y - start.Y));
                            g3.DrawEllipse(pen, r);
                            //myCircle.setRectC(start, finish, pen, _thick);
                        }
                        BmpList.Add(DrawBmp);
                        panel1.BackgroundImage = BmpList.Last();
                    }
                    //BmpList.Add(DrawBmp);
                    //panel1.BackgroundImage = BmpList.Last();
                    switch (curMode)
                    {
                        case 1: // 직선
                            myLine.setPoint(new Point(0, 0), new Point(0, 0), pen, _thick);
                            break;
                        case 2: // 사각형
                            myRect.setRect(new Point(0, 0), new Point(0, 0), pen, _thick);
                            break;
                        case 3: // 원
                            myCircle.setRectC(new Point(0, 0), new Point(0, 0), pen, _thick);
                            break;
                    }
                    Draw();
                }
            }));

            
        }
        private void btn_image_Click(object sender, EventArgs e)
        {
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

                if (int.Parse(lblCurrentPage.Text) == 1)
                {
                    panel1.Controls.Add(p);
                }
                else if (int.Parse(lblCurrentPage.Text) == 2)
                {
                    //panel2.Controls.Add(p);
                }
                else if (int.Parse(lblCurrentPage.Text) == 3)
                {
                    //panel3.Controls.Add(p);
                }

                p.MouseDown += p_MouseDown;
                p.MouseMove += p_MouseMove;
                p.MouseUp += p_MouseUp;
            }
        }
        private void Btn_SelectColor_Click(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                MouseEventArgs mouseEvent = e as MouseEventArgs;
                if (sender == color1)
                    currentColor = color1.BackColor;
                else if (sender == color2)
                    currentColor = color2.BackColor;
                else if (sender == color3)
                    currentColor = color3.BackColor;
            }
            else
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (sender == color1)
                    {
                        color1.BackColor = colorDialog1.Color;
                        currentColor = color1.BackColor;
                    }
                    else if (sender == color2)
                    {
                        color2.BackColor = colorDialog1.Color;
                        currentColor = color2.BackColor;
                    }
                    else if (sender == color3)
                    {
                        color3.BackColor = colorDialog1.Color;
                        currentColor = color3.BackColor;
                    }
                }
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            myLine = new MyLines(1); 
            myRect = new MyRect();
            myCircle = new MyCircle();
            shape = new Shape();
        }

        public void Draw()
        {
            this.Invoke(new Action(delegate ()
            {
                panel1.Invalidate(true);
                panel1.Update();
            }));
        }

        private void item_line_Click(object sender, EventArgs e)
        {
            curMode = (int)CANVAS_MODE.LINEMODE;

            this.btn_eraser.BackColor = Color.White;
            this.btn_pen.BackColor = Color.White;
            this.btn_shape.BackColor = Color.Orange;
            this.btn_text.BackColor = Color.White;
        }

        private void item_rect_Click(object sender, EventArgs e)
        {
            curMode = (int)CANVAS_MODE.RECTMODE;

            this.btn_eraser.BackColor = Color.White;
            this.btn_pen.BackColor = Color.White;
            this.btn_shape.BackColor = Color.Orange;
            this.btn_text.BackColor = Color.White;
        }

        private void item_circle_Click(object sender, EventArgs e)
        {
            curMode = (int)CANVAS_MODE.CIRCLEMODE;

            this.btn_eraser.BackColor = Color.White;
            this.btn_pen.BackColor = Color.White;
            this.btn_shape.BackColor = Color.Orange;
            this.btn_text.BackColor = Color.White;
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            m_Write.WriteLine("btnUndo");
            m_Write.Flush();

            if (BmpList.Count() > 0)
            {
                undoing = true;
                tmpList.Add(BmpList.Last());
                BmpList.RemoveAt(BmpList.Count() - 1);
                if (BmpList.Count() == 0)
                    panel1.BackgroundImage = OriginalBmp;
                else
                {
                    panel1.BackgroundImage = BmpList.Last();
                }
            }
        }

        private void btn_redo_Click(object sender, EventArgs e)
        {
            m_Write.WriteLine("btnRedo");
            m_Write.Flush();
            if (tmpList.Count() > 0)
            {
                BmpList.Add(tmpList.Last());
                tmpList.RemoveAt(tmpList.Count() - 1);
                panel1.BackgroundImage = BmpList.Last();
            }
            else
            {
                panel1.BackgroundImage = BmpList.Last();
            }
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_bConnect = false;

            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_thReader.Abort();
        }
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
