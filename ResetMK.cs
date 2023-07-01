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
    public partial class ResetMK : Form
    {
        private string tenTK;
        public ResetMK()
        {
            InitializeComponent();
        }

        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\btLon_qLyBanDoDienTu\QLBH.mdf;Integrated Security=True";
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

        private void kTraMail()
        {
            moKetNoi();

            string mail = emailTb.Text;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.CommandText = "select * from Login where Email='" + mail + "'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                tenTK = reader.GetString(0);
                xacNhanOtpPn.Visible = true;
            }
            else
            {
                messageTb.Text = "Không thể tìm thấy tài khoản liên kết với email này!";
            }

            reader.Close();
        }

        private void sendMailBtn_Click(object sender, EventArgs e)
        {
            if (emailTb.Text == "")
                messageTb.Text = "Vui lòng nhập email!";
            else
                kTraMail();
        }

        private void guiOTPXacNhanBtn_Click(object sender, EventArgs e)
        {
            xacNhanOtpPn.Visible = false;
            nhapMKMoiPn.Visible = true;
            datLaiMKChoTKLb.Text = datLaiMKChoTKLb.Text + tenTK + ")";
        }

        private void ResetMK_Load(object sender, EventArgs e)
        {
            Random otp = new Random();
            otpTb.Text = otp.Next(1000, 9999).ToString();
        }

        private void doiMK()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update Login set Password='" + mkMoiTb.Text + "' where Username='" + tenTK + "'";
            sqlCmd.Connection = sqlCon;
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }

        }

        private void xacNhanDoiMKBtn_Click(object sender, EventArgs e)
        {
            if (mkMoiTb.Text == "" || nhapLaiMKMoiTb.Text == "")
                message3Lb.Text = "Vui lòng nhập đầy đủ thông tin!";
            else if (mkMoiTb.Text != nhapLaiMKMoiTb.Text)
                message3Lb.Text = "Vui lòng nhập chính xác!";
            else
                doiMK();
        }
    }
}
