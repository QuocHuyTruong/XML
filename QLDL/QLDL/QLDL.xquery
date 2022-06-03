<QLDL>
    <Cau_a>
    </Cau_a>
    <Cau_b>
        {
            for $tour in doc("QLDL1.xml")//DSTour
            where $tour/Gia < 2000000
            return 
            $tour
        }
    </Cau_b>
    <Cau_c>
        {
            for $dkTour in doc("QLDL1.xml")//DangKyTour
            where $dkTour/TinhTrang = 'tốt'
            return 
            $dkTour
        }
    </Cau_c>
</QLDL>