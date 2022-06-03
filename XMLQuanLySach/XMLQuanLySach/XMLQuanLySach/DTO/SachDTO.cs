using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLQuanLySach.DTO
{
    public class SachDTO
    {
        private string _MaSach;
        private string _TenSach;
        private int _SoLuong;
        private double _DongGia;

        public double DongGia
        {
            get { return _DongGia; }
            set { _DongGia = value; }
        }

        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        public string TenSach
        {
            get { return _TenSach; }
            set { _TenSach = value; }
        }

        public string MaSach
        {
            get { return _MaSach; }
            set { _MaSach = value; }
        }
    }
}
