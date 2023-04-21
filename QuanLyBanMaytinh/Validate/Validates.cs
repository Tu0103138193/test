using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanMaytinh.Validate
{
    class Validates
    {
        public static bool checkEmpty(string strinfo)
        {
            if (strinfo.Trim().Equals(""))
                return false;

        return true;
        }
    }
}
