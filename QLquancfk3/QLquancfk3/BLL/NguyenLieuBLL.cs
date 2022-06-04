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
    public class NguyenLieuBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        string fileName = @"D:\XML\QLquancfk3\QLquancfk3\XMQLquancf3k.xml";

        public NguyenLieuBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void Them(NguyenLieuDTO NguyenLieuThem)
        {
            XmlNode nguyenlieu = doc.CreateElement("NguyenLieu");

            XmlElement manl = doc.CreateElement("MaNL");
            manl.InnerText = NguyenLieuThem.MaNL;
            nguyenlieu.AppendChild(manl);

            XmlElement mancc = doc.CreateElement("MaNCC");
            mancc.InnerText = NguyenLieuThem.MaNCC;
            nguyenlieu.AppendChild(mancc);

            XmlElement tennl = doc.CreateElement("TenNL");
            tennl.InnerText = NguyenLieuThem.TenNL;
            nguyenlieu.AppendChild(tennl);

            XmlElement soluong = doc.CreateElement("SoLuong");
            soluong.InnerText = NguyenLieuThem.SoLuong.ToString();
            nguyenlieu.AppendChild(soluong);

            XmlElement donvi = doc.CreateElement("DonVi");
            donvi.InnerText = NguyenLieuThem.DonVi;
            nguyenlieu.AppendChild(donvi);

            XmlElement gia = doc.CreateElement("Gia");
            gia.InnerText = NguyenLieuThem.Gia.ToString();
            nguyenlieu.AppendChild(gia);

            root.AppendChild(nguyenlieu);
            doc.Save(fileName);
        }

        public void Sua(NguyenLieuDTO NguyenLieuSua)
        {
            XmlNode nguyenlieucu = root.SelectSingleNode("NguyenLieu[MaNL ='" + NguyenLieuSua.MaNL + "']");
            if (nguyenlieucu != null)
            {
                XmlNode nguyenlieumoi = doc.CreateElement("NguyenLieu");

                XmlElement manl = doc.CreateElement("MaNL");
                manl.InnerText = NguyenLieuSua.MaNL;
                nguyenlieumoi.AppendChild(manl);

                //----------------------------------------------
                XmlElement mancc = doc.CreateElement("MaNCC");
                if (NguyenLieuSua.MaNCC.Trim() == "")
                {
                    XmlNode nguyenlieu = root.SelectSingleNode("NguyenLieu[MaNL ='" + NguyenLieuSua.MaNL + "']");
                    mancc.InnerText = nguyenlieu.SelectSingleNode("MaNCC").InnerText;
                }
                else
                {
                    mancc.InnerText = NguyenLieuSua.MaNCC;
                }
                nguyenlieumoi.AppendChild(mancc);

                //----------------------------------------------
                XmlElement tennl = doc.CreateElement("TenNL");
                if (NguyenLieuSua.TenNL.Trim() == "")
                {
                    XmlNode nguyenlieu = root.SelectSingleNode("NguyenLieu[MaNL ='" + NguyenLieuSua.MaNL + "']");
                    tennl.InnerText = nguyenlieu.SelectSingleNode("TenNL").InnerText;
                }
                else
                {
                    tennl.InnerText = NguyenLieuSua.TenNL;
                }
                nguyenlieumoi.AppendChild(tennl);

                //----------------------------------------------
                XmlElement soluong = doc.CreateElement("SoLuong");
                if (NguyenLieuSua.SoLuong == -1)
                {
                    XmlNode nguyenlieu = root.SelectSingleNode("NguyenLieu[MaNL ='" + NguyenLieuSua.MaNL + "']");
                    soluong.InnerText = nguyenlieu.SelectSingleNode("SoLuong").InnerText;
                }
                else
                {
                    soluong.InnerText = NguyenLieuSua.SoLuong.ToString();
                }
                nguyenlieumoi.AppendChild(soluong);

                //----------------------------------------------
                XmlElement donvi = doc.CreateElement("DonVi");
                if (NguyenLieuSua.DonVi.Trim() == "")
                {
                    XmlNode nguyenlieu = root.SelectSingleNode("NguyenLieu[MaNL ='" + NguyenLieuSua.MaNL + "']");
                    donvi.InnerText = nguyenlieu.SelectSingleNode("DonVi").InnerText;
                }
                else
                {
                    donvi.InnerText = NguyenLieuSua.DonVi;
                }
                nguyenlieumoi.AppendChild(donvi);

                //----------------------------------------------
                XmlElement gia = doc.CreateElement("Gia");
                if (NguyenLieuSua.Gia == -1)
                {
                    XmlNode nguyenlieu = root.SelectSingleNode("NguyenLieu[MaNL ='" + NguyenLieuSua.MaNL + "']");
                    gia.InnerText = nguyenlieu.SelectSingleNode("Gia").InnerText;
                }
                else
                {
                    gia.InnerText = NguyenLieuSua.Gia.ToString();
                }
                nguyenlieumoi.AppendChild(gia);

                root.ReplaceChild(nguyenlieumoi, nguyenlieucu);
                doc.Save(fileName);
            }
        }

        public void Xoa(NguyenLieuDTO NguyenLieuXoa)
        {
            XmlNode nguyenlieuxoa = root.SelectSingleNode("NguyenLieu[MaNL ='" + NguyenLieuXoa.MaNL + "']");
            if (nguyenlieuxoa != null)
            {
                root.RemoveChild(nguyenlieuxoa);

                doc.Save(fileName);
            }
        }

        public void TimKiem(NguyenLieuDTO NguyenLieuTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode nguyenlieutim = root.SelectSingleNode("NguyenLieu[MaNL ='" + NguyenLieuTim.MaNL + "']");

            if (nguyenlieutim != null)
            {
                dgv.ColumnCount = 6;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = nguyenlieutim.SelectSingleNode("MaNL").InnerText;
                dgv.Rows[0].Cells[1].Value = nguyenlieutim.SelectSingleNode("MaNCC").InnerText;
                dgv.Rows[0].Cells[2].Value = nguyenlieutim.SelectSingleNode("TenNL").InnerText;
                dgv.Rows[0].Cells[3].Value = nguyenlieutim.SelectSingleNode("SoLuong").InnerText;
                dgv.Rows[0].Cells[4].Value = nguyenlieutim.SelectSingleNode("DonVi").InnerText;
                dgv.Rows[0].Cells[5].Value = nguyenlieutim.SelectSingleNode("Gia").InnerText;
            }
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 6;

            XmlNodeList ds = root.SelectNodes("NguyenLieu");

            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaNL").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaNCC").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("TenNL").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("SoLuong").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("DonVi").InnerText;
                dgv.Rows[sd].Cells[5].Value = item.SelectSingleNode("Gia").InnerText;
                sd++;
            }
        }

        public List<String> HienThiMaNCC()
        {
            List<string> items = new List<string>();
            XmlNodeList ds = root.SelectNodes("NhaCungCap");
            foreach (XmlNode item in ds)
            {
                items.Add(item.SelectSingleNode("MaNCC").InnerText);
            }
            return items;
        }
    }
}
