using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QLquancfk3.DTO;
using System.Windows.Forms;

namespace QLquancfk3.BLL
{
    class NhanVienBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        string fileName = @"D:\XML\QLquancfk3\QLquancfk3\XMQLquancf3k.xml";

        public NhanVienBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void Them(NhanVienDTO NVThem)
        {
            XmlNode nhanvien = doc.CreateElement("NhanVien");

            XmlElement manv = doc.CreateElement("MaNV");
            manv.InnerText = NVThem.MaNV;
            nhanvien.AppendChild(manv);

            XmlElement macv = doc.CreateElement("MaCV");
            macv.InnerText = NVThem.MaCV;
            nhanvien.AppendChild(macv);

            XmlElement tennv = doc.CreateElement("TenNV");
            tennv.InnerText = NVThem.TenNV;
            nhanvien.AppendChild(tennv);

            XmlElement ngaysinh = doc.CreateElement("NgaySinh");
            ngaysinh.InnerText = NVThem.NgaySinh;
            nhanvien.AppendChild(ngaysinh);

            XmlElement gioitinh = doc.CreateElement("GioiTinh");
            gioitinh.InnerText = NVThem.GioiTinh.ToString();
            nhanvien.AppendChild(gioitinh);

            XmlElement ngayvao = doc.CreateElement("NgayVao");
            ngayvao.InnerText = NVThem.NgayVao;
            nhanvien.AppendChild(ngayvao);

            XmlElement diachi = doc.CreateElement("DiaChi");
            diachi.InnerText = NVThem.DiaChi;
            nhanvien.AppendChild(diachi);

            XmlElement sdt = doc.CreateElement("SDT");
            sdt.InnerText = NVThem.SDT.ToString();
            nhanvien.AppendChild(sdt);

            root.AppendChild(nhanvien);
            doc.Save(fileName);//lưu dữ liệu
        }

        public void Sua(NhanVienDTO NhanVienSua)
        {
            XmlNode nhanviencu = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienSua.MaNV + "']");
            if (nhanviencu != null)
            {
                XmlNode nhanvienmoi = doc.CreateElement("NhanVien");

                XmlElement manv = doc.CreateElement("MaNV");
                manv.InnerText = NhanVienSua.MaNV;
                nhanvienmoi.AppendChild(manv);

                //----------------------------------------------
                XmlElement macv = doc.CreateElement("MaCV");
                if (NhanVienSua.MaCV.Trim() == "")
                {
                    XmlNode nhanvien = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienSua.MaNV + "']");
                    macv.InnerText = nhanvien.SelectSingleNode("MaCV").InnerText;

                }
                else
                {
                    macv.InnerText = NhanVienSua.MaCV;
                }
                nhanvienmoi.AppendChild(macv);

                //----------------------------------------------
                XmlElement tennv = doc.CreateElement("TenNV");
                if (NhanVienSua.TenNV.Trim() == "")
                {
                    XmlNode nhanvien = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienSua.MaNV + "']");
                    tennv.InnerText = nhanvien.SelectSingleNode("TenNV").InnerText;

                }
                else
                {
                    tennv.InnerText = NhanVienSua.TenNV;
                }
                nhanvienmoi.AppendChild(tennv);

                //----------------------------------------------
                XmlElement ngaysinh = doc.CreateElement("NgaySinh");
                if (NhanVienSua.NgaySinh.Trim() == "")
                {
                    XmlNode nhanvien = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienSua.MaNV + "']");
                    ngaysinh.InnerText = nhanvien.SelectSingleNode("NgaySinh").InnerText;

                }
                else
                {
                    ngaysinh.InnerText = NhanVienSua.NgaySinh;
                }
                nhanvienmoi.AppendChild(ngaysinh);

                //----------------------------------------------
                XmlElement gioitinh = doc.CreateElement("GioiTinh");
                if (NhanVienSua.GioiTinh.Trim() == "")
                {
                    XmlNode nhanvien = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienSua.MaNV + "']");
                    gioitinh.InnerText = nhanvien.SelectSingleNode("GioiTinh").InnerText;

                }
                else
                {
                    gioitinh.InnerText = NhanVienSua.GioiTinh.ToString();
                }
                nhanvienmoi.AppendChild(gioitinh);

                //----------------------------------------------
                XmlElement ngayvao = doc.CreateElement("NgayVao");
                if (NhanVienSua.NgayVao.Trim() == "")
                {
                    XmlNode nhanvien = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienSua.MaNV + "']");
                    ngayvao.InnerText = nhanvien.SelectSingleNode("NgayVao").InnerText;

                }
                else
                {
                    ngayvao.InnerText = NhanVienSua.NgayVao;
                }
                nhanvienmoi.AppendChild(ngayvao);

                //----------------------------------------------
                XmlElement diachi = doc.CreateElement("DiaChi");
                if (NhanVienSua.DiaChi.Trim() == "")
                {
                    XmlNode nhanvien = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienSua.MaNV + "']");
                    diachi.InnerText = nhanvien.SelectSingleNode("DiaChi").InnerText;

                }
                else
                {
                    diachi.InnerText = NhanVienSua.DiaChi;
                }
                nhanvienmoi.AppendChild(diachi);

                //----------------------------------------------
                XmlElement sdt = doc.CreateElement("SDT");
                if (NhanVienSua.SDT == -1)
                {
                    XmlNode nhanvien = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienSua.MaNV + "']");
                    sdt.InnerText = nhanvien.SelectSingleNode("SDT").InnerText;
                }
                else
                {
                    sdt.InnerText = NhanVienSua.SDT.ToString();
                }
                nhanvienmoi.AppendChild(sdt);

                root.ReplaceChild(nhanvienmoi, nhanviencu);
                doc.Save(fileName);
            }
        }

        public void Xoa(NhanVienDTO NhanVienXoa)
        {
            XmlNode nhanvienxoa = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienXoa.MaNV + "']");
            if (nhanvienxoa != null)
            {
                root.RemoveChild(nhanvienxoa);

                doc.Save(fileName);
            }
        }

        public void TimKiem(NhanVienDTO NhanVienTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode nhanvientim = root.SelectSingleNode("NhanVien[MaNV ='" + NhanVienTim.MaNV + "']");

            if (nhanvientim != null)
            {
                dgv.ColumnCount = 8;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = nhanvientim.SelectSingleNode("MaNV").InnerText;
                dgv.Rows[0].Cells[1].Value = nhanvientim.SelectSingleNode("MaCV").InnerText;
                dgv.Rows[0].Cells[2].Value = nhanvientim.SelectSingleNode("TenNV").InnerText;
                dgv.Rows[0].Cells[3].Value = nhanvientim.SelectSingleNode("NgaySinh").InnerText;
                dgv.Rows[0].Cells[4].Value = nhanvientim.SelectSingleNode("GioiTinh").InnerText;
                dgv.Rows[0].Cells[5].Value = nhanvientim.SelectSingleNode("NgayVao").InnerText;
                dgv.Rows[0].Cells[6].Value = nhanvientim.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[0].Cells[7].Value = nhanvientim.SelectSingleNode("SDT").InnerText;
            }
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 8;

            XmlNodeList ds = root.SelectNodes("NhanVien");

            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaNV").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaCV").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("TenNV").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("NgaySinh").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("GioiTinh").InnerText;
                dgv.Rows[sd].Cells[5].Value = item.SelectSingleNode("NgayVao").InnerText;
                dgv.Rows[sd].Cells[6].Value = item.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[sd].Cells[7].Value = item.SelectSingleNode("SDT").InnerText;
                sd++;
            }
        }

        public List<String> HienThiMaCV()
        {
            List<string> items = new List<string>();
            XmlNodeList ds = root.SelectNodes("ChucVu");
            foreach (XmlNode item in ds)
            {
                items.Add(item.SelectSingleNode("MaCV").InnerText);
            }
            return items;
        }
    }
}
