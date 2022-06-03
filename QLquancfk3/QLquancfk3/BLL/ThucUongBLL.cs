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
    class ThucUongBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        string fileName = @"D:\XML\QLquancfk3\QLquancfk3\XMQLquancf3k.xml";

        public ThucUongBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void Them(ThucUongDTO TUThem)
        {
            XmlNode thucuong = doc.CreateElement("ThucUong");

            XmlElement matu = doc.CreateElement("MaTU");
            matu.InnerText = TUThem.MaTU;
            thucuong.AppendChild(matu);

            XmlElement maloai = doc.CreateElement("MaLoai");
            maloai.InnerText = TUThem.MaLoai;
            thucuong.AppendChild(maloai);

            XmlElement tentu = doc.CreateElement("TenTU");
            tentu.InnerText = TUThem.TenTU;
            thucuong.AppendChild(tentu);

            XmlElement gia = doc.CreateElement("Gia");
            gia.InnerText = TUThem.Gia.ToString();
            thucuong.AppendChild(gia);

            XmlElement donvitinh = doc.CreateElement("DonViTinh");
            donvitinh.InnerText = TUThem.DonViTinh;
            thucuong.AppendChild(donvitinh);

            root.AppendChild(thucuong);
            doc.Save(fileName);
        }

        public void Sua(ThucUongDTO ThucUongSua)
        {
            XmlNode thucuongcu = root.SelectSingleNode("ThucUong[MaTU ='" + ThucUongSua.MaTU + "']");
            if (thucuongcu != null)
            {
                XmlNode thucuongmoi = doc.CreateElement("ThucUong");

                XmlElement matu = doc.CreateElement("MaTu");
                matu.InnerText = ThucUongSua.MaTU;
                thucuongmoi.AppendChild(matu);


                XmlElement maloai = doc.CreateElement("MaLoai");
                if (ThucUongSua.MaLoai.Trim() == "")
                {
                    XmlNode thucuong = root.SelectSingleNode("ThucUong[MaTU ='" + ThucUongSua.MaTU + "']");
                    maloai.InnerText = thucuong.SelectSingleNode("MaLoai").InnerText;
                }
                else
                {
                    maloai.InnerText = ThucUongSua.MaLoai;
                }
                thucuongmoi.AppendChild(maloai);


                XmlElement tentu = doc.CreateElement("TenTU");
                if (ThucUongSua.TenTU.Trim() == "")
                {
                    XmlNode thucuong = root.SelectSingleNode("ThucUong[MaTU ='" + ThucUongSua.MaTU + "']");
                    tentu.InnerText = thucuong.SelectSingleNode("TenTU").InnerText;
                }
                else
                {
                    tentu.InnerText = ThucUongSua.TenTU;
                }
                thucuongmoi.AppendChild(tentu);

                XmlElement gia = doc.CreateElement("Gia");
                if (ThucUongSua.Gia == -1)
                {
                    XmlNode thucuong = root.SelectSingleNode("ThucUong[MaTU ='" + ThucUongSua.MaTU + "']");
                    gia.InnerText = thucuong.SelectSingleNode("Gia").InnerText;
                }
                else
                {
                    gia.InnerText = ThucUongSua.Gia.ToString();
                }
                thucuongmoi.AppendChild(gia);

                XmlElement donvitinh = doc.CreateElement("DonViTinh");
                if (ThucUongSua.DonViTinh.Trim() == "")
                {
                    XmlNode thucuong = root.SelectSingleNode("ThucUong[MaTU ='" + ThucUongSua.MaTU + "']");
                    donvitinh.InnerText = thucuong.SelectSingleNode("DonViTinh").InnerText;
                }
                else
                {
                    donvitinh.InnerText = ThucUongSua.DonViTinh;
                }

                root.ReplaceChild(thucuongmoi, thucuongcu);
                doc.Save(fileName);
            }
        }

        public void Xoa(ThucUongDTO ThucUongXoa)
        {
            XmlNode thucuongxoa = root.SelectSingleNode("ThucUong[MaTU ='" + ThucUongXoa.MaTU + "']");
            if (thucuongxoa != null)
            {
                root.RemoveChild(thucuongxoa);
                doc.Save(fileName);
            }
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 5;

            XmlNodeList ds = root.SelectNodes("ThucUong");

            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaTU").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaLoai").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("TenTU").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("Gia").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("DonViTinh").InnerText;
                sd++;
            }
        }

        public void TimKiem(ThucUongDTO ThucUongTim,DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode thucuongtim = root.SelectSingleNode("ThucUong[MaTU ='" + ThucUongTim.MaTU + "']");

            if (thucuongtim != null)
            {
                dgv.ColumnCount = 5;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = thucuongtim.SelectSingleNode("MaTU").InnerText;
                dgv.Rows[0].Cells[1].Value = thucuongtim.SelectSingleNode("MaLoai").InnerText;
                dgv.Rows[0].Cells[2].Value = thucuongtim.SelectSingleNode("TenTU").InnerText;
                dgv.Rows[0].Cells[3].Value = thucuongtim.SelectSingleNode("Gia").InnerText;
                dgv.Rows[0].Cells[4].Value = thucuongtim.SelectSingleNode("DonViTinh").InnerText;
            }
        }

        public List<String> HienThiMaLoai()
        {
            List<string> items = new List<string>();
            XmlNodeList ds = root.SelectNodes("LoaiThucUong");
            foreach (XmlNode item in ds)
            {
                items.Add(item.SelectSingleNode("MaLoai").InnerText);
            }
            return items;
        }
    }
}
