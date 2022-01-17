namespace ChatClient
{
    partial class MsgForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMsgContent = new System.Windows.Forms.TextBox();
            this.txtHisterMsgContent = new System.Windows.Forms.TextBox();
            this.txtToUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(604, 374);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(73, 25);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMsgContent
            // 
            this.txtMsgContent.Location = new System.Drawing.Point(98, 256);
            this.txtMsgContent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMsgContent.Multiline = true;
            this.txtMsgContent.Name = "txtMsgContent";
            this.txtMsgContent.Size = new System.Drawing.Size(604, 96);
            this.txtMsgContent.TabIndex = 8;
            // 
            // txtHisterMsgContent
            // 
            this.txtHisterMsgContent.Location = new System.Drawing.Point(98, 99);
            this.txtHisterMsgContent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHisterMsgContent.Multiline = true;
            this.txtHisterMsgContent.Name = "txtHisterMsgContent";
            this.txtHisterMsgContent.Size = new System.Drawing.Size(604, 142);
            this.txtHisterMsgContent.TabIndex = 9;
            // 
            // txtToUser
            // 
            this.txtToUser.Location = new System.Drawing.Point(415, 52);
            this.txtToUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtToUser.Name = "txtToUser";
            this.txtToUser.Size = new System.Drawing.Size(174, 23);
            this.txtToUser.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "好友名称：";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(191, 54);
            this.lblCurrentUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(68, 17);
            this.lblCurrentUser.TabIndex = 5;
            this.lblCurrentUser.Text = "当前用户：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "当前用户：";
            // 
            // MsgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMsgContent);
            this.Controls.Add(this.txtHisterMsgContent);
            this.Controls.Add(this.txtToUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.label1);
            this.Name = "MsgForm";
            this.Text = "MsgForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSend;
        private TextBox txtMsgContent;
        private TextBox txtHisterMsgContent;
        private TextBox txtToUser;
        private Label label2;
        private Label lblCurrentUser;
        private Label label1;
    }
}