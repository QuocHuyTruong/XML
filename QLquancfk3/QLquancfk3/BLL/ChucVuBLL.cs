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
    public class ChucVuBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        string fileName = @"D:\XML\QLquancfk3\QLquancfk3\XMQLquancf3k.xml";

        public ChucVuBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void Them(ChucVuDTO CVThem)
        {
            //tạo nút chucvu
            XmlNode chucvu = doc.CreateElement("ChucVu");

            //tạo cac nút con của chucvu
            XmlElement macv = doc.CreateElement("MaCV");
            macv.InnerText = CVThem.MaCV;
            chucvu.AppendChild(macv);

            XmlElement tencv = doc.CreateElement("TenCV");  
            tencv.InnerText = CVThem.TenCV;
            chucvu.AppendChild(tencv);

            XmlElement soluong = doc.CreateElement("SoLuong");
            soluong.InnerText = CVThem.SoLuong.ToString();
            chucvu.AppendChild(soluong);

            //sau khi tạo xong cv thì thêm cv vào gốc root
            root.AppendChild(chucvu);
            doc.Save(fileName);//lưu dữ liệu
        }

        public void Sua(ChucVuDTO ChucVuSua)
        {
            XmlNode chucvucu = root.SelectSingleNode("ChucVu[MaCV ='" + ChucVuSua.MaCV + "']");
            if (chucvucu != null)
            {
                XmlNode chucvumoi = doc.CreateElement("ChucVu");

                XmlElement macv = doc.CreateElement("MaCV");
                macv.InnerText = ChucVuSua.MaCV;
                chucvumoi.AppendChild(macv);

                //----------------------------------------------
                XmlElement tencv = doc.CreateElement("TenCV");
                if(ChucVuSua.TenCV.Trim() == "")
                {
                    XmlNode chucvu = root.SelectSingleNode("ChucVu[MaCV ='" + ChucVuSua.MaCV + "']");
                    tencv.InnerText = chucvu.SelectSingleNode("TenCV").InnerText;
                }
                else
                {
                    tencv.InnerText = ChucVuSua.TenCV;
                }
                chucvumoi.AppendChild(tencv);

                //----------------------------------------------
                XmlElement soluong = doc.CreateElement("SoLuong");
                if (ChucVuSua.SoLuong == -1)
                {
                    XmlNode chucvu = root.SelectSingleNode("ChucVu[MaCV ='" + ChucVuSua.MaCV + "']");
                    soluong.InnerText = chucvu.SelectSingleNode("SoLuong").InnerText;
                }
                else
                {
                    soluong.InnerText = ChucVuSua.SoLuong.ToString();
                }
                chucvumoi.AppendChild(soluong);



                root.ReplaceChild(chucvumoi, chucvucu);
                doc.Save(fileName);
            }
        }

        public void Xoa(ChucVuDTO ChucVuXoa)
        {
            XmlNode chucvuxoa = root.SelectSingleNode("ChucVu[MaCV ='" + ChucVuXoa.MaCV + "']");
            if (chucvuxoa != null)
            {
                root.RemoveChild(chucvuxoa);

                doc.Save(fileName);
            }
        }

        public void TimKiem(ChucVuDTO ChucVuTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode chucvutim = root.SelectSingleNode("ChucVu[MaCV ='" + ChucVuTim.MaCV + "']");

            if (chucvutim != null)
            {
                dgv.ColumnCount = 3;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = chucvutim.SelectSingleNode("MaCV").InnerText;
                dgv.Rows[0].Cells[1].Value = chucvutim.SelectSingleNode("TenCV").InnerText;
                dgv.Rows[0].Cells[2].Value = chucvutim.SelectSingleNode("SoLuong").InnerText;
            }
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 3;

            XmlNodeList ds = root.SelectNodes("ChucVu");
           
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaCV").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenCV").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("SoLuong").InnerText;
                sd++;
            }
        }
    }
}
