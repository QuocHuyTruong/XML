


for $item in doc("QLNH.xml")/QLNH/NhanVien
for $item2 in doc("QLNH.xml")/QLNH/HoaDonNhap
where($item2[contains(NgayNhap,"2020")])
where($item[contains(MaNV,$item2/MaNV)])
    return $item