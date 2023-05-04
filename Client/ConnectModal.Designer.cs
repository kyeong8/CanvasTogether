namespace CanvasTogether
{
    partial class ConnectModal
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnServer = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(584, 174);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port Number";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(256, 204);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(132, 21);
            this.txtIP.TabIndex = 4;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(256, 237);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(132, 21);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "8000";
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(208, 308);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(75, 23);
            this.btnServer.TabIndex = 6;
            this.btnServer.Text = "서버 열기";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(313, 308);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "서버 연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(463, 326);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "프로그램 종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "NickName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "사진이나 로고 등으로 메인 화면 꾸미기";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(256, 273);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 21);
            this.txtName.TabIndex = 13;
            this.txtName.Text = "Client";
            // 
            // ConnectModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ConnectModal";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
    }
}

