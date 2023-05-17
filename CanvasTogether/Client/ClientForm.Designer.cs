namespace CanvasTogether
{
    partial class ClientForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.delPageBtn = new System.Windows.Forms.Button();
            this.createPageBtn = new System.Windows.Forms.Button();
            this.nextPageBtn = new System.Windows.Forms.Button();
            this.prevPageBtn = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_undo = new System.Windows.Forms.ToolStripButton();
            this.btn_redo = new System.Windows.Forms.ToolStripButton();
            this.btn_pen = new System.Windows.Forms.ToolStripButton();
            this.btn_eraser = new System.Windows.Forms.ToolStripButton();
            this.ddbtn_polygon = new System.Windows.Forms.ToolStripDropDownButton();
            this.item_line = new System.Windows.Forms.ToolStripMenuItem();
            this.item_rect = new System.Windows.Forms.ToolStripMenuItem();
            this.item_circle = new System.Windows.Forms.ToolStripMenuItem();
            this.ddbtn_thick = new System.Windows.Forms.ToolStripDropDownButton();
            this.item_Thick1 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_Thick2 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_Thick3 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_Thick4 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_Thick5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_text = new System.Windows.Forms.ToolStripButton();
            this.btn_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.color1 = new System.Windows.Forms.ToolStripButton();
            this.color2 = new System.Windows.Forms.ToolStripButton();
            this.color3 = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "freepen.png");
            this.imageList1.Images.SetKeyName(1, "eraser.png");
            this.imageList1.Images.SetKeyName(2, "line.png");
            this.imageList1.Images.SetKeyName(3, "rect.png");
            this.imageList1.Images.SetKeyName(4, "circle.png");
            this.imageList1.Images.SetKeyName(5, "fill.png");
            this.imageList1.Images.SetKeyName(6, "text.png");
            this.imageList1.Images.SetKeyName(7, "image.png");
            this.imageList1.Images.SetKeyName(8, "thick1.JPG");
            this.imageList1.Images.SetKeyName(9, "thick2.JPG");
            this.imageList1.Images.SetKeyName(10, "thick3.JPG");
            this.imageList1.Images.SetKeyName(11, "thick4.JPG");
            this.imageList1.Images.SetKeyName(12, "thick5.JPG");
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(568, 11);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(300, 450);
            this.txtChat.TabIndex = 29;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(804, 481);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(68, 26);
            this.btnSend.TabIndex = 31;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(572, 481);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(226, 26);
            this.txtInput.TabIndex = 30;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(283, 480);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(0, 12);
            this.lblCurrentPage.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 414);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 414);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(12, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(550, 415);
            this.panel3.TabIndex = 19;
            // 
            // delPageBtn
            // 
            this.delPageBtn.Location = new System.Drawing.Point(283, 511);
            this.delPageBtn.Name = "delPageBtn";
            this.delPageBtn.Size = new System.Drawing.Size(88, 23);
            this.delPageBtn.TabIndex = 38;
            this.delPageBtn.Text = "페이지 삭제";
            this.delPageBtn.UseVisualStyleBackColor = true;
            // 
            // createPageBtn
            // 
            this.createPageBtn.Location = new System.Drawing.Point(189, 511);
            this.createPageBtn.Name = "createPageBtn";
            this.createPageBtn.Size = new System.Drawing.Size(88, 23);
            this.createPageBtn.TabIndex = 37;
            this.createPageBtn.Text = "페이지 생성";
            this.createPageBtn.UseVisualStyleBackColor = true;
            // 
            // nextPageBtn
            // 
            this.nextPageBtn.Location = new System.Drawing.Point(510, 470);
            this.nextPageBtn.Name = "nextPageBtn";
            this.nextPageBtn.Size = new System.Drawing.Size(52, 38);
            this.nextPageBtn.TabIndex = 36;
            this.nextPageBtn.Text = ">>";
            this.nextPageBtn.UseVisualStyleBackColor = true;
            // 
            // prevPageBtn
            // 
            this.prevPageBtn.Location = new System.Drawing.Point(12, 470);
            this.prevPageBtn.Name = "prevPageBtn";
            this.prevPageBtn.Size = new System.Drawing.Size(52, 38);
            this.prevPageBtn.TabIndex = 35;
            this.prevPageBtn.Text = "<<";
            this.prevPageBtn.UseVisualStyleBackColor = true;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(228, 480);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(49, 12);
            this.lblPage.TabIndex = 34;
            this.lblPage.Text = "페이지: ";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(427, 525);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 32;
            this.btnDisconnect.Text = "연결 종료";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_undo,
            this.btn_redo,
            this.btn_pen,
            this.btn_eraser,
            this.ddbtn_polygon,
            this.ddbtn_thick,
            this.btn_text,
            this.btn_image,
            this.toolStripSeparator1,
            this.color1,
            this.color2,
            this.color3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(562, 43);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_undo
            // 
            this.btn_undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_undo.Image = ((System.Drawing.Image)(resources.GetObject("btn_undo.Image")));
            this.btn_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_undo.Name = "btn_undo";
            this.btn_undo.Size = new System.Drawing.Size(34, 40);
            this.btn_undo.Text = "toolStripButton1";
            // 
            // btn_redo
            // 
            this.btn_redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_redo.Image = ((System.Drawing.Image)(resources.GetObject("btn_redo.Image")));
            this.btn_redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_redo.Name = "btn_redo";
            this.btn_redo.Size = new System.Drawing.Size(34, 40);
            this.btn_redo.Text = "toolStripButton2";
            // 
            // btn_pen
            // 
            this.btn_pen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_pen.Image = ((System.Drawing.Image)(resources.GetObject("btn_pen.Image")));
            this.btn_pen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_pen.Name = "btn_pen";
            this.btn_pen.Size = new System.Drawing.Size(34, 40);
            this.btn_pen.Text = "toolStripButton1";
            // 
            // btn_eraser
            // 
            this.btn_eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_eraser.Image = ((System.Drawing.Image)(resources.GetObject("btn_eraser.Image")));
            this.btn_eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(34, 40);
            this.btn_eraser.Text = "toolStripButton1";
            // 
            // ddbtn_polygon
            // 
            this.ddbtn_polygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbtn_polygon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_line,
            this.item_rect,
            this.item_circle});
            this.ddbtn_polygon.Image = ((System.Drawing.Image)(resources.GetObject("ddbtn_polygon.Image")));
            this.ddbtn_polygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbtn_polygon.Name = "ddbtn_polygon";
            this.ddbtn_polygon.Size = new System.Drawing.Size(43, 40);
            this.ddbtn_polygon.Text = "toolStripDropDownButton1";
            this.ddbtn_polygon.Click += new System.EventHandler(this.ddbtn_polygon_Click);
            // 
            // item_line
            // 
            this.item_line.Image = ((System.Drawing.Image)(resources.GetObject("item_line.Image")));
            this.item_line.Name = "item_line";
            this.item_line.Size = new System.Drawing.Size(126, 22);
            this.item_line.Text = "Line";
            // 
            // item_rect
            // 
            this.item_rect.Image = ((System.Drawing.Image)(resources.GetObject("item_rect.Image")));
            this.item_rect.Name = "item_rect";
            this.item_rect.Size = new System.Drawing.Size(126, 22);
            this.item_rect.Text = "Rectangle";
            // 
            // item_circle
            // 
            this.item_circle.Image = ((System.Drawing.Image)(resources.GetObject("item_circle.Image")));
            this.item_circle.Name = "item_circle";
            this.item_circle.Size = new System.Drawing.Size(126, 22);
            this.item_circle.Text = "Circle";
            // 
            // ddbtn_thick
            // 
            this.ddbtn_thick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbtn_thick.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_Thick1,
            this.item_Thick2,
            this.item_Thick3,
            this.item_Thick4,
            this.item_Thick5});
            this.ddbtn_thick.Image = ((System.Drawing.Image)(resources.GetObject("ddbtn_thick.Image")));
            this.ddbtn_thick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbtn_thick.Name = "ddbtn_thick";
            this.ddbtn_thick.Size = new System.Drawing.Size(43, 40);
            this.ddbtn_thick.Text = "toolStripDropDownButton2";
            this.ddbtn_thick.Click += new System.EventHandler(this.ddbtn_thick_Click);
            // 
            // item_Thick1
            // 
            this.item_Thick1.Image = ((System.Drawing.Image)(resources.GetObject("item_Thick1.Image")));
            this.item_Thick1.Name = "item_Thick1";
            this.item_Thick1.Size = new System.Drawing.Size(109, 22);
            this.item_Thick1.Text = "Thick1";
            // 
            // item_Thick2
            // 
            this.item_Thick2.Image = ((System.Drawing.Image)(resources.GetObject("item_Thick2.Image")));
            this.item_Thick2.Name = "item_Thick2";
            this.item_Thick2.Size = new System.Drawing.Size(109, 22);
            this.item_Thick2.Text = "Thick2";
            // 
            // item_Thick3
            // 
            this.item_Thick3.Image = ((System.Drawing.Image)(resources.GetObject("item_Thick3.Image")));
            this.item_Thick3.Name = "item_Thick3";
            this.item_Thick3.Size = new System.Drawing.Size(109, 22);
            this.item_Thick3.Text = "Thick3";
            // 
            // item_Thick4
            // 
            this.item_Thick4.Image = ((System.Drawing.Image)(resources.GetObject("item_Thick4.Image")));
            this.item_Thick4.Name = "item_Thick4";
            this.item_Thick4.Size = new System.Drawing.Size(109, 22);
            this.item_Thick4.Text = "Thick4";
            // 
            // item_Thick5
            // 
            this.item_Thick5.Image = ((System.Drawing.Image)(resources.GetObject("item_Thick5.Image")));
            this.item_Thick5.Name = "item_Thick5";
            this.item_Thick5.Size = new System.Drawing.Size(109, 22);
            this.item_Thick5.Text = "Thick5";
            // 
            // btn_text
            // 
            this.btn_text.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_text.Image = ((System.Drawing.Image)(resources.GetObject("btn_text.Image")));
            this.btn_text.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_text.Name = "btn_text";
            this.btn_text.Size = new System.Drawing.Size(34, 40);
            this.btn_text.Text = "toolStripButton1";
            // 
            // btn_image
            // 
            this.btn_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_image.Image = ((System.Drawing.Image)(resources.GetObject("btn_image.Image")));
            this.btn_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_image.Name = "btn_image";
            this.btn_image.Size = new System.Drawing.Size(34, 40);
            this.btn_image.Text = "toolStripButton2";
            this.btn_image.Click += new System.EventHandler(this.btn_image_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // color1
            // 
            this.color1.AutoSize = false;
            this.color1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.color1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.color1.Image = ((System.Drawing.Image)(resources.GetObject("color1.Image")));
            this.color1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(28, 28);
            this.color1.Click += new System.EventHandler(this.Btn_SelectColor_Click);
            // 
            // color2
            // 
            this.color2.AutoSize = false;
            this.color2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.color2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.color2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.color2.Image = ((System.Drawing.Image)(resources.GetObject("color2.Image")));
            this.color2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(28, 28);
            this.color2.Click += new System.EventHandler(this.Btn_SelectColor_Click);
            // 
            // color3
            // 
            this.color3.AutoSize = false;
            this.color3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.color3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.color3.Image = ((System.Drawing.Image)(resources.GetObject("color3.Image")));
            this.color3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(28, 28);
            this.color3.Click += new System.EventHandler(this.Btn_SelectColor_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.delPageBtn);
            this.Controls.Add(this.createPageBtn);
            this.Controls.Add(this.nextPageBtn);
            this.Controls.Add(this.prevPageBtn);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClientForm";
            this.Text = "Lobby";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button delPageBtn;
        private System.Windows.Forms.Button createPageBtn;
        private System.Windows.Forms.Button nextPageBtn;
        private System.Windows.Forms.Button prevPageBtn;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_undo;
        private System.Windows.Forms.ToolStripButton btn_redo;
        private System.Windows.Forms.ToolStripButton btn_pen;
        private System.Windows.Forms.ToolStripButton btn_eraser;
        private System.Windows.Forms.ToolStripDropDownButton ddbtn_polygon;
        private System.Windows.Forms.ToolStripMenuItem item_line;
        private System.Windows.Forms.ToolStripMenuItem item_rect;
        private System.Windows.Forms.ToolStripMenuItem item_circle;
        private System.Windows.Forms.ToolStripDropDownButton ddbtn_thick;
        private System.Windows.Forms.ToolStripMenuItem item_Thick1;
        private System.Windows.Forms.ToolStripMenuItem item_Thick2;
        private System.Windows.Forms.ToolStripMenuItem item_Thick3;
        private System.Windows.Forms.ToolStripMenuItem item_Thick4;
        private System.Windows.Forms.ToolStripMenuItem item_Thick5;
        private System.Windows.Forms.ToolStripButton btn_text;
        private System.Windows.Forms.ToolStripButton btn_image;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton color1;
        private System.Windows.Forms.ToolStripButton color2;
        private System.Windows.Forms.ToolStripButton color3;
    }
}

