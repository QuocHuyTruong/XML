using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLquancfk3.DTO
{
    public class ChucVuDTO
    {
        private string macv;
        private string tencv;
        private int soluong;

        public string MaCV
        {
            get { return macv; }
            set { macv = value; }
        }
        public string TenCV
        {
            get { return tencv; }
            set { tencv = value; }
        }
        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }

    }
}
