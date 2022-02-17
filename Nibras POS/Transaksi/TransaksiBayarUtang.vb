Imports MySql.Data.MySqlClient

Public Class TransaksiBayarUtang

    Sub NomorOtomatis()
        cekOpen()

        CMD = New MySqlCommand("select * from bayarutang where nomor_bayar in(select max(nomor_bayar) from bayarutang)", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            lblnomor.Text = "BY" + Format(Now, "yyMMdd") + "01"
        Else
            If Mid(DR.Item("Nomor_bayar"), 3, 6) <> Format(Now, "yyMMdd") Then
                lblnomor.Text = "BY" + Format(Now, "yyMMdd") + "01"
            Else
                lblnomor.Text = Microsoft.VisualBasic.Right(DR.Item("Nomor_bayar"), 8) + 1
                lblnomor.Text = "BY" + lblnomor.Text
            End If
        End If

        cekClose()

        GetAkun()
    End Sub

    Sub GetAkun()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc IS NOT NULL ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            cbAkun.Items.Add(DR.Item("kodeacc") + "." + DR.Item("namaacc"))
        Loop
        cekClose()
    End Sub

    Sub TampilFakturUtang()
        cekClose()
        'cekOpen()

        'CMD = New MySqlCommand("select * from pembelian where status_beli='BELUM LUNAS' AND faktur_beli NOT LIKE 'BTL%' ", Conn)
        'DR = CMD.ExecuteReader
        'ListBox1.Items.Clear()
        'Do While DR.Read
        '    ListBox1.Items.Add(DR.Item("faktur_beli"))
        'Loop

        'cekClose()

        LookUpEditFaktur.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT faktur_beli, tgl_beli, total_beli, nama_supplier, kode_user AS `User Input` FROM pembelian WHERE status_beli='BELUM LUNAS' AND faktur_beli NOT LIKE 'BTL%'", Conn)
        DS = New DataSet
        DA.Fill(DS)
        LookUpEditFaktur.Properties.DataSource = DS.Tables(0)
        LookUpEditFaktur.Properties.DisplayMember = "faktur_beli"
        LookUpEditFaktur.Properties.ValueMember = "faktur_beli"
        cekClose()
    End Sub

    Sub InfoUtang()
        If ListBox1.Items.Count = 0 Then
            MsgBox("Semua Hutang Sudah Lunas", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub TransaksiBayarUtang_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilFakturUtang()
        Call NomorOtomatis()
        'Call InfoUtang()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        'On Error Resume Next
        cekOpen()
        CMD = New MySqlCommand("select * from pembelian where faktur_beli='" & ListBox1.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            lbltglbeli.Text = DR.Item("TGL_BELI")
            lblkodesupplier.Text = DR.Item("KODE_SUPPLIER")

            'Label4.Text = DR.Item("ITEM_BELI")
            txtdibayar.Enabled = False
            txttempo.Enabled = False
            lbltotalharga.Text = FormatNumber(DR.Item("TOTAL_BELI"), 0)
            txtdibayar.Text = FormatNumber(DR.Item("BAYAR_BELI"), 0)
            lblcarabeli.Text = DR.Item("CARA_BELI")
            lblsisahutang.Text = FormatNumber(DR.Item("SISA_HUTANG"), 0)
            txtjumlahbayar.Text = lblsisahutang.Text
            txttempo.Text = DR.Item("TEMPO_HARI")
            lblnamasupplier.Text = DR.Item("nama_supplier")
            If IsDBNull(DR.Item("keterangan")) Then
                txtKeterangan.Text = ""
            Else
                txtKeterangan.Text = DR.Item("keterangan")
            End If


            lbljatuhtempo.Text = DR.Item("JTH_TEMPO_BELI")
            cekClose()

            cekOpen()

            CMD = New MySqlCommand("select * from supplier_m where kode_supplier='" & lblkodesupplier.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                lblnamasupplier.Text = DR.Item("nama_supplier")
            End If
            cekClose()

            cekOpen()
            DA = New MySqlDataAdapter("Select detailbeli.kode_barang, barang_m.nama_barang, detailbeli.harga_beli, qty_beli ,subtotal_beli from detailbeli,barang_m where detailbeli.kode_barang=barang_m.kode_item and detailbeli.faktur_beli='" & ListBox1.Text & "'", Conn)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
            DGV.ReadOnly = True

            DGV.Columns(2).DefaultCellStyle.Format = "c0"
            DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(3).DefaultCellStyle.Format = "n0"
            DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(4).DefaultCellStyle.Format = "c0"
            DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            cekClose()

        End If
    End Sub

    Private Sub txtjumlahbayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtjumlahbayar.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txtjumlahbayar.Text.Replace(".", "")) < Val(lblsisahutang.Text.Replace(".", "")) Then
                MsgBox("Sisa utang  " & Val(lblsisahutang.Text.Replace(".", "")) - Val(txtjumlahbayar.Text.Replace(".", "")) & "")
                btnSimpan.Focus()
            ElseIf Val(txtjumlahbayar.Text.Replace(".", "")) = Val(lblsisahutang.Text.Replace(".", "")) Then
                MsgBox("Utang lunas")
                btnSimpan.Focus()
            ElseIf Val(txtjumlahbayar.Text.Replace(".", "")) > Val(lblsisahutang.Text.Replace(".", "")) Then
                MsgBox("Utang lunas, uang kembali " & Val(txtjumlahbayar.Text.Replace(".", "")) - Val(lblsisahutang.Text.Replace(".", "")) & "")
                btnSimpan.Focus()
            End If
        End If
    End Sub

    Sub Bersihkan()
        lbltglbeli.Text = ""
        lblkodesupplier.Text = ""
        lblnamasupplier.Text = ""
        lbltotalharga.Text = ""
        lblcarabeli.Text = ""
        lblsisahutang.Text = ""
        lbljatuhtempo.Text = ""
        txtdibayar.Clear()
        txttempo.Clear()
        txtjumlahbayar.Clear()
        DGV.Columns.Clear()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Bersihkan()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtjumlahbayar.Text = "" Then
            MsgBox("pembayaran belum lengkap")
            Exit Sub
        End If

        If cbAkun.Text = "" Then
            MsgBox("Nomor Akun Harus diisi!!")
            cbAkun.Focus()
            cbAkun.Select()
            Exit Sub
        End If

        Dim kodeakun As String = cbAkun.Text
        Dim strArr() As String
        strArr = kodeakun.Split(".")

        'Cek Saldo Kas yang diambil
        Dim saldoKas As Double = 0
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM arus_kas_saldo WHERE kodeacc = '" & strArr(0) & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            saldoKas = DR.Item("saldo_akhir")
        End If
        cekClose()

        If (saldoKas > 0) And (Double.Parse(Val(txtjumlahbayar.Text.Replace(".", ""))) <= saldoKas) Then

            Dim sisa_utang As Double = 0
            If Val(txtjumlahbayar.Text.Replace(".", "")) < Val(lblsisahutang.Text.Replace(".", "")) Then
                sisa_utang = Val(lblsisahutang.Text.Replace(".", "")) - Val(txtjumlahbayar.Text.Replace(".", ""))
                'Button1.Focus()
            ElseIf Val(txtjumlahbayar.Text.Replace(".", "")) >= Val(lblsisahutang.Text.Replace(".", "")) Then
                sisa_utang = 0
                'ElseIf Val(TextBox3.Text) > Val(Label16.Text) Then
                ' sisa_utang = 0
            End If

            cekOpen()
            Dim bayar As String = "insert into bayarutang values('" & lblnomor.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & LookUpEditFaktur.EditValue.ToString & "','" & Val(txtjumlahbayar.Text.Replace(".", "")) & "','" & sisa_utang & "','" & MainMenu.PanelUser.Text & "')"
            CMD = New MySqlCommand(bayar, Conn)
            CMD.ExecuteNonQuery()

            Dim jurnal1 As String = "insert into jurnal values('" & lblnomor.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & strArr(0) & "', '" & strArr(1) & "', 0, '" & Val(txtjumlahbayar.Text.Replace(".", "")) & "', 'BAYAR " & LookUpEditFaktur.EditValue.ToString & "', 1, 1)"
            CMD = New MySqlCommand(jurnal1, Conn)
            CMD.ExecuteNonQuery()

            Dim jurnal2 As String = "insert into jurnal values('" & lblnomor.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '2-1101','HUTANG USAHA', '" & Val(txtjumlahbayar.Text.Replace(".", "")) & "', 0, 'BAYAR " & LookUpEditFaktur.EditValue.ToString & "', 1, 2)"
            CMD = New MySqlCommand(jurnal2, Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & Val(txtjumlahbayar.Text.Replace(".", "")) & "' WHERE kodeacc = '" & strArr(0) & "' ", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strArr(0) & "', '" & strArr(1) & "', '" & lblnomor.Text & "', 0, '" & Val(txtjumlahbayar.Text.Replace(".", "")) & "') ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("select * from pembelian where faktur_beli='" & LookUpEditFaktur.EditValue.ToString & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then

                Dim sisahutang As Double = DR.Item("sisa_hutang")
                cekClose()

                cekOpen()
                If Val(txtjumlahbayar.Text.Replace(".", "")) >= Val(lblsisahutang.Text.Replace(".", "")) Then
                    Dim edit As String = "Update pembelian set status_beli='LUNAS' where faktur_beli='" & LookUpEditFaktur.EditValue.ToString & "'"
                    CMD = New MySqlCommand(edit, Conn)
                    CMD.ExecuteNonQuery()
                End If

                Dim edit1 As String = "Update pembelian set sisa_hutang='" & sisahutang - Val(txtjumlahbayar.Text.Replace(".", "")) & "' where faktur_beli='" & LookUpEditFaktur.EditValue.ToString & "'"
                CMD = New MySqlCommand(edit1, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

            End If

            Call InsertLogTrans(lblnomor.Text, "CREATE", MainMenu.PanelUser.Text, "BAYAR HUTANG - Total Rp. " & txtjumlahbayar.Text)

            Call NomorOtomatis()
            Call Bersihkan()
            Call TampilFakturUtang()
            Call InfoUtang()
            Call CheckHutang()
        Else
            MsgBox("Mohon Maaf Saldo " & strArr(1) & " -Kosong- Atau melebihi Saldo yang ada!", MsgBoxStyle.Critical, "Perhatian")
        End If
    End Sub

    Private Sub LookUpEditFaktur_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEditFaktur.EditValueChanged
        'On Error Resume Next
        cekOpen()
        CMD = New MySqlCommand("select * from pembelian where faktur_beli='" & LookUpEditFaktur.EditValue.ToString & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            lbltglbeli.Text = DR.Item("TGL_BELI")
            lblkodesupplier.Text = DR.Item("KODE_SUPPLIER")

            'Label4.Text = DR.Item("ITEM_BELI")
            txtdibayar.Enabled = False
            txttempo.Enabled = False
            lbltotalharga.Text = FormatNumber(DR.Item("TOTAL_BELI"), 0)
            txtdibayar.Text = FormatNumber(DR.Item("BAYAR_BELI"), 0)
            lblcarabeli.Text = DR.Item("CARA_BELI")
            lblsisahutang.Text = FormatNumber(DR.Item("SISA_HUTANG"), 0)
            txtjumlahbayar.Text = lblsisahutang.Text
            txttempo.Text = DR.Item("TEMPO_HARI")
            lblnamasupplier.Text = DR.Item("nama_supplier")
            If IsDBNull(DR.Item("keterangan")) Then
                txtKeterangan.Text = ""
            Else
                txtKeterangan.Text = DR.Item("keterangan")
            End If


            lbljatuhtempo.Text = DR.Item("JTH_TEMPO_BELI")
            cekClose()

            cekOpen()

            CMD = New MySqlCommand("select * from supplier_m where kode_supplier='" & lblkodesupplier.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                lblnamasupplier.Text = DR.Item("nama_supplier")
            End If
            cekClose()

            cekOpen()
            DA = New MySqlDataAdapter("Select detailbeli.kode_barang, barang_m.nama_barang, detailbeli.harga_beli, qty_beli ,subtotal_beli from detailbeli,barang_m where detailbeli.kode_barang=barang_m.kode_item and detailbeli.faktur_beli='" & LookUpEditFaktur.EditValue.ToString & "'", Conn)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
            DGV.ReadOnly = True

            DGV.Columns(2).DefaultCellStyle.Format = "c0"
            DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(3).DefaultCellStyle.Format = "n0"
            DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(4).DefaultCellStyle.Format = "c0"
            DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            cekClose()

        End If
    End Sub
End Class