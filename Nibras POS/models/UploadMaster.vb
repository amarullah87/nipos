Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports System.Net
Imports System.Text
Imports System.IO

Module UploadMaster
    Dim today As Date = Date.Today
    Dim lastDate As Date = today.AddDays(-3)

    Dim tgl1 As String = Format(lastDate, "yyyy-MM-dd")
    Dim tgl2 As String = Format(today, "yyyy-MM-dd")

    Dim lokasi As String = Application.StartupPath & "\Config.txt"
    Dim baris As String()

    Function GetIdOutlet() As String
        baris = File.ReadAllLines(lokasi)

        Return baris(4)
    End Function

    Public Sub uploadStok()

        Dim dataBarang As New List(Of ModelStok)()
        If CheckForInternetConnection() Then

            cekOpen()
            CMD = New MySqlCommand("SELECT kode_item, hpp, stok FROM barang_m WHERE stok <> 0", Conn)
            DR = CMD.ExecuteReader

            Do While DR.Read

                dataBarang.Add(New ModelStok() With {
                              .kode_item = DR.Item("kode_item"),
                              .hpp = DR.Item("hpp"),
                              .stok = DR.Item("stok"),
                              .id_outlet = MainMenu.PanelID.Text
                })
            Loop
            cekClose()

            Dim postbody As String = "dataItem=" & JsonConvert.SerializeObject(dataBarang)

            Try
                Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "upBarangNew")
                Request.Method = "POST"
                Request.Timeout = 300000

                'Console.WriteLine(postbody)
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                Request.ContentType = "application/x-www-form-urlencoded"
                Request.ContentLength = byteArray.Length

                Dim dataStream As Stream = Request.GetRequestStream()

                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
            Catch ex As WebException
                If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                End If
            End Try
        End If
    End Sub

    Public Sub uploadItemNon(ByVal kode_item As String)

        If CheckForInternetConnection() Then

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & kode_item & "' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                Dim postbody As String = "kode_item=" & DR.Item("kode_item") & "&barcode=" & DR.Item("barcode") & "&nama_barang=" & DR.Item("nama_barang") & "&satuan=" & DR.Item("satuan") &
                    "&jenis=" & DR.Item("jenis") & "&merek=" & DR.Item("merek") & "&hpp=" & DR.Item("hpp") & "&hpj=" & DR.Item("hpj") & "&hpp_avg=" & DR.Item("hpp_avg") &
                    "&tipe=" & DR.Item("tipe") & "&stok_min=" & DR.Item("stok_min") & "&stok=" & DR.Item("stok") & "&keterangan=" & DR.Item("keterangan")
                cekClose()

                Try
                    Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "upBarangNon")
                    Request.Method = "POST"
                    Request.Timeout = 300000

                    'Console.WriteLine(postbody)
                    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                    Request.ContentType = "application/x-www-form-urlencoded"
                    Request.ContentLength = byteArray.Length

                    Dim dataStream As Stream = Request.GetRequestStream()

                    dataStream.Write(byteArray, 0, byteArray.Length)
                    dataStream.Close()
                Catch ex As WebException
                    If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                    End If
                End Try
            End If
        End If
    End Sub

End Module

Public Class ModelStok

    Private tKode_item As String
    Public Property kode_item() As String
        Get
            Return tKode_item
        End Get
        Set(ByVal value As String)
            tKode_item = value
        End Set
    End Property

    Private tHpp As Double
    Public Property hpp() As Double
        Get
            Return tHpp
        End Get
        Set(ByVal value As Double)
            tHpp = value
        End Set
    End Property

    Private tStok As Integer
    Public Property stok() As Integer
        Get
            Return tStok
        End Get
        Set(ByVal value As Integer)
            tStok = value
        End Set
    End Property

    Private tIdOutlet As String
    Public Property id_outlet() As String
        Get
            Return tIdOutlet
        End Get
        Set(ByVal value As String)
            tIdOutlet = value
        End Set
    End Property
End Class
