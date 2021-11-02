using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyVatTu.Views
{
    public partial class FMain : Form
    {
        FLogin fLogin;
        public FMain(FLogin f)
        {
            InitializeComponent();
            fLogin = f;
        }
        public void UpdateInfoLogin()
        {
            lbCodeLogin.Text = "Ma NV: " + Program.username;
            lbNameLogin.Text = "Ten: " + Program.fullName;
            lbGroup.Text = "Nhom: " + Program.group;
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            fLogin.Close();
        }
    }
}
