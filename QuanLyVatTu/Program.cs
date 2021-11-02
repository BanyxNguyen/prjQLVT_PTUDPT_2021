using QuanLyVatTu.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static SqlConnection sqlConn = new SqlConnection();
        public static String dbName = "QLVT";
        public static String connStr;
        public static String connStrOrigin = "Data Source=DESKTOP-SK3SNKM;Initial Catalog=QLVT;User ID=sa;Password=sa";
        public static int branch;
        public static String serverName;
        public static String username;
        public static String loginName;
        public static String loginNameCurrent;
        public static String password;
        public static String passwordCurrent;
        public static String fullName;
        public static String group;
        public static SqlDataReader myReader;

        public static BindingSource bds_dspm = new BindingSource();

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FLogin());
        }
        public static bool CheckConnection()
        {
            if (sqlConn != null && sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
            try
            {
                connStr = "Data Source=" + serverName + ";Initial Catalog=" + dbName + ";User ID=" + loginName + ";Password=" + password;
                sqlConn.ConnectionString = connStr;
                sqlConn.Open();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản hoặc mật khẩu.", "", MessageBoxButtons.OK);
                return false;
            }
        }
        public static SqlDataReader ExecSqlDataReader(string strQuery)
        {
            SqlDataReader sqlDR;
            SqlCommand sqlCmd = new SqlCommand(strQuery, sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
            try
            {
                sqlDR = sqlCmd.ExecuteReader();
                return sqlDR;
            }
            catch (Exception e)
            {
                sqlConn.Close();
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public static DataTable ExecSqlDataTable(string strQuery)
        {
            DataTable dt = new DataTable();
            if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(strQuery, sqlConn);
            da.Fill(dt);
            sqlConn.Close();
            return dt;
        }
        public static int ExecSqlNonQuery(string strQuery)
        {
            SqlCommand sqlCmd = new SqlCommand(strQuery, sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandTimeout = 300; // 5 min
            if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
            try
            {
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                return 0;
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
                sqlConn.Close();
                return e.State;
            }
        }
    }
}
