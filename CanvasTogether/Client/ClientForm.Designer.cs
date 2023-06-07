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
            this.btnExit = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_undo = new System.Windows.Forms.ToolStripButton();
            this.btn_redo = new System.Windows.Forms.ToolStripButton();
            this.btn_pen = new System.Windows.Forms.ToolStripButton();
            this.btn_eraser = new System.Windows.Forms.ToolStripButton();
            this.btn_shape = new System.Windows.Forms.ToolStripDropDownButton();
            this.item_line = new System.Windows.Forms.ToolStripMenuItem();
            this.item_rect = new System.Windows.Forms.ToolStripMenuItem();
            this.item_circle = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_thick = new System.Windows.Forms.ToolStripDropDownButton();
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
            this.userNameList = new System.Windows.Forms.TextBox();
            this.userCnt = new System.Windows.Forms.Label();
            this.panel1 = new CanvasTogether.DoubleBufferPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1010, 24);
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
            this.txtChat.Location = new System.Drawing.Point(646, 144);
            this.txtChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(346, 450);
            this.txtChat.TabIndex = 29;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(919, 600);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(73, 32);
            this.btnSend.TabIndex = 31;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(646, 599);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(266, 32);
            this.txtInput.TabIndex = 30;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(323, 600);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(0, 15);
            this.lblCurrentPage.TabIndex = 40;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(480, 658);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(111, 29);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "방에서 나가기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_undo,
            this.btn_redo,
            this.btn_pen,
            this.btn_eraser,
            this.btn_shape,
            this.btn_thick,
            this.btn_text,
            this.btn_image,
            this.toolStripSeparator1,
            this.color1,
            this.color2,
            this.color3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(642, 46);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btn_undo
            // 
            this.btn_undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_undo.Image = ((System.Drawing.Image)(resources.GetObject("btn_undo.Image")));
            this.btn_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_undo.Name = "btn_undo";
            this.btn_undo.Size = new System.Drawing.Size(34, 43);
            this.btn_undo.Text = "toolStripButton1";
            this.btn_undo.ToolTipText = "실행 취소";
            this.btn_undo.Click += new System.EventHandler(this.btn_undo_Click);
            // 
            // btn_redo
            // 
            this.btn_redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_redo.Image = ((System.Drawing.Image)(resources.GetObject("btn_redo.Image")));
            this.btn_redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_redo.Name = "btn_redo";
            this.btn_redo.Size = new System.Drawing.Size(34, 43);
            this.btn_redo.Text = "toolStripButton2";
            this.btn_redo.ToolTipText = "다시 실행";
            this.btn_redo.Click += new System.EventHandler(this.btn_redo_Click);
            // 
            // btn_pen
            // 
            this.btn_pen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_pen.Image = ((System.Drawing.Image)(resources.GetObject("btn_pen.Image")));
            this.btn_pen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_pen.Name = "btn_pen";
            this.btn_pen.Size = new System.Drawing.Size(34, 43);
            this.btn_pen.Text = "toolStripButton1";
            this.btn_pen.ToolTipText = "자유펜";
            // 
            // btn_eraser
            // 
            this.btn_eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_eraser.Image = ((System.Drawing.Image)(resources.GetObject("btn_eraser.Image")));
            this.btn_eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(34, 43);
            this.btn_eraser.Text = "toolStripButton1";
            this.btn_eraser.ToolTipText = "지우개";
            // 
            // btn_shape
            // 
            this.btn_shape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_shape.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_line,
            this.item_rect,
            this.item_circle});
            this.btn_shape.Image = ((System.Drawing.Image)(resources.GetObject("btn_shape.Image")));
            this.btn_shape.Name = "btn_shape";
            this.btn_shape.Size = new System.Drawing.Size(44, 43);
            this.btn_shape.Text = "toolStripDropDownButton1";
            this.btn_shape.ToolTipText = "도형 선택";
            this.btn_shape.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Btn_shape_Click);
            // 
            // item_line
            // 
            this.item_line.Image = global::CanvasTogether.Properties.Resources.line;
            this.item_line.Name = "item_line";
            this.item_line.Size = new System.Drawing.Size(159, 26);
            this.item_line.Text = "Line";
            this.item_line.Click += new System.EventHandler(this.item_line_Click);
            // 
            // item_rect
            // 
            this.item_rect.Image = global::CanvasTogether.Properties.Resources.rect;
            this.item_rect.Name = "item_rect";
            this.item_rect.Size = new System.Drawing.Size(159, 26);
            this.item_rect.Text = "Rectangle";
            this.item_rect.Click += new System.EventHandler(this.item_rect_Click);
            // 
            // item_circle
            // 
            this.item_circle.Image = global::CanvasTogether.Properties.Resources.circle;
            this.item_circle.Name = "item_circle";
            this.item_circle.Size = new System.Drawing.Size(159, 26);
            this.item_circle.Text = "Circle";
            this.item_circle.Click += new System.EventHandler(this.item_circle_Click);
            // 
            // btn_thick
            // 
            this.btn_thick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_thick.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_Thick1,
            this.item_Thick2,
            this.item_Thick3,
            this.item_Thick4,
            this.item_Thick5});
            this.btn_thick.Image = ((System.Drawing.Image)(resources.GetObject("btn_thick.Image")));
            this.btn_thick.Name = "btn_thick";
            this.btn_thick.Size = new System.Drawing.Size(44, 43);
            this.btn_thick.Text = "toolStripDropDownButton2";
            this.btn_thick.ToolTipText = "굵기 선택";
            this.btn_thick.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Btn_thick_Click);
            // 
            // item_Thick1
            // 
            this.item_Thick1.Image = global::CanvasTogether.Properties.Resources.thick1;
            this.item_Thick1.Name = "item_Thick1";
            this.item_Thick1.Size = new System.Drawing.Size(136, 26);
            this.item_Thick1.Text = "Thick1";
            // 
            // item_Thick2
            // 
            this.item_Thick2.Image = global::CanvasTogether.Properties.Resources.thick2;
            this.item_Thick2.Name = "item_Thick2";
            this.item_Thick2.Size = new System.Drawing.Size(136, 26);
            this.item_Thick2.Text = "Thick2";
            // 
            // item_Thick3
            // 
            this.item_Thick3.Image = global::CanvasTogether.Properties.Resources.thick3;
            this.item_Thick3.Name = "item_Thick3";
            this.item_Thick3.Size = new System.Drawing.Size(136, 26);
            this.item_Thick3.Text = "Thick3";
            // 
            // item_Thick4
            // 
            this.item_Thick4.Image = global::CanvasTogether.Properties.Resources.thick4;
            this.item_Thick4.Name = "item_Thick4";
            this.item_Thick4.Size = new System.Drawing.Size(136, 26);
            this.item_Thick4.Text = "Thick4";
            // 
            // item_Thick5
            // 
            this.item_Thick5.Image = global::CanvasTogether.Properties.Resources.thick5;
            this.item_Thick5.Name = "item_Thick5";
            this.item_Thick5.Size = new System.Drawing.Size(136, 26);
            this.item_Thick5.Text = "Thick5";
            // 
            // btn_text
            // 
            this.btn_text.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_text.Image = ((System.Drawing.Image)(resources.GetObject("btn_text.Image")));
            this.btn_text.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_text.Name = "btn_text";
            this.btn_text.Size = new System.Drawing.Size(34, 43);
            this.btn_text.Text = "toolStripButton1";
            this.btn_text.ToolTipText = "텍스트 추가";
            // 
            // btn_image
            // 
            this.btn_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_image.Image = ((System.Drawing.Image)(resources.GetObject("btn_image.Image")));
            this.btn_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_image.Name = "btn_image";
            this.btn_image.Size = new System.Drawing.Size(34, 43);
            this.btn_image.Text = "toolStripButton2";
            this.btn_image.ToolTipText = "이미지 추가";
            this.btn_image.Click += new System.EventHandler(this.btn_image_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // color1
            // 
            this.color1.AutoSize = false;
            this.color1.BackColor = System.Drawing.Color.Black;
            this.color1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.color1.Image = ((System.Drawing.Image)(resources.GetObject("color1.Image")));
            this.color1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(28, 28);
            this.color1.ToolTipText = "좌클릭 시 색상 적용, 우클릭 시 색상 선택";
            this.color1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_SelectColor_Click);
            // 
            // color2
            // 
            this.color2.AutoSize = false;
            this.color2.BackColor = System.Drawing.Color.DodgerBlue;
            this.color2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.color2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.color2.Image = ((System.Drawing.Image)(resources.GetObject("color2.Image")));
            this.color2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(28, 28);
            this.color2.ToolTipText = "좌클릭 시 색상 적용, 우클릭 시 색상 선택";
            this.color2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_SelectColor_Click);
            // 
            // color3
            // 
            this.color3.AutoSize = false;
            this.color3.BackColor = System.Drawing.Color.OrangeRed;
            this.color3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.color3.Image = ((System.Drawing.Image)(resources.GetObject("color3.Image")));
            this.color3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(28, 28);
            this.color3.ToolTipText = "좌클릭 시 색상 적용, 우클릭 시 색상 선택";
            this.color3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_SelectColor_Click);
            // 
            // userNameList
            // 
            this.userNameList.Location = new System.Drawing.Point(646, 34);
            this.userNameList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userNameList.Multiline = true;
            this.userNameList.Name = "userNameList";
            this.userNameList.Size = new System.Drawing.Size(346, 102);
            this.userNameList.TabIndex = 42;
            // 
            // userCnt
            // 
            this.userCnt.AutoSize = true;
            this.userCnt.Location = new System.Drawing.Point(651, 11);
            this.userCnt.Name = "userCnt";
            this.userCnt.Size = new System.Drawing.Size(117, 15);
            this.userCnt.TabIndex = 43;
            this.userCnt.Text = "번 방, 접속인원:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(14, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 582);
            this.panel1.TabIndex = 39;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 701);
            this.Controls.Add(this.userCnt);
            this.Controls.Add(this.userNameList);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClientForm";
            this.Text = "Lobby";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
            this.Load += new System.EventHandler(this.ClientForm_Load);
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
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_undo;
        private System.Windows.Forms.ToolStripButton btn_redo;
        private System.Windows.Forms.ToolStripButton btn_pen;
        private System.Windows.Forms.ToolStripButton btn_eraser;
        private System.Windows.Forms.ToolStripDropDownButton btn_shape;
        private System.Windows.Forms.ToolStripMenuItem item_line;
        private System.Windows.Forms.ToolStripMenuItem item_rect;
        private System.Windows.Forms.ToolStripMenuItem item_circle;
        private System.Windows.Forms.ToolStripDropDownButton btn_thick;
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
        private DoubleBufferPanel panel1;
        private System.Windows.Forms.TextBox userNameList;
        private System.Windows.Forms.Label userCnt;
    }
}

