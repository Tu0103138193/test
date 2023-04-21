using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanMaytinh
{
    public partial class Trang_chu : Form
    {
        public Trang_chu()
        {
            InitializeComponent();
        }

        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Hang_hoa hang = new Hang_hoa();
            hang.MdiParent = this;
            hang.Show();  
            
        }

        private void hoaĐơnBanHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HoaDonBanHang hoaDonBan = new HoaDonBanHang();
            hoaDonBan.MdiParent = this;
            hoaDonBan.Show();
        }

        private void hoaĐơnNhâpHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonNhapHang hoaDonNhap = new HoaDonNhapHang();
            hoaDonNhap.MdiParent = this;
            hoaDonNhap.Show();
        }
    }
}
