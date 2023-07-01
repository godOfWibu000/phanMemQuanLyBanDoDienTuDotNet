using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btLon_qLyBanDoDienTu
{
    public partial class QLLuongNV : Form
    {
        public QLLuongNV()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn thoát!", "Xác nhận thoát!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            mainUI mainui = new mainUI();
            this.Close();
            this.Hide();
            mainui.ShowDialog();
        }
    }
}
