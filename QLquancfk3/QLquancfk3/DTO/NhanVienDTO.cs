using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLquancfk3.DTO
{
    class NhanVienDTO
    {
        private string manv;
        private string macv;
        private string tennv;
        private string ngaysinh;
        private string gioitinh;
        private string ngayvao;
        private string diachi;
        private int sdt;

        public string MaNV
        {
            get { return manv; }
            set { manv = value;}
        }
        public string MaCV
        {
            get { return macv; }
            set { macv = value; }
        }
        public string TenNV
        {
            get { return tennv; }
            set { tennv = value; }
        }
        public string NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        public string GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        public string NgayVao
        {
            get { return ngayvao; }
            set { ngayvao = value; }
        }
        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public int SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
    }
}
