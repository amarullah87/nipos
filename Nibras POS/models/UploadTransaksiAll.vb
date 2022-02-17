Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports System.Net
Imports System.Text
Imports System.IO

Module UploadTransaksiAll

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

    Public Sub uploadLeads(ByVal tanggal As String)
        Call cekKoneksi()
        Dim detailLeads As New List(Of ModelLeads)()

        If CheckForInternetConnection() Then
            Try
                Dim Raw As String
                Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "uploadLeadsNew")
                Request.Method = "POST"
                Request.Timeout = 3600000

                cekClose()
                cekOpen()
                CMD = New MySqlCommand("SELECT * FROM leads WHERE tanggal = '" & tanggal & "' ", Conn)
                DR = CMD.ExecuteReader

                Do While DR.Read
                    detailLeads.Add(New ModelLeads() With {
                        .tanggal = Format(DR.Item("tanggal"), "yyyy-MM-dd"),
                        .jenis = DR.Item("jenis"),
                        .total = DR.Item("total")
                    })
                Loop
                cekClose()

                Dim postbody As String = "data=" & JsonConvert.SerializeObject(detailLeads) & "&tanggal=" & tanggal & "&idoutlet=" & GetIdOutlet()
                'Console.WriteLine(JsonConvert.SerializeObject(detailbeli))
                'Console.WriteLine(postbody)
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                Request.ContentType = "application/x-www-form-urlencoded"
                Request.ContentLength = byteArray.Length

                Dim dataStream As Stream = Request.GetRequestStream()

                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                Dim Response As WebResponse = Request.GetResponse()
                Dim Read = New StreamReader(Response.GetResponseStream())
                Raw = ""
                Raw = Read.ReadToEnd()
                Console.WriteLine(Raw)

            Catch ex As WebException
                If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                    MsgBox(ex.Message.ToString + " Tidak dapat terhubung dengan Server!")
                End If
            End Try
        End If
    End Sub

    Public Sub uploadPenjualanHariDetail(ByVal tanggal As String)
        Call cekKoneksi()
        Dim detailbeli As New List(Of ModelPenjualanDetail)()

        If CheckForInternetConnection() Then
            Try
                Dim Raw As String
                Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "penjualanDetailDayNew")
                Request.Method = "POST"
                Request.Timeout = 3600000

                cekClose()
                cekOpen()
                CMD = New MySqlCommand("select d.*, p.`tgl_jual` from detailjual d inner join penjualan p on p.`faktur_jual` = d.`faktur_jual` where p.`tgl_jual` = '" & tanggal & "' AND p.faktur_jual NOT LIKE 'BTL%' ", Conn)
                'CMD = New MySqlCommand("select d.*, p.`tgl_jual` from detailjual d inner join penjualan p on p.`faktur_jual` = d.`faktur_jual` where p.`tgl_jual` = '2021-03-15' ", Conn)
                DR = CMD.ExecuteReader

                Do While DR.Read
                    detailbeli.Add(New ModelPenjualanDetail() With {
                                .faktur = DR.Item("faktur_jual"),
                                .kodebarang = DR.Item("kode_barang"),
                                .harga = DR.Item("harga_jual"),
                                .qty = DR.Item("qty_jual"),
                                .diskon = DR.Item("diskon"),
                                .diskon_rp = DR.Item("diskon_rp"),
                                .subtotal = DR.Item("subtotal_jual"),
                                .keterangan = DR.Item("ket_jual"),
                                .qtyretur = DR.Item("qty_retur"),
                                .id_outlet = GetIdOutlet()
                    })
                Loop
                cekClose()

                Dim postbody As String = "data=" & JsonConvert.SerializeObject(detailbeli) & "&tanggal=" & tanggal & "&idoutlet=" & GetIdOutlet()
                'Console.WriteLine(postbody)
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                Request.ContentType = "application/x-www-form-urlencoded"
                Request.ContentLength = byteArray.Length

                Dim dataStream As Stream = Request.GetRequestStream()

                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                Dim Response As WebResponse = Request.GetResponse()
                Dim Read = New StreamReader(Response.GetResponseStream())
                Raw = ""
                Raw = Read.ReadToEnd()
                Console.WriteLine(Raw)

            Catch ex As WebException
                If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                    MsgBox(ex.Message.ToString + " Tidak dapat terhubung dengan Server!")
                End If
            End Try

            Call uploadLeads(tanggal)
        End If
    End Sub

    Public Sub uploadPenjualanHari(ByVal tanggal As String)
        Call cekKoneksi()

        If CheckForInternetConnection() Then
            If GetIdOutlet() <> "" Then

                Dim penjualanList As New List(Of ModelPenjualan)()
                Dim Raw As String
                If CheckForInternetConnection() Then
                    Try
                        Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "penjualanDayNew")
                        Request.Method = "POST"
                        Request.Timeout = 3600000

                        cekClose()
                        cekOpen()
                        CMD = New MySqlCommand("SELECT * FROM penjualan WHERE tgl_jual = '" & tanggal & "' AND faktur_jual NOT LIKE 'BTL%' ", Conn)
                        'CMD = New MySqlCommand("SELECT * FROM penjualan WHERE tgl_jual = '2021-03-15' ", Conn)
                        DR = CMD.ExecuteReader

                        Do While DR.Read

                            'Console.Write(DR.Item("faktur_jual"))

                            penjualanList.Add(New ModelPenjualan() With {
                                .faktur = DR.Item("faktur_jual"),
                                .tgljual = Format(DR.Item("tgl_jual"), "yyyy-MM-dd"),
                                .qty = DR.Item("item_jual"),
                                .total = DR.Item("total_jual"),
                                .total_diskon = DR.Item("total_diskon"),
                                .bayar = DR.Item("bayar_jual"),
                                .kembali = DR.Item("kembali_jual"),
                                .carajual = DR.Item("cara_jual"),
                                .sisahutang = DR.Item("sisa_piutang"),
                                .jthtempo = Format(DR.Item("jth_tempo_jual"), "yyyy-MM-dd"),
                                .statusjual = DR.Item("status_jual"),
                                .tunai = DR.Item("tunai"),
                                .kredit = DR.Item("kredit"),
                                .debita = DR.Item("debit_a"),
                                .banka = DR.Item("bank_a"),
                                .kartua = DR.Item("kartu_a"),
                                .cc = DR.Item("credit_card"),
                                .bankcc = DR.Item("bank_cc"),
                                .kartucc = DR.Item("kartu_cc"),
                                .emoney = DR.Item("emoney"),
                                .bankemoney = DR.Item("bank_emoney"),
                                .kartuemoney = DR.Item("kartu_emoney"),
                                .member = DR.Item("kode_customer"),
                                .user = DR.Item("kode_user"),
                                .idoutlet = GetIdOutlet()
                            })
                        Loop

                        cekClose()
                        'Console.WriteLine(tanggal)
                        'Console.WriteLine(JsonConvert.SerializeObject(penjualanList))
                        Dim postbody As String = "data=" & JsonConvert.SerializeObject(penjualanList) & "&tanggal=" & tanggal & "&idoutlet=" & GetIdOutlet()
                        'Console.WriteLine(postbody)

                        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                        Request.ContentType = "application/x-www-form-urlencoded"
                        Request.ContentLength = byteArray.Length

                        Dim dataStream As Stream = Request.GetRequestStream()

                        dataStream.Write(byteArray, 0, byteArray.Length)
                        dataStream.Close()

                        Dim Response As WebResponse = Request.GetResponse()
                        Dim Read = New StreamReader(Response.GetResponseStream())
                        Raw = ""
                        Raw = Read.ReadToEnd()
                        Console.WriteLine(Raw)

                    Catch ex As WebException
                        If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                            MsgBox(ex.Message.ToString + "Tidak dapat terhubung dengan Server!")
                        End If
                    End Try
                End If
            End If

            Call uploadPenjualanHariDetail(tanggal)
        End If
    End Sub

    Public Class ModelLeads
        Private t_tanggal As String
        Public Property tanggal() As String
            Get
                Return t_tanggal
            End Get
            Set(ByVal value As String)
                t_tanggal = value
            End Set
        End Property

        Private t_jenis As String
        Public Property jenis() As String
            Get
                Return t_jenis
            End Get
            Set(ByVal value As String)
                t_jenis = value
            End Set
        End Property

        Private t_total As Integer
        Public Property total() As Integer
            Get
                Return t_total
            End Get
            Set(ByVal value As Integer)
                t_total = value
            End Set
        End Property
    End Class

    Public Class ModelPenjualanDetail
        Private t_faktur As String
        Public Property faktur() As String
            Get
                Return t_faktur
            End Get
            Set(ByVal value As String)
                t_faktur = value
            End Set
        End Property
        Private t_kodebarang As String
        Public Property kodebarang() As String
            Get
                Return t_kodebarang
            End Get
            Set(ByVal value As String)
                t_kodebarang = value
            End Set
        End Property

        Private t_harga As Double
        Public Property harga() As Double
            Get
                Return t_harga
            End Get
            Set(ByVal value As Double)
                t_harga = value
            End Set
        End Property

        Private t_qty As Integer
        Public Property qty() As Integer
            Get
                Return t_qty
            End Get
            Set(ByVal value As Integer)
                t_qty = value
            End Set
        End Property

        Private t_diskon As Integer
        Public Property diskon() As Integer
            Get
                Return t_diskon
            End Get
            Set(ByVal value As Integer)
                t_diskon = value
            End Set
        End Property

        Private t_subtotal As Double
        Public Property subtotal() As Double
            Get
                Return t_subtotal
            End Get
            Set(ByVal value As Double)
                t_subtotal = value
            End Set
        End Property

        Private t_keterangan As String
        Public Property keterangan() As String
            Get
                Return t_keterangan
            End Get
            Set(ByVal value As String)
                t_keterangan = value
            End Set
        End Property

        Private t_qtyretur As Integer
        Public Property qtyretur() As Integer
            Get
                Return t_qtyretur
            End Get
            Set(ByVal value As Integer)
                t_qtyretur = value
            End Set
        End Property


        Private t_diskon_rp As Double
        Public Property diskon_rp() As Double
            Get
                Return t_diskon_rp
            End Get
            Set(ByVal value As Double)
                t_diskon_rp = value
            End Set
        End Property

        Private t_id_outlet As String
        Public Property id_outlet() As String
            Get
                Return t_id_outlet
            End Get
            Set(ByVal value As String)
                t_id_outlet = value
            End Set
        End Property
    End Class

    Public Class ModelPenjualan
        Private t_faktur As String
        Private t_tgljual As String
        Private t_qty As Integer
        Private t_total_diskon As Integer
        Private t_total As Double
        Private t_bayar As Double
        Private t_kembali As Double
        Private t_carajual As String
        Private t_sisahutang As Double
        Private t_jthtempo As String
        Private t_status As String

        Private t_tunai As Double
        Private t_kredit As Double
        Private t_debita As Double
        Private t_banka As String
        Private t_kartua As String
        Private t_cc As Double
        Private t_bankcc As String
        Private t_kartucc As String
        Private t_emoney As Double
        Private t_bankemoney As String
        Private t_kartuemoney As String

        Private t_member As String
        Private t_user As String
        Private t_detail As String
        Private t_idoutlet As String

        Public Property faktur() As String
            Get
                Return t_faktur
            End Get
            Set(ByVal value As String)
                t_faktur = value
            End Set
        End Property
        Public Property tgljual() As String
            Get
                Return t_tgljual
            End Get
            Set(ByVal value As String)
                t_tgljual = value
            End Set
        End Property
        Public Property qty() As Integer
            Get
                Return t_qty
            End Get
            Set(ByVal value As Integer)
                t_qty = value
            End Set
        End Property

        Public Property total_diskon() As Double
            Get
                Return t_total_diskon
            End Get
            Set(ByVal value As Double)
                t_total_diskon = value
            End Set
        End Property

        Public Property total() As Double
            Get
                Return t_total
            End Get
            Set(ByVal value As Double)
                t_total = value
            End Set
        End Property
        Public Property bayar() As Double
            Get
                Return t_bayar
            End Get
            Set(ByVal value As Double)
                t_bayar = value
            End Set
        End Property
        Public Property kembali() As Double
            Get
                Return t_kembali
            End Get
            Set(ByVal value As Double)
                t_kembali = value
            End Set
        End Property
        Public Property sisahutang() As Double
            Get
                Return t_sisahutang
            End Get
            Set(ByVal value As Double)
                t_sisahutang = value
            End Set
        End Property
        Public Property carajual() As String
            Get
                Return t_carajual
            End Get
            Set(ByVal value As String)
                t_carajual = value
            End Set
        End Property
        Public Property jthtempo() As String
            Get
                Return t_jthtempo
            End Get
            Set(ByVal value As String)
                t_jthtempo = value
            End Set
        End Property
        Public Property statusjual() As String
            Get
                Return t_status
            End Get
            Set(ByVal value As String)
                t_status = value
            End Set
        End Property
        Public Property tunai() As Double
            Get
                Return t_tunai
            End Get
            Set(ByVal value As Double)
                t_tunai = value
            End Set
        End Property
        Public Property kredit() As Double
            Get
                Return t_kredit
            End Get
            Set(ByVal value As Double)
                t_kredit = value
            End Set
        End Property

        Public Property debita() As Double
            Get
                Return t_debita
            End Get
            Set(ByVal value As Double)
                t_debita = value
            End Set
        End Property
        Public Property banka() As String
            Get
                Return t_banka
            End Get
            Set(ByVal value As String)
                t_banka = value
            End Set
        End Property
        Public Property kartua() As String
            Get
                Return t_kartua
            End Get
            Set(ByVal value As String)
                t_kartua = value
            End Set
        End Property

        Public Property cc() As Double
            Get
                Return t_cc
            End Get
            Set(ByVal value As Double)
                t_cc = value
            End Set
        End Property
        Public Property bankcc() As String
            Get
                Return t_bankcc
            End Get
            Set(ByVal value As String)
                t_bankcc = value
            End Set
        End Property
        Public Property kartucc() As String
            Get
                Return t_kartucc
            End Get
            Set(ByVal value As String)
                t_kartucc = value
            End Set
        End Property

        Public Property emoney() As Double
            Get
                Return t_emoney
            End Get
            Set(ByVal value As Double)
                t_emoney = value
            End Set
        End Property
        Public Property bankemoney() As String
            Get
                Return t_bankemoney
            End Get
            Set(ByVal value As String)
                t_bankemoney = value
            End Set
        End Property
        Public Property kartuemoney() As String
            Get
                Return t_kartuemoney
            End Get
            Set(ByVal value As String)
                t_kartuemoney = value
            End Set
        End Property

        Public Property member() As String
            Get
                Return t_member
            End Get
            Set(ByVal value As String)
                t_member = value
            End Set
        End Property
        Public Property user() As String
            Get
                Return t_user
            End Get
            Set(ByVal value As String)
                t_user = value
            End Set
        End Property
        Public Property detailitem() As String
            Get
                Return t_detail
            End Get
            Set(ByVal value As String)
                t_detail = value
            End Set
        End Property
        Public Property idoutlet() As String
            Get
                Return t_idoutlet
            End Get
            Set(ByVal value As String)
                t_idoutlet = value
            End Set
        End Property
    End Class
End Module
