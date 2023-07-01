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
    public partial class ThongTinSP : Form
    {
        private string _maSP;
        private int _maNV;
        private string tenSP;
        public ThongTinSP()
        {
            InitializeComponent();
        }

        public string MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void collapseBtn_Click(object sender, EventArgs e)
        {

        }

        //Hien thi tt sp
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\btLon_qLyBanDoDienTu\QLBH.mdf;Integrated Security=True";
        SqlConnection sqlCon = null;

        private void moKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        private void hienThiTT()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from SanPham where MaSP='" + _maSP + "'";
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                ttMaSPLb.Text = suaMaSPLb.Text = reader.GetInt32(0).ToString();
                ttTenSPLb.Text = tenSP = suaTenSPTb.Text = reader.GetString(1);
                ttGiaBanLb.Text = suaGiaBanTb.Text = reader.GetInt32(2).ToString();
                ttGiaBanLb.Text = ttGiaBanLb.Text + ".000 đ";
                ttSoLuongLb.Text = reader.GetInt32(3).ToString();
                ttSLNhapLb.Text = suaSLNhapTb.Text = reader.GetInt32(5).ToString();
                ttGiaNhapLb.Text = suaGiaNhapTb.Text = reader.GetInt32(7).ToString();
                ttGiaNhapLb.Text = ttGiaNhapLb.Text + ".000 đ";
            }

            reader.Close();
        }

        private void ThongTinSP_Load(object sender, EventArgs e)
        {
            if (_maNV == 0)
                suaTTSPBtn.Enabled = true;
            hienThiTT();
        }


        //Kiem tra du lieu
        private bool kTraGiaBan()
        {
            for (int i = 0; i < suaGiaBanTb.Text.Length; i++)
            {
                if (char.IsLetter(suaGiaBanTb.Text[i]))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        private bool kTraSL()
        {
            for (int i = 0; i < suaSLNhapTb.Text.Length; i++)
            {
                if (char.IsLetter(suaSLNhapTb.Text[i]))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        private bool kTraGiaNhap()
        {
            for (int i = 0; i < suaGiaNhapTb.Text.Length; i++)
            {
                if (char.IsLetter(suaGiaNhapTb.Text[i]))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        private bool kTraSP()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select count (*) from SanPham where TenSP='" + suaTenSPTb.Text + "'";
            sqlCmd.Connection = sqlCon;
            int sl = (int)sqlCmd.ExecuteScalar();

            if (sl > 0)
                return true;
            else
                return false;
        }


        //Cap nhat san pham
        private void capNhatSP()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update SanPham set TenSP='" + suaTenSPTb.Text +
                "',GiaBan=" + suaGiaBanTb.Text + ",SLNhap=" + suaSLNhapTb.Text +
                ",GiaNhap=" + suaGiaNhapTb.Text + " where MaSP=" + suaMaSPLb.Text + "";
            sqlCmd.Connection = sqlCon;
            int kq = sqlCmd.ExecuteNonQuery();
            if(kq>0)
            {
                MessageBox.Show("Cập nhật thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                capNhatSPPn.Visible = false;
                suaTTSPBtn.Enabled = true;
                chucNangSuaSPPn.Visible = true;
                chucNangLuuSPPn.Visible = false;
                hienThiTT();
            }
        }


        //Luu, quay lai
        private void capNhatSPBtn_Click(object sender, EventArgs e)
        {
            capNhatSPPn.Visible = true;
            suaTTSPBtn.Enabled = false;
            chucNangSuaSPPn.Visible = false;
            chucNangLuuSPPn.Visible = true;
        }

        private void quayLaiBtn_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn quay lại!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(hoi == DialogResult.Yes)
            {
                capNhatSPPn.Visible = false;
                suaTTSPBtn.Enabled = true;
                chucNangSuaSPPn.Visible = true;
                chucNangLuuSPPn.Visible = false;

                hienThiTT();
            }
        }

        private void luuDHBtn_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn lưu lại?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                if (suaTenSPTb.Text == "" || suaGiaBanTb.Text == "" || suaGiaNhapTb.Text == "" || suaSLNhapTb.Text == "")
                    MessageBox.Show("Vui lòng nhập đủ dữ liệu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if(kTraGiaBan() || kTraGiaNhap() || kTraSL())
                    MessageBox.Show("Dữ liệu không hợp lệ, vui lòng nhập lại!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if(tenSP == suaTenSPTb.Text || kTraSP() == false)
                        capNhatSP();
                    else
                        MessageBox.Show("Sản phẩm đã tồn tại, vui lòng nhập lại!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }      
            }
        }


        //Reset form
        private void resetBtn_Click(object sender, EventArgs e)
        {
            hienThiTT();
        }
    }
}
