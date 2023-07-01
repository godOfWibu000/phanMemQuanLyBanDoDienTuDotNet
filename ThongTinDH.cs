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
    public partial class ThongTinDH : Form
    {
        private int soLuong = 0;
        private int tongTien = 0; 
        private string _maDH;
        private string _tenDH;
        private bool _kTraTK;
        public bool KTraTK
        {
            get { return _kTraTK; }
            set { _kTraTK = value; }
        }
        public ThongTinDH()
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

        public string TenDH
        {
            get { return _tenDH; }
            set { _tenDH = value; }
        }
        public string MaDH
        {
            get { return _maDH; }
            set { _maDH = value; }
        }

        //Cac nut bam thoat va quay lai
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quayLaiBtn_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn quay lại không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                capNhatDonHangPn.Visible = false;
                chucNangLuuDHPn.Visible = false;
                hienTTDH();
            }
        }

        private void collapseBtn_Click(object sender, EventArgs e)
        {

        }


        //Hien thong tin don hang
        private void hienTTDH()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from DonHang inner join SanPham on DonHang.MaSP=SanPham.MaSP inner join KhachHang on DonHang.MaKH=KhachHang.MaKH where MaDH='"+ _maDH +"'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if(reader.Read())
            {
                //Load thong tin don hang
                ttMaDHLb.Text = suaMaDHLb.Text = reader.GetInt32(0).ToString();
                
                //Lay thong tin san pham
                ttMaSPLb.Text = suaSPCb.Text = reader.GetInt32(1).ToString();//Lay ma san pham
                suaSPCb.Text = suaSPCb.Text + "-" + reader.GetString(9) + "-" + reader.GetInt32(10) + ".000 đ-" + reader.GetInt32(11);

                //Lay thong tin khach hang
                ttMaKHLb.Text = suaKHCb.Text = reader.GetInt32(3).ToString();
                suaKHCb.Text = suaKHCb.Text + "-" + reader.GetString(18) + "-" + reader.GetString(19);
                

                ttSLLb.Text = suaSLTb.Text = reader.GetInt32(4).ToString();
                ttTongTienLb.Text = reader.GetInt32(7).ToString() + ".000 đ";
                ttTenDHLb.Text = suaTenDHLb.Text = reader.GetString(9) + " (x" + ttSLLb.Text + ")";
                ttTGLb.Text = reader.GetDateTime(5).ToString("dd/MM/yyyy");
                string[] dt = ttTGLb.Text.Split('/');
                suaTGDtp.Value = new DateTime(int.Parse(dt[2]), int.Parse(dt[1]), int.Parse(dt[0]));
                string trangThai = reader.GetBoolean(6).ToString();
                if (trangThai == "True")
                    ttTrangThaiLb.Text = suaTrangThaiCb.Text = "Đã duyệt";
                else
                    ttTrangThaiLb.Text = suaTrangThaiCb.Text = "Chưa duyệt";

            }

            reader.Close();
        }

        private void hienDSSP()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from SanPham";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while(reader.Read())
            {
                string sanPham = reader.GetInt32(0) + "-" + reader.GetString(1) + "-" + reader.GetInt32(2) + ".000 đ-" + reader.GetInt32(3);
                suaSPCb.Items.Add(sanPham);
            }

            reader.Close();
        }

        private void hienDSKH()
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
                suaKHCb.Items.Add(khachHang);
            }

            reader.Close();
        }

        private void ThongTinDH_Load(object sender, EventArgs e)
        {
            hienTTDH();
            hienDSSP();
            hienDSKH();
            if (_kTraTK)
                capNhatDHBtn.Enabled = false;

            if (ttTrangThaiLb.Text == "Đã duyệt")
                capNhatDHBtn.Enabled = false;
        }

        
        //Cap nhat don hang
        private void layTTSP()
        {
            moKetNoi();

            string[] sp = suaSPCb.Text.Split('-');
            string maSP = sp[0];

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from SanPham where MaSP=" + maSP;
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while(reader.Read())
            {
                tongTien = reader.GetInt32(2);
                soLuong = reader.GetInt32(3);
            }

            reader.Close();
        }
        
        private void capNhatDH()
        {
            moKetNoi();

            int tt = 0;
            if (suaTrangThaiCb.Text == "Đã duyệt")
                tt = 1;
            else
                tt = 0;

            tongTien = tongTien * int.Parse(suaSLTb.Text);
            string[] sp = suaSPCb.Text.Split('-');
            string maSP = sp[0];
            string[] kh = suaKHCb.Text.Split('-');
            string maKH = kh[0];

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update DonHang set MaSP=" + maSP + ",MaKH=" + maKH + ",SoLuong=" + suaSLTb.Text + ",TongTien=" + tongTien + ",ThoiGian='" + suaTGDtp.Value.ToString("MM/dd/yyyy") + "',TrangThai=" + tt + " where MaDH=" + suaMaDHLb.Text;
            sqlCmd.Connection = sqlCon;
            int kq = sqlCmd.ExecuteNonQuery();
            if(kq>0)
            {
                if (suaTrangThaiCb.Text == "Đã duyệt")
                {
                    capNhatSLSP(int.Parse(suaSLTb.Text));
                }
                MessageBox.Show("Cập nhật dữ liệu thành công!");
                capNhatDonHangPn.Visible = false;
                chucNangLuuDHPn.Visible = false;
                hienTTDH();
            }
        }

        private void capNhatSLSP(int slBan)
        {
            moKetNoi();

            soLuong = soLuong - slBan;
            int tinhTrang = 1;
            if (soLuong == 0)
                tinhTrang = 0;

            string[] sp = suaSPCb.Text.Split('-');
            string maSP = sp[0];

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update SanPham set SoLuong = " + soLuong + ",TinhTrang=" + tinhTrang + " where MaSP=" + maSP;
            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
        }

        private void capNhatDHBtn_Click(object sender, EventArgs e)
        {
            capNhatDonHangPn.Visible = true;
            chucNangLuuDHPn.Visible = true;
        }

        private bool kTraSL()
        {
            for (int i = 0; i < suaSLTb.Text.Length; i++)
            {
                if (char.IsLetter(suaSLTb.Text[i]))
                {
                    return true;
                    break;
                }
            }
            return false;
        }


        //Luu lai
        private void luuDHBtn_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn lưu lại!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                if (kTraSL())
                    MessageBox.Show("Dữ liệu không hợp lệ, vui lòng nhập lại!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    layTTSP();
                    if (suaSLTb.Text == "")
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (soLuong == 0)
                        MessageBox.Show("Sản phẩm đã hết hàng, vui lòng chọn sản phẩm khác!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (int.Parse(suaSLTb.Text) > soLuong)
                        MessageBox.Show("Số lượng sản phẩm không đủ, vui lòng nhập lại!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        capNhatDH();
                }
            }
        }


        //Reset
        private void resetBtn_Click(object sender, EventArgs e)
        {
            hienTTDH();
        }
    }
}
