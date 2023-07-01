namespace btLon_qLyBanDoDienTu
{
    partial class ResetMK
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
            this.emailTb = new System.Windows.Forms.TextBox();
            this.sendMailBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.messageTb = new System.Windows.Forms.Label();
            this.xacNhanOtpPn = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.guiOTPXacNhanBtn = new System.Windows.Forms.Button();
            this.otpTb = new System.Windows.Forms.TextBox();
            this.message2Lb = new System.Windows.Forms.Label();
            this.nhapMKMoiPn = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.xacNhanDoiMKBtn = new System.Windows.Forms.Button();
            this.mkMoiTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nhapLaiMKMoiTb = new System.Windows.Forms.TextBox();
            this.datLaiMKChoTKLb = new System.Windows.Forms.Label();
            this.message3Lb = new System.Windows.Forms.Label();
            this.xacNhanOtpPn.SuspendLayout();
            this.nhapMKMoiPn.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailTb
            // 
            this.emailTb.Location = new System.Drawing.Point(42, 93);
            this.emailTb.Margin = new System.Windows.Forms.Padding(4);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(399, 26);
            this.emailTb.TabIndex = 0;
            // 
            // sendMailBtn
            // 
            this.sendMailBtn.Location = new System.Drawing.Point(182, 179);
            this.sendMailBtn.Name = "sendMailBtn";
            this.sendMailBtn.Size = new System.Drawing.Size(118, 35);
            this.sendMailBtn.TabIndex = 1;
            this.sendMailBtn.Text = "Gửi";
            this.sendMailBtn.UseVisualStyleBackColor = true;
            this.sendMailBtn.Click += new System.EventHandler(this.sendMailBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập email của bạn:";
            // 
            // messageTb
            // 
            this.messageTb.AutoSize = true;
            this.messageTb.ForeColor = System.Drawing.Color.Crimson;
            this.messageTb.Location = new System.Drawing.Point(39, 136);
            this.messageTb.Name = "messageTb";
            this.messageTb.Size = new System.Drawing.Size(0, 20);
            this.messageTb.TabIndex = 3;
            // 
            // xacNhanOtpPn
            // 
            this.xacNhanOtpPn.Controls.Add(this.message2Lb);
            this.xacNhanOtpPn.Controls.Add(this.label2);
            this.xacNhanOtpPn.Controls.Add(this.guiOTPXacNhanBtn);
            this.xacNhanOtpPn.Controls.Add(this.otpTb);
            this.xacNhanOtpPn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xacNhanOtpPn.Location = new System.Drawing.Point(0, 0);
            this.xacNhanOtpPn.Name = "xacNhanOtpPn";
            this.xacNhanOtpPn.Size = new System.Drawing.Size(482, 253);
            this.xacNhanOtpPn.TabIndex = 4;
            this.xacNhanOtpPn.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nhập OTP được gửi đến email của bạn:";
            // 
            // guiOTPXacNhanBtn
            // 
            this.guiOTPXacNhanBtn.Location = new System.Drawing.Point(183, 164);
            this.guiOTPXacNhanBtn.Name = "guiOTPXacNhanBtn";
            this.guiOTPXacNhanBtn.Size = new System.Drawing.Size(118, 35);
            this.guiOTPXacNhanBtn.TabIndex = 4;
            this.guiOTPXacNhanBtn.Text = "Gửi";
            this.guiOTPXacNhanBtn.UseVisualStyleBackColor = true;
            this.guiOTPXacNhanBtn.Click += new System.EventHandler(this.guiOTPXacNhanBtn_Click);
            // 
            // otpTb
            // 
            this.otpTb.Location = new System.Drawing.Point(43, 78);
            this.otpTb.Margin = new System.Windows.Forms.Padding(4);
            this.otpTb.Name = "otpTb";
            this.otpTb.Size = new System.Drawing.Size(399, 26);
            this.otpTb.TabIndex = 3;
            // 
            // message2Lb
            // 
            this.message2Lb.AutoSize = true;
            this.message2Lb.ForeColor = System.Drawing.Color.Crimson;
            this.message2Lb.Location = new System.Drawing.Point(42, 136);
            this.message2Lb.Name = "message2Lb";
            this.message2Lb.Size = new System.Drawing.Size(0, 20);
            this.message2Lb.TabIndex = 6;
            // 
            // nhapMKMoiPn
            // 
            this.nhapMKMoiPn.Controls.Add(this.message3Lb);
            this.nhapMKMoiPn.Controls.Add(this.datLaiMKChoTKLb);
            this.nhapMKMoiPn.Controls.Add(this.label4);
            this.nhapMKMoiPn.Controls.Add(this.nhapLaiMKMoiTb);
            this.nhapMKMoiPn.Controls.Add(this.label3);
            this.nhapMKMoiPn.Controls.Add(this.xacNhanDoiMKBtn);
            this.nhapMKMoiPn.Controls.Add(this.mkMoiTb);
            this.nhapMKMoiPn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nhapMKMoiPn.Location = new System.Drawing.Point(0, 0);
            this.nhapMKMoiPn.Name = "nhapMKMoiPn";
            this.nhapMKMoiPn.Size = new System.Drawing.Size(482, 253);
            this.nhapMKMoiPn.TabIndex = 5;
            this.nhapMKMoiPn.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nhập mật khẩu mới:";
            // 
            // xacNhanDoiMKBtn
            // 
            this.xacNhanDoiMKBtn.Location = new System.Drawing.Point(183, 202);
            this.xacNhanDoiMKBtn.Name = "xacNhanDoiMKBtn";
            this.xacNhanDoiMKBtn.Size = new System.Drawing.Size(118, 35);
            this.xacNhanDoiMKBtn.TabIndex = 4;
            this.xacNhanDoiMKBtn.Text = "Xác nhận";
            this.xacNhanDoiMKBtn.UseVisualStyleBackColor = true;
            this.xacNhanDoiMKBtn.Click += new System.EventHandler(this.xacNhanDoiMKBtn_Click);
            // 
            // mkMoiTb
            // 
            this.mkMoiTb.Location = new System.Drawing.Point(43, 85);
            this.mkMoiTb.Margin = new System.Windows.Forms.Padding(4);
            this.mkMoiTb.Name = "mkMoiTb";
            this.mkMoiTb.Size = new System.Drawing.Size(399, 26);
            this.mkMoiTb.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nhập lại mật khẩu:";
            // 
            // nhapLaiMKMoiTb
            // 
            this.nhapLaiMKMoiTb.Location = new System.Drawing.Point(43, 148);
            this.nhapLaiMKMoiTb.Margin = new System.Windows.Forms.Padding(4);
            this.nhapLaiMKMoiTb.Name = "nhapLaiMKMoiTb";
            this.nhapLaiMKMoiTb.Size = new System.Drawing.Size(399, 26);
            this.nhapLaiMKMoiTb.TabIndex = 6;
            // 
            // datLaiMKChoTKLb
            // 
            this.datLaiMKChoTKLb.AutoSize = true;
            this.datLaiMKChoTKLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.datLaiMKChoTKLb.Location = new System.Drawing.Point(111, 16);
            this.datLaiMKChoTKLb.Name = "datLaiMKChoTKLb";
            this.datLaiMKChoTKLb.Size = new System.Drawing.Size(260, 29);
            this.datLaiMKChoTKLb.TabIndex = 8;
            this.datLaiMKChoTKLb.Text = "Đặt lại mật khẩu cho (";
            // 
            // message3Lb
            // 
            this.message3Lb.AutoSize = true;
            this.message3Lb.ForeColor = System.Drawing.Color.Crimson;
            this.message3Lb.Location = new System.Drawing.Point(42, 181);
            this.message3Lb.Name = "message3Lb";
            this.message3Lb.Size = new System.Drawing.Size(0, 20);
            this.message3Lb.TabIndex = 9;
            // 
            // ResetMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.nhapMKMoiPn);
            this.Controls.Add(this.xacNhanOtpPn);
            this.Controls.Add(this.messageTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendMailBtn);
            this.Controls.Add(this.emailTb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResetMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt lại mật khẩu";
            this.Load += new System.EventHandler(this.ResetMK_Load);
            this.xacNhanOtpPn.ResumeLayout(false);
            this.xacNhanOtpPn.PerformLayout();
            this.nhapMKMoiPn.ResumeLayout(false);
            this.nhapMKMoiPn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Button sendMailBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label messageTb;
        private System.Windows.Forms.Panel xacNhanOtpPn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button guiOTPXacNhanBtn;
        private System.Windows.Forms.TextBox otpTb;
        private System.Windows.Forms.Label message2Lb;
        private System.Windows.Forms.Panel nhapMKMoiPn;
        private System.Windows.Forms.Label datLaiMKChoTKLb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nhapLaiMKMoiTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button xacNhanDoiMKBtn;
        private System.Windows.Forms.TextBox mkMoiTb;
        private System.Windows.Forms.Label message3Lb;
    }
}