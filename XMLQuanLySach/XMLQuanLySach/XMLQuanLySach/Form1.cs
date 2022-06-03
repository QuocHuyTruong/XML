using System;
using System.Windows.Forms;
using XMLQuanLySach.BLL;
using XMLQuanLySach.DTO;

namespace XMLQuanLySach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SachBLL sachBLL = new SachBLL();
        private SachDTO sachDTO = new SachDTO();

        private void btnNhap_Click(object sender, EventArgs e)
        {
            sachBLL.HienThi(dgv);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSach = txtMS.Text.ToLower();
                sachDTO.TenSach = txtTS.Text;
                sachDTO.SoLuong = int.Parse(txtSL.Text);
                sachDTO.DongGia = double.Parse(txtDG.Text);
                //gọi BLL thực hiện
                sachBLL.Them(sachDTO);
                //hiện lên dgv
                sachBLL.HienThi(dgv);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSach = txtMS.Text.ToLower();
                sachDTO.TenSach = txtTS.Text;
                sachDTO.SoLuong = int.Parse(txtSL.Text);
                sachDTO.DongGia = double.Parse(txtDG.Text);
                //gọi BLL thực hiện
                sachBLL.Sua(sachDTO);
                //hiện lên dgv
                sachBLL.HienThi(dgv);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSach = txtMS.Text.ToLower();

                //gọi BLL thực hiện
                sachBLL.Xoa(sachDTO);
                //hiện lên dgv
                sachBLL.HienThi(dgv);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSach = txtMS.Text.ToLower();
                //gọi BLL thực hiện
                var sachTim = sachBLL.TimKiem2(sachDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (sachTim != null)
                {
                    txtDG.Text = sachTim.DongGia.ToString();
                    txtSL.Text = sachTim.SoLuong.ToString();
                    txtMS.Text = sachTim.MaSach;
                    txtTS.Text = sachTim.TenSach;
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMS.Text = txtDG.Text = txtSL.Text = txtTS.Text = string.Empty;
                }
            }
        }
    }
}