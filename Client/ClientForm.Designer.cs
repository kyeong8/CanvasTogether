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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
<<<<<<< HEAD:CanvasTogether/Form2.Designer.cs
            this.chatUI = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
=======
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
>>>>>>> 2af93a44c36ea2203ad57ad2c3ac182f4fc4efb0:Client/ClientForm.Designer.cs
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "왼쪽 그림판 영역";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "사이즈는 600, 600으로 해주세요";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(467, 658);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(86, 29);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "연결 종료";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
<<<<<<< HEAD:CanvasTogether/Form2.Designer.cs
            // chatUI
            // 
            this.chatUI.Location = new System.Drawing.Point(708, 12);
            this.chatUI.Multiline = true;
            this.chatUI.Name = "chatUI";
            this.chatUI.Size = new System.Drawing.Size(300, 600);
            this.chatUI.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(814, 666);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "송신";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(708, 627);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(300, 25);
            this.txtSend.TabIndex = 7;
            // 
            // Form2
=======
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
            // ClientForm
>>>>>>> 2af93a44c36ea2203ad57ad2c3ac182f4fc4efb0:Client/ClientForm.Designer.cs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD:CanvasTogether/Form2.Designer.cs
            this.ClientSize = new System.Drawing.Size(1010, 701);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.chatUI);
=======
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtChat);
>>>>>>> 2af93a44c36ea2203ad57ad2c3ac182f4fc4efb0:Client/ClientForm.Designer.cs
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
<<<<<<< HEAD:CanvasTogether/Form2.Designer.cs
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
=======
            this.Controls.Add(this.label1);
            this.Name = "ClientForm";
>>>>>>> 2af93a44c36ea2203ad57ad2c3ac182f4fc4efb0:Client/ClientForm.Designer.cs
            this.Text = "CanvasTogether";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDisconnect;
<<<<<<< HEAD:CanvasTogether/Form2.Designer.cs
        private System.Windows.Forms.TextBox chatUI;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
=======
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
>>>>>>> 2af93a44c36ea2203ad57ad2c3ac182f4fc4efb0:Client/ClientForm.Designer.cs
    }
}