
namespace CanvasTogether
{
    partial class Lobby
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
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblConnect = new System.Windows.Forms.Label();
            this.nextPageBtn = new System.Windows.Forms.Button();
            this.prevPageBtn = new System.Windows.Forms.Button();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.btnMake = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Enabled = false;
            this.btn1.Location = new System.Drawing.Point(223, 87);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(333, 50);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "Room1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn2
            // 
            this.btn2.Enabled = false;
            this.btn2.Location = new System.Drawing.Point(223, 143);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(333, 50);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "Room2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn3
            // 
            this.btn3.Enabled = false;
            this.btn3.Location = new System.Drawing.Point(223, 199);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(333, 50);
            this.btn3.TabIndex = 2;
            this.btn3.Text = "Room3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn4
            // 
            this.btn4.Enabled = false;
            this.btn4.Location = new System.Drawing.Point(223, 255);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(333, 50);
            this.btn4.TabIndex = 3;
            this.btn4.Text = "Room4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWelcome.Location = new System.Drawing.Point(230, 38);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(131, 15);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "___님 환영합니다.";
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConnect.Location = new System.Drawing.Point(228, 59);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(112, 20);
            this.lblConnect.TabIndex = 5;
            this.lblConnect.Text = "로비 / 접속";
            // 
            // nextPageBtn
            // 
            this.nextPageBtn.Location = new System.Drawing.Point(507, 311);
            this.nextPageBtn.Name = "nextPageBtn";
            this.nextPageBtn.Size = new System.Drawing.Size(40, 28);
            this.nextPageBtn.TabIndex = 24;
            this.nextPageBtn.Text = ">>";
            this.nextPageBtn.UseVisualStyleBackColor = true;
            // 
            // prevPageBtn
            // 
            this.prevPageBtn.Location = new System.Drawing.Point(461, 312);
            this.prevPageBtn.Name = "prevPageBtn";
            this.prevPageBtn.Size = new System.Drawing.Size(40, 27);
            this.prevPageBtn.TabIndex = 25;
            this.prevPageBtn.Text = "<<";
            this.prevPageBtn.UseVisualStyleBackColor = true;
            // 
            // txtRoom
            // 
            this.txtRoom.Font = new System.Drawing.Font("굴림", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txtRoom.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtRoom.Location = new System.Drawing.Point(21, 181);
            this.txtRoom.Multiline = true;
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(167, 30);
            this.txtRoom.TabIndex = 26;
            this.txtRoom.Text = "방이름";
            this.txtRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(21, 217);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(167, 41);
            this.btnMake.TabIndex = 27;
            this.btnMake.Text = "방만들기";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(21, 264);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(167, 41);
            this.btnEnter.TabIndex = 28;
            this.btnEnter.Text = "방접속하기";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 350);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnMake);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.prevPageBtn);
            this.Controls.Add(this.nextPageBtn);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Lobby_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Button nextPageBtn;
        private System.Windows.Forms.Button prevPageBtn;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.Button btnEnter;
    }
}