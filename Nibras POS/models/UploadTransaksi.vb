Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports System.Net
Imports System.Text
Imports System.IO

Module UploadTransaksi

    Dim today As Date = Date.Today
    Dim lastDate As Date = today.AddDays(-3)

    Dim tgl1 As String = Format(lastDate, "yyyy-MM-dd")
    Dim tgl2 As String = Format(today, "yyyy-MM-dd")

    Public Function GetPembelianDetail(ByVal noFaktur As String) As String
        Dim detailbeli As New List(Of ModelPembelianDetail)()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM detailbeli WHERE faktur_beli = '" & noFaktur & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            detailbeli.Add(New ModelPembelianDetail() With {
                        .faktur = DR.Item("faktur_beli"),
                        .kodebarang = DR.Item("kode_barang"),
                        .harga = DR.Item("harga_beli"),
                        .qty = DR.Item("qty_beli"),
                        .diskon = DR.Item("diskon"),
                        .subtotal = DR.Item("subtotal_beli"),
                        .keterangan = DR.Item("ket_beli"),
                        .qtyretur = DR.Item("qty_retur"),
                        .qtyreal = DR.Item("qty_real"),
                        .subtotalreal = DR.Item("subtotal_real")
            })
        Loop
        cekClose()

        'cekOpen()
        'CMD = New MySqlCommand("SELECT * FROM pembelian WHERE faktur_beli = '" & noFaktur & "' ", Conn)
        'DR = CMD.ExecuteReader
        'DR.Read()

        'If DR.HasRows Then
        '    details.Add(New ModelPembelian() With {
        '                .faktur = DR.Item("faktur_beli"),
        '                .tglbeli = DR.Item("tgl_beli"),
        '                .qty = DR.Item("item_beli"),
        '                .total = DR.Item("total_beli"),
        '                .bayar = DR.Item("bayar_beli"),
        '                .carabeli = DR.Item("cara_beli"),
        '                .sisahutang = DR.Item("sisa_hutang"),
        '                .tempo = DR.Item("tempo_hari"),
        '                .jthtempo = DR.Item("jth_tempo_beli"),
        '                .statusbeli = DR.Item("status_beli"),
        '                .supplier = DR.Item("kode_supplier"),
        '                .user = DR.Item("kode_user"),
        '                .detailitem = JsonConvert.SerializeObject(detailbeli),
        '                .idoutlet = MenuUtamaNew.PanelID.Text
        '    })
        'End If
        'cekClose()

        Return JsonConvert.SerializeObject(detailbeli)
    End Function

    Public Sub uploadPembelian(ByVal noFaktur As String)

        Dim dataInput As String = GetPembelianDetail(noFaktur)

        Dim Raw As String
        If CheckForInternetConnection() Then
            Try
                Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "pembelian")
                Request.Method = "POST"
                Request.Timeout = 60000

                cekOpen()
                CMD = New MySqlCommand("SELECT * FROM pembelian WHERE faktur_beli = '" & noFaktur & "' ", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                Dim postbody As String = "faktur_beli=" & DR.Item("faktur_beli") & "&tgl_beli=" & Format(DR.Item("tgl_beli"), "yyyy-MM-dd") & "&item_beli=" & DR.Item("item_beli") & "&total_beli=" & DR.Item("total_beli") &
                        "&bayar_beli=" & DR.Item("bayar_beli") & "&cara_beli=" & DR.Item("cara_beli") & "&sisa_hutang=" & DR.Item("sisa_hutang") & "&tempo_hari=" & DR.Item("tempo_hari") &
                        "&jth_tempo_beli=" & Format(DR.Item("jth_tempo_beli"), "yyyy-MM-dd") & "&status_beli=" & DR.Item("status_beli") & "&kode_supplier=" & DR.Item("kode_supplier") & "&kode_user=" & DR.Item("kode_user") &
                        "&detail_item=" & dataInput & "&no_pesanan=" & DR.Item("no_pesanan") & "&nama_supplier=" & DR.Item("nama_supplier") & "&id_outlet=" & MainMenu.PanelID.Text
                'Dim postbody As String = ""
                cekClose()

                'Console.WriteLine(postbody)
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                Request.ContentType = "application/x-www-form-urlencoded"
                Request.ContentLength = byteArray.Length

                Dim dataStream As Stream = Request.GetRequestStream()

                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                'get HTTP Response
                Dim Response As WebResponse = Request.GetResponse()
                'Console.WriteLine((CType(Response, HttpWebResponse)).StatusDescription)

                'read HTTP response
                Dim Read = New StreamReader(Response.GetResponseStream())
                Raw = ""
                Raw = Read.ReadToEnd()
                'Console.WriteLine(Raw)
            Catch ex As WebException
                If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                    'MsgBox(ex.Message.ToString)
                    'MsgBox("Tidak dapat terhubung dengan Server!")
                End If
            End Try
        End If
    End Sub

    Public Sub UploadPembelianPerHari()
        cekOpen()
    End Sub

    Public Function GetMasterBarang() As String
        Dim details As New List(Of ModelMasterBarang)()
        Dim user As New ModelMasterBarang

        cekOpen()
        CMD = New MySqlCommand("SELECT kode_item, hpp, stok FROM barang_m LIMIT 5", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            details.Add(New ModelMasterBarang() With {
                        .kodeitem = DR.Item("kode_item"),
                        .hpp = DR.Item("hpp"),
                        .stok = DR.Item("stok"),
                        .idoutlet = ""
            })
        Loop
        cekClose()

        ''Untuk Deserialize
        ''Dim user = JsonConvert.DeserializeObject(Of List(Of userdetails))(strmsg)
        Return JsonConvert.SerializeObject(details)
    End Function

    Public Function GetJurnal() As String
        Dim details As New List(Of ModelJurnal)()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM jurnal WHERE LEFT(tgl_transaksi, 10) = '" & tgl2 & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            details.Add(New ModelJurnal() With {
                        .nomortransaksi = DR.Item("nomor_transaksi"),
                        .tgltrans = DR.Item("tgl_transaksi"),
                        .kodeacc = DR.Item("kode_perkiraan"),
                        .uraian = DR.Item("uraian"),
                        .debet = DR.Item("debet"),
                        .kredit = DR.Item("kredit"),
                        .idoutlet = ""
            })
        Loop
        cekClose()

        Return JsonConvert.SerializeObject(details)
        'Return Format(lastDate, "yyyy-MM-dd") + " s.d " + Format(today, "yyyy-MM-dd")
    End Function


    Public Sub CheckHutang()
        cekOpen()
        CMD = New MySqlCommand("SELECT faktur_beli, DATEDIFF(jth_tempo_beli, NOW()) AS expired FROM pembelian WHERE status_beli = 'BELUM LUNAS'", Conn)
        DR = CMD.ExecuteReader

        Dim totalHutang As Integer
        Do While DR.Read

            Dim exp As Integer = Convert.ToInt16(DR.Item("expired"))
            If exp <= 3 Then
                totalHutang += 1
            End If

        Loop

        'If totalHutang > 0 Then
        '    MenuUtamaNew.lblWarning.Text = "PERHATIAN!! Ada [ " & totalHutang & " ] Transaksi Hutang Pembelian yang belum terbayar dan akan Jatuh Tempo!"
        '    MenuUtamaNew.lblWarning.Visible = True
        'Else
        '    MenuUtamaNew.lblWarning.Text = ""
        'End If
        cekClose()
    End Sub
End Module

'System.Threading.ThreadPool.QueueUserWorkItem(AddressOf DoAsyncWork)
Public Class ModelPembelian
    Private t_faktur As String
    Private t_tglbeli As String
    Private t_qty As Integer
    Private t_total As Double
    Private t_bayar As Double
    Private t_carabeli As String
    Private t_sisahutang As Double
    Private t_tempo As Integer
    Private t_jthtempo As String
    Private t_status As String
    Private t_supplier As String
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
    Public Property tglbeli() As String
        Get
            Return t_tglbeli
        End Get
        Set(ByVal value As String)
            t_tglbeli = value
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
    Public Property carabeli() As String
        Get
            Return t_carabeli
        End Get
        Set(ByVal value As String)
            t_carabeli = value
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
    Public Property tempo() As Integer
        Get
            Return t_tempo
        End Get
        Set(ByVal value As Integer)
            t_tempo = value
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
    Public Property statusbeli() As String
        Get
            Return t_status
        End Get
        Set(ByVal value As String)
            t_status = value
        End Set
    End Property
    Public Property supplier() As String
        Get
            Return t_supplier
        End Get
        Set(ByVal value As String)
            t_supplier = value
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

Public Class ModelPembelianDetail
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

    Private t_qtyreal As Integer
    Public Property qtyreal() As Integer
        Get
            Return t_qtyreal
        End Get
        Set(ByVal value As Integer)
            t_qtyreal = value
        End Set
    End Property

    Private t_subtotalreal As Double
    Public Property subtotalreal() As Double
        Get
            Return t_subtotalreal
        End Get
        Set(ByVal value As Double)
            t_subtotalreal = value
        End Set
    End Property

End Class

Public Class ModelPenjualan
    Private t_faktur As String
    Private t_tgljual As String
    Private t_qty As Integer
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

Public Class ModelMasterBarang
    Private t_kodeitem As String
    Private t_idoutlet As String
    Private t_hpp As Double
    Private t_stok As Integer

    Public Property kodeitem() As String
        Get
            Return t_kodeitem
        End Get
        Set(ByVal value As String)
            t_kodeitem = value
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
    Public Property hpp() As Double
        Get
            Return t_hpp
        End Get
        Set(ByVal value As Double)
            t_hpp = value
        End Set
    End Property
    Public Property stok() As Integer
        Get
            Return t_stok
        End Get
        Set(ByVal value As Integer)
            t_stok = value
        End Set
    End Property
End Class

Public Class ModelBayarUtang
    Private t_nomorbayar As String
    Private t_idoutlet As String
    Private t_tglbayar As String
    Private t_fakturbeli As String
    Private t_jmlbarang As Integer
    Private t_sisautang As Double
    Private t_user As String

    Public Property nomorbayar() As String
        Get
            Return t_nomorbayar
        End Get
        Set(ByVal value As String)
            t_nomorbayar = value
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
    Public Property tglbayar() As String
        Get
            Return t_tglbayar
        End Get
        Set(ByVal value As String)
            t_tglbayar = value
        End Set
    End Property
    Public Property fakturbeli() As String
        Get
            Return t_fakturbeli
        End Get
        Set(ByVal value As String)
            t_fakturbeli = value
        End Set
    End Property
    Public Property jmlbarang() As Integer
        Get
            Return t_jmlbarang
        End Get
        Set(ByVal value As Integer)
            t_jmlbarang = value
        End Set
    End Property
    Public Property sisautang() As Double
        Get
            Return t_sisautang
        End Get
        Set(ByVal value As Double)
            t_sisautang = value
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
End Class

Public Class ModelHistoryHpp
    Private t_kodeitem As String
    Private t_idoutlet As String
    Private t_hppawal As Double
    Private t_hppakhir As Double
    Private t_qty As Integer
    Private t_subtotal As Double
    Private t_createddate As String

    Public Property kodeitem() As String
        Get
            Return t_kodeitem
        End Get
        Set(ByVal value As String)
            t_kodeitem = value
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
    Public Property hppawal() As Double
        Get
            Return t_hppawal
        End Get
        Set(ByVal value As Double)
            t_hppawal = value
        End Set
    End Property
    Public Property hppakhir() As Double
        Get
            Return t_hppakhir
        End Get
        Set(ByVal value As Double)
            t_hppakhir = value
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
    Public Property subtotal() As Double
        Get
            Return t_subtotal
        End Get
        Set(ByVal value As Double)
            t_subtotal = value
        End Set
    End Property
    Public Property created_date() As String
        Get
            Return t_createddate
        End Get
        Set(ByVal value As String)
            t_createddate = value
        End Set
    End Property
End Class

Public Class ModelHistoryStok
    Private t_kodeitem As String
    Private t_idoutlet As String
    Private t_notransaksi As String
    Private t_tgltrans As String
    Private t_keterangan As String
    Private t_stokawal As Integer
    Private t_qty As Integer
    Private t_stokakhir As Integer
    Private t_createddate As String
    Private t_createdby As String

    Public Property kodeitem() As String
        Get
            Return t_kodeitem
        End Get
        Set(ByVal value As String)
            t_kodeitem = value
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
    Public Property notransaksi() As String
        Get
            Return t_notransaksi
        End Get
        Set(ByVal value As String)
            t_notransaksi = value
        End Set
    End Property
    Public Property tgltrans() As String
        Get
            Return t_tgltrans
        End Get
        Set(ByVal value As String)
            t_tgltrans = value
        End Set
    End Property
    Public Property keterangan() As String
        Get
            Return t_keterangan
        End Get
        Set(ByVal value As String)
            t_keterangan = value
        End Set
    End Property
    Public Property stokawal() As Integer
        Get
            Return t_stokawal
        End Get
        Set(ByVal value As Integer)
            t_stokawal = value
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
    Public Property stokakhir() As Integer
        Get
            Return t_stokakhir
        End Get
        Set(ByVal value As Integer)
            t_stokakhir = value
        End Set
    End Property
    Public Property createddate() As String
        Get
            Return t_createddate
        End Get
        Set(ByVal value As String)
            t_createddate = value
        End Set
    End Property
    Public Property createdby() As String
        Get
            Return t_createdby
        End Get
        Set(ByVal value As String)
            t_createdby = value
        End Set
    End Property
End Class

Public Class ModelJurnal
    Private t_nomortransaksi As String
    Private t_idoutlet As String
    Private t_tgltrans As String
    Private t_kodeacc As String
    Private t_uraian As String
    Private t_debet As Double
    Private t_kredit As Double

    Public Property nomortransaksi() As String
        Get
            Return t_nomortransaksi
        End Get
        Set(ByVal value As String)
            t_nomortransaksi = value
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
    Public Property tgltrans() As String
        Get
            Return t_tgltrans
        End Get
        Set(ByVal value As String)
            t_tgltrans = value
        End Set
    End Property
    Public Property kodeacc() As String
        Get
            Return t_kodeacc
        End Get
        Set(ByVal value As String)
            t_kodeacc = value
        End Set
    End Property
    Public Property uraian() As String
        Get
            Return t_uraian
        End Get
        Set(ByVal value As String)
            t_uraian = value
        End Set
    End Property
    Public Property debet() As Double
        Get
            Return t_debet
        End Get
        Set(ByVal value As Double)
            t_debet = value
        End Set
    End Property
    Public Property kredit() As String
        Get
            Return t_kredit
        End Get
        Set(ByVal value As String)
            t_kredit = value
        End Set
    End Property
End Class

Public Class ModelMemberDeposit
    Private t_nomortransaksi As String
    Private t_idoutlet As String
    Private t_tgltrans As String
    Private t_kodemember As String
    Private t_jenis As String
    Private t_jumlah As Double
    Private t_createdby As String
    Private t_createddate As String

    Public Property nomortransaksi() As String
        Get
            Return t_nomortransaksi
        End Get
        Set(ByVal value As String)
            t_nomortransaksi = value
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
    Public Property tgltrans() As String
        Get
            Return t_tgltrans
        End Get
        Set(ByVal value As String)
            t_tgltrans = value
        End Set
    End Property
    Public Property kodemember() As String
        Get
            Return t_kodemember
        End Get
        Set(ByVal value As String)
            t_kodemember = value
        End Set
    End Property
    Public Property jenis() As String
        Get
            Return t_jenis
        End Get
        Set(ByVal value As String)
            t_jenis = value
        End Set
    End Property
    Public Property jumlah() As Double
        Get
            Return t_jumlah
        End Get
        Set(ByVal value As Double)
            t_jumlah = value
        End Set
    End Property
    Public Property createdby() As String
        Get
            Return t_createdby
        End Get
        Set(ByVal value As String)
            t_createdby = value
        End Set
    End Property
    Public Property createddate() As String
        Get
            Return t_createddate
        End Get
        Set(ByVal value As String)
            t_createddate = value
        End Set
    End Property
End Class

Public Class ModelMember
    Private t_kodemember As String
    Private t_idoutlet As String
    Private t_nama As String
    Private t_alamat As String
    Private t_kota As String
    Private t_provinsi As String
    Private t_kodepos As String
    Private t_telepon As String
    Private t_email As String
    Private t_tgllahir As String
    Private t_kontak As String
    Private t_limit As Double
    Private t_limithari As Integer
    Private t_jatuhtempo As Integer
    Private t_group As String
    Private t_tipe As String
    Private t_deposit As Double

    Public Property kodemember() As String
        Get
            Return t_kodemember
        End Get
        Set(ByVal value As String)
            t_kodemember = value
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
    Public Property nama() As String
        Get
            Return t_nama
        End Get
        Set(ByVal value As String)
            t_nama = value
        End Set
    End Property
    Public Property alamat() As String
        Get
            Return t_alamat
        End Get
        Set(ByVal value As String)
            t_alamat = value
        End Set
    End Property
    Public Property kota() As String
        Get
            Return t_kota
        End Get
        Set(ByVal value As String)
            t_kota = value
        End Set
    End Property
    Public Property provinsi() As Double
        Get
            Return t_provinsi
        End Get
        Set(ByVal value As Double)
            t_provinsi = value
        End Set
    End Property
    Public Property kodepos() As String
        Get
            Return t_kodepos
        End Get
        Set(ByVal value As String)
            t_kodepos = value
        End Set
    End Property
    Public Property telepon() As String
        Get
            Return t_telepon
        End Get
        Set(ByVal value As String)
            t_telepon = value
        End Set
    End Property
    Public Property email() As String
        Get
            Return t_email
        End Get
        Set(ByVal value As String)
            t_email = value
        End Set
    End Property
    Public Property tgllahir() As String
        Get
            Return t_tgllahir
        End Get
        Set(ByVal value As String)
            t_tgllahir = value
        End Set
    End Property
    Public Property kontak() As String
        Get
            Return t_kontak
        End Get
        Set(ByVal value As String)
            t_kontak = value
        End Set
    End Property
    Public Property limit() As Double
        Get
            Return t_limit
        End Get
        Set(ByVal value As Double)
            t_limit = value
        End Set
    End Property
    Public Property limithari() As Integer
        Get
            Return t_limithari
        End Get
        Set(ByVal value As Integer)
            t_limithari = value
        End Set
    End Property
    Public Property jatuhtempo() As Integer
        Get
            Return t_jatuhtempo
        End Get
        Set(ByVal value As Integer)
            t_jatuhtempo = value
        End Set
    End Property
    Public Property group() As String
        Get
            Return t_group
        End Get
        Set(ByVal value As String)
            t_group = value
        End Set
    End Property
    Public Property tipediskon() As String
        Get
            Return t_tipe
        End Get
        Set(ByVal value As String)
            t_tipe = value
        End Set
    End Property
    Public Property deposit() As Double
        Get
            Return t_deposit
        End Get
        Set(ByVal value As Double)
            t_deposit = value
        End Set
    End Property
End Class

Public Class ModelReturPembelian
    Private t_noreturbeli As String
    Private t_idoutlet As String
    Private t_tglretur As String
    Private t_faktur As String
    Private t_qty As Integer
    Private t_user As String
    Private t_detailitem As String

    Public Property noreturbeli() As String
        Get
            Return t_noreturbeli
        End Get
        Set(ByVal value As String)
            t_noreturbeli = value
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
    Public Property tglretur() As String
        Get
            Return t_tglretur
        End Get
        Set(ByVal value As String)
            t_tglretur = value
        End Set
    End Property
    Public Property faktur() As String
        Get
            Return t_faktur
        End Get
        Set(ByVal value As String)
            t_faktur = value
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
            Return t_detailitem
        End Get
        Set(ByVal value As String)
            t_detailitem = value
        End Set
    End Property
End Class

Public Class ModelReturPenjualan
    Private t_noreturjual As String
    Private t_idoutlet As String
    Private t_tglretur As String
    Private t_faktur As String
    Private t_qty As Integer
    Private t_user As String
    Private t_detailitem As String

    Public Property noreturbeli() As String
        Get
            Return t_noreturjual
        End Get
        Set(ByVal value As String)
            t_noreturjual = value
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
    Public Property tglretur() As String
        Get
            Return t_tglretur
        End Get
        Set(ByVal value As String)
            t_tglretur = value
        End Set
    End Property
    Public Property faktur() As String
        Get
            Return t_faktur
        End Get
        Set(ByVal value As String)
            t_faktur = value
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
            Return t_detailitem
        End Get
        Set(ByVal value As String)
            t_detailitem = value
        End Set
    End Property
End Class

Public Class ModelTerimaPiutang
    Private t_nomorterima As String
    Private t_idoutlet As String
    Private t_tglterima As String
    Private t_fakturjual As String
    Private t_jmlbarang As Integer
    Private t_sisautang As Double
    Private t_user As String

    Public Property nomorterima() As String
        Get
            Return t_nomorterima
        End Get
        Set(ByVal value As String)
            t_nomorterima = value
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
    Public Property tglterima() As String
        Get
            Return t_tglterima
        End Get
        Set(ByVal value As String)
            t_tglterima = value
        End Set
    End Property
    Public Property fakturjual() As String
        Get
            Return t_fakturjual
        End Get
        Set(ByVal value As String)
            t_fakturjual = value
        End Set
    End Property
    Public Property jmlbarang() As Integer
        Get
            Return t_jmlbarang
        End Get
        Set(ByVal value As Integer)
            t_jmlbarang = value
        End Set
    End Property
    Public Property sisautang() As Double
        Get
            Return t_sisautang
        End Get
        Set(ByVal value As Double)
            t_sisautang = value
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
End Class