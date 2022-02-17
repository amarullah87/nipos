Imports MySql.Data.MySqlClient

Public Class TransaksiTerimaPiutang
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select COUNT(nomor_terima) AS nomor_terima from terimapiutang where tanggal_terima  = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Dim inc As Integer = DR.Item("nomor_terima") + 1
            lnlnomorterima.Text = "TP" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", inc)
        Else
            Dim inc As Integer = 1
            lnlnomorterima.Text = "TP" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()

        Call GetAkun()
    End Sub

    Sub NomorOtomatisX()
        cekOpen()

        CMD = New MySqlCommand("select * from terimapiutang where Nomor_Terima in(select max(Nomor_Terima) from terimapiutang)", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            lnlnomorterima.Text = "TP" + Format(Now, "yyMMdd") + "01"
        Else
            If Microsoft.VisualBasic.Mid(DR.Item("Nomor_Terima"), 3, 6) <> Format(Now, "yyMMdd") Then
                lnlnomorterima.Text = "TP" + Format(Now, "yyMMdd") + "01"
            Else
                lnlnomorterima.Text = Microsoft.VisualBasic.Right(DR.Item("Nomor_Terima"), 8) + 1
                lnlnomorterima.Text = "TP" + lnlnomorterima.Text
            End If
        End If

        cekClose()

        GetAkun()
    End Sub

    Sub GetAkun()
        'cekOpen()
        'CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc IS NOT NULL ", Conn)
        'DR = CMD.ExecuteReader

        'Do While DR.Read
        '    cbAkun.Items.Add(DR.Item("kodeacc") + "." + DR.Item("namaacc"))
        'Loop
        'cekClose()

        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT kodeacc, namaacc FROM perkiraan WHERE parentacc = '1-1100'", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "namaacc"
        lookUpEdit.Properties.ValueMember = "kodeacc"
        cekClose()
    End Sub

    Sub TampilFakturPiutang()
        cekClose()

        'cekOpen()
        'CMD = New MySqlCommand("select * from penjualan where Status_Jual='BELUM LUNAS' AND faktur_jual NOT LIKE 'BTL%' ", Conn)
        'DR = CMD.ExecuteReader
        'ListBox1.Items.Clear()
        'Do While DR.Read
        '    ListBox1.Items.Add(DR.Item("Faktur_Jual"))
        'Loop
        'cekClose()

        LookUpEditFaktur.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT faktur_jual, tgl_jual, total_jual, kode_customer, jenis_member FROM penjualan WHERE Status_Jual='BELUM LUNAS' AND faktur_jual NOT LIKE 'BTL%'", Conn)
        DS = New DataSet
        DA.Fill(DS)
        LookUpEditFaktur.Properties.DataSource = DS.Tables(0)
        LookUpEditFaktur.Properties.DisplayMember = "faktur_jual"
        LookUpEditFaktur.Properties.ValueMember = "faktur_jual"
        cekClose()
    End Sub

    Private Sub TransaksiTerimaPiutang_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilFakturPiutang()
        Call NomorOtomatis()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("select * from penjualan where Faktur_Jual='" & ListBox1.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            lbltanggaljual.Text = DR.Item("TGL_Jual")
            lblkodecustomer.Text = DR.Item("KODE_Customer")

            'Label4.Text = DR.Item("ITEM_Jual")
            txtdibayar.Enabled = False
            txttempohari.Enabled = False
            lbltotalharga.Text = FormatNumber(DR.Item("TOTAL_Jual"), 0)
            txtdibayar.Text = FormatNumber(DR.Item("BAYAR_Jual"), 0)
            lblcarajual.Text = DR.Item("CARA_Jual")
            lblsisapiutang.Text = FormatNumber(DR.Item("SISA_Piutang"), 0)
            txtjumlahterima.Text = lblsisapiutang.Text
            txttempohari.Text = DR.Item("jTH_TEMPO_JUAL")
            If IsDBNull(DR.Item("keterangan")) Then
                txtKeterangan.Text = ""
            Else
                txtKeterangan.Text = DR.Item("keterangan")
            End If

            lbljatuhtempo.Text = DR.Item("JTH_TEMPO_Jual")
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("select * from member_m where kode_member='" & lblkodecustomer.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                lblnamacustomer.Text = DR.Item("nama_customer")
            End If
            cekClose()

            cekOpen()
            DA = New MySqlDataAdapter("Select detailjual.kode_barang,barang_m.nama_barang,detailjual.harga_jual,qty_jual,subtotal_jual from detailjual,barang_m where detailjual.kode_barang=barang_m.kode_item and detailjual.faktur_jual='" & ListBox1.Text & "'", Conn)
            'DA = New MySqlDataAdapter("Select * FROM TBLDETAILJUAL WHERE Faktur_Jual='" & ListBox1.Text & "'", Conn)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
            'DGV.Columns(1).Width = 200
            DGV.ReadOnly = True
            cekClose()

            DGV.Columns(0).HeaderText = "Kode Item"
            DGV.Columns(1).HeaderText = "Nama Barang"
            DGV.Columns(2).HeaderText = "Harga Jual"
            DGV.Columns(2).DefaultCellStyle.Format = "c0"
            DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(3).HeaderText = "Qty"
            DGV.Columns(3).DefaultCellStyle.Format = "n0"
            DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(4).HeaderText = "Subtotal"
            DGV.Columns(4).DefaultCellStyle.Format = "c0"
            DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(4).Width = 200

            DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End If
    End Sub

    Private Sub txtjumlahterima_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtjumlahterima.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txtjumlahterima.Text.Replace(".", "")) < Val(lblsisapiutang.Text.Replace(".", "")) Then
                MsgBox("Sisa piutang  " & Val(lblsisapiutang.Text.Replace(".", "")) - Val(txtjumlahterima.Text.Replace(".", "")) & "")
                btnSimpan.Focus()
            ElseIf Val(txtjumlahterima.Text.Replace(".", "")) = Val(lblsisapiutang.Text.Replace(".", "")) Then
                MsgBox("Utang lunas")
                btnSimpan.Focus()
            ElseIf Val(txtjumlahterima.Text.Replace(".", "")) > Val(lblsisapiutang.Text.Replace(".", "")) Then
                MsgBox("Utang lunas, uang kembali " & Val(txtjumlahterima.Text.Replace(".", "")) - Val(lblsisapiutang.Text.Replace(".", "")) & "")
                btnSimpan.Focus()
            End If
        End If
    End Sub

    Sub Bersihkan()
        lbltanggaljual.Text = ""
        lblkodecustomer.Text = ""
        lblnamacustomer.Text = ""
        lbltotalharga.Text = ""
        lblcarajual.Text = ""
        lblsisapiutang.Text = ""
        lbljatuhtempo.Text = ""
        txtdibayar.Clear()
        txttempohari.Clear()
        txtjumlahterima.Clear()
        DGV.Columns.Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtjumlahterima.Text = "" Then
            MsgBox("pembayaran belum lengkap")
            Exit Sub
        End If

        If lookUpEdit.Text.ToString = "" Then
            MsgBox("Nomor Akun Harus diisi!!")
            lookUpEdit.Focus()
            lookUpEdit.Select()
            Exit Sub
        End If

        Dim sisa_utang As Double = 0
        If Val(txtjumlahterima.Text.Replace(".", "")) < Val(lblsisapiutang.Text.Replace(".", "")) Then
            sisa_utang = Val(lblsisapiutang.Text.Replace(".", "")) - Val(txtjumlahterima.Text.Replace(".", ""))
            'Button1.Focus()
        ElseIf Val(txtjumlahterima.Text.Replace(".", "")) >= Val(lblsisapiutang.Text.Replace(".", "")) Then
            sisa_utang = 0
            'ElseIf Val(TextBox3.Text) > Val(Label16.Text) Then
            '    sisa_utang = 0
        End If

        cekOpen()
        Dim bayar As String = "insert into terimapiutang values('" & lnlnomorterima.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & LookUpEditFaktur.EditValue.ToString & "','" & Val(txtjumlahterima.Text.Replace(".", "")) & "','" & sisa_utang & "','" & MainMenu.PanelUser.Text & "')"
        CMD = New MySqlCommand(bayar, Conn)
        CMD.ExecuteNonQuery()

        Dim jurnal1 As String = "insert into jurnal values('" & lnlnomorterima.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & lookUpEdit.EditValue.ToString & "', '" & lookUpEdit.Text.ToString & "', '" & Val(txtjumlahterima.Text.Replace(".", "")) & "', 0, 'BAYAR " & LookUpEditFaktur.EditValue.ToString & "', 2, 1)"
        CMD = New MySqlCommand(jurnal1, Conn)
        CMD.ExecuteNonQuery()

        Dim jurnal2 As String = "insert into jurnal values('" & lnlnomorterima.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '1-1210','PIUTANG USAHA', 0, '" & Val(txtjumlahterima.Text.Replace(".", "")) & "', 'BAYAR " & LookUpEditFaktur.EditValue.ToString & "', 2, 2)"
        CMD = New MySqlCommand(jurnal2, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & Val(txtjumlahterima.Text.Replace(".", "")) & "' WHERE kodeacc = '" & lookUpEdit.EditValue.ToString & "' ", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & lookUpEdit.EditValue.ToString & "', '" & lookUpEdit.Text.ToString & "', '" & lnlnomorterima.Text & "', 1, '" & Val(txtjumlahterima.Text.Replace(".", "")) & "') ", Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("select * from penjualan where faktur_jual='" & LookUpEditFaktur.EditValue.ToString & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then

            Dim sisapiutang As Double = DR.Item("sisa_piutang")
            cekClose()

            cekOpen()
            If Val(txtjumlahterima.Text.Replace(".", "")) >= Val(lblsisapiutang.Text.Replace(".", "")) Then
                Dim edit As String = "Update penjualan set status_jual='LUNAS' where faktur_jual='" & LookUpEditFaktur.EditValue.ToString & "'"
                CMD = New MySqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
            End If

            Dim edit1 As String = "Update penjualan set sisa_piutang='" & sisapiutang - Val(txtjumlahterima.Text.Replace(".", "")) & "' where faktur_jual='" & LookUpEditFaktur.EditValue.ToString & "'"
            CMD = New MySqlCommand(edit1, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

        End If
        cekClose()

        Call InsertLogTrans(lnlnomorterima.Text, "CREATE", MainMenu.PanelUser.Text, "PENJUALAN - BAYAR PIUTANG Total Rp. " & txtjumlahterima.Text)

        Call NomorOtomatis()
        Call Bersihkan()
        Call TampilFakturPiutang()
        'Call InfoPiutang()

        MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "Sukses")
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Bersihkan()
    End Sub

    Private Sub dtptanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtptanggal.ValueChanged
        Call NomorOtomatis()
    End Sub

    Private Sub LookUpEditFaktur_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEditFaktur.EditValueChanged
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("select * from penjualan where Faktur_Jual='" & LookUpEditFaktur.EditValue.ToString & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            lbltanggaljual.Text = DR.Item("TGL_Jual")
            lblkodecustomer.Text = DR.Item("KODE_Customer")

            'Label4.Text = DR.Item("ITEM_Jual")
            txtdibayar.Enabled = False
            txttempohari.Enabled = False
            lbltotalharga.Text = FormatNumber(DR.Item("TOTAL_Jual"), 0)
            txtdibayar.Text = FormatNumber(DR.Item("BAYAR_Jual"), 0)
            lblcarajual.Text = DR.Item("CARA_Jual")
            lblsisapiutang.Text = FormatNumber(DR.Item("SISA_Piutang"), 0)
            txtjumlahterima.Text = lblsisapiutang.Text
            txttempohari.Text = DR.Item("jTH_TEMPO_JUAL")
            If IsDBNull(DR.Item("keterangan")) Then
                txtKeterangan.Text = ""
            Else
                txtKeterangan.Text = DR.Item("keterangan")
            End If

            lbljatuhtempo.Text = DR.Item("JTH_TEMPO_Jual")
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("select * from member_m where kode_member='" & lblkodecustomer.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                lblnamacustomer.Text = DR.Item("nama_customer")
            End If
            cekClose()

            cekOpen()
            DA = New MySqlDataAdapter("Select detailjual.kode_barang,barang_m.nama_barang,detailjual.harga_jual,qty_jual,subtotal_jual from detailjual,barang_m where detailjual.kode_barang=barang_m.kode_item and detailjual.faktur_jual='" & LookUpEditFaktur.EditValue.ToString & "'", Conn)
            'DA = New MySqlDataAdapter("Select * FROM TBLDETAILJUAL WHERE Faktur_Jual='" & ListBox1.Text & "'", Conn)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
            'DGV.Columns(1).Width = 200
            DGV.ReadOnly = True
            cekClose()

            DGV.Columns(0).HeaderText = "Kode Item"
            DGV.Columns(1).HeaderText = "Nama Barang"
            DGV.Columns(2).HeaderText = "Harga Jual"
            DGV.Columns(2).DefaultCellStyle.Format = "c0"
            DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(3).HeaderText = "Qty"
            DGV.Columns(3).DefaultCellStyle.Format = "n0"
            DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(4).HeaderText = "Subtotal"
            DGV.Columns(4).DefaultCellStyle.Format = "c0"
            DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(4).Width = 200

            DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End If
    End Sub
End Class