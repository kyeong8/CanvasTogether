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
            string stm = $"select *, count(*) as ct from member where id = \'" + ID_txtbox.Text.Trim() + "\'or name = \'" + Name_txtbox.Text.Trim() + "\'";
            int dupCheck = 0;
            try
            {
                conn = new SQLiteConnection(@"Data Source=" + route + "\\Database\\cvtDB.db");
                conn.Open();

                cmd = new SQLiteCommand(stm, conn);

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ct"].ToString() != "0")
                    {
                        MessageBox.Show("동일한 아이디 또는 닉네임이 존재합니다.");
                    }
                    else
                    {
                        dupCheck = 1;
                    }
                }
                reader.Close();
                conn.Close();

                if (dupCheck == 1)
                {
                    conn.Open();
                    cmd = new SQLiteCommand(conn);
                    cmd.CommandText = $"insert into member (id, pw, name) values (" +
                           $"'{ID_txtbox.Text.Trim()}', '{SHA256HASH(PW_txtbox.Text.Trim())}', '{Name_txtbox.Text.Trim()}')";
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("회원 가입 완료");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다. : " + ex.ToString());
            }
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

