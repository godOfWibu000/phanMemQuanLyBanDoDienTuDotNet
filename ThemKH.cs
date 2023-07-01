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
    public partial class ThemKH : Form
    {
        public ThemKH()
        {
            InitializeComponent();
        }

        //Ket noi db
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\btLon_qLyBanDoDienTu\QLBH.mdf;Integrated Security=True";
        SqlConnection sqlCon = null;
        private void moKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (themTenKHTb.Text != "" || themSDTTb.Text != "" || themDiaChiTb.Text != "")
            {
                DialogResult hoi = MessageBox.Show("Bạn chưa lưu khách hàng, bạn có muốn thoát không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hoi == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }

        private void xoaTatCaTTKHBtn_Click(object sender, EventArgs e)
        {
            themTenKHTb.Text = themSDTTb.Text = themDiaChiTb.Text = "";
        }

        private void themKH()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "insert into KhachHang(TenKH,SDT,DiaChi) values(N'" + themTenKHTb.Text + "','" + themSDTTb.Text + "',N'" + themDiaChiTb.Text + "')";
            sqlCmd.Connection = sqlCon;
            int kq = sqlCmd.ExecuteNonQuery();
            if(kq>0)
            {
                MessageBox.Show("Thêm dữ liệu thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                themTenKHTb.Text = themSDTTb.Text = themDiaChiTb.Text = "";
            }
        }

        private void luuKHBtn_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn lưu khách hàng?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(hoi == DialogResult.Yes)
            {
                if (themTenKHTb.Text == "" || themSDTTb.Text == "" || themDiaChiTb.Text == "")
                    MessageBox.Show("Vui lòng nhập đủ dữ liệu?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    themKH();
            }
        }
    }
}
