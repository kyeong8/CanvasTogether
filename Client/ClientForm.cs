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

namespace CanvasTogether
{
    public partial class ClientForm : Form
    {
        NetworkStream m_Stream;
        TcpClient m_Client;
        StreamReader m_Read;
        StreamWriter m_Write;
        private Thread m_thReader;
        bool m_bConnect;
        public static string ip, port, name, exitFlag;

        int pages = 1;

        public ClientForm()
        {
            InitializeComponent();

            lblCurrentPage.Text = 1.ToString();
            //panel2.BackColor = Color.MintCream;
            //panel3.BackColor = Color.Red;
            panel2.Visible = false;
            panel3.Visible = false;

            ConnectModal connectModal = new ConnectModal();
            connectModal.ShowDialog();
            if (exitFlag == "Exit") this.Close();
            Connect();
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
            m_Write.Flush();

            m_bConnect = false;

            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_thReader.Abort();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            m_Write.WriteLine("Message");
            m_Write.WriteLine(name + " : " + txtInput.Text);
            m_Write.Flush();
            txtInput.Clear();
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
                lblCurrentPage.Text = 2.ToString();
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            m_Write.WriteLine("Message");
            m_Write.WriteLine(name + " : " + txtInput.Text);
            m_Write.Flush();
            txtInput.Clear();
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
            }
        }
    }
}
