using QuanLyBanMaytinh.Validate;
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
using QuanLyBanMaytinh.Util;

namespace QuanLyBanMaytinh
{
    public partial class Nhan_vien : Form
    {
        static string maNhanVien;
        static string tenNhanVien;
        static string diaChiNhanVien;
        static string dienThoaiNhanVien;
        static string ngaySinhNhanVien;
        static string ngayVaoLamNhanVien;
        static string strNam = "Nam";
        static string strNu = "Nữ";
        static string strMafind;
        static DataTable tblNhanVien = new DataTable();
        public Nhan_vien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            maNhanVien = txtMaNV.Text;
            tenNhanVien = txtHoten.Text;
            dienThoaiNhanVien = txtDienthoai.Text;
            diaChiNhanVien = txtDiachi.Text;
            ngaySinhNhanVien = txtNgaysinh.Text;
            ngayVaoLamNhanVien = txtNgayvaolam.Text;
            bool checkGioiTinh = true;
            if (
               Validates.checkEmpty(maNhanVien) &&
               Validates.checkEmpty(tenNhanVien) &&
               Validates.checkEmpty(dienThoaiNhanVien) &&
               Validates.checkEmpty(diaChiNhanVien) &&
               Validates.checkEmpty(ngaySinhNhanVien) &&
               Validates.checkEmpty(ngayVaoLamNhanVien))
            {
                try {

                    using (SqlConnection cnn = new SqlConnection(Utils.strConnect))
                    {
                        cnn.Open();
                        using(SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = Utils.insertNhanVien;
                            cmd.Parameters.AddWithValue("@iMaNV", Convert.ToInt16(maNhanVien));
                            cmd.Parameters.AddWithValue("@sTenNV", tenNhanVien);
                            if(rbtnNu.Checked)
                                cmd.Parameters.AddWithValue("@sGioitinh", strNu);
                            else
                                cmd.Parameters.AddWithValue("@sGioitinh", strNam);
                            cmd.Parameters.AddWithValue("@sDiachi", diaChiNhanVien);
                            cmd.Parameters.AddWithValue("@sDienthoai", dienThoaiNhanVien);
                            cmd.Parameters.AddWithValue("@dNgaysinh", Convert.ToDateTime(ngaySinhNhanVien));
                            cmd.Parameters.AddWithValue("@dNgayvaolam", Convert.ToDateTime(ngayVaoLamNhanVien));
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
                        cmd.CommandText = Utils.getAllNhanVien;
                        tblNhanVien.Clear();
                        tblNhanVien.Load(cmd.ExecuteReader());
                    }
                    gdvNhanvien.DataSource = tblNhanVien;
                }
            }
            catch(Exception ex)
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
                        cmd.CommandText = Utils.DeleteNhanVien;
                        cmd.Parameters.AddWithValue("@maNV" , strMafind);
                        cmd.ExecuteNonQuery();
                        btnLammoi_Click(sender, e);
                    }
                    gdvNhanvien.DataSource = tblNhanVien;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gdvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gdvNhanvien.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    strMafind = gdvNhanvien.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtMaNV.Text = gdvNhanvien.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtHoten.Text = gdvNhanvien.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtDiachi.Text = gdvNhanvien.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtDienthoai.Text = gdvNhanvien.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    txtNgaysinh.Text = gdvNhanvien.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    txtNgayvaolam.Text = gdvNhanvien.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    if (gdvNhanvien.Rows[e.RowIndex].Cells[6].FormattedValue.ToString().Equals(strNam))
                    {
                        rbtnNam.Checked = true;
                    }
                    else
                    {
                        rbtnNu.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có index");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            maNhanVien = txtMaNV.Text;
            tenNhanVien = txtHoten.Text;
            dienThoaiNhanVien = txtDienthoai.Text;
            diaChiNhanVien = txtDiachi.Text;
            ngaySinhNhanVien = txtNgaysinh.Text;
            ngayVaoLamNhanVien = txtNgayvaolam.Text;

            try
            {
                using (SqlConnection cnn = new SqlConnection(Utils.strConnect))
                {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = Utils.UpdateNhanVien;
                        cmd.Parameters.AddWithValue("@iMaNV", Convert.ToInt16(maNhanVien));
                        cmd.Parameters.AddWithValue("@sTenNV", tenNhanVien);
                        if (rbtnNu.Checked)
                            cmd.Parameters.AddWithValue("@sGioitinh", strNu);
                        else
                            cmd.Parameters.AddWithValue("@sGioitinh", strNam);
                        cmd.Parameters.AddWithValue("@sDiachi", diaChiNhanVien);
                        cmd.Parameters.AddWithValue("@sDienthoai", dienThoaiNhanVien);
                        cmd.Parameters.AddWithValue("@dNgaysinh", Convert.ToDateTime(ngaySinhNhanVien));
                        cmd.Parameters.AddWithValue("@dNgayvaolam", Convert.ToDateTime(ngayVaoLamNhanVien));
                        cmd.ExecuteNonQuery();
                        btnLammoi_Click(sender, e);
                    }
                   /* gdvNhanvien.DataSource = tblNhanVien;*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
