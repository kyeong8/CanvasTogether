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

namespace CanvasTogether
{
    public partial class ClientForm : Form
    {
        enum CANVAS_MODE
        {
            PENMODE = 0, // 펜 모드
            SHAPEMODE = 1, // 선, 사각형, 원 모드
            PAINTMODE = 2, // 채우기 모드
            ERASERMODE = 3, // 지우개 모드
            TEXTMODE = 4, // 텍스트 모드
        }

        NetworkStream m_Stream;
        TcpClient m_Client;
        StreamReader m_Read;
        StreamWriter m_Write;
        private Thread m_thReader;
        bool m_bConnect;
        public static string name;
        public static string totalCount = "0";
        public static string roomCount = "0";
        public static bool exitFlag = true;
        public static int enterRoomNumber = 0;
        public Lobby lobby = new Lobby();
        public static List<string> roomNames = new List<string>();
        public static bool closeFlag = false;

        int pages = 1;
        int curMode;
        int _polygon = 1;
        int _thick = 1;

        // ==========================================

        private bool freePen;
        private bool line;
        private bool rect;
        private bool circle;
        private Point start; // 도형의 시작점
        private Point finish; // 도형의 끝점
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
        private List<Shape> shapes = new List<Shape>();
        Pen pen; // 펜
        SolidBrush brush;
        Shape shape;

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
            brush = new SolidBrush(Color.Black);
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

        // ==========================================

        private PictureBox movingPictureBox;

        public ClientForm()
        {
            InitializeComponent();
            SetupShapeVar();

            lblCurrentPage.Text = 1.ToString();
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

            // lobby = new Lobby();
            lobby.form2SendEvent += new Lobby.FormSendDataHandler(requestRoomUpdate);
            lobby.form2SendUpdate += new Lobby.FormSendUpdateHandler(requestEnterUpdate);
            lobby.ShowDialog();

            requestUpdate();

            if (exitFlag)
            {
                object sender = null;
                FormClosingEventArgs e = null;
                this.ClientForm_FormClosing(sender, e);
            }
        }
        
        private void Btn_shape_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == item_line)
            {
                btn_shape.Image = item_line.Image;
                _polygon = 0; // line
            }
            else if(e.ClickedItem == item_rect)
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
            else if( e.ClickedItem == item_Thick3)
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

        //private void SetCanvasMode(int mode)
        //{
        //    switch (mode)
        //    {
        //        case (int)CANVAS_MODE.PENMODE:
        //            curMode = (int)CANVAS_MODE.PENMODE;
        //            this.Cursor=
        //            break;

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


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_bConnect)
                return;

            m_Write.WriteLine("Disconnect");
            m_Write.WriteLine(name);
            m_Write.Flush();

            m_bConnect = false;

            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_thReader.Abort();
            this.Close();
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

            m_Read = new StreamReader(m_Stream);
            m_Write = new StreamWriter(m_Stream);

            m_thReader = new Thread(new ThreadStart(Receive));
            m_thReader.Start();
        }

        public void requestUpdate()
        {
            m_Write.WriteLine("Update");
            m_Write.Flush();
        }

        public void requestEnterUpdate(bool flag)
        {
            if (!flag)
            {
                m_Write.WriteLine("Enter");
                m_Write.WriteLine(name);
                m_Write.WriteLine(enterRoomNumber.ToString());
                m_Write.Flush();
            }
        }

        public void requestRoomUpdate(string text)
        {
            m_Write.WriteLine("Generate");
            m_Write.WriteLine(text);
            m_Write.Flush();
        }

        private void Receive()
        {
            m_Write.WriteLine("New Client");
            m_Write.WriteLine(name);
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

                        lobby.uiUpdate();
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

                        lobby.uiUpdate();
                    }  
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem == btn_pen)
            {
                //curMode = (int)CANVAS_MODE.PENMODE;
                freePen = true;
                line = false;
                rect = false;
                circle = false;

                this.btn_pen.BackColor = Color.Orange;
                this.btn_eraser.BackColor = Color.White;
                this.btn_shape.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
            }
            if(e.ClickedItem == btn_eraser)
            {
                curMode = (int)CANVAS_MODE.ERASERMODE;

                this.btn_eraser.BackColor = Color.Orange;
                this.btn_pen.BackColor = Color.White;
                this.btn_shape.BackColor = Color.White;
                this.btn_text.BackColor = Color.White;
            }
            if(e.ClickedItem == btn_shape)
            {
                freePen = false;
                //if (_polygon == 0)
                //{
                //    freePen = false;
                //    line = true;
                //    rect = false;
                //    circle = false;
                //}
                //else if(_polygon == 1)
                //{
                //    freePen = false;
                //    line = false;
                //    rect = true;
                //    circle = false;
                //}
                //else if (_polygon == 2)
                //{
                //    freePen = false;
                //    line = false;
                //    rect = false;
                //    circle = true;
                //}
                this.btn_pen.BackColor = Color.White;
                this.btn_eraser.BackColor = Color.White;
                this.btn_shape.BackColor = Color.Orange;
                this.btn_text.BackColor = Color.White;
            }
            if(e.ClickedItem == btn_text)
            {
                curMode = (int)CANVAS_MODE.TEXTMODE;

                this.btn_eraser.BackColor = Color.White;
                this.btn_pen.BackColor = Color.White;
                this.btn_shape.BackColor = Color.White;
                this.btn_text.BackColor = Color.Orange;
            }
        }

        private void UpdatePolygon()
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (i = 0; i < nfreepen; i++)
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // 임시방편
            if (!freePen)
            {
                if (btn_shape.Image == item_line.Image)
                {
                    _polygon = 0;
                    freePen = false;
                    line = true;
                    rect = false;
                    circle = false;
                }
                else if (btn_shape.Image == item_rect.Image)
                {
                    _polygon = 1;
                    freePen = false;
                    line = false;
                    rect = true;
                    circle = false;
                }
                else if (btn_shape.Image == item_circle.Image)
                {
                    _polygon = 2;
                    freePen = false;
                    line = false;
                    rect = false;
                    circle = true;
                }
            }

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
                myfreepens[nfreepen].setRectF(curPoint, pen, brush, _thick);
                nfreepen++;
            }
            if (line == true)
            {
                mylines[nline].setPoint(start, finish, pen, _thick);
            }
            if (rect == true)
            {
                myrect[nrect].setRect(start, finish, pen, _thick);
            }
            if (circle == true)
            {
                mycircle[ncircle].setRectC(start, finish, pen, _thick);
            }
            panel1.Invalidate(true);
            panel1.Update();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (freePen == true)
                nfreepen++;
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
        private void Btn_SelectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (sender == color1)
                    color1.BackColor = colorDialog1.Color;
                else if (sender == color2)
                    color2.BackColor = colorDialog1.Color;
                else if (sender == color3)
                    color3.BackColor = colorDialog1.Color;
            }
        }

        
    }
}
