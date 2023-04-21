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

        private void loadForm(Form objForm)
        {
            try
            {
                objForm.TopLevel = false;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                panelTrangTru.Controls.Add(objForm);
                panelTrangTru.Tag = objForm;
                objForm.BringToFront();
                objForm.Show();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
 
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

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nhan_vien nhan_Vien = new Nhan_vien();
            loadForm(nhan_Vien);
        }

   
        private void khachHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Khach_hang khach_Hang = new Khach_hang();
            loadForm(khach_Hang);
        }

        private void nhomHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhom_hang nhom_Hang = new Nhom_hang();
            loadForm(nhom_Hang);
        }

        private void nhaCungCâpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nha_Cung_cap nha_Cung_Cap = new Nha_Cung_cap();
            loadForm(nha_Cung_Cap);
        }
    }
}
