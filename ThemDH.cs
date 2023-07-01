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
    public partial class ThemDH : Form
    {
        private int slSP;

        public ThemDH()
        {
            InitializeComponent();
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.FlatAppearance.BorderSize = 0;
            collapseBtn.FlatStyle = FlatStyle.Flat;
            collapseBtn.FlatAppearance.BorderSize = 0;
        }

        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\btLon_qLyBanDoDienTu\QLBH.mdf;Integrated Security=True";
        SqlConnection sqlCon = null;

        private int _maNV;
        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        private void moKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        //Danh sach san pham
        private void hienThiDSSP()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from SanPham";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string sanPham = reader.GetInt32(0) + "-" +
                    reader.GetString(1) + "-" + reader.GetInt32(2) + ".000 đ-" + reader.GetInt32(3);
                sanPhamCb.Items.Add(sanPham);
            }

            reader.Close();
        }

        //Danh sach khach hang
        private void hienThiDSKH()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from KhachHang";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string khachHang = reader.GetInt32(0) + "-" + reader.GetString(1) + "-" + reader.GetString(2);
                khachHangCb.Items.Add(khachHang);
            }

            reader.Close();
        }

        private void ThemDH_Load(object sender, EventArgs e)
        {
            hienThiDSSP();
            hienThiDSKH();
            themMaNVTb.Text = _maNV.ToString();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (themSLTb.Text == "" && sanPhamCb.Text == "Chọn sản phẩm" && khachHangCb.Text == "Chọn khách hàng")
                this.Close();
            else
            {
                DialogResult result = MessageBox.Show("Bạn chưa lưu đơn hàng, bạn có muốn thoát không?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        //Them don hang vao csdl
        private void themDH()
        {
            moKetNoi();

            string[] SP = sanPhamCb.Text.Split('-');
            string maSP = SP[0];
            string maNV = themMaNVTb.Text;
            string[] KH = khachHangCb.Text.Split('-');
            string maKH = KH[0];
            string soLuong = themSLTb.Text;
            string thoiGian = DateTime.Now.ToString("MM/dd/yyyy");
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "insert into DonHang(MaSP,MaNV,MaKH,SoLuong,ThoiGian,TrangThai) values(" + maSP + "," + maNV + "," + maKH + "," + soLuong + ",'" + thoiGian + "',0)";
            sqlCmd.Connection = sqlCon;
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Lưu đơn hàng thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool kTraSL()
        {
            for (int i = 0; i < themSLTb.Text.Length; i++)
            {
                if (char.IsLetter(themSLTb.Text[i]))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        //Luu don hang
        private void luuDHBtn_Click(object sender, EventArgs e)
        {
            if (themSLTb.Text == "" || sanPhamCb.Text == "Chọn sản phẩm" || khachHangCb.Text == "Chọn khách hàng")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(kTraSL())
                MessageBox.Show("Dữ liệu không hợp lệ, vui lòng nhập đầy đủ thông tin!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string[] sp = sanPhamCb.Text.Split('-');
                int sl = int.Parse(sp[3]);
                if (sl == 0)
                    MessageBox.Show("Sản phẩm đã hết hàng, vui lòng chọn sản phẩm khác!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (int.Parse(themSLTb.Text) > sl)
                    MessageBox.Show("Không đủ số lượng để đặt hàng!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    themDH();
                    themSLTb.Text = "";
                    sanPhamCb.Text = "Chọn sản phẩm";
                    khachHangCb.Text = "Chọn khách hàng";
                }
            }
        }
        
        //Reset form
        private void xoaTatCaTTDHBtn_Click(object sender, EventArgs e)
        {
            themSLTb.Text = "";
            sanPhamCb.Text = "Chọn sản phẩm";
            khachHangCb.Text = "Chọn khách hàng";
        }
    }
}
