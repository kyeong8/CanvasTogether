namespace CanvasTogether
{
    partial class ClientForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.delPageBtn = new System.Windows.Forms.Button();
            this.createPageBtn = new System.Windows.Forms.Button();
            this.nextPageBtn = new System.Windows.Forms.Button();
            this.prevPageBtn = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.toolBarPanel = new System.Windows.Forms.Panel();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.penButton = new System.Windows.Forms.ToolBarButton();
            this.eraserButton = new System.Windows.Forms.ToolBarButton();
            this.lineButton = new System.Windows.Forms.ToolBarButton();
            this.rectButton = new System.Windows.Forms.ToolBarButton();
            this.circleButton = new System.Windows.Forms.ToolBarButton();
            this.fillButton = new System.Windows.Forms.ToolBarButton();
            this.textButton = new System.Windows.Forms.ToolBarButton();
            this.imageButton = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "오른쪽 채팅 영역";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(638, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "사이즈는 300, 600으로 해주세요";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(409, 526);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "연결 종료";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(572, 12);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(300, 450);
            this.txtChat.TabIndex = 5;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(572, 482);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(226, 26);
            this.txtInput.TabIndex = 6;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(804, 482);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(68, 26);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(283, 482);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(0, 12);
            this.lblCurrentPage.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 409);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 409);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(-1, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(550, 409);
            this.panel3.TabIndex = 19;
            // 
            // delPageBtn
            // 
            this.delPageBtn.Location = new System.Drawing.Point(283, 513);
            this.delPageBtn.Name = "delPageBtn";
            this.delPageBtn.Size = new System.Drawing.Size(88, 23);
            this.delPageBtn.TabIndex = 25;
            this.delPageBtn.Text = "페이지 삭제";
            this.delPageBtn.UseVisualStyleBackColor = true;
            this.delPageBtn.Click += new System.EventHandler(this.delPageBtn_Click);
            // 
            // createPageBtn
            // 
            this.createPageBtn.Location = new System.Drawing.Point(189, 513);
            this.createPageBtn.Name = "createPageBtn";
            this.createPageBtn.Size = new System.Drawing.Size(88, 23);
            this.createPageBtn.TabIndex = 24;
            this.createPageBtn.Text = "페이지 생성";
            this.createPageBtn.UseVisualStyleBackColor = true;
            this.createPageBtn.Click += new System.EventHandler(this.createPageBtn_Click);
            // 
            // nextPageBtn
            // 
            this.nextPageBtn.Location = new System.Drawing.Point(510, 472);
            this.nextPageBtn.Name = "nextPageBtn";
            this.nextPageBtn.Size = new System.Drawing.Size(52, 38);
            this.nextPageBtn.TabIndex = 23;
            this.nextPageBtn.Text = ">>";
            this.nextPageBtn.UseVisualStyleBackColor = true;
            this.nextPageBtn.Click += new System.EventHandler(this.nextPageBtn_Click);
            // 
            // prevPageBtn
            // 
            this.prevPageBtn.Location = new System.Drawing.Point(12, 472);
            this.prevPageBtn.Name = "prevPageBtn";
            this.prevPageBtn.Size = new System.Drawing.Size(52, 38);
            this.prevPageBtn.TabIndex = 22;
            this.prevPageBtn.Text = "<<";
            this.prevPageBtn.UseVisualStyleBackColor = true;
            this.prevPageBtn.Click += new System.EventHandler(this.prevPageBtn_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(228, 482);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(49, 12);
            this.lblPage.TabIndex = 21;
            this.lblPage.Text = "페이지: ";
            // 
            // toolBarPanel
            // 
            this.toolBarPanel.BackColor = System.Drawing.SystemColors.Window;
            this.toolBarPanel.Controls.Add(this.toolBar1);
            this.toolBarPanel.Location = new System.Drawing.Point(12, 12);
            this.toolBarPanel.Name = "toolBarPanel";
            this.toolBarPanel.Size = new System.Drawing.Size(550, 34);
            this.toolBarPanel.TabIndex = 20;
            // 
            // toolBar1
            // 
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.penButton,
            this.eraserButton,
            this.lineButton,
            this.rectButton,
            this.circleButton,
            this.fillButton,
            this.textButton,
            this.imageButton});
            this.toolBar1.ButtonSize = new System.Drawing.Size(32, 32);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(550, 35);
            this.toolBar1.TabIndex = 0;
            // 
            // penButton
            // 
            this.penButton.ImageIndex = 0;
            this.penButton.Name = "penButton";
            // 
            // eraserButton
            // 
            this.eraserButton.ImageIndex = 1;
            this.eraserButton.Name = "eraserButton";
            // 
            // lineButton
            // 
            this.lineButton.ImageIndex = 2;
            this.lineButton.Name = "lineButton";
            // 
            // rectButton
            // 
            this.rectButton.ImageIndex = 3;
            this.rectButton.Name = "rectButton";
            // 
            // circleButton
            // 
            this.circleButton.ImageIndex = 4;
            this.circleButton.Name = "circleButton";
            // 
            // fillButton
            // 
            this.fillButton.ImageIndex = 5;
            this.fillButton.Name = "fillButton";
            // 
            // textButton
            // 
            this.textButton.ImageIndex = 6;
            this.textButton.Name = "textButton";
            // 
            // imageButton
            // 
            this.imageButton.ImageIndex = 7;
            this.imageButton.Name = "imageButton";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pen.png");
            this.imageList1.Images.SetKeyName(1, "eraser.png");
            this.imageList1.Images.SetKeyName(2, "line.png");
            this.imageList1.Images.SetKeyName(3, "square.png");
            this.imageList1.Images.SetKeyName(4, "circle.png");
            this.imageList1.Images.SetKeyName(5, "fill.png");
            this.imageList1.Images.SetKeyName(6, "text.png");
            this.imageList1.Images.SetKeyName(7, "imageInsert.png");
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.delPageBtn);
            this.Controls.Add(this.createPageBtn);
            this.Controls.Add(this.nextPageBtn);
            this.Controls.Add(this.prevPageBtn);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.toolBarPanel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ClientForm";
            this.Text = "CanvasTogether";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button delPageBtn;
        private System.Windows.Forms.Button createPageBtn;
        private System.Windows.Forms.Button nextPageBtn;
        private System.Windows.Forms.Button prevPageBtn;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Panel toolBarPanel;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton penButton;
        private System.Windows.Forms.ToolBarButton eraserButton;
        private System.Windows.Forms.ToolBarButton lineButton;
        private System.Windows.Forms.ToolBarButton rectButton;
        private System.Windows.Forms.ToolBarButton circleButton;
        private System.Windows.Forms.ToolBarButton fillButton;
        private System.Windows.Forms.ToolBarButton textButton;
        private System.Windows.Forms.ToolBarButton imageButton;
        private System.Windows.Forms.ImageList imageList1;
    }
}