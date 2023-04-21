using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanMaytinh.Util
{
    class Utils
    {
        /*Ten proc */
        //Nhân viên
        public static string insertNhanVien = "InsertNhanVien";
        public static string UpdateNhanVien = "UpdateNhanVien";
        public static string DeleteNhanVien = "DeleteNhanVien";
        public static string EditNhanVien = "EditNhanVien";
        public static string ReportNhanVien = "ReportNhanVien";
        public static string SearchNhanVien = "SearchNhanVien";
        public static string getAllNhanVien = "getAllNhanVien";

        //Khach hang
        public static string insertKhachHang = "insertKhachHang";
        public static string UpdateKhachHang = "UpdateKhachHang";
        public static string DeleteKhachHang = "DeleteKhachHang";
        public static string EditKhachHang = "EditKhachHang";
        public static string ReporKhachHang = "ReporKhachHang";
        public static string SearchKhachHang = "SearchKhachHang";
        public static string getAllKhachHang = "getAllKhachHang";

        //Nhóm hàng
        public static string insertNhomHang = "insertNhomHang";
        public static string UpdateNhomHang = "UpdateNhomHang";
        public static string DeleteNhomHang = "DeleteNhomHang";
        public static string EditNhomHang = "EditNhomHang";
        public static string ReportNhomHang = "ReportNhomHang";
        public static string SearchNhomHang = "SearchNhomHang";
        public static string getAlNhomHang = "getAlNhomHang";
        //Nhà cung cấp
        public static string insertNhaCC = "insertNhaCC";
        public static string UpdateNhaCC = "UpdateNhaCC";
        public static string DeleteNhaCC = "DeleteNhaCC";
        public static string EditNhaCC = "EditNhaCC";
        public static string ReportNhaCC = "ReportNhaCC";
        public static string SearchNhaCC = "SearchNhaCC";
        public static string getAllNhaCC = "getAllNhaCC";

        /*Path connect data base*/
        public static string strConnect = "Data Source=.;Initial Catalog=dbQuanLyBanHang_TBMayTinh;Integrated Security=True";
    }
}
