using System.Windows.Forms;
using System.Xml;
using XMLQuanLySach.DTO;

namespace XMLQuanLySach.BLL
{
    public class SachBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        private string fileName = @"I:\Code\CSharp\XMLQuanLySach\XMLQuanLySach\XMLSach.xml";

        public SachBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void Them(SachDTO sachThem)
        {
            //tạo nút sách
            XmlNode sach = doc.CreateElement("sach");

            //tạo nút con của sách là masach
            XmlElement masach = doc.CreateElement("masach");
            masach.InnerText = sachThem.MaSach;//gán giá trị cho mã sách
            sach.AppendChild(masach);//thêm masach vào trong sách(sach nhận masach là con)

            XmlElement tensach = doc.CreateElement("tensach");
            tensach.InnerText = sachThem.TenSach;
            sach.AppendChild(tensach);

            XmlElement soluong = doc.CreateElement("soluong");
            soluong.InnerText = sachThem.SoLuong.ToString();
            sach.AppendChild(soluong);

            XmlElement dongia = doc.CreateElement("dongia");
            dongia.InnerText = sachThem.DongGia.ToString();
            sach.AppendChild(dongia);
            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(sach);
            doc.Save(fileName);//lưu dữ liệu
        }

        public void Sua(SachDTO sachSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode sachCu = root.SelectSingleNode("sach[masach ='" + sachSua.MaSach + "']");
            if (sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("sach");

                //tạo nút con của sách là masach
                XmlElement masach = doc.CreateElement("masach");
                masach.InnerText = sachSua.MaSach;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(masach);//thêm masach vào trong sách(sach nhận masach là con)

                XmlElement tensach = doc.CreateElement("tensach");
                tensach.InnerText = sachSua.TenSach;
                sachSuaMoi.AppendChild(tensach);

                XmlElement soluong = doc.CreateElement("soluong");
                soluong.InnerText = sachSua.SoLuong.ToString();
                sachSuaMoi.AppendChild(soluong);

                XmlElement dongia = doc.CreateElement("dongia");
                dongia.InnerText = sachSua.DongGia.ToString();
                sachSuaMoi.AppendChild(dongia);

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save(fileName);//lưu lại
            }
        }

        public void Xoa(SachDTO sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("sach[masach ='" + sachXoa.MaSach + "']");
            if (sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save(fileName);
            }
        }

        public void TimKiem(SachDTO sachTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("sach[masach ='" + sachTim.MaSach + "']");

            if (sachCanTim != null)
            {
                dgv.ColumnCount = 4;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachCanTim.SelectSingleNode("masach").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("tensach").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("soluong").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("dongia").InnerText;
            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="sachTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public SachDTO TimKiem2(SachDTO sachTim, DataGridView dgv)
        {
            SachDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("sach[masach ='" + sachTim.MaSach + "']");
            if (sachCanTim != null)
            {
                dgv.ColumnCount = 4;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachTim.MaSach = sachCanTim.SelectSingleNode("masach").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("tensach").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("soluong").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("dongia").InnerText;

                ketQua = new SachDTO();

                ketQua.MaSach = sachCanTim.SelectSingleNode("masach").InnerText;
                ketQua.TenSach = sachCanTim.SelectSingleNode("tensach").InnerText;
                ketQua.SoLuong = int.Parse(sachCanTim.SelectSingleNode("soluong").InnerText);
                ketQua.DongGia = double.Parse(sachCanTim.SelectSingleNode("dongia").InnerText);
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 4;

            XmlNodeList ds = root.SelectNodes("sach");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("masach").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("tensach").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("soluong").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("dongia").InnerText;
                sd++;
            }
        }
    }
}