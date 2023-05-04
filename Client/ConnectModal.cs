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
    public partial class ConnectModal : Form
    {
        public ConnectModal()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            ClientForm.ip = txtIP.Text;
            ClientForm.port = txtPort.Text;
            ClientForm.name = txtName.Text;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ClientForm.exitFlag = "Exit";
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ClientForm.ip = txtIP.Text;
            ClientForm.port = txtPort.Text;
            ClientForm.name = txtName.Text;
            this.Close();
        }
    }
}
