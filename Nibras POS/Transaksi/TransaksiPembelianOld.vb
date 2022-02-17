Imports DevExpress.XtraEditors.Controls
Imports MySql.Data.MySqlClient

Public Class TransaksiPembelianOld

    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select max(faktur_beli) AS faktur_beli from pembelian where faktur_beli LIKE 'FB" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("faktur_beli")) Then
            txtnofaktur.Text = "FB" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("faktur_beli")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtnofaktur.Text = "FB" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()

        cbosupplier.Focus()
        cbosupplier.Select()
    End Sub

    Sub LoadItemDb()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select kode, nama, nama_toko, domisili from mst_distributor", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama"
        lookUpEdit.Properties.ValueMember = "kode"
        cekClose()
    End Sub

    Sub LoadItemNhs()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select id as kode, nama, nama as nama_toko, alamat as domisili from master_nhs", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama"
        lookUpEdit.Properties.ValueMember = "kode"
        cekClose()
    End Sub

    Sub CallAkun()
        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE parentacc = '1-1100' ORDER BY kodeacc ASC", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
        Loop
        cekClose()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim diskon As Double = DGV.Rows(e.RowIndex).Cells(4).Value / 100
        Dim diskonRupiah As Double = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) * diskon

        If e.ColumnIndex = 0 Then

            'cegah kode barang ganda
            For barisatas As Integer = 0 To DGV.RowCount - 1
                For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                    If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                        Dim diskonEdit As Double = DGV.Rows(barisatas).Cells(4).Value / 100
                        Dim qtyEdit As Double = DGV.Rows(barisatas).Cells(3).Value + 1
                        Dim diskonRupiahEdit As Double = (DGV.Rows(barisatas).Cells(2).Value * qtyEdit) * diskonEdit

                        DGV.Rows(barisatas).Cells(3).Value = qtyEdit
                        DGV.Rows(barisatas).Cells(5).Value = (DGV.Rows(barisatas).Cells(2).Value * qtyEdit) - diskonRupiahEdit
                        DGV.Rows.RemoveAt(barisbawah)
                        SendKeys.Send("{down}")
                        Call Hitungtransaksi()
                        Exit Sub
                    End If
                Next
            Next

            cekOpen()
            CMD = New MySqlCommand("select * from barang_m where kode_item='" & DGV.Rows(e.RowIndex).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                DGV.Rows(e.RowIndex).Cells(1).Value = DR.Item("nama_barang")
                DGV.Rows(e.RowIndex).Cells(2).Value = DR.Item("hpj")
                DGV.Rows(e.RowIndex).Cells(4).Value = 35
                DGV.Focus()
                DGV.CurrentCell = DGV(2, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{up}")
            Else
                MsgBox("Kode barang tidak terdaftar")
                SendKeys.Send("{up}")
                DownloadBarang.Show()
            End If
            cekClose()
        End If

        If e.ColumnIndex = 2 Then
            Try
                DGV.Rows(e.RowIndex).Cells(2).Value = DGV.Rows(e.RowIndex).Cells(2).Value
                DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiah
                DGV.CurrentCell = DGV(2, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{up}")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If e.ColumnIndex = 3 Then
            Try
                DGV.Rows(e.RowIndex).Cells(3).Value = DGV.Rows(e.RowIndex).Cells(3).Value
                DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiah
                DGV.CurrentCell = DGV(3, DGV.CurrentCell.RowIndex)
                Call Hitungtransaksi()
            Catch ex As Exception
                MsgBox("harus data angka")
                DGV.Rows(e.RowIndex).Cells(3).Value = 0
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(5).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
                Call Hitungtransaksi()
            End Try
        End If

        If e.ColumnIndex = 4 Then
            Try
                DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiah
                DGV.CurrentCell = DGV(4, DGV.CurrentCell.RowIndex)
                Call Hitungtransaksi()
            Catch ex As Exception
                MsgBox("harus data angka")
                DGV.Rows(e.RowIndex).Cells(4).Value = 0
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(5).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
                Call Hitungtransaksi()
            End Try
        End If

        If e.ColumnIndex = 5 Then
            Dim minDisc As Integer
            Dim maxDisc As Integer

            Select Case MainMenu.PanelJenis.Text
                Case "D"
                    minDisc = 40
                    maxDisc = 43
                Case "M"
                    minDisc = 35
                    maxDisc = 35
                Case Else
                    minDisc = 10
                    maxDisc = 10
            End Select

            Try
                'If DGV.Rows(e.RowIndex).Cells(4).Value >= minDisc And DGV.Rows(e.RowIndex).Cells(4).Value <= maxDisc Then
                '    DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiah
                '    DGV.CurrentCell = DGV(4, DGV.CurrentCell.RowIndex)
                '    Call Hitungtransaksi()
                'Else
                '    MsgBox("Diskon Melebihi Ketentuan!! (" & minDisc & " - " & maxDisc & "%)")
                '    DGV.Rows(e.RowIndex).Cells(4).Value = minDisc
                '    Dim diskonX As Double = minDisc / 100
                '    Dim diskonRupiahX As Double = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) * diskonX

                '    DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiahX
                '    DGV.CurrentCell = DGV(4, DGV.CurrentCell.RowIndex)
                '    Call Hitungtransaksi()
                'End If
                DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiah
                DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
                Call Hitungtransaksi()
            Catch ex As Exception
                MsgBox("harus data angka")
                DGV.Rows(e.RowIndex).Cells(5).Value = 35
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(5).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
                Call Hitungtransaksi()
            End Try
        End If
    End Sub

    Private Sub TransaksiPembelian_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        txtnofaktur.Focus()
        txtnofaktur.Select()
        Call NomorOtomatis()
        Call CallAkun()
        Call LoadItemDb()
        SetDoubleBuffered(DGV, True)
    End Sub

    Sub Hitungtransaksi()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(3).Value
            lbljumlahbarang.Text = x
        Next

        Dim y As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            y = y + DGV.Rows(baris).Cells(5).Value
            lbltotalharga.Text = FormatNumber(y, 0)
            lbltotalhargahide.Text = y
            txtKredit.Text = FormatNumber(y, 0)
            lblKredit.Text = y
        Next

        Call HitungNilaiTransaksi()
        Call HitungTransaksiAll()
    End Sub

    Dim totalAkhir As Double
    Sub HitungTransaksiAll()
        Dim biayaLain As String = lblBiayaLain.Text
        Dim deposit As String = txtDeposit.Text
        Dim tunai As String = lblTunai.Text
        Dim kredit As String = lblKredit.Text

        totalAkhir = (Double.Parse(lbltotalhargahide.Text) + Double.Parse(biayaLain)) - Double.Parse(deposit) - Double.Parse(tunai)

        If totalAkhir >= 0 Then
            txtKredit.Text = FormatNumber(totalAkhir, 0)
            lblKredit.Text = totalAkhir
        Else
            txtKredit.Text = 0
            lblKredit.Text = 0
        End If
    End Sub

    Sub HitungNilaiTransaksi()
        If Val(txtdibayar.Text) >= Val(lbltotalhargahide.Text) Then
            lblcarabeli.Text = "TUNAI"
            lblsisahutang.Text = 0
            'txttempo.Text = 0
            'txttempo.Enabled = False
            'lbljatuhtempo.Text = Format(dtptanggal.value, "yyyy-MM-dd")
            lblstatusbeli.Text = "LUNAS"
            'btnSimpan.Focus()
        Else
            lblcarabeli.Text = "KREDIT"
            lblsisahutang.Text = FormatNumber(Val(lbltotalhargahide.Text) - Val(txtdibayar.Text), 0)
            lblsisahutanghide.Text = Val(lbltotalhargahide.Text) - Val(txtdibayar.Text)
            lblstatusbeli.Text = "BELUM LUNAS"
            'txttempo.Enabled = True
            'txttempo.Focus()
        End If

        Call HitungJatuhTempo()
    End Sub

    Sub HitungJatuhTempo()
        Dim tambahhari As Integer = txttempo.Text
        lbljatuhtempo.Text = DateAdd(DateInterval.Day, tambahhari, Today)
    End Sub

    Private Sub txtdibayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdibayar.KeyPress
        If e.KeyChar = Chr(13) Then
            Call HitungNilaiTransaksi()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txttempo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttempo.KeyPress
        If e.KeyChar = Chr(13) Then
            Call HitungJatuhTempo()
            btnSimpan.Focus()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub DGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGV.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then
            DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
            Call Hitungtransaksi()
        End If

        If e.KeyChar = Chr(13) Then
            txtdibayar.Focus()
        End If
    End Sub

    Sub Kosongkan()
        txtJenisNhs.Text = ""
        cbosupplier.Text = ""
        lbljumlahbarang.Text = ""
        lbltotalharga.Text = ""
        lbltotalhargahide.Text = ""
        lblcarabeli.Text = ""
        lblsisahutang.Text = ""
        lbljatuhtempo.Text = ""
        lblstatusbeli.Text = ""
        lblkodesupplier.Text = ""
        txtdibayar.Text = 0
        txttempo.Text = 7
        txtNoPesanan.Text = ""
        txtDeposit.Text = 0
        txtTunai.Text = 0
        txtKredit.Text = 0
        txtBiayaLain.Text = 0
        DGV.Rows.Clear()

        Call NomorOtomatis()
        Call LoadItemDb()
        cbFromNHS.Checked = False
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
        DGV.Rows.Clear()
        DGV.Enabled = False
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtnofaktur.Text = "" Or lookUpEdit.Text.ToString = "" Or txtdibayar.Text = "" Or txttempo.Text = "" Or lbljumlahbarang.Text = "" Or lbltotalhargahide.Text = "" Then
            MsgBox("Transaksi belum lengkap", MsgBoxStyle.Critical, "Perhatian")
        ElseIf totalAkhir < 0 Then
            MsgBox("Total Nilai yang di input Melebihi Total Akhir", MsgBoxStyle.Information, "Informasi")
        Else
            'SplashScreenManager1.ShowWaitForm()
            '## Call dulu penomoran biar tidak terjadi Double ##'
            Call NomorOtomatis()

            Dim tDeposit As Double = Double.Parse(txtDeposit.Text)
            Dim lDeposit As Double = Double.Parse(lblDeposit.Text)

            If tDeposit > 0 Then

                If tDeposit > lDeposit Then
                    MsgBox("Nilai Deposit Melebihi " & FormatCurrency(lDeposit, 0) & " !! Silahkan Perbaiki Transaksi.", MsgBoxStyle.Critical)
                Else
                    SaveTransaksi()
                End If
            Else
                SaveTransaksi()
            End If
            'SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        'On ENTER
        If e.KeyChar = ChrW(Keys.Return) Then

            Dim namabarang As String
            If txtBarcode.Text.Contains("'") Then
                namabarang = txtBarcode.Text.Replace("'", "''")
            Else
                namabarang = txtBarcode.Text
            End If

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & namabarang & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()


            If (DR.HasRows) Then

                Dim minDisc As Integer
                Dim maxDisc As Integer

                Select Case MainMenu.PanelJenis.Text
                    Case "D"
                        minDisc = 40
                        maxDisc = 43
                    Case "M"
                        minDisc = 35
                        maxDisc = 35
                    Case "N"
                        minDisc = 35
                        maxDisc = 35
                    Case "K"
                        minDisc = 35
                        maxDisc = 35
                    Case "AB"
                        minDisc = 35
                        maxDisc = 35
                    Case "A"
                        minDisc = 30
                        maxDisc = 30
                    Case "R"
                        minDisc = 20
                        maxDisc = 20
                    Case Else
                        minDisc = 10
                        maxDisc = 10
                End Select

                Dim baris As Integer = DGV.RowCount - 1
                DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("hpj"), 1, minDisc)
                txtBarcode.Clear()
                cekClose()

                Dim diskon As Double = DGV.Rows(baris).Cells(4).Value / 100
                Dim diskonRupiah As Double = (DGV.Rows(baris).Cells(2).Value * DGV.Rows(baris).Cells(3).Value) * diskon
                DGV.Rows(baris).Cells(5).Value = (DGV.Rows(baris).Cells(2).Value * DGV.Rows(baris).Cells(3).Value) - diskonRupiah

                Call Hitungtransaksi()
                For barisatas As Integer = 0 To DGV.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                        If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                            Dim diskonEdit As Double = DGV.Rows(barisatas).Cells(4).Value / 100
                            Dim qtyEdit As Double = DGV.Rows(barisatas).Cells(3).Value + 1
                            Dim diskonRupiahEdit As Double = (DGV.Rows(barisatas).Cells(2).Value * qtyEdit) * diskonEdit

                            DGV.Rows(barisatas).Cells(3).Value = DGV.Rows(barisatas).Cells(3).Value + 1
                            DGV.Rows(barisatas).Cells(5).Value = (DGV.Rows(barisatas).Cells(2).Value * qtyEdit) - diskonRupiahEdit
                            DGV.Rows.RemoveAt(barisbawah)
                            Call Hitungtransaksi()
                            Exit Sub
                        End If
                    Next
                Next
            Else
                cekClose()
                PencarianBarangBeliOff.ShowDialog()
                PencarianBarangBeliOff.TXTCariBarang.Text = txtBarcode.Text
            End If
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                DownloadBarang.Show()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub cbosupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles cbosupplier.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If cbosupplier.Text = "" Then
                    DGV.Enabled = False
                Else
                    DGV.Enabled = True
                End If

                cekOpen()

                Dim query As String
                If cbFromNHS.Checked = True Then
                    query = "select * from master_nhs where id ='" & cbosupplier.Text & "'"
                    CMD = New MySqlCommand(query, Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    If DR.HasRows Then
                        cbosupplier.Text = DR.Item("id")
                        lblkodesupplier.Text = DR.Item("nama")
                        txtJenisNhs.Text = DR.Item("jenis_nhs")
                        txtDeposit.Text = 0
                        lblDeposit.Text = 0

                        txtNoPesanan.Focus()
                        txtNoPesanan.Select()

                        cekClose()
                    Else
                        cekClose()
                        cbosupplier.Focus()
                        cbosupplier.Select()
                        PencarianSupplier.ShowDialog()
                        PencarianSupplier.TXTCariBarang.Text = cbosupplier.Text
                    End If
                Else
                    query = "select * from mst_distributor where kode ='" & cbosupplier.Text & "'"
                    CMD = New MySqlCommand(query, Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    If DR.HasRows Then
                        cbosupplier.Text = DR.Item("kode")
                        lblkodesupplier.Text = DR.Item("nama")
                        txtJenisNhs.Text = DR.Item("jenis_nhs")
                        txtDeposit.Text = DR.Item("deposit")
                        lblDeposit.Text = DR.Item("deposit")

                        txtNoPesanan.Focus()
                        txtNoPesanan.Select()

                        cekClose()
                    Else
                        cekClose()
                        cbosupplier.Focus()
                        cbosupplier.Select()
                        PencarianSupplier.ShowDialog()
                        PencarianSupplier.TXTCariBarang.Text = cbosupplier.Text
                    End If
                End If
                cekClose()

                'Case Keys.F12
                '    DownloadOutlet.Show()
        End Select
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'If lookUpEdit.Text.ToString = "" Then
        '    MsgBox("Silahkan Isi Supplier!")
        '    lookUpEdit.Focus()
        '    lookUpEdit.Select()
        'Else

        '    'Select Case MainMenu.PanelJenis.Text

        '    '    Case "D"
        '    '        PesananKarung.Show()
        '    '        'Case "N"
        '    '        'Case "M"
        '    '        'Case "AB"
        '    '        'Case "A"
        '    '        'PesananNonDB.Show()
        '    '    Case Else
        '    '        DaftarPesanan.Show()
        '    'End Select

        '    PesananKarung.Show()
        '    PesananKarung.lblKodeSupp.Text = lookUpEdit.EditValue.ToString
        '    PesananKarung.lblNamaSupp.Text = lookUpEdit.Text.ToString

        'End If
        MsgBox("Fitur ini hanya ada pada menu [Pembelian Terintegrasi] yaaa....", MsgBoxStyle.Information, "NiPOS")
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If lookUpEdit.Text.ToString = "" Then
            MsgBox("Supplier belum di pilih!", MsgBoxStyle.Information)
        Else
            DPembelianDeposit.ShowDialog()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        DPembelianTunai.ShowDialog()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        DPembelianKredit.ShowDialog()
    End Sub

    Private Sub SaveTransaksi()
        Dim biayaLain As String = lblBiayaLain.Text
        Dim deposit As String = txtDeposit.Text
        Dim tunai As String = lblTunai.Text
        Dim kredit As String = lblKredit.Text

        Dim kodeakun As String = lblKodeTunai.Text
        Dim strArr() As String = kodeakun.Split("/")
        Dim kodeAkunKredit As String = lblKodeKredit.Text
        Dim strArrK() As String = kodeAkunKredit.Split("/")
        Dim kodeAkunDeposit As String = lblKodeDeposit.Text
        Dim strArrD() As String = kodeAkunDeposit.Split("/")

        cekOpen()
        CMD = New MySqlCommand("select * from pembelian where faktur_beli='" & txtnofaktur.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        cekClose()
        If DR.HasRows Then
            MsgBox("nomor transkasi sudah terdaftar")
            Exit Sub
        End If

        Dim simpan1 As String
        cekOpen()
        If kredit = 0 Then
            simpan1 = "insert into pembelian (`faktur_beli`,`tgl_beli`,`item_beli`,`biaya_lain`,`total_beli`,`bayar_beli`,`cara_beli`,`sisa_hutang`,`tempo_hari`,`jth_tempo_beli`,`status_beli`, `kode_supplier`,`kode_user`,`no_pesanan`,`nama_supplier`,`deposit`,`tunai`,`kredit`,`keterangan`) values ('" &
                txtnofaktur.Text & "','" &
                Format(dtptanggal.Value, "yyyy-MM-dd") & "','" &
                lbljumlahbarang.Text & "', '" &
                biayaLain & "', '" &
                lbltotalhargahide.Text & "','" &
                Double.Parse(lblTunai.Text) + Double.Parse(lblDeposit.Text) & "','TUNAI','" &
                lblKredit.Text & "','" &
                txttempo.Text & "','" &
                Format(dtptanggal.Value, "yyyy-MM-dd") & "','LUNAS','" &
                lookUpEdit.EditValue.ToString & "','" &
                MainMenu.PanelUser.Text & "', '" &
                txtNoPesanan.Text & "', '" &
                lookUpEdit.Text.ToString & "', " &
                deposit & ", " &
                tunai & ", " &
                kredit & ", '" & txtKeterangan.Text & "' )"
        Else
            simpan1 = "insert into pembelian (`faktur_beli`,`tgl_beli`,`item_beli`,`biaya_lain`,`total_beli`,`bayar_beli`,`cara_beli`,`sisa_hutang`,`tempo_hari`,`jth_tempo_beli`,`status_beli`, `kode_supplier`,`kode_user`,`no_pesanan`,`nama_supplier`,`deposit`,`tunai`,`kredit`,`keterangan`) values ('" &
                txtnofaktur.Text & "','" &
                Format(dtptanggal.Value, "yyyy-MM-dd") & "','" &
                lbljumlahbarang.Text & "', '" &
                biayaLain & "', '" &
                lbltotalhargahide.Text & "','" &
                Double.Parse(lblTunai.Text) + Double.Parse(lblDeposit.Text) & "','KREDIT','" &
                lblKredit.Text & "','" &
                txttempo.Text & "','" &
                Format(DateValue(lbljatuhtempo.Text), "yyyy-MM-dd") & "','BELUM LUNAS','" &
                lookUpEdit.EditValue.ToString & "','" &
                MainMenu.PanelUser.Text & "', '" &
                txtNoPesanan.Text & "', '" &
                lookUpEdit.Text.ToString & "', " &
                deposit & ", " &
                tunai & ", " &
                kredit & ", '" & txtKeterangan.Text & "' )"
        End If

        CMD = New MySqlCommand(simpan1, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        cekOpen()
        'Jika Pembayaran TUNAI
        If kredit = 0 Then
            Dim simpanjurnal1 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510', 'PERSEDIAAN BARANG', '" & lbltotalhargahide.Text & "',0, '" & txtNoPesanan.Text & "', 1, 1)"
            CMD = New MySqlCommand(simpanjurnal1, Conn)
            CMD.ExecuteNonQuery()

            'Jika Ada Deposit
            If deposit <> 0 Then
                '#Kode Akun Deposit
                Dim simpanjurnalDepo As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & strArrD(0) & "', '" & strArrD(1) & "', 0, '" & deposit & "', '" & txtNoPesanan.Text & "', 1, 3)"
                CMD = New MySqlCommand(simpanjurnalDepo, Conn)
                CMD.ExecuteNonQuery()

                '#Update Deposit
                CMD = New MySqlCommand("UPDATE mst_distributor SET deposit = deposit - '" & deposit & "' WHERE kode = '" & lookUpEdit.EditValue.ToString & "' ", Conn)
                CMD.ExecuteNonQuery()

                'Jika Campur antara Deposit dan Cash
                If tunai <> 0 Then
                    '#Kode Akun Tunai
                    Dim simpanjurnal2 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & strArr(0) & "', '" & strArr(1) & "', 0, '" & tunai & "', '" & txtNoPesanan.Text & "', 1, 2)"
                    CMD = New MySqlCommand(simpanjurnal2, Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & lbltotalhargahide.Text & "' WHERE kodeacc = '" & strArr(0) & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strArr(0) & "', '" & strArr(1) & "', '" & txtnofaktur.Text & "', 0, '" & lbltotalhargahide.Text & "') ", Conn)
                    CMD.ExecuteNonQuery()
                End If

            Else
                '#Kode Akun Tunai
                Dim simpanjurnal2 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & strArr(0) & "', '" & strArr(1) & "', 0, '" & tunai & "', '" & txtNoPesanan.Text & "', 1, 2)"
                CMD = New MySqlCommand(simpanjurnal2, Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & lbltotalhargahide.Text & "' WHERE kodeacc = '" & strArr(0) & "' ", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strArr(0) & "', '" & strArr(1) & "', '" & txtnofaktur.Text & "', 0, '" & lbltotalhargahide.Text & "') ", Conn)
                CMD.ExecuteNonQuery()

            End If

            If biayaLain <> 0 Then
                Dim simpanjurnal22 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','6-1105','BIAYA PENGIRIMAN DARI SUPPLIER', '" & biayaLain & "', 0, '" & txtNoPesanan.Text & "', 1, 4)"
                CMD = New MySqlCommand(simpanjurnal22, Conn)
                CMD.ExecuteNonQuery()
            End If
            cekClose()
        Else
            'Jika Pembayaran KREDIT
            Dim simpanjurnal3 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG', '" & lbltotalhargahide.Text & "',0, '" & txtNoPesanan.Text & "', 1, 1)"
            CMD = New MySqlCommand(simpanjurnal3, Conn)
            CMD.ExecuteNonQuery()

            '#Kode Akun Hutang
            Dim simpanjurnal4 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & strArrK(0) & "', '" & strArrK(1) & "', 0, '" & kredit & "', '" & txtNoPesanan.Text & "', 1, 2)"
            CMD = New MySqlCommand(simpanjurnal4, Conn)
            CMD.ExecuteNonQuery()

            If txtTunai.Text <> 0 Then
                '#Kode Akun Tunai
                Dim simpanjurnal2 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & strArr(0) & "', '" & strArr(1) & "', 0, '" & tunai & "', '" & txtNoPesanan.Text & "', 1, 3)"
                CMD = New MySqlCommand(simpanjurnal2, Conn)
                CMD.ExecuteNonQuery()

                'Kredit ga ngurangin saldo kas
                'CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & txtdibayar.Text & "' WHERE kodeacc = '" & strArr(0) & "' ", Conn)
                'CMD.ExecuteNonQuery()

                'CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, jenis, nominal) VALUES ('" & strArr(0) & "', '" & strArr(1) & "', 0, '" & txtdibayar.Text & "') ", Conn)
                'CMD.ExecuteNonQuery()
            End If

            If txtDeposit.Text <> 0 Then
                '#Kode Akun Deposit
                Dim simpanjurnal2 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & strArrD(0) & "', '" & strArrD(1) & "', 0, '" & deposit & "', '" & txtNoPesanan.Text & "', 1, 4)"
                CMD = New MySqlCommand(simpanjurnal2, Conn)
                CMD.ExecuteNonQuery()

                '#Update Deposit
                CMD = New MySqlCommand("UPDATE mst_distributor SET deposit = deposit - '" & deposit & "' WHERE kode = '" & lookUpEdit.EditValue.ToString & "' ", Conn)
                CMD.ExecuteNonQuery()
            End If

            If biayaLain <> 0 Then
                Dim simpanjurnal22 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','6-1105','BIAYA PENGIRIMAN DARI SUPPLIER', '" & biayaLain & "', 0, '" & txtNoPesanan.Text & "', 1, 5)"
                CMD = New MySqlCommand(simpanjurnal22, Conn)
                CMD.ExecuteNonQuery()
            End If
            cekClose()


            'Dim simpanjurnal5 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "','200','   HUTANG PEMBELIAN KREDIT KE " & cbosupplier.Text & "',0, '" & lblsisahutang.Text & "')"
            'CMD = New MySqlCommand(simpanjurnal5, Conn)
            'CMD.ExecuteNonQuery()
            'cekClose()

        End If

        For baris As Integer = 0 To DGV.RowCount - 2

            cekOpen()
            Dim simpan2 As String = "insert into `detailbeli` (`faktur_beli`,`kode_barang`,`harga_beli`,`qty_beli`,`diskon`,`subtotal_beli`,`ket_beli`,`qty_retur`,`qty_real`,`subtotal_real`) values ('" &
                txtnofaktur.Text & "','" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(2).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "', '" & DGV.Rows(baris).Cells(5).Value & "', '-', 0, '" & DGV.Rows(baris).Cells(3).Value & "', '" & DGV.Rows(baris).Cells(5).Value & "')"
            CMD = New MySqlCommand(simpan2, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("select * from barang_m where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then

                Dim tambahstok As String = "update barang_m set stok= stok + '" & DGV.Rows(baris).Cells(3).Value & "' where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'"
                Dim stokAwal As Integer = DR.Item("stok")
                Dim stokAkhir As Integer = DGV.Rows(baris).Cells(3).Value + DR.Item("stok")
                cekClose()

                'Update Stok
                cekOpen()
                CMD = New MySqlCommand(tambahstok, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                cekOpen()
                Dim updatehistory As String = "INSERT INTO history_stok VALUES ( '" &
                        DGV.Rows(baris).Cells(0).Value & "', '" &
                        txtnofaktur.Text & "', '" &
                        Format(dtptanggal.Value, "yyyy-MM-dd") & "', 'Pembelian', '" &
                        stokAwal & "', '" &
                        DGV.Rows(baris).Cells(3).Value & "', '" &
                        stokAkhir & "', '" &
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" &
                        MainMenu.PanelUser.Text & "' )"
                CMD = New MySqlCommand(updatehistory, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                'Insert History HPP
                Dim diskonEdit As Double = DGV.Rows(baris).Cells(4).Value / 100
                Dim newHPP As Double = DGV.Rows(baris).Cells(2).Value - (DGV.Rows(baris).Cells(2).Value * diskonEdit)
                Dim subtotal As Double = DGV.Rows(baris).Cells(3).Value * newHPP

                If newHPP > 0 Then
                    Dim insertHPP As String = "INSERT INTO history_hpp (kode_item, hpp_awal, qty_awal, hpp_akhir, qty, subtotal, created_date) VALUES ('" &
                    DGV.Rows(baris).Cells(0).Value & "', '" &
                    DGV.Rows(baris).Cells(2).Value & "', '" &
                    stokAwal & "', '" &
                    newHPP & "', '" &
                    DGV.Rows(baris).Cells(3).Value & "', '" &
                    subtotal & "', '" &
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' )"

                    cekOpen()
                    CMD = New MySqlCommand(insertHPP, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    ''--------------------Disini settingan untuk perhitungan AVG HPP dan update HPPnya--------------------''
                    cekOpen()
                    Dim hppakhir As Double
                    CMD = New MySqlCommand("SELECT IFNULL(SUM(subtotal), 0) AS subtotal, IFNULL(SUM(qty), 0) AS qty FROM history_hpp WHERE kode_item = '" & DGV.Rows(baris).Cells(0).Value & "' ", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()

                    If DR.HasRows Then
                        hppakhir = Convert.ToDouble(DR.Item("subtotal")) / Convert.ToDouble(DR.Item("qty"))
                    Else
                        hppakhir = newHPP
                    End If
                    cekClose()

                    '## Update HPP Baru ##'
                    cekOpen()
                    CMD = New MySqlCommand("UPDATE barang_m SET hpp = '" & hppakhir & "' WHERE kode_item = '" & DGV.Rows(baris).Cells(0).Value & "' ", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()
                    ''--------------------######################################################################--------------------''
                End If
            End If
        Next

        '## Update Status Order ##'
        If txtNoPesanan.Text <> "" Then
            cekOpen()
            CMD = New MySqlCommand("UPDATE pembelian_order SET status = 0 WHERE faktur_beli = '" & txtNoPesanan.Text & "' ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        End If
        MsgBox("Data Berhasil Disimpan!")
        Call InsertLogTrans(txtnofaktur.Text, "CREATE", MainMenu.PanelUser.Text, "PEMBELIAN - Total Rp. " & lbltotalharga.Text)

        '### Upload Pembelian ##'
        Call uploadPembelian(txtnofaktur.Text)

        Call Kosongkan()
        txtnofaktur.Clear()
        DGV.Rows.Clear()
        Call CheckHutang()
        Call NomorOtomatis()
    End Sub

    Private Sub txtDeposit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDeposit.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtDeposit.Text.Length = 0 Then
                txtDeposit.Text = 0
            Else
                'txtDeposit.Text = FormatNumber(txtDeposit.Text, 0)
                'lblDeposit.Text = txtDeposit.Text.Replace(".", "")
            End If

            Call Hitungtransaksi()
        End If
    End Sub

    Private Sub txtTunai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTunai.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtTunai.Text.Length = 0 Then
                txtTunai.Text = 0
            Else
                'txtTunai.Text = FormatNumber(txtTunai.Text, 0)
                lblTunai.Text = txtTunai.Text.Replace(".", "")
            End If

            Call Hitungtransaksi()
        End If
    End Sub

    Private Sub txtBiayaLain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBiayaLain.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtBiayaLain.Text.Length = 0 Then
                txtBiayaLain.Text = 0
            Else
                'txtBiayaLain.Text = FormatNumber(txtBiayaLain.Text, 0)
                lblBiayaLain.Text = txtBiayaLain.Text.Replace(".", "")
            End If

            Call Hitungtransaksi()
        End If
    End Sub

    Private Sub txtDeposit_LostFocus(sender As Object, e As EventArgs) Handles txtDeposit.LostFocus
        If txtDeposit.Text.Length = 0 Then
            txtDeposit.Text = 0
        Else
            'txtDeposit.Text = FormatNumber(txtDeposit.Text, 0)
            'lblDeposit.Text = txtDeposit.Text.Replace(".", "")
        End If

        Call Hitungtransaksi()
    End Sub

    Private Sub txtTunai_LostFocus(sender As Object, e As EventArgs) Handles txtTunai.LostFocus
        If txtTunai.Text.Length = 0 Then
            txtTunai.Text = 0
        Else
            'txtTunai.Text = FormatNumber(txtTunai.Text, 0)
            lblTunai.Text = txtTunai.Text.Replace(".", "")
        End If

        Call Hitungtransaksi()
    End Sub

    Private Sub txtBiayaLain_LostFocus(sender As Object, e As EventArgs) Handles txtBiayaLain.LostFocus
        If txtBiayaLain.Text.Length = 0 Then
            txtBiayaLain.Text = 0
        Else
            'txtBiayaLain.Text = FormatNumber(txtBiayaLain.Text, 0)
            lblBiayaLain.Text = txtBiayaLain.Text.Replace(".", "")
        End If

        Call Hitungtransaksi()
    End Sub

    Private Sub txtDeposit_GotFocus(sender As Object, e As EventArgs) Handles txtDeposit.GotFocus
        'txtDeposit.Text = txtDeposit.Text.Replace(".", "")
    End Sub

    Private Sub txtTunai_GotFocus(sender As Object, e As EventArgs) Handles txtTunai.GotFocus
        'txtTunai.Text = txtTunai.Text.Replace(".", "")
    End Sub

    Private Sub txtBiayaLain_GotFocus(sender As Object, e As EventArgs) Handles txtBiayaLain.GotFocus
        'txtBiayaLain.Text = txtBiayaLain.Text.Replace(".", "")
    End Sub

    Private Sub cbFromNHS_CheckedChanged(sender As Object, e As EventArgs) Handles cbFromNHS.CheckedChanged
        If cbFromNHS.Checked Then
            Call LoadItemNhs()
        Else
            Call LoadItemDb()
        End If
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        ImportPembelian.ShowDialog()
    End Sub

    Private Sub lookUpEdit_Closed(sender As Object, e As ClosedEventArgs) Handles lookUpEdit.Closed
        If lookUpEdit.Text.ToString <> "" Then
            cekOpen()

            Dim query As String
            If cbFromNHS.Checked = True Then
                query = "select * from master_nhs where id ='" & lookUpEdit.EditValue.ToString & "'"
                CMD = New MySqlCommand(query, Conn)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    cbosupplier.Text = DR.Item("id")
                    lblkodesupplier.Text = DR.Item("nama")
                    txtJenisNhs.Text = DR.Item("jenis_nhs")
                    txtDeposit.Text = 0
                    lblDeposit.Text = 0

                    'txtNoPesanan.Focus()
                    'txtNoPesanan.Select()
                    txtKeterangan.Focus()
                    txtKeterangan.Select()

                    cekClose()
                Else
                    cekClose()
                    'cbosupplier.Focus()
                    'cbosupplier.Select()
                    'PencarianSupplier.ShowDialog()
                    'PencarianSupplier.TXTCariBarang.Text = cbosupplier.Text
                End If
            Else
                query = "select * from mst_distributor where kode ='" & lookUpEdit.EditValue.ToString & "'"
                CMD = New MySqlCommand(query, Conn)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    cbosupplier.Text = DR.Item("kode")
                    lblkodesupplier.Text = DR.Item("nama")
                    txtJenisNhs.Text = DR.Item("jenis_nhs")
                    txtDeposit.Text = DR.Item("deposit")
                    lblDeposit.Text = DR.Item("deposit")

                    txtKeterangan.Focus()
                    txtKeterangan.Select()

                    cekClose()
                Else
                    cekClose()
                    'cbosupplier.Focus()
                    'cbosupplier.Select()
                    'PencarianSupplier.ShowDialog()
                    'PencarianSupplier.TXTCariBarang.Text = cbosupplier.Text
                End If
            End If

            Call Hitungtransaksi()
            cekClose()
        End If
    End Sub

    Private Sub DGV_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DGV.UserDeletedRow
        Call Hitungtransaksi()
    End Sub
End Class