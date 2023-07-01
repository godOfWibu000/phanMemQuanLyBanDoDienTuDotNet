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
    public partial class ThemSP : Form
    {
        public ThemSP()
        {
            InitializeComponent();
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.FlatAppearance.BorderSize = 0;
            collapseBtn.FlatStyle = FlatStyle.Flat;
            collapseBtn.FlatAppearance.BorderSize = 0;
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


        //Thoat khoi form
        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (themTenSPTb.Text == "" && themGiaBanTb.Text == "" && themSLNhapTb.Text == "" && themGiaNhapTb.Text == "")
            {
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn chưa lưu sản phẩm, bạn có muốn thoát không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }


        //Them san pham
        private void themSP()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "insert into SanPham(TenSP,GiaBan,SLNhap,GiaNhap,SoLuong,TinhTrang) values('" + themTenSPTb.Text + "'," + themGiaBanTb.Text + "," + themSLNhapTb.Text + "," + themGiaNhapTb.Text + "," + themSLNhapTb.Text + ",1)";
            sqlCmd.Connection = sqlCon;
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Lưu sản phẩm thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                themTenSPTb.Text = themGiaBanTb.Text = themSLNhapTb.Text = themGiaNhapTb.Text = "";
            }
            else
                MessageBox.Show("Lưu sản phẩm không thành công!Vui lòng kiểm tra lại dữ liệu", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
        //Kiem tra du lieu
        //Kiem tra kieu du lieu
        private bool kTraGiaBan()
        {
            for (int i = 0; i < themGiaBanTb.Text.Length; i++)
            {
                if (char.IsLetter(themGiaBanTb.Text[i]))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        private bool kTraSL()
        {
            for (int i = 0; i < themSLNhapTb.Text.Length; i++)
            {
                if (char.IsLetter(themSLNhapTb.Text[i]))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        private bool kTraGiaNhap()
        {
            for (int i = 0; i < themGiaNhapTb.Text.Length; i++)
            {
                if (char.IsLetter(themGiaNhapTb.Text[i]))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        //Kiem gia trung lap du lieu
        private bool kTraSP()
        {
            moKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select count (*) from SanPham where TenSP='" + themTenSPTb.Text + "'";
            sqlCmd.Connection = sqlCon;
            int sl = (int)sqlCmd.ExecuteScalar();
        
            if (sl > 0)
                return true;
            else
                return false;
        }


        //Xoa tat ca
        private void xoaTatCaTTSPBtn_Click(object sender, EventArgs e)
        {
            themTenSPTb.Text = themGiaBanTb.Text = themSLNhapTb.Text = themGiaNhapTb.Text = "";
        }


        //Luu lai
        private void luuSPBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu sản phẩm?", "Save!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (themTenSPTb.Text == "" || themGiaBanTb.Text == "" || themSLNhapTb.Text == "" || themGiaNhapTb.Text == "")
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (kTraGiaBan() || kTraSL() || kTraGiaNhap())
                    MessageBox.Show("Dữ liệu  không hợp lệ, vui lòng nhập lại!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (kTraSP())
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        themTenSPTb.Text = "";
                    }
                    else
                        themSP();
                    
                }
            }
        }
    }
}
