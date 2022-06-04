using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLquancfk3.DTO
{
    public class ThucUongDTO
    {
        private string matu;
        private string maloai;
        private string tentu;
        private int gia;
        private string donvitinh;

        public string MaTU
        {
            get { return matu; }
            set { matu = value; }
        }
        public string MaLoai
        {
            get { return maloai; }
            set { maloai = value; }
        }
        public string TenTU
        {
            get { return tentu; }
            set { tentu = value; }
        }
        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        public string DonViTinh
        {
            get { return donvitinh; }
            set { donvitinh = value; }
        }
    }
}
