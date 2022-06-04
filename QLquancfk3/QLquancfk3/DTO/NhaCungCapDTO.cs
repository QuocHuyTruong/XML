using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLquancfk3.DTO
{
    public class NhaCungCapDTO
    {
        private string mancc;
        private string tenncc;
        private string diachi;
        private int sdt;
        private string email;

        public string MaNCC
        {
            get { return mancc; }
            set { mancc = value; }
        }
        public string TenNCC
        {
            get { return tenncc; }
            set { tenncc = value; }
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
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
