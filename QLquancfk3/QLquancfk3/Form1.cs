using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLquancfk3.DTO;
using QLquancfk3.BLL;
using System.Xml;

namespace QLquancfk3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            object[] array = nhanvienbll.HienThiMaCV().ToArray<object>();
            comboBoxmacv.Items.AddRange(array);
            array = thucuongbll.HienThiMaLoai().ToArray<object>();
            comboBoxmaloai.Items.AddRange(array);
        }

        ChucVuBLL chucvubll = new ChucVuBLL();
        ChucVuDTO chucvudto = new ChucVuDTO();
        NhanVienBLL nhanvienbll = new NhanVienBLL();
        NhanVienDTO nhanviendto = new NhanVienDTO();
        ThucUongBLL thucuongbll = new ThucUongBLL();
        ThucUongDTO thucuongdto = new ThucUongDTO();

        private void button1_Click(object sender, EventArgs e)
        {
            chucvubll.HienThi(dataGridViewChucVu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textmacv.Text.Trim() != "") 
            {
                chucvudto.MaCV = textmacv.Text;
                chucvudto.TenCV = texttencv.Text;
                chucvudto.SoLuong = int.Parse(textsoluong.Text);

                chucvubll.Them(chucvudto);
                chucvubll.HienThi(dataGridViewChucVu);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textmacv.Text.Trim() != "")
            {
                chucvudto.MaCV = textmacv.Text;
                chucvudto.TenCV = texttencv.Text;
                
                if (textsoluong.Text.Trim() == "")
                {
                    chucvudto.SoLuong = -1;
                }
                else
                {
                    chucvudto.SoLuong = int.Parse(textsoluong.Text);
                }
                chucvubll.Sua(chucvudto);
                chucvubll.HienThi(dataGridViewChucVu);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textmacv.Text.Trim() != "")
            {
                chucvudto.MaCV = textmacv.Text;

                chucvubll.Xoa(chucvudto);
                chucvubll.HienThi(dataGridViewChucVu);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textmacv.Text.Trim() != "")
            {
                chucvudto.MaCV = textmacv.Text;

                chucvubll.TimKiem(chucvudto,dataGridViewChucVu);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nhanvienbll.HienThi(dataGridViewNhanVien);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBoxmanv.Text.Trim() != "")
            {
                nhanviendto.MaNV = textBoxmanv.Text;
                nhanviendto.MaCV = comboBoxmacv.Text;
                nhanviendto.TenNV =textBoxtennv.Text;
                nhanviendto.NgaySinh=textBoxngaysinh.Text;

                if (radioButtonnam.Checked)
                {
                    nhanviendto.GioiTinh = "Nam";
                }

                if (radioButtonnu.Checked)
                {
                    nhanviendto.GioiTinh = "Nữ";
                }
                nhanviendto.NgayVao=textBoxngayvao.Text;
                nhanviendto.DiaChi=textBoxdiachi.Text;
                nhanviendto.SDT = int.Parse(textBoxsdt.Text);
                nhanvienbll.Them(nhanviendto);
                nhanvienbll.HienThi(dataGridViewNhanVien);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBoxmanv.Text.Trim() != "")
            {
                nhanviendto.MaNV = textBoxmanv.Text;
                nhanviendto.MaCV = comboBoxmacv.Text;
                nhanviendto.TenNV = textBoxtennv.Text;
                nhanviendto.NgaySinh = textBoxngaysinh.Text;

                if (radioButtonnam.Checked)
                {
                    nhanviendto.GioiTinh = "Nam";
                }

                if (radioButtonnu.Checked)
                {
                    nhanviendto.GioiTinh = "Nữ";
                }
                nhanviendto.NgayVao = textBoxngayvao.Text;
                nhanviendto.DiaChi = textBoxdiachi.Text;
                if (textBoxsdt.Text.Trim() == "")
                {
                    nhanviendto.SDT = -1;
                }
                else
                {
                    nhanviendto.SDT = int.Parse(textBoxsdt.Text);
                }

                nhanvienbll.Sua(nhanviendto);
                nhanvienbll.HienThi(dataGridViewNhanVien);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBoxmanv.Text.Trim() != "")
            {
                nhanviendto.MaNV = textBoxmanv.Text;

                nhanvienbll.Xoa(nhanviendto);
                nhanvienbll.HienThi(dataGridViewNhanVien);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBoxmanv.Text.Trim() != "")
            {
                nhanviendto.MaNV = textBoxmanv.Text;

                nhanvienbll.TimKiem(nhanviendto, dataGridViewNhanVien);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            thucuongbll.HienThi(dataGridViewThucUong);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBoxmatu.Text.Trim() != "")
            {
                thucuongdto.MaTU = textBoxmatu.Text;
                thucuongdto.MaLoai = comboBoxmaloai.Text;
                thucuongdto.TenTU = textBoxtentu.Text;
                thucuongdto.Gia = int.Parse(textBoxgia.Text);
                thucuongdto.DonViTinh = textBoxdonvitinh.Text;
                thucuongbll.Them(thucuongdto);
                thucuongbll.HienThi(dataGridViewThucUong);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBoxmatu.Text.Trim() != "")
            {
                thucuongdto.MaTU = textBoxmatu.Text;

                thucuongbll.Xoa(thucuongdto);
                thucuongbll.HienThi(dataGridViewThucUong);
            }
        }

    }
}
