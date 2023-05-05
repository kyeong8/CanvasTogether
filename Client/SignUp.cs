using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class SignUp : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            string route = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            try
            {
                conn = new SQLiteConnection(@"Data Source=" + route + "\\Database\\cvtDB.db");
                conn.Open();

                cmd = new SQLiteCommand(conn);
                cmd.CommandText = $"insert into member (id, pw, name) values (" +
                    $"'{ID_txtbox.Text.Trim()}', '{PW_txtbox.Text.Trim()}', '{Name_txtbox.Text.Trim()}')";
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("회원 가입 완료");

                this.Close();
            }
            catch
            {
                MessageBox.Show("오류가 발생했습니다.");
            }
        }
    }
}
