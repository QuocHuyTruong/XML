<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
    exclude-result-prefixes="xs"
    version="2.0">
    
    <xsl:template match="/">
        <HTML> 
            <HEAD> <TITLE>QUẢN LÝ TOUR DU LỊCH</TITLE> </HEAD>
            <BODY>
                <H1 style="color:blue" align="center">Bảng đăng ký Tour</H1>
                <H3 style="color:red" align="center">Diệp Túy Dũng</H3>
                
                <TABLE align="center" border="1">
                    <TR> 
                        <TH>Mã chuyến đi</TH>  
                        <TH>Ngày đăng ký</TH>
                        <TH>Tổng số tiền</TH>
                        <TH>Tiền đặt cọc</TH>
                        <TH>Tình trạng</TH>
                        <TH>Phải trả</TH>
                    </TR>
                    <xsl:for-each select="QLDL/DangKyTour">
                        <TR>
                            <TD><xsl:value-of select ="MaChuyenDi" /></TD>
                            <TD><xsl:value-of select ="NgayDK" /></TD>
                            <TD><xsl:value-of select ="TongSoTien" /></TD>
                            <TD><xsl:value-of select ="TienDatCoc" /></TD>
                            <TD><xsl:value-of select ="TinhTrang" /></TD>
                            <xsl:choose>
                                <xsl:when test="TinhTrang = 'tốt'">
                                    <TD><xsl:value-of select ="format-number(number(TongSoTien)-number(TienDatCoc),'#')" /></TD>
                                </xsl:when>
                                <xsl:otherwise>
                                    <TD><xsl:value-of select ="format-number(-(number(TienDatCoc) div 2),'#')" /></TD>
                                </xsl:otherwise>
                            </xsl:choose>
                        </TR>
                    </xsl:for-each>
                </TABLE>
            </BODY>
        </HTML>
    </xsl:template>
</xsl:stylesheet>