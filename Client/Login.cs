using CanvasTogether;
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

namespace CanvasTogether
{
    public partial class Login : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string route = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string stm = $"select * from member where id = \'" + ID_txtbox.Text.Trim() + "\'";
            int LoginStatus = 0;
            string nickname = "";

            try
            {
                conn = new SQLiteConnection(@"Data Source=" + route + "\\Database\\cvtDB.db");
                conn.Open();

                cmd = new SQLiteCommand(stm, conn);
                
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (ID_txtbox.Text.Trim() == (string)reader["id"] && SHA256HASH(PW_txtbox.Text.Trim()) == (string)reader["pw"])
                    {
                        LoginStatus = 1;
                        nickname = (string)reader["id"];
                    }
                }
                conn.Close();

                if (LoginStatus == 1)
                {
                    MessageBox.Show("로그인 완료");
                    ClientForm.exitFlag = false;
                    ClientForm.name = nickname;
                    this.Close();
                }
                else
                    MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다.");

            }
            catch
            {
                MessageBox.Show("오류가 발생했습니다.");
            }
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        public static string SHA256HASH(string data)
        {
            System.Security.Cryptography.SHA256 sha = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return stringBuilder.ToString();
        }
    }
}
