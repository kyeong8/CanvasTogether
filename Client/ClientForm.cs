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

        public ClientForm()
        {
            InitializeComponent();
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
