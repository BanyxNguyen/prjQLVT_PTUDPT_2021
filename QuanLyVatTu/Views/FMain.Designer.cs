
namespace QuanLyVatTu.Views
{
    partial class FMain
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
            this.lbCodeLogin = new System.Windows.Forms.Label();
            this.lbNameLogin = new System.Windows.Forms.Label();
            this.lbGroup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbCodeLogin
            // 
            this.lbCodeLogin.AutoSize = true;
            this.lbCodeLogin.Location = new System.Drawing.Point(44, 443);
            this.lbCodeLogin.Name = "lbCodeLogin";
            this.lbCodeLogin.Size = new System.Drawing.Size(52, 20);
            this.lbCodeLogin.TabIndex = 0;
            this.lbCodeLogin.Text = "MANV";
            // 
            // lbNameLogin
            // 
            this.lbNameLogin.AutoSize = true;
            this.lbNameLogin.Location = new System.Drawing.Point(165, 443);
            this.lbNameLogin.Name = "lbNameLogin";
            this.lbNameLogin.Size = new System.Drawing.Size(56, 20);
            this.lbNameLogin.TabIndex = 1;
            this.lbNameLogin.Text = "TENNV";
            // 
            // lbGroup
            // 
            this.lbGroup.AutoSize = true;
            this.lbGroup.Location = new System.Drawing.Point(277, 443);
            this.lbGroup.Name = "lbGroup";
            this.lbGroup.Size = new System.Drawing.Size(55, 20);
            this.lbGroup.TabIndex = 2;
            this.lbGroup.Text = "NHOM";
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 488);
            this.Controls.Add(this.lbGroup);
            this.Controls.Add(this.lbNameLogin);
            this.Controls.Add(this.lbCodeLogin);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCodeLogin;
        private System.Windows.Forms.Label lbNameLogin;
        private System.Windows.Forms.Label lbGroup;
    }
}