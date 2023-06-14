namespace CanvasTogether
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ID_txtbox = new System.Windows.Forms.TextBox();
            this.PW_txtbox = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignUP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "비밀번호";
            // 
            // ID_txtbox
            // 
            this.ID_txtbox.Location = new System.Drawing.Point(148, 75);
            this.ID_txtbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ID_txtbox.Name = "ID_txtbox";
            this.ID_txtbox.Size = new System.Drawing.Size(162, 25);
            this.ID_txtbox.TabIndex = 2;
            // 
            // PW_txtbox
            // 
            this.PW_txtbox.Location = new System.Drawing.Point(148, 127);
            this.PW_txtbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PW_txtbox.Name = "PW_txtbox";
            this.PW_txtbox.Size = new System.Drawing.Size(162, 25);
            this.PW_txtbox.TabIndex = 3;
            this.PW_txtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PW_txtbox_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(79, 176);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 38);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignUP
            // 
            this.btnSignUP.Location = new System.Drawing.Point(208, 176);
            this.btnSignUP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSignUP.Name = "btnSignUP";
            this.btnSignUP.Size = new System.Drawing.Size(81, 38);
            this.btnSignUP.TabIndex = 5;
            this.btnSignUP.Text = "회원가입";
            this.btnSignUP.UseVisualStyleBackColor = true;
            this.btnSignUP.Click += new System.EventHandler(this.btnSignUP_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 228);
            this.Controls.Add(this.btnSignUP);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.PW_txtbox);
            this.Controls.Add(this.ID_txtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ID_txtbox;
        private System.Windows.Forms.TextBox PW_txtbox;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignUP;
    }
}