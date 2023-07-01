using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace btLon_qLyBanDoDienTu
{
    public partial class Login : Form
    {
        private string loaiNV;
        private int maNV = 0;
        public Login()
        {
            InitializeComponent();
            panel5.BackColor = Color.FromArgb(150, Color.Black);
            panel6.BackColor = Color.FromArgb(0, Color.Black);
            checkBox1.BackColor = Color.FromArgb(0, Color.Black);
            label2.BackColor = Color.FromArgb(0, Color.Black);
            resetMKBtn.BackColor = Color.FromArgb(0, Color.Black);
            label5.BackColor = Color.FromArgb(0, Color.Black);
            label3.BackColor = Color.FromArgb(0, Color.Black);
            Message.BackColor = Color.FromArgb(0, Color.Black);
            userNameLb.BackColor = Color.FromArgb(0, Color.Black);
            passwordLb.BackColor = Color.FromArgb(0, Color.Black);
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.FlatAppearance.BorderSize = 0;
            returnBtn.FlatStyle = FlatStyle.Flat;
            returnBtn.FlatAppearance.BorderSize = 0;
            collapseBtn.FlatStyle = FlatStyle.Flat;
            collapseBtn.FlatAppearance.BorderSize = 0;
        }

        private async Task setPosterAsync()
        {
            int x = 1;
            while (x > 0)
            {
                await Task.Delay(3000);
                pictureBox1.Image = global::btLon_qLyBanDoDienTu.Properties.Resources.banner1;
                await Task.Delay(3000);
                pictureBox1.Image = global::btLon_qLyBanDoDienTu.Properties.Resources.banner2;
                await Task.Delay(3000);
                pictureBox1.Image = global::btLon_qLyBanDoDienTu.Properties.Resources.banner3;
            }
        }

        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\btLon_qLyBanDoDienTu\QuanLyBanHang.mdf;Integrated Security=True";
        SqlConnection sqlCon = null;
        private void moKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

        }

        private void traVeMaNV()
        {
            moKetNoi();

            string username = usernameTb.Text.Trim();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from NhanVien where Username='" + username + "'";

            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                maNV = reader.GetInt32(0);
            }
            reader.Close();
        }

        private bool kt;
        private void kTraDangNhap()
        {
            moKetNoi();

            string username = usernameTb.Text.Trim();
            string password = passwordTb.Text.Trim();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.CommandText = "select * from Login where Username='" + username + "' and Password='" + password + "'";

            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                loaiNV = reader.GetString(2);
                kt = true;
            }
            else
            {
                Message.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                kt = false;
            }

            reader.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(kt)
            {
                this.Hide();
                mainUI mainui = new mainUI();
                if (loaiNV == "Nhân viên")
                {
                    traVeMaNV();
                    mainui.MaNV = maNV;
                }
                mainui.Message = loaiNV;
                mainui.ShowDialog();
                this.Close();
            }
        }

        private void loginBtn_Enter(object sender, EventArgs e)
        {
            kTraDangNhap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadUser();
            setPosterAsync();
        }

        private void loadUser()
        {
            moKetNoi();
       
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.CommandText = "select * from SaveLogin";

            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                usernameTb.Text = reader.GetString(0);
            }

            reader.Close();

            sqlCon.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            moKetNoi();

            string username = usernameTb.Text.Trim();

            SqlCommand sqlCmd1 = new SqlCommand();
            sqlCmd1.CommandType = CommandType.Text;
            SqlCommand sqlCmd2 = new SqlCommand();
            sqlCmd2.CommandType = CommandType.Text;

            sqlCmd1.CommandText = "insert into SaveLogin(Username) values('" + username + "')";
            sqlCmd1.Connection = sqlCon;
            sqlCmd2.CommandText = "delete from SaveLogin";
            sqlCmd2.Connection = sqlCon;

            sqlCmd2.ExecuteNonQuery();

            sqlCmd1.ExecuteNonQuery();

            Message.Text = "Đã lưu tài khoản!";

            sqlCon.Close();
        }

        private void exitBtn_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn thoát!", "Xác nhận thoát!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void resetMKBtn_Click(object sender, EventArgs e)
        {
            ResetMK rsmk = new ResetMK();
            rsmk.ShowDialog();
        }
    }
}
