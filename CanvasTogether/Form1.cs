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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Form2 canvas = new Form2();
            canvas.ShowDialog(); // 모달리스로 창 띄우기
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
