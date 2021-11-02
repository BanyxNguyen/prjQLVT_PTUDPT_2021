using QuanLyVatTu.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu
{
    public partial class FLogin : Form
    {
        private SqlConnection myConnection = new SqlConnection();
        public FLogin()
        {
            InitializeComponent();
        }
        private void GetFragmentation(String strQuery)
        {
            DataTable dt = new DataTable();
            if (myConnection.State == ConnectionState.Closed) myConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(strQuery, myConnection);
            sda.Fill(dt);
            myConnection.Close();
            Program.bds_dspm.DataSource = dt;
            cmbBranch.DataSource = Program.bds_dspm;
            cmbBranch.DisplayMember = "TENCN";
            cmbBranch.ValueMember = "TENSERVER";
        }
        private Boolean CheckChonnection()
        {
            if (myConnection != null && myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            try
            {
                myConnection.ConnectionString = Program.connStrOrigin;
                myConnection.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối đến server gốc, vui lòng kiểm tra lại.\n" + e.Message, "", MessageBoxButtons.OK);
                return false;
            }
        }
        private void fLogin_Load(object sender, EventArgs e)
        {
            if (!CheckChonnection()) return;
            GetFragmentation("SELECT * FROM Get_Subcriber");
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.SelectedIndex = 1;
            cmbBranch.SelectedIndex = 0;
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.serverName = cmbBranch.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui long dien tai khoan va mat khau", "", MessageBoxButtons.OK);
                return;
            }
            Program.loginName = txtUser.Text.Trim();
            Program.password = txtPassword.Text.Trim();
            if (!Program.CheckConnection()) return;

            Program.branch = cmbBranch.SelectedIndex;
            Program.loginNameCurrent = Program.loginName;
            Program.passwordCurrent = Program.password;

            string strQuery = "EXEC Sp_GetInfoLogin " + Program.loginNameCurrent;
            Program.myReader = Program.ExecSqlDataReader(strQuery);
            if (Program.myReader == null) return;
            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0);
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Tai khoan khong co quyen truy cap, vui long kiem tra lai tai khoan, mat khau", "", MessageBoxButtons.OK);
                return;
            }
            Program.fullName = Program.myReader.GetString(1);
            Program.group = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.sqlConn.Close();

            Hide();
            FMain fMain = new FMain(this);
            fMain.UpdateInfoLogin();
            fMain.Show();
        }
    }
}
