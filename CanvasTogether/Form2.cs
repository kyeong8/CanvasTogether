using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasTogether
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Message(string message)
        {
            this.Invoke(new MethodInvoker(delegate () //크로스 스레드 문제 예방
            {
                chatUI.AppendText(message + "\r\n"); //채팅 목록창에 문자열 추가
                chatUI.Focus();
                chatUI.ScrollToCaret(); //현재 캐럿의 위치로 윈도우 스크롤 이동
                txtSend.Focus();
            }));

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}
