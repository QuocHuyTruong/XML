<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
    exclude-result-prefixes="xs"
    version="2.0">
    <xsl:template match = "/">
        <html>
            <head><title> Quản Lý Nhập Hàng</title></head>
            <body>
                <div style="text-align : center">
                    <h1 style="color : red">Quản Lý Nhập Hàng</h1>
                    <h3 style="color : green">Trương Quốc Huy</h3>
                </div>
                <table  border="1" style="margin-left:470">
                    <tr>
                        <th>STT</th>
                        <th>Số hóa đơn</th>
                        <th>Ngày nhập</th>
                        <th>Mã hàng hóa</th>
                        <th>Số lượng</th>
                        <th>Đơn giá nhập</th>
                        <th>Thành Tiền</th>
                    </tr>
                    
                    <xsl:for-each select="QLNH/ChiTietNhap">
                        <xsl:variable name="SoHD" select="SoHD"/>
                        <tr>
                            <td><xsl:value-of select="position()"/></td>
                            <td><xsl:value-of select="SoHD"/></td>
                            <td><xsl:value-of select="/QLNH/HoaDonNhap[SoHD = $SoHD]/NgayNhap"/></td>
                            <td><xsl:value-of select="MaHH"/></td>
                            <td><xsl:value-of select="SoLuong"/></td>
                            <td><xsl:value-of select="DonGiaNhap"/></td>
                            <td><xsl:value-of select='format-number(SoLuong*DonGiaNhap, "#")'/></td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>