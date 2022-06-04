using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLquancfk3.DTO
{
    public class NguyenLieuDTO
    {
        private string manl;
        private string mancc;
        private string tennl;
        private int soluong;
        private string donvi;
        private int gia;

        public string MaNL
        {
            get { return manl; }
            set { manl = value; }
        }
        public string MaNCC
        {
            get { return mancc; }
            set { mancc = value; }
        }
        public string TenNL
        {
            get { return tennl; }
            set { tennl = value; }
        }
        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public string DonVi
        {
            get { return donvi; }
            set { donvi = value; }
        }
        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }
    }
}
