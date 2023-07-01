using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace btLon_qLyBanDoDienTu
{
    public partial class mainUI : Form
    {
        private string _message;
        private int _maNV = 0;
        //Trang chu, cac nut bam chinh
        public mainUI()
        {
            InitializeComponent();
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.FlatAppearance.BorderSize = 0;
            returnBtn.FlatStyle = FlatStyle.Flat;
            returnBtn.FlatAppearance.BorderSize = 0;
            collapseBtn.FlatStyle = FlatStyle.Flat;
            collapseBtn.FlatAppearance.BorderSize = 0;
            qLySPFrame.BackColor = Color.FromArgb(125, Color.White);
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }


        //Nut thoat va quay lai
        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn thoát!", "Xác nhận thoát!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form1 = new Login();
            form1.ShowDialog();
            this.Close();
        }

        private void collapseBtn_Click(object sender, EventArgs e)
        {
            
        }


        //Menu
        private void menuBtn_Click(object sender, EventArgs e)
        {
            if (tabBar.Location == new Point(0, 0))
            {
                tabBar.Location = new Point(-300, 0);
            }
            else
                tabBar.Location = new Point(0, 0);
        }


        //Nut bam chuc nang
        //Click
        private void trangChuBtn_Click(object sender, EventArgs e)
        {
            titleMainUILb.Text = "GearVNUA-Trang chủ";
            tabBar.Location = new Point(-300, 0);
            mainFrame.Visible = true;
            qLySPFrame.Visible = false;
            qLyDHFrame.Visible = false;
        }

        private void qlLuongBtn_Click(object sender, EventArgs e)
        {
            QLLuongNV qlluong = new QLLuongNV();
            this.Close();
            this.Hide();
            qlluong.ShowDialog();
        }


        //Hover
        private void trangChuBtn_MouseHover(object sender, EventArgs e)
        {
            trangChuBtn.BackColor = Color.DodgerBlue;
        }

        private void trangChuBtn_MouseLeave(object sender, EventArgs e)
        {
            trangChuBtn.BackColor = Color.MidnightBlue;
        }

        private void qlSPBtn_MouseHover(object sender, EventArgs e)
        {
            qlSPBtn.BackColor = Color.DodgerBlue;
        }

        private void qlSPBtn_MouseLeave(object sender, EventArgs e)
        {
            qlSPBtn.BackColor = Color.MidnightBlue;
        }

        private void qlDHBtn_MouseHover(object sender, EventArgs e)
        {
            qlDHBtn.BackColor = Color.DodgerBlue;
        }

        private void qlDHBtn_MouseLeave(object sender, EventArgs e)
        {
            qlDHBtn.BackColor = Color.MidnightBlue;
        }

        private void qlKHBtn_MouseHover(object sender, EventArgs e)
        {
            qlKHBtn.BackColor = Color.DodgerBlue;
        }

        private void qlKHBtn_MouseLeave(object sender, EventArgs e)
        {
            qlKHBtn.BackColor = Color.MidnightBlue;
        }


        //Ket noi db
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\btLon_qLyBanDoDienTu\QuanLyBanHang.mdf;Integrated Security=True";
        SqlConnection sqlCon = null;

        private void moKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }


        //Hien thi danh sach
        public void hienThiDSSP(string query)
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.Connection = sqlCon;
            dsSPLv.Items.Clear();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while(reader.Read())
            {
                string maSP = reader.GetInt32(0).ToString();
                string tenSP = reader.GetString(1);
                string giaBan = reader.GetInt32(2).ToString() + ".000 đ";
                string soLuong = reader.GetInt32(3).ToString();
                string sLNhap = reader.GetInt32(5).ToString();
                string tinhTrang = reader.GetBoolean(6).ToString();
                string giaNhap = reader.GetInt32(7).ToString() + ".000 đ";
                string tinhTrangStr = "";
                if (tinhTrang == "True")
                    tinhTrangStr = "Còn hàng";
                else
                    tinhTrangStr = "Hết hàng";


                ListViewItem ds = new ListViewItem(maSP);
                ds.SubItems.Add(tenSP);
                ds.SubItems.Add(giaBan);
                ds.SubItems.Add(soLuong);
                ds.SubItems.Add(giaNhap);
                ds.SubItems.Add(sLNhap);
                ds.SubItems.Add(tinhTrangStr);

                dsSPLv.Items.Add(ds);
            }
            reader.Close();
        }

        private void hienThiDSDH(string query)
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.Connection = sqlCon;
            dsDHLv.Items.Clear();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                string maDH = reader.GetInt32(0).ToString();
                string maSP = reader.GetInt32(1).ToString();
                string maNV = reader.GetInt32(2).ToString();
                string maKH = reader.GetInt32(3).ToString();
                string soLuong = reader.GetInt32(4).ToString();
                string thoiGian = reader.GetDateTime(5).ToString();
                string trangThaiStr = reader.GetBoolean(6).ToString();
                string trangThai;
                if (trangThaiStr == "True")
                    trangThai = "Đã duyệt";
                else
                    trangThai = "Chưa duyệt";

                ListViewItem ds = new ListViewItem(maDH);
                ds.SubItems.Add(maSP);
                ds.SubItems.Add(maNV);
                ds.SubItems.Add(maKH);
                ds.SubItems.Add(soLuong);
                ds.SubItems.Add(thoiGian);
                ds.SubItems.Add(trangThai);

                dsDHLv.Items.Add(ds);
            }
            reader.Close();
        }

        private void hienThiDSKH(string query)
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.Connection = sqlCon;
            dsKHLv.Items.Clear();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while(reader.Read())
            {
                string maKH = reader.GetInt32(0).ToString();
                string tenKH = reader.GetString(1);
                string SDT = reader.GetString(2);
                string diaChi = reader.GetString(3);

                ListViewItem lvi = new ListViewItem(maKH);
                lvi.SubItems.Add(tenKH);
                lvi.SubItems.Add(SDT);
                lvi.SubItems.Add(diaChi);

                dsKHLv.Items.Add(lvi);
            }

            reader.Close();
        }

        //Form
        private void mainUI_Load(object sender, EventArgs e)
        {
            LoaiTKTb.Text = _message;
            if (_message != "Quản trị viên")
            {
                LoaiTKTb.Text = LoaiTKTb.Text + "-Mã: " + _maNV;
                themSPBtn.Enabled = false;
            }
            else
                themDHBtn.Enabled = false;
        }


        //Lua chon chuc nang quan ly
        private void qlSPBtn_Click(object sender, EventArgs e)
        {
            titleMainUILb.Text = "GearVNUA-Quản lý sản phẩm";
            tabBar.Location = new Point(-300, 0);
            mainFrame.Visible = false;
            qLyDHFrame.Visible = false;
            qLyKHFrame.Visible = false;
            qLySPFrame.Visible = true;

            hienThiDSSP("select * from SanPham order by TenSP");
        }

        private void qlDHBtn_Click(object sender, EventArgs e)
        {
            titleMainUILb.Text = "GearVNUA-Quản lý đơn hàng";
            tabBar.Location = new Point(-300, 0);
            mainFrame.Visible = false;
            qLySPFrame.Visible = false;
            qLyKHFrame.Visible = false;
            qLyDHFrame.Visible = true;
            if (_message == "Quản trị viên")
                hienThiDSDH("select * from DonHang order by ThoiGian desc");
            else
                hienThiDSDH("select * from DonHang order by ThoiGian desc");
        }

        private void qlKHBtn_Click(object sender, EventArgs e)
        {
            titleMainUILb.Text = "GearVNUA-Quản lý khách hàng";
            tabBar.Location = new Point(-300, 0);
            mainFrame.Visible = false;
            qLySPFrame.Visible = false;
            qLyDHFrame.Visible = false;
            qLyKHFrame.Visible = true;

            hienThiDSKH("select * from KhachHang");
        }


        //Them don hang, san pham
        private void themDHBtn_Click(object sender, EventArgs e)
        {
            ThemDH add = new ThemDH();
            add.MaNV = _maNV;
            add.ShowDialog();
        }

        private void themSPBtn_Click(object sender, EventArgs e)
        {
            ThemSP add = new ThemSP();
            add.ShowDialog();
        }

        private void themKHBtn_Click(object sender, EventArgs e)
        {
            ThemKH themKH = new ThemKH();
            themKH.ShowDialog();
        }

        //Chon san pham, don hang
        private void dsDHLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dsDHLv.SelectedItems.Count == 0) return;

            if (LoaiTKTb.Text == "Quản trị viên")
                xoaDHBtn.Enabled = false;
            else
                xoaDHBtn.Enabled = true;

            ttChiTietDHBtn.Enabled = true;
            ListViewItem item = dsDHLv.SelectedItems[0];

            maDHTb.Text = item.SubItems[0].Text;
        }

        private void dsSPLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dsSPLv.SelectedItems.Count == 0) return;

            ttChiTietSPBtn.Enabled = true;
            if(_message == "Quản trị viên")
                xoaSPBtn.Enabled = true;

            ListViewItem item = dsSPLv.SelectedItems[0];
            maSPTb.Text = item.SubItems[0].Text;
        }

        private string tenKH;
        private string sdt;
        private string diaChi;
        private void dsKHLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dsKHLv.SelectedItems.Count == 0) return;

            if (_message == "Quản trị viên")
            {
                capNhatKHBtn.Enabled = true;
                xoaKHBtn.Enabled = true;
            }

            ListViewItem lvi = dsKHLv.SelectedItems[0];
            maKHTb.Text = lvi.SubItems[0].Text;
            tenKHTb.Text = tenKH = lvi.SubItems[1].Text;
            sdtTb.Text = sdt = lvi.SubItems[2].Text;
            diaChiTb.Text = diaChi = lvi.SubItems[3].Text;
        }
        private void resetKHBtn_Click(object sender, EventArgs e)
        {
            tenKHTb.Text = tenKH;
            sdtTb.Text = sdt;
            diaChiTb.Text = diaChi;
        }
        private void capNhatKHBtn_Click(object sender, EventArgs e)
        {
            luuKHBtn.Enabled = true;
            resetKHBtn.Enabled = true;
            tenKHTb.ReadOnly = false;
            sdtTb.ReadOnly = false;
            diaChiTb.ReadOnly = false;
        }


        //Xoa san pham, don hang, khach hang
        private void xoaSP()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from SanPham where MaSP=" + maSPTb.Text;

            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Xóa dữ liệu thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void xoaDH()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from DonHang where MaDH=" + maDHTb.Text;

            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Xóa dữ liệu thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void xoaSPBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa sản phẩm này!", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                xoaSP();
                reloadQLSP();
            }
        }

        private void xoaDHBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa đơn hàng này!", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                xoaDH();
                reloadQLDH();
            }
        }

        private void xoaKH()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from KhachHang where MaKH=" + maKHTb.Text;

            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
            if(kq>0)
            {
                MessageBox.Show("Xóa dữ liệu thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiDSKH("select * from KhachHang");
            }
        }

        private void xoaKHBtn_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn xóa khách hàng này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                xoaKH();
                reloadQLKH();
            }
        }

        private void capNhatKH()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update KhachHang set TenKH=N'" + tenKHTb.Text + "', SDT='" + sdtTb.Text + "', DiaChi=N'" + diaChiTb.Text + "' where MaKH=" + maKHTb.Text;

            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiDSKH("select * from KhachHang");
            }
        }

        private void luuKHBtn_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn cập nhật thông tin khách hàng này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                capNhatKH();
                reloadQLKH();
            }
        }

        //Thong tin chi tiet
        private void ttChiTietDHBtn_Click(object sender, EventArgs e)
        {
            ThongTinDH ttdh = new ThongTinDH();
            if (LoaiTKTb.Text == "Quản trị viên")
                ttdh.KTraTK = true;
            else
                ttdh.KTraTK = false;
            ttdh.MaDH = maDHTb.Text;
            ttdh.ShowDialog();
        }

        private void ttChiTietSPBtn_Click(object sender, EventArgs e)
        {
            ThongTinSP tt = new ThongTinSP();
            tt.MaSP = maSPTb.Text;
            tt.MaNV = _maNV;
            tt.ShowDialog();
        }


        //Load lai form
        
        private void reloadQLSP()
        {
            ttChiTietSPBtn.Enabled = false;
            xoaSPBtn.Enabled = false;
            maSPTb.Text = "";
            timTenSPTb.Text = "";
            hienThiDSSP("select * from SanPham order by TenSP");
        }

        private void reloadQLSPBtn_Click(object sender, EventArgs e)
        {
            reloadQLSP();
        }

        private void reloadQLDH()
        {
            ttChiTietDHBtn.Enabled = false;
            xoaDHBtn.Enabled = false;
            maDHTb.Text = "";
            timTenDHTb.Text = "";
            sapXepDHTheoTGMoiRb.Checked = true;
            hienThiDSDH("select * from DonHang order by ThoiGian desc");
        }

        private void reloadQLDHBtn_Click(object sender, EventArgs e)
        {
            reloadQLDH();
        }

        private void reloadQLKH()
        {
            timMaKHTb.Text = timTenKHTb.Text = maKHTb.Text = tenKHTb.Text = sdtTb.Text = diaChiTb.Text = "";
            luuKHBtn.Enabled = false;
            resetKHBtn.Enabled = false;
            capNhatKHBtn.Enabled = false;
            xoaKHBtn.Enabled = false;
            maKHTb.ReadOnly = true;
            tenKHTb.ReadOnly = true;
            sdtTb.ReadOnly = true;
            diaChiTb.ReadOnly = true;

            hienThiDSKH("select * from KhachHang");
        }

        private void reloadQLKHBtn_Click(object sender, EventArgs e)
        {
            reloadQLKH();
        }


        //Tim kiem san pham
        private void timMaSPBtn_Click(object sender, EventArgs e)
        {
            if (timMaSPTb.Text == "")
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                hienThiDSSP("select * from SanPham where MaSP LIKE '%" + timMaSPTb.Text + "%'");
        }

        private void timTenSPBtn_Click(object sender, EventArgs e)
        {
            if (timTenSPTb.Text == "")
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                hienThiDSSP("select * from SanPham where TenSP LIKE '%" + timTenSPTb.Text + "%'");
        }

        //Loc san pham
        private void locSPTheoTTConHangRb_CheckedChanged(object sender, EventArgs e)
        {
            hienThiDSSP("select * from SanPham where TinhTrang=1");
        }

        private void locSPTheoTTHetHangRb_CheckedChanged(object sender, EventArgs e)
        {
            hienThiDSSP("select * from SanPham where TinhTrang=0");
        }

        private void locSPAllRb_CheckedChanged(object sender, EventArgs e)
        {
            hienThiDSSP("select * from SanPham");
        }


        //Tim kiem don hang
        private void timMaDHBtn_Click(object sender, EventArgs e)
        {
            if (timMaDHTb.Text == "")
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                hienThiDSDH("select * from DonHang where MaDH like '%" + timMaDHTb.Text + "%'");
        }

        private void timTenDHBtn_Click(object sender, EventArgs e)
        {
            if (timTenDHTb.Text == "")
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                hienThiDSDH("select * from DonHang inner join SanPham on DonHang.MaSP = SanPham.MaSP where TenSP like '%" + timTenDHTb.Text + "%'");
        }


        //Sap xep don hang
        private void sapXepDHTheoTGMoiRb_CheckedChanged(object sender, EventArgs e)
        {
            hienThiDSDH("select * from DonHang order by ThoiGian desc");
        }

        private void sapXepDHTheoTGCuRb_CheckedChanged(object sender, EventArgs e)
        {
            hienThiDSDH("select * from DonHang order by ThoiGian asc");
        }

        private void sapXepDHTheoMaSPRb_CheckedChanged(object sender, EventArgs e)
        {
            hienThiDSDH("select * from DonHang order by MaSP");
        }

        private void sapXepDHTheoSLRb_CheckedChanged(object sender, EventArgs e)
        {
            hienThiDSDH("select * from DonHang order by SoLuong");
        }


        //Loc don hang
        private void locDHDaDuyetRb_CheckedChanged(object sender, EventArgs e)
        {
            if(_message == "Quản trị viên")
                hienThiDSDH("select * from DonHang where TrangThai=1");
            else
                hienThiDSDH("select * from DonHang where TrangThai=1 and MaNV=" + _maNV);
        }

        private void locDHChuaDuyetRb_CheckedChanged(object sender, EventArgs e)
        {
            if (_message == "Quản trị viên")
                hienThiDSDH("select * from DonHang where TrangThai=0");
            else
                hienThiDSDH("select * from DonHang where TrangThai=0 and MaNV=" + _maNV);
        }

        private void locDHAllRb_CheckedChanged(object sender, EventArgs e)
        {
            hienThiDSDH("select * from DonHang order by ThoiGian desc");
        }


        //Tim khach hang
        private void timMaKHBtn_Click(object sender, EventArgs e)
        {
            if (timMaKHTb.Text == "")
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                hienThiDSKH("select * from KhachHang where MaKH like '%" + timMaKHTb.Text + "%'");
        }

        private void timTenKHBtn_Click(object sender, EventArgs e)
        {
            if (timTenKHTb.Text == "")
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                hienThiDSKH("select * from KhachHang where TenKH like '%" + timTenKHTb.Text + "%'");
        }
    }
}
