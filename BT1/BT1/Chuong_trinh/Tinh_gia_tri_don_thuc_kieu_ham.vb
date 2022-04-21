Imports System.Xml

Module Tinh_gia_tri_don_thuc_kieu_ham
    Structure DON_THUC
        Public He_so As Double
        Public So_mu As Integer
    End Structure
    Public Function Doc_don_thuc(ByVal Duong_dan As String) As DON_THUC
        Dim Kq As DON_THUC
        Dim Tai_lieu As New XmlDocument
        Tai_lieu.Load(Duong_dan)
        Dim Goc As XmlElement = Tai_lieu.DocumentElement
        Kq.He_so = Goc.GetAttribute("He_so")
        Kq.So_mu = Goc.GetAttribute("So_mu")
        Return Kq
    End Function
    Public Function Gia_tri(ByVal P As DON_THUC, ByVal x0 As Double) As Double
        Dim Kq As Double
        Kq = P.He_so * Math.Pow(x0, P.So_mu)
        Return Kq
    End Function
    Public Function Chuoi_don_thuc(ByVal P As DON_THUC) As String
        Dim Kq As String = ""
        Kq &= P.He_so & "x^" & P.So_mu
        Return Kq
    End Function
    Public Function Nhap_so_thuc(ByVal Ghi_chu As String) As Double
        Dim Kq As Double
        Console.Write(Ghi_chu)
        Kq = Double.Parse(Console.ReadLine)
        Return Kq
    End Function
    Public Sub Main()
        Dim Duong_dan As String = "..\..\Du_lieu\Don_thuc.xml"
        Dim P As DON_THUC
        Dim x0 As Double
        Dim Kq As Double
        P = Doc_don_thuc(Duong_dan)
        x0 = Nhap_so_thuc("Gia tri x0= ")
        Kq = Gia_tri(P, x0)
        Dim Chuoi As String
        Chuoi = "Ket qua la: " & Kq
        Console.Write(Chuoi)
        Console.ReadLine()
    End Sub
End Module
