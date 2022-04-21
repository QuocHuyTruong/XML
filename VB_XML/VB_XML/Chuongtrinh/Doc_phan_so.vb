Imports System.Xml

Module Doc_phan_so
    Public Sub main()
        Dim Tu_so, Mau_so As Integer
        Dim Duong_dan As String = "..\..\Du_lieu\Phan_so.xml"
        Dim Tai_lieu As New XmlDocument
        Tai_lieu.Load(Duong_dan)
        Dim Goc As XmlElement = Tai_lieu.DocumentElement
        Tu_so = Goc.GetAttribute("Tu_so")
        Mau_so = Goc.GetAttribute("Mau_so")
        Dim Chuoi As String = "Phan so: "
        Chuoi &= Tu_so & "/" & Mau_so
        Console.Write(Chuoi)
        Console.ReadLine()
    End Sub
End Module
