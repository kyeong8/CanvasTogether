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
    public partial class Lobby : MetroFramework.Forms.MetroForm
    {
        public delegate void FormSendDataHandler(string text);
        public event FormSendDataHandler form2SendEvent;

        public delegate void FormSendUpdateHandler(bool flag);
        public event FormSendUpdateHandler form2SendUpdate;

        public int roomIndex = 1;
        private string lobbyCount;
        private string connectCount;
        private int activateButton;
        private bool flag = true;

        delegate void fnSetTextBoxCallback(string contents);
        delegate void fnSetButtonCallback(Button btn, int index);

        public Lobby()
        {
            InitializeComponent();
            lblWelcome.Text = ClientForm.name + "님 환영합니다.";
            lobbyCount = (Convert.ToInt32(ClientForm.totalCount) - Convert.ToInt32(ClientForm.roomCount)).ToString();
            connectCount = ClientForm.totalCount;
            lblConnect.Text = lobbyCount + "로비 / " + connectCount + "접속";
        }

        public void uiUpdate()
        {
            lobbyCount = (Convert.ToInt32(ClientForm.totalCount) - Convert.ToInt32(ClientForm.roomCount)).ToString();
            connectCount = ClientForm.totalCount;

            if (this.IsDisposed == false)
            {
                if (this.lblConnect.InvokeRequired)
                {
                    this.Invoke(new fnSetTextBoxCallback(SetTextboxInput), new object[]
                    {
                    lobbyCount + "로비 / " + connectCount + "접속"
                    });
                }
                else
                {
                    this.lblConnect.Text = lobbyCount + "로비 / " + connectCount + "접속";
                }
                if (this.lblWelcome.InvokeRequired)
                {
                    this.Invoke(new fnSetTextBoxCallback(SetWelcomeInput), new object[]
                    {
                    ClientForm.name + "님 환영합니다."
                    });
                }
                else
                {
                    this.lblWelcome.Text = ClientForm.name + "님 환영합니다.";
                }

                for (int i = 1; i <= ClientForm.roomNames.Count; i++)
                {
                    string btnName = "btn" + i;
                    Button btn = this.Controls.Find(btnName, true).FirstOrDefault() as Button;

                    if (btn != null)
                    {
                        if (btn.InvokeRequired)
                        {
                            this.Invoke(new fnSetButtonCallback(SetButtonState), new object[]
                            {
                            btn, i-1
                            });
                        }
                        else
                        {
                            btn.Enabled = true;
                            btn.Text = ClientForm.roomNames[i - 1];
                        }
                    }
                }

                Application.DoEvents();
            }

        }

        private void SetTextboxInput(string contents)
        {
            this.lblConnect.Text = contents;
        }

        private void SetWelcomeInput(string contents)
        {
            this.lblWelcome.Text = contents;
        }

        private void SetButtonState(Button btn, int index)
        {
            btn.Enabled = true;
            btn.Text = ClientForm.roomNames[index];
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (0 < activateButton && activateButton <= (ClientForm.roomNames.Count + 1))
            {
                string btnName = "btn" + activateButton;
                Button btn = this.Controls.Find(btnName, true).FirstOrDefault() as Button;

                if (btn != null)
                {
                    ClientForm.enterRoomNumber = activateButton;
                    ClientForm.exitFlag = false;
                    flag = false;
                    this.Close();
                }
                ClientForm.roomCount += 1;
            }
        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            if (txtRoom.Text != "방이름")
            {
                string btnName = "btn" + (ClientForm.roomNames.Count + 1);
                Button btn = this.Controls.Find(btnName, true).FirstOrDefault() as Button;

                if (btn != null)
                {
                    btn.Text = txtRoom.Text;
                    btn.Enabled = true;
                }

                this.form2SendEvent(btn.Text);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            activateButton = selectedButton.TabIndex;
        }

        private void Lobby_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            this.form2SendUpdate(flag);
            
        }

        private void Lobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientForm.closeFlag = true;
            //FormClosedEventArgs ex = null;
            //Lobby_FormClosed(sender, ex);
            
        }
    }
}
