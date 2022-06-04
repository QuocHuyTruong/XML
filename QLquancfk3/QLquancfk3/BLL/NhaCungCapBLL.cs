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
    public class NhaCungCapBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        string fileName = @"D:\XML\QLquancfk3\QLquancfk3\XMQLquancf3k.xml";

        public NhaCungCapBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void Them(NhaCungCapDTO NhaCungCapThem)
        {
            XmlNode nhacungcap = doc.CreateElement("NhaCungCap");

            XmlElement mancc = doc.CreateElement("MaNCC");
            mancc.InnerText = NhaCungCapThem.MaNCC;
            nhacungcap.AppendChild(mancc);

            XmlElement tenncc = doc.CreateElement("TenNCC");
            tenncc.InnerText = NhaCungCapThem.TenNCC;
            nhacungcap.AppendChild(tenncc);

            XmlElement diachi = doc.CreateElement("DiaChi");
            diachi.InnerText = NhaCungCapThem.DiaChi;
            nhacungcap.AppendChild(diachi);

            XmlElement sdt = doc.CreateElement("SDT");
            sdt.InnerText = NhaCungCapThem.SDT.ToString();
            nhacungcap.AppendChild(sdt);

            XmlElement email = doc.CreateElement("EmailNCC");
            email.InnerText = NhaCungCapThem.Email;
            nhacungcap.AppendChild(email);

            root.AppendChild(nhacungcap);
            doc.Save(fileName);
        }

        public void Sua(NhaCungCapDTO NhaCungCapSua)
        {
            XmlNode nhacccu = root.SelectSingleNode("NhaCungCap[MaNCC ='" + NhaCungCapSua.MaNCC + "']");
            if (nhacccu != null)
            {
                XmlNode nhaccmoi = doc.CreateElement("NhaCungCap");

                XmlElement mancc = doc.CreateElement("MaNCC");
                mancc.InnerText = NhaCungCapSua.MaNCC;
                nhaccmoi.AppendChild(mancc);

                //----------------------------------------------
                XmlElement tenncc = doc.CreateElement("TenNCC");
                if (NhaCungCapSua.TenNCC.Trim() == "")
                {
                    XmlNode nhacc = root.SelectSingleNode("NhaCungCap[MaNCC ='" + NhaCungCapSua.MaNCC + "']");
                    tenncc.InnerText = nhacc.SelectSingleNode("TenNCC").InnerText;
                }
                else
                {
                    tenncc.InnerText = NhaCungCapSua.TenNCC;
                }
                nhaccmoi.AppendChild(tenncc);

                //----------------------------------------------
                XmlElement diachi = doc.CreateElement("DiaChi");
                if (NhaCungCapSua.DiaChi.Trim() == "")
                {
                    XmlNode nhacc = root.SelectSingleNode("NhaCungCap[MaNCC ='" + NhaCungCapSua.MaNCC + "']");
                    diachi.InnerText = nhacc.SelectSingleNode("DiaChi").InnerText;
                }
                else
                {
                    diachi.InnerText = NhaCungCapSua.DiaChi;
                }
                nhaccmoi.AppendChild(diachi);

                //----------------------------------------------
                XmlElement sdt = doc.CreateElement("SDT");
                if (NhaCungCapSua.SDT == -1)
                {
                    XmlNode nhacc = root.SelectSingleNode("NhaCungCap[MaNCC ='" + NhaCungCapSua.MaNCC + "']");
                    sdt.InnerText = nhacc.SelectSingleNode("SDT").InnerText;
                }
                else
                {
                    sdt.InnerText = NhaCungCapSua.SDT.ToString();
                }
                nhaccmoi.AppendChild(sdt);

                //----------------------------------------------
                XmlElement email = doc.CreateElement("EmailNCC");
                if (NhaCungCapSua.Email.Trim() == "")
                {
                    XmlNode nhacc = root.SelectSingleNode("NhaCungCap[MaNCC ='" + NhaCungCapSua.MaNCC + "']");
                    email.InnerText = nhacc.SelectSingleNode("EmailNCC").InnerText;
                }
                else
                {
                    email.InnerText = NhaCungCapSua.Email;
                }
                nhaccmoi.AppendChild(email);


                root.ReplaceChild(nhaccmoi, nhacccu);
                doc.Save(fileName);
            }
        }

        public void Xoa(NhaCungCapDTO NhaCungCapXoa)
        {
            XmlNode nhaccxoa = root.SelectSingleNode("NhaCungCap[MaNCC ='" + NhaCungCapXoa.MaNCC + "']");
            if (nhaccxoa != null)
            {
                root.RemoveChild(nhaccxoa);

                doc.Save(fileName);
            }
        }

        public void TimKiem(NhaCungCapDTO NhaCungCapTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode nhacctim = root.SelectSingleNode("NhaCungCap[MaNCC ='" + NhaCungCapTim.MaNCC + "']");

            if (nhacctim != null)
            {
                dgv.ColumnCount = 5;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = nhacctim.SelectSingleNode("MaNCC").InnerText;
                dgv.Rows[0].Cells[1].Value = nhacctim.SelectSingleNode("TenNCC").InnerText;
                dgv.Rows[0].Cells[2].Value = nhacctim.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[0].Cells[3].Value = nhacctim.SelectSingleNode("SDT").InnerText;
                dgv.Rows[0].Cells[4].Value = nhacctim.SelectSingleNode("EmailNCC").InnerText;
            }
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 5;

            XmlNodeList ds = root.SelectNodes("NhaCungCap");

            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaNCC").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenNCC").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("SDT").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("EmailNCC").InnerText;
                sd++;
            }
        }
    }
}
