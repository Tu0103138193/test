using QuanLyBanMaytinh.Util;
using QuanLyBanMaytinh.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanMaytinh
{
   
    public partial class Khach_hang : Form
    {
        static string maKhachHang;
        static string tenKhachHang;
        static string diaChiKhachHang;
        static string dienThoaiKhachHang;
        static string maFind;
        static DataTable tblKhachHang = new DataTable();
        public Khach_hang()
        {
            InitializeComponent();
        }

        private void Khach_hang_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            maKhachHang = txtMaKH.Text;
            tenKhachHang = txtHoten.Text;
            dienThoaiKhachHang = txtDienthoai.Text;
            diaChiKhachHang = txtDiachi.Text;
            if (
               Validates.checkEmpty(maKhachHang) &&
               Validates.checkEmpty(tenKhachHang) &&
               Validates.checkEmpty(dienThoaiKhachHang) &&
               Validates.checkEmpty(diaChiKhachHang))
            {
                try
                {

                    using (SqlConnection cnn = new SqlConnection(Utils.strConnect))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = Utils.insertKhachHang;
                            cmd.Parameters.AddWithValue("@iMaKH", Convert.ToInt32(maKhachHang));
                            cmd.Parameters.AddWithValue("@sTenKH", tenKhachHang);
                            cmd.Parameters.AddWithValue("@sDiachi", diaChiKhachHang);
                            cmd.Parameters.AddWithValue("@sDienthoai", dienThoaiKhachHang);
                            cmd.ExecuteNonQuery();
                            btnLammoi_Click(sender, e);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Không để trống thông tin");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            maKhachHang = txtMaKH.Text;
            tenKhachHang = txtHoten.Text;
            dienThoaiKhachHang = txtDienthoai.Text;
            diaChiKhachHang = txtDiachi.Text;
            try
            {

                using (SqlConnection cnn = new SqlConnection(Utils.strConnect))
                {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = Utils.UpdateKhachHang;
                        cmd.Parameters.AddWithValue("@iMaKH", Convert.ToInt32(maKhachHang));
                        cmd.Parameters.AddWithValue("@sTenKH", tenKhachHang);
                        cmd.Parameters.AddWithValue("@sDiachi", diaChiKhachHang);
                        cmd.Parameters.AddWithValue("@sDienthoai", dienThoaiKhachHang);
                        cmd.ExecuteNonQuery();
                        btnLammoi_Click(sender, e);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(Utils.strConnect))
                {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = Utils.DeleteKhachHang;
                        cmd.Parameters.AddWithValue("@maKH", maFind);
                        cmd.ExecuteNonQuery();
                        btnLammoi_Click(sender, e);
                    }
                    gdvKhachhang.DataSource = tblKhachHang;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(Utils.strConnect))
                {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = Utils.getAllKhachHang;
                        tblKhachHang.Clear();
                        tblKhachHang.Load(cmd.ExecuteReader());
                    }
                    gdvKhachhang.DataSource = tblKhachHang;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void gdvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gdvKhachhang.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    maFind = gdvKhachhang.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtMaKH.Text = gdvKhachhang.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtHoten.Text = gdvKhachhang.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtDiachi.Text = gdvKhachhang.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtDienthoai.Text = gdvKhachhang.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có index");
            }
        }
    }
}
