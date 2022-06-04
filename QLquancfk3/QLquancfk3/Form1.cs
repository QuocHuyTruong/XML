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
            array = nguyenlieubll.HienThiMaNCC().ToArray<object>();
            comboBoxmancc.Items.AddRange(array);
        }

        ChucVuBLL chucvubll = new ChucVuBLL();
        ChucVuDTO chucvudto = new ChucVuDTO();
        NhanVienBLL nhanvienbll = new NhanVienBLL();
        NhanVienDTO nhanviendto = new NhanVienDTO();
        ThucUongBLL thucuongbll = new ThucUongBLL();
        ThucUongDTO thucuongdto = new ThucUongDTO();
        NhaCungCapBLL nhaccbll = new NhaCungCapBLL();
        NhaCungCapDTO nhaccdto = new NhaCungCapDTO();
        NguyenLieuBLL nguyenlieubll = new NguyenLieuBLL();
        NguyenLieuDTO nguyenlieudto = new NguyenLieuDTO();

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
            if (textBoxmatu.Text.Trim() != "")
            {
                thucuongdto.MaTU = textBoxmatu.Text;
                thucuongdto.MaLoai = comboBoxmaloai.Text;
                thucuongdto.TenTU = textBoxtentu.Text;
                if (textBoxgia.Text.Trim() == "")
                {
                    thucuongdto.Gia = -1;
                }
                else
                {
                    thucuongdto.Gia = int.Parse(textBoxgia.Text);
                }
                thucuongdto.DonViTinh = textBoxdonvitinh.Text;
                thucuongbll.Sua(thucuongdto);
                thucuongbll.HienThi(dataGridViewThucUong);
            }
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

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBoxmatu.Text.Trim() != "")
            {
                thucuongdto.MaTU = textBoxmatu.Text;

                thucuongbll.TimKiem(thucuongdto, dataGridViewThucUong);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            nhaccbll.HienThi(dataGridViewNhaCungCap);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBoxmancc.Text.Trim() != "")
            {
                nhaccdto.MaNCC = textBoxmancc.Text;
                nhaccdto.TenNCC = textBoxtenncc.Text;
                nhaccdto.DiaChi = textBoxdiachincc.Text;
                nhaccdto.SDT = int.Parse(textBoxsdtncc.Text);
                nhaccdto.Email = textBoxemailncc.Text;

                nhaccbll.Them(nhaccdto);
                nhaccbll.HienThi(dataGridViewNhaCungCap);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBoxmancc.Text.Trim() != "")
            {
                nhaccdto.MaNCC = textBoxmancc.Text;
                nhaccdto.TenNCC = textBoxtenncc.Text;
                nhaccdto.DiaChi = textBoxdiachincc.Text;

                if (textBoxsdtncc.Text.Trim() == "")
                {
                    nhaccdto.SDT = -1;
                }
                else
                {
                    nhaccdto.SDT = int.Parse(textBoxsdtncc.Text);
                }
                nhaccdto.Email = textBoxemailncc.Text;
                nhaccbll.Sua(nhaccdto);
                nhaccbll.HienThi(dataGridViewNhaCungCap);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBoxmancc.Text.Trim() != "")
            {
                nhaccdto.MaNCC = textBoxmancc.Text;

                nhaccbll.Xoa(nhaccdto);
                nhaccbll.HienThi(dataGridViewNhaCungCap);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBoxmancc.Text.Trim() != "")
            {
                nhaccdto.MaNCC = textBoxmancc.Text;

                nhaccbll.TimKiem(nhaccdto, dataGridViewNhaCungCap);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            nguyenlieubll.HienThi(dataGridViewNguyenLieu);   
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBoxmanl.Text.Trim() != "")
            {
                nguyenlieudto.MaNL = textBoxmanl.Text;
                nguyenlieudto.MaNCC = comboBoxmancc.Text;
                nguyenlieudto.TenNL = textBoxtennl.Text;
                nguyenlieudto.SoLuong = int.Parse(textBoxslnl.Text);
                nguyenlieudto.DonVi = textBoxdonvinl.Text;
                nguyenlieudto.Gia = int.Parse(textBoxgianl.Text);

                nguyenlieubll.Them(nguyenlieudto);
                nguyenlieubll.HienThi(dataGridViewNguyenLieu);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (textBoxmanl.Text.Trim() != "")
            {
                nguyenlieudto.MaNL = textBoxmanl.Text;
                nguyenlieudto.MaNCC = comboBoxmancc.Text;
                nguyenlieudto.TenNL = textBoxtennl.Text;

                if (textBoxslnl.Text.Trim() == "")
                {
                    nguyenlieudto.SoLuong = -1;
                }
                else
                {
                    nguyenlieudto.SoLuong = int.Parse(textBoxslnl.Text);
                }
                nguyenlieubll.Sua(nguyenlieudto);
                nguyenlieubll.HienThi(dataGridViewNguyenLieu);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBoxmanl.Text.Trim() != "")
            {
                nguyenlieudto.MaNL = textBoxmanl.Text;

                nguyenlieubll.Xoa(nguyenlieudto);
                nguyenlieubll.HienThi(dataGridViewNguyenLieu);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (textBoxmanl.Text.Trim() != "")
            {
                nguyenlieudto.MaNL = textBoxmanl.Text;

                nguyenlieubll.TimKiem(nguyenlieudto,dataGridViewNguyenLieu);
            }
        }

        private void dataGridViewChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex != -1)
            {
                row = dataGridViewChucVu.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridViewChucVu.Rows[0];
            }

            textmacv.Text = Convert.ToString(row.Cells["Column1"].Value);
            texttencv.Text = Convert.ToString(row.Cells["Column2"].Value);
            textsoluong.Text = Convert.ToString(row.Cells["Column3"].Value);
        }

        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex != -1)
            {
                row = dataGridViewNhanVien.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridViewNhanVien.Rows[0];
            }

            textBoxmanv.Text = Convert.ToString(row.Cells["MaNV"].Value);
            comboBoxmacv.Text = Convert.ToString(row.Cells["MaCV"].Value);
            textBoxtennv.Text = Convert.ToString(row.Cells["TenNV"].Value);
            textBoxngaysinh.Text = Convert.ToString(row.Cells["Column4"].Value);
            if (Convert.ToString(row.Cells["Column5"].Value) == "Nam")
            {
                radioButtonnam.Checked = true;
            }
            else
            {
                radioButtonnu.Checked = true;
            }
            textBoxngayvao.Text = Convert.ToString(row.Cells["Column6"].Value);
            textBoxdiachi.Text = Convert.ToString(row.Cells["Column7"].Value);
            textBoxsdt.Text = Convert.ToString(row.Cells["Column8"].Value);
        }

        private void dataGridViewThucUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex != -1)
            {
                row = dataGridViewThucUong.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridViewThucUong.Rows[0];
            }

            textBoxmatu.Text = Convert.ToString(row.Cells["Column9"].Value);
            comboBoxmaloai.Text = Convert.ToString(row.Cells["Column10"].Value);
            textBoxtentu.Text = Convert.ToString(row.Cells["Column11"].Value);
            textBoxgia.Text = Convert.ToString(row.Cells["Column12"].Value);
            textBoxdonvitinh.Text = Convert.ToString(row.Cells["Column13"].Value);
        }

        private void dataGridViewNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex != -1)
            {
                row = dataGridViewNhaCungCap.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridViewNhaCungCap.Rows[0];
            }

            textBoxmancc.Text = Convert.ToString(row.Cells["MaNCC"].Value);
            textBoxtenncc.Text = Convert.ToString(row.Cells["TenNCC"].Value);
            textBoxdiachincc.Text = Convert.ToString(row.Cells["DiaChi"].Value);
            textBoxsdtncc.Text = Convert.ToString(row.Cells["SDT"].Value);
            textBoxemailncc.Text = Convert.ToString(row.Cells["Email"].Value);
        }

        private void dataGridViewNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex != -1)
            {
                row = dataGridViewNguyenLieu.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridViewNguyenLieu.Rows[0];
            }

            textBoxmanl.Text = Convert.ToString(row.Cells["MaNL"].Value);
            comboBoxmancc.Text = Convert.ToString(row.Cells["MaNCCNL"].Value);
            textBoxtennl.Text = Convert.ToString(row.Cells["TenNL"].Value);
            textBoxslnl.Text = Convert.ToString(row.Cells["SoLuong"].Value);
            textBoxdonvinl.Text = Convert.ToString(row.Cells["DonVi"].Value);
            textBoxgianl.Text = Convert.ToString(row.Cells["Gia"].Value);
        }



    }
}
