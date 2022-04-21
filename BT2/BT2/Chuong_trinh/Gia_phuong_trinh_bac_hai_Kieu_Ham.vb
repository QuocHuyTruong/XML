Imports System.Xml

Module Gia_phuong_trinh_bac_hai_Kieu_Ham
    Structure TAM_THUC
        Public a As Double
        Public b As Double
        Public c As Double
    End Structure
    Public Function Doc_tam_thuc(ByVal Duong_dan As String) As TAM_THUC
        Dim Kq As TAM_THUC
        Dim Tai_lieu As New XmlDocument
        Tai_lieu.Load(Duong_dan)
        Dim Goc As XmlElement = Tai_lieu.DocumentElement
        Kq.a = Goc.GetAttribute("a")
        Kq.b = Goc.GetAttribute("b")
        Kq.c = Goc.GetAttribute("c")
        Return Kq
    End Function
    Public Function Giai_phuong_trinh(ByVal P As TAM_THUC) As ArrayList
        Dim Kq As New ArrayList
        Dim Delta As Double = P.b * P.b - 4 * P.a * P.c
        If Delta Then
            Dim x As Double = (-P.b) / (2 * P.a)
            Kq.Add(x)
        ElseIf Delta > 0 Then
            Dim x1 As Double = (-P.b - Math.Sqrt(Delta)) / (2 * P.a)
            Dim x1 As Double = (-P.b + Math.Sqrt(Delta)) / (2 * P.a)
            Kq.Add(x1)
            Kq.Add(x2)
        End If
        Return Kq
    End Function
    Public Function Chuoi_tam_thuc(ByVal P As TAM_THUC) As String
        Dim Kq As String = ""
        Kq &= String.Format("{0}x^2+{1}x+{2}", P.a, P.b, P.c)
        Return Kq
    End Function
    Public Function Chuoi_nghiem(ByVal Ng As ArrayList) As String
        Dim Kq As String = ""
        If Ng.Count = 0 Then
            Kq = "vo nghiem"
        ElseIf Ng.Count = 1 Then
            Kq = String.Format("co nghiem kep x1=x2={0:F2}", Ng(0))
        ElseIf Ng.Count = 2 Then
            Kq = String.Formt("co 2 nghiem x1={0:F2} x2={1:F2}", Ng(0), Ng(1))
        End If
        Return Kq
    End Function
    Public Sub Main()
        Dim Duong_dan As String = "..\..\Du_lieu\Tam_thuc.xml"
    End Sub
End Module
