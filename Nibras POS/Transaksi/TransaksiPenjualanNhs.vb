Imports MySql.Data.MySqlClient

Public Class TransaksiPenjualanNhs

    Sub NomorOtomatis()
        Dim nomor As String

        cekOpen()
        'CMD = New MySqlCommand("select COUNT(faktur_jual) AS faktur_jual from penjualan where faktur_jual LIKE 'FJ" & Format(Now, "yyMMdd") & "%' ", Conn)
        CMD = New MySqlCommand("select COUNT(faktur_jual) AS faktur_jual from penjualan where tgl_jual  = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        'If IsDBNull(DR.Item("faktur_jual")) Then
        '    lblnomrofaktur.Text = "FJ" + Format(Now, "yyMMdd") + "001"
        'Else
        '    Dim nofaktur As String = DR.Item("faktur_jual")
        '    Dim inc As Integer = nofaktur.Substring(8, 3) + 1
        '    lblnomrofaktur.Text = "FJ" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        'End If

        If DR.HasRows Then
            Dim inc As Integer = DR.Item("faktur_jual") + 1
            nomor = "FJ" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", inc)
        Else
            Dim inc As Integer = 1
            nomor = "FJ" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()

        Dim up As Integer

        cekOpen()
        CMD = New MySqlCommand("SELECT COUNT(faktur_jual) AS faktur_jual FROM penjualan WHERE faktur_jual = '" + nomor + "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            up = DR.Item("faktur_jual")
        End If
        cekClose()

        If up > 0 Then
            nomor = "FJ" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", up + 1)
        End If

        lblnomrofaktur.Text = nomor
    End Sub

    Sub NomorOtomatisX()
        cekOpen()
        CMD = New MySqlCommand("SELECT COUNT(faktur_jual) AS faktur_jual FROM penjualan WHERE tgl_jual = '" & Format(Now, "yyyy-MM-dd") & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Dim inc As Integer = DR.Item("faktur_jual") + 1
            lblnomrofaktur.Text = "FJ" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        Else
            Dim inc As Integer = 1
            lblnomrofaktur.Text = "FJ" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub GetDiskon()
        cekOpen()
        CMD = New MySqlCommand("SELECT m.`kode_member`, m.`group_member`, g.`diskon` FROM member_m m INNER JOIN group_member g ON g.`kode_group` = m.`group_member`WHERE m.`kode_member` = '" & txtMember.Text & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtDiskon.Text = DR.Item("diskon")
        Else
            txtDiskon.Text = 0
        End If
        cekClose()
    End Sub

    Sub LoadItemMarket()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT name FROM market_place ORDER BY id ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "name"
        lookUpEdit.Properties.ValueMember = "name"
        cekClose()

        lookUpEdit.ItemIndex = 0
    End Sub

    Sub TampilCustomer()
        txtMember.Text = "00000"
        lblkodecustomer.Text = "Non Member"
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub TransaksiPenjualanNhs_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        'AssignValidation(Me.txtDiscRpAll, ValidationType.Only_Numbers)
        'AssignValidation(Me.txtDiscPersenAll, ValidationType.Only_Numbers)

        Call NomorOtomatis()
        Call TampilCustomer()
        Call GetDiskon()
        Call LoadItemMarket()
        txtBarcode.Focus()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim diskon As Double = DGV.Rows(e.RowIndex).Cells(6).Value / 100
        Dim diskonRupiah As Double = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) * diskon

        If e.ColumnIndex = 0 Then

            'cegah kode barang ganda
            For barisatas As Integer = 0 To DGV.RowCount - 1
                For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                    If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                        Dim diskonEdit As Double = DGV.Rows(barisatas).Cells(6).Value / 100
                        Dim qtyEdit As Double = DGV.Rows(barisatas).Cells(5).Value + 1
                        Dim diskonRupiahEdit As Double = (DGV.Rows(barisatas).Cells(4).Value * qtyEdit) * diskonEdit

                        DGV.Rows(barisatas).Cells(5).Value = DGV.Rows(barisatas).Cells(5).Value + 1
                        DGV.Rows(barisatas).Cells(8).Value = (DGV.Rows(barisatas).Cells(4).Value * qtyEdit) - diskonRupiahEdit
                        DGV.Rows(barisatas).Cells(9).Value = diskonRupiahEdit
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

            ''UBAH DISINI UNTUK NANTI HPJ AVERAGE!!
            If DR.HasRows Then
                DGV.Rows(e.RowIndex).Cells(1).Value = DR.Item("nama_barang")
                DGV.Rows(e.RowIndex).Cells(2).Value = DR.Item("satuan")
                DGV.Rows(e.RowIndex).Cells(3).Value = DR.Item("jenis")
                DGV.Rows(e.RowIndex).Cells(4).Value = DR.Item("hpj")
                DGV.Rows(e.RowIndex).Cells(5).Value = 1
                DGV.Rows(e.RowIndex).Cells(6).Value = 0

                DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                DGV.CurrentCell = DGV(0, DGV.CurrentCell.RowIndex)
            Else
                MsgBox("Kode barang tidak terdaftar", MsgBoxStyle.Critical)
                SendKeys.Send("{up}")
            End If

            cekClose()
        End If


        If e.ColumnIndex = 5 Then
            Try
                DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                DGV.Rows(e.RowIndex).Cells(9).Value = diskonRupiah
                DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
            Catch ex As Exception
                MsgBox("harus data angka", MsgBoxStyle.Critical)
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(5).Value = 0
                DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
            End Try
        End If

        If e.ColumnIndex = 6 Then

            Try
                If txtJenisNhs.Text <> "" Then

                    Dim disc As Integer
                    If cbMemberInternal.Checked = True Then
                        disc = 30
                    Else
                        disc = txtDiskon.Text
                    End If

                    'If (DGV.Rows(e.RowIndex).Cells(6).Value >= disc And DGV.Rows(e.RowIndex).Cells(6).Value <= disc) Or DGV.Rows(e.RowIndex).Cells(6).Value > 0 Then
                    '    DGV.Rows(e.RowIndex).Cells(7).Value = 0
                    '    DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                    '    DGV.Rows(e.RowIndex).Cells(9).Value = diskonRupiah
                    '    DGV.CurrentCell = DGV(6, DGV.CurrentCell.RowIndex)
                    'Else
                    '    MsgBox("Batas diskon untuk Member " & lblkodecustomer.Text & " adalah " & disc & "% atau NOL (Tergantung Kebijakan yg ada)", MsgBoxStyle.Critical)
                    '    DGV.Rows(e.RowIndex).Cells(6).Value = disc
                    '    DGV.Rows(e.RowIndex).Cells(7).Value = 0
                    '    DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - ((DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) * (disc / 100))
                    '    DGV.Rows(e.RowIndex).Cells(9).Value = ((DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) * (disc / 100))
                    '    DGV.CurrentCell = DGV(6, DGV.CurrentCell.RowIndex)
                    'End If
                    DGV.Rows(e.RowIndex).Cells(7).Value = 0
                    DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                    DGV.Rows(e.RowIndex).Cells(9).Value = diskonRupiah
                    DGV.CurrentCell = DGV(6, DGV.CurrentCell.RowIndex)
                Else
                    'If DGV.Rows(e.RowIndex).Cells(6).Value = txtDiskon.Text Then
                    '    DGV.Rows(e.RowIndex).Cells(7).Value = 0
                    '    DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                    '    DGV.Rows(e.RowIndex).Cells(9).Value = diskonRupiah
                    '    DGV.CurrentCell = DGV(6, DGV.CurrentCell.RowIndex)
                    'Else
                    '    MsgBox("Member Tidak Berhak mendapatkan diskon tersebut", MsgBoxStyle.Critical)
                    '    DGV.Rows(e.RowIndex).Cells(6).Value = txtDiskon.Text
                    '    DGV.Rows(e.RowIndex).Cells(7).Value = 0
                    'End If
                    DGV.Rows(e.RowIndex).Cells(7).Value = 0
                    DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                    DGV.Rows(e.RowIndex).Cells(9).Value = diskonRupiah
                    DGV.CurrentCell = DGV(6, DGV.CurrentCell.RowIndex)
                End If

            Catch ex As Exception
                MsgBox("harus data angka", MsgBoxStyle.Critical)
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(5).Value = 0
                DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
            End Try
        End If

        If e.ColumnIndex = 7 Then
            Try
                DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - DGV.Rows(e.RowIndex).Cells(7).Value
                DGV.Rows(e.RowIndex).Cells(9).Value = DGV.Rows(e.RowIndex).Cells(7).Value
                DGV.Rows(e.RowIndex).Cells(6).Value = 0
                DGV.CurrentCell = DGV(7, DGV.CurrentCell.RowIndex)
            Catch ex As Exception
                MsgBox("harus data angka", MsgBoxStyle.Critical)
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(6).Value = 0
                DGV.Rows(e.RowIndex).Cells(7).Value = 0
                DGV.Rows(e.RowIndex).Cells(8).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - DGV.Rows(e.RowIndex).Cells(7).Value
            End Try
        End If

        Call Hitungtransaksi()
    End Sub

    Sub Hitungtransaksi()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(5).Value
            lbljumlahbarang.Text = x
        Next

        Dim ongkir As Integer = Integer.Parse(txtBiayaLain.Text.Replace(".", ""))

        Dim y As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            y = y + DGV.Rows(baris).Cells(8).Value
        Next
        lbltotalharga.Text = y
        lbltotalhargaBig.Text = FormatCurrency(y + ongkir)
        lbltotalhargaBigHide.Text = y + ongkir
        txtBiayaLainHide.Text = ongkir

        lblTotalHargaFixed.Text = y + ongkir

        Dim z As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            z = z + DGV.Rows(baris).Cells(9).Value
            lbltotaldiskon.Text = z
            txtTotalPotongan.Text = FormatCurrency(z)
        Next
    End Sub

    Private Sub txtdibayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdibayar.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txtdibayar.Text) = Val(lbltotalharga.Text) Then
                lblcarajual.Text = "CASH"
                lblsisahutang.Text = 0
                txttempo.Text = 0
                lblkembali.Text = 0
                txttempo.Enabled = False
                lbljatuhtempo.Text = Format(dtptanggal.Value, "yyyy-MM-dd")
                lblstatusjual.Text = "LUNAS"
                btnSimpan.Focus()
            ElseIf Val(txtdibayar.Text) > Val(lbltotalharga.Text) Then
                lblcarajual.Text = "CASH"
                lblsisahutang.Text = 0
                txttempo.Text = 0
                lblkembali.Text = Val(txtdibayar.Text) - Val(lbltotalharga.Text)
                txttempo.Enabled = False
                lbljatuhtempo.Text = Format(dtptanggal.Value, "yyyy-MM-dd")
                lblstatusjual.Text = "LUNAS"
                btnSimpan.Focus()
            Else
                lblcarajual.Text = "CREDIT"
                lblsisahutang.Text = Val(lbltotalharga.Text) - Val(txtdibayar.Text)
                lblstatusjual.Text = "BELUM LUNAS"
                lblkembali.Text = 0
                txttempo.Enabled = True
                txttempo.Focus()
            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txttempo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttempo.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim tambahhari As Integer = txttempo.Text
            lbljatuhtempo.Text = DateAdd(DateInterval.Day, tambahhari, Today)
            btnSimpan.Focus()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Sub Kosongkan()
        txtJenisNhs.Text = ""
        lbljumlahbarang.Text = ""
        lbltotalharga.Text = ""
        lblcarajual.Text = ""
        lblsisahutang.Text = ""
        lbljatuhtempo.Text = ""
        lblstatusjual.Text = ""
        lblkembali.Text = ""
        txtdibayar.Text = ""
        txttempo.Text = ""
        lbltotalhargaBig.Text = FormatCurrency(0)
        txtMember.Text = "00000"
        lblkodecustomer.Text = "Non Member"
        txtBiayaLain.Text = "0"
        txtBiayaLainHide.Text = "0"
        txtNoFakturPending.Text = ""
        txtDiscPersenAll.Text = 0
        txtDiscRpAll.Text = 0
        txtDiscRpAllHide.Text = 0
        lbltotaldiskon.Text = 0
        txtTotalPotongan.Text = FormatCurrency(0)

        Call NomorOtomatis()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
        DGV.Rows.Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim checkGrid = True
        For baris As Integer = 0 To DGV.RowCount - 2

            If DGV.Rows(baris).Cells(0).Value = "" Then
                checkGrid = False
            End If

            'If DGV.Rows(baris).Cells(0).Value.ToString.Length < 10 Then

            '    If DGV.Rows(baris).Cells(0).Value = "001" Or DGV.Rows(baris).Cells(0).Value = "002" Or DGV.Rows(baris).Cells(0).Value = "003" Then
            '        checkGrid = True
            '    Else
            '        checkGrid = False
            '    End If

            'End If
        Next

        If checkGrid = True Then

            If txtMember.Text = "" Then
                MsgBox("Kode Member Belum diisi", MsgBoxStyle.Information, "Penjualan")
            ElseIf lbltotalharga.Text = "0" Or lbltotalharga.Text = "" Or lbljumlahbarang.Text = "" Then
                MsgBox("Transaksi masih kosong, silahkan tambah barang yang akan ditransaksikan!", MsgBoxStyle.Information, "Penjualan")
            ElseIf lookUpEdit.EditValue.ToString = "" Then
                MsgBox("Asal Belanja Kosong, silakan isi Asal Belanja Customer!", MsgBoxStyle.Information, "Penjualan")
            Else
                DialogPembayaranNhs.Show()
            End If

        Else
            MsgBox("Oops! Item Tidak Sesuai! Silahkan periksa kembali pada Daftar Item yang Dijual.", MsgBoxStyle.Critical, "Penjualan")
        End If
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
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

                If DR.Item("stok") < 1 Then

                    MsgBox("Barang Tidak Dapat Ditransaksikan! Stok Barang: 0", MsgBoxStyle.Critical)
                    txtBarcode.Clear()
                    cekClose()

                Else
                    Dim baris As Integer = DGV.RowCount - 1

                    If txtJenisNhs.Text <> "" Then

                        Dim disc As Integer
                        If cbMemberInternal.Checked = True Then
                            disc = 30
                        Else
                            disc = txtDiskon.Text
                        End If

                        DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("jenis"), DR.Item("hpj"), 1, disc)
                    Else
                        DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("jenis"), DR.Item("hpj"), 1, txtDiskon.Text)
                    End If
                    txtBarcode.Clear()
                    cekClose()

                    Dim diskon As Double = DGV.Rows(baris).Cells(6).Value / 100
                    Dim diskonRupiah As Double = (DGV.Rows(baris).Cells(4).Value * DGV.Rows(baris).Cells(5).Value) * diskon
                    DGV.Rows(baris).Cells(8).Value = (DGV.Rows(baris).Cells(4).Value * DGV.Rows(baris).Cells(5).Value) - diskonRupiah
                    DGV.Rows(baris).Cells(9).Value = diskonRupiah

                    Call Hitungtransaksi()
                    For barisatas As Integer = 0 To DGV.RowCount - 1
                        For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                            If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                                Dim diskonEdit As Double = DGV.Rows(barisatas).Cells(6).Value / 100
                                Dim qtyEdit As Double = DGV.Rows(barisatas).Cells(5).Value + 1
                                Dim diskonRupiahEdit As Double = (DGV.Rows(barisatas).Cells(4).Value * qtyEdit) * diskonEdit

                                DGV.Rows(barisatas).Cells(5).Value = DGV.Rows(barisatas).Cells(5).Value + 1
                                DGV.Rows(barisatas).Cells(8).Value = (DGV.Rows(barisatas).Cells(4).Value * qtyEdit) - diskonRupiahEdit
                                DGV.Rows(barisatas).Cells(9).Value = diskonRupiahEdit
                                DGV.Rows.RemoveAt(barisbawah)
                                Call Hitungtransaksi()
                                Exit Sub
                            End If
                        Next
                    Next

                End If

            Else
                PencarianBarangJual.ShowDialog()
                PencarianBarangJual.TXTCariBarang.Text = txtBarcode.Text
                cekClose()
            End If
            'cekClose()
        End If
    End Sub

    Private Sub DGV_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                btnSimpan.PerformClick()
                e.SuppressKeyPress = True
        End Select
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

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                DownloadBarang.Show()
                e.SuppressKeyPress = True
            Case Keys.F5
                btnSimpan.PerformClick()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub txtMember_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMember.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                'DownloadOutletJual.Show()
        End Select
    End Sub

    Private Sub txtMember_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMember.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then

            If txtMember.Text = "00000" Then

                lblkodecustomer.Text = "Non Member"

            Else

                If cbMemberInternal.Checked = True Then
                    cekOpen()
                    CMD = New MySqlCommand("SELECT id, nama, jenis_nhs FROM master_nhs WHERE id = '" & txtMember.Text & "' UNION SELECT kode AS id, nama, jenis_nhs FROM mst_distributor WHERE kode = '" & txtMember.Text & "' ", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()

                    If DR.HasRows Then
                        lblkodecustomer.Text = DR.Item("nama")
                        txtJenisNhs.Text = DR.Item("jenis_nhs")
                        txtBarcode.Focus()
                        txtBarcode.Select()
                    Else
                        PencarianMember.ShowDialog()
                        PencarianMember.TXTCariBarang.Text = txtMember.Text
                    End If
                    txtDiskon.Text = 30
                    cekClose()
                Else
                    cekOpen()
                    CMD = New MySqlCommand("select * from member_m where kode_member='" & txtMember.Text & "'", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()

                    If DR.HasRows Then
                        lblkodecustomer.Text = DR.Item("nama_member")
                        txtJenisNhs.Text = ""
                        txtBarcode.Focus()
                        txtBarcode.Select()
                    Else
                        PencarianMember.ShowDialog()
                        PencarianMember.TXTCariBarang.Text = txtMember.Text
                    End If
                    cekClose()

                    Call GetDiskon()
                End If

                'If MainMenu.PanelJenis.Text <> "D" Then
                '    If cbMemberInternal.Checked = True Then
                '        cekOpen()
                '        CMD = New MySqlCommand("select * from master_nhs where id='" & txtMember.Text & "'", Conn)
                '        DR = CMD.ExecuteReader
                '        DR.Read()

                '        If DR.HasRows Then
                '            lblkodecustomer.Text = DR.Item("nama")
                '            txtJenisNhs.Text = DR.Item("jenis_nhs")
                '            txtBarcode.Focus()
                '            txtBarcode.Select()
                '        Else
                '            PencarianMember.ShowDialog()
                '            PencarianMember.TXTCariBarang.Text = txtMember.Text
                '        End If
                '        txtDiskon.Text = 30
                '        cekClose()
                '    Else
                '        cekOpen()
                '        CMD = New MySqlCommand("select * from member_m where kode_member='" & txtMember.Text & "'", Conn)
                '        DR = CMD.ExecuteReader
                '        DR.Read()

                '        If DR.HasRows Then
                '            lblkodecustomer.Text = DR.Item("nama_member")
                '            txtJenisNhs.Text = ""
                '            txtBarcode.Focus()
                '            txtBarcode.Select()
                '        Else
                '            PencarianMember.ShowDialog()
                '            PencarianMember.TXTCariBarang.Text = txtMember.Text
                '        End If
                '        cekClose()

                '        Call GetDiskon()
                '    End If
                'Else
                '    cekOpen()
                '    CMD = New MySqlCommand("select * from master_nhs where id='" & txtMember.Text & "'", Conn)
                '    DR = CMD.ExecuteReader
                '    DR.Read()

                '    If DR.HasRows Then
                '        lblkodecustomer.Text = DR.Item("nama")
                '        txtJenisNhs.Text = DR.Item("jenis_nhs")
                '        txtBarcode.Focus()
                '        txtBarcode.Select()
                '    Else
                '        MsgBox("Kode Member tidak terdaftar")
                '        txtMember.Text = "00000"
                '        lblkodecustomer.Text = "Non Member"
                '    End If

                '    cekClose()
                'End If
            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If txtMember.Text <> "" Then
            DaftarPesananJual.Show()
        Else
            MsgBox("Silahkan isi Data Member!")
            txtMember.Focus()
            txtMember.Select()
        End If
    End Sub

    Private Sub txtBiayaLain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBiayaLain.KeyPress
        If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
        End If

        If e.KeyChar = ChrW(Keys.Return) Then
            If txtBiayaLain.Text = "" Then
                txtBiayaLain.Text = 0
            Else
                txtBiayaLain.Text = FormatNumber(txtBiayaLain.Text, 0)
            End If

            'Call Hitungtransaksi()

            Dim total As Double = 0
            Dim totalAll As Double = Double.Parse(lbltotalharga.Text)
            Dim ongkir As Integer = Integer.Parse(txtBiayaLain.Text.Replace(".", ""))

            lbltotalhargaBig.Text = FormatCurrency(totalAll + ongkir)
            lbltotalhargaBigHide.Text = totalAll + ongkir
            txtBiayaLainHide.Text = ongkir
        End If
    End Sub

    Private Sub txtBiayaLain_LostFocus(sender As Object, e As EventArgs) Handles txtBiayaLain.LostFocus

        If txtBiayaLain.Text = "" Then
            txtBiayaLain.Text = 0
        Else
            txtBiayaLain.Text = FormatNumber(txtBiayaLain.Text, 0)
        End If

        Call Hitungtransaksi()
    End Sub

    Private Sub btnSimpanTransaksi_Click(sender As Object, e As EventArgs) Handles btnSimpanTransaksi.Click
        cekOpen()
        CMD = New MySqlCommand("select COUNT(faktur_jual) AS faktur_jual from pending_jual where faktur_jual LIKE 'TMP-J" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        Dim inc As Integer = DR.Item("faktur_jual") + 1
        Dim TempFakturJual As String = "TMP-J" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)

        'If DR.HasRows Then
        '    Dim inc As Integer = DR.Item("faktur_jual")
        '    TempFakturJual = "TMP-J" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        '    'lblnomrofaktur.Text = "FJ" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        'Else
        '    Dim inc As Integer = 1
        '    TempFakturJual = "TMP-J" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        'End If
        cekClose()

        cekOpen()
        If txtNoFakturPending.Text <> "" Then
            CMD = New MySqlCommand("DELETE FROM pending_jual WHERE faktur_jual = '" & txtNoFakturPending.Text & "' ", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("DELETE FROM pending_jual_detail WHERE faktur_jual = '" & txtNoFakturPending.Text & "' ", Conn)
            CMD.ExecuteNonQuery()
        End If

        CMD = New MySqlCommand("INSERT INTO `pending_jual` (`faktur_jual`,`tanggal`,`kode_member`,`nama_member`,`qty`,`total`,`ongkir`,`created_by`,`created_date`,`status`)
        VALUES('" & TempFakturJual & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & txtMember.Text & "', '" & lblkodecustomer.Text & "', '" & lbljumlahbarang.Text & "', '" & lbltotalharga.Text & "', '" & txtBiayaLainHide.Text & "', '" & MainMenu.PanelUser.Text & "', NOW(), 1);", Conn)
        CMD.ExecuteNonQuery()

        For baris As Integer = 0 To DGV.RowCount - 2

            CMD = New MySqlCommand("INSERT INTO `pending_jual_detail` (`faktur_jual`,`kode_item`,`nama`,`satuan`,`jenis`,`harga`,`jumlah`,`disc_p`,`disc_rp`,`total`,`total_disc`)
        VALUES('" & TempFakturJual & "', '" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '" & DGV.Rows(baris).Cells(2).Value & "', '" & DGV.Rows(baris).Cells(3).Value & "', '" & DGV.Rows(baris).Cells(4).Value & "', '" & DGV.Rows(baris).Cells(5).Value & "', '" & DGV.Rows(baris).Cells(6).Value & "', '" & DGV.Rows(baris).Cells(7).Value & "', '" & DGV.Rows(baris).Cells(8).Value & "', '" & DGV.Rows(baris).Cells(9).Value & "');", Conn)
            CMD.ExecuteNonQuery()

        Next
        cekClose()

        MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information, "Perhatian")
        Call Kosongkan()
        DGV.Rows.Clear()

        Call DaftarPenjualan.TampilGrid()
    End Sub

    Private Sub dtptanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtptanggal.ValueChanged
        Call NomorOtomatis()
    End Sub

    Private Sub DGV_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DGV.UserDeletedRow
        Call Hitungtransaksi()
    End Sub

    Dim ubahDiscRpAll As Boolean = True

    Private Sub txtDiscRpAll_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiscRpAll.KeyPress
        If e.KeyChar = Chr(13) Then

            If ubahDiscRpAll = True Then
                Dim hitunganDisc As Double
                Dim total As Double = 0

                'lbltotalharga.Text = y
                Dim totalAll As Double = Double.Parse(lblTotalHargaFixed.Text)
                Dim ongkir As Integer = Integer.Parse(txtBiayaLain.Text.Replace(".", ""))
                'lbltotalhargaBig.Text = FormatCurrency(y + ongkir)
                'lbltotalhargaBigHide.Text = y + ongkir
                'txtBiayaLainHide.Text = ongkir

                If txtDiscRpAll.Text.Contains("RP") Then
                    MsgBox("Oops! Silakan input angka nominal diskon dengan benar.", MsgBoxStyle.Information, "Perhatian")
                Else

                    If (Integer.Parse(txtDiscRpAll.Text) < 0) Or (Double.Parse(txtDiscRpAll.Text) > totalAll) Then

                        txtDiscPersenAll.Text = 0
                        txtDiscRpAllHide.Text = 0
                        Call Hitungtransaksi()

                    Else

                        If txtDiscRpAll.Text = 0 Then

                            txtDiscPersenAll.Text = 0
                            txtDiscRpAllHide.Text = 0
                            Call Hitungtransaksi()
                        Else

                            hitunganDisc = (Double.Parse(txtDiscRpAll.Text) / totalAll) * 100
                            txtDiscPersenAll.Text = Format(hitunganDisc, "N2")

                            txtDiscRpAllHide.Text = txtDiscRpAll.Text
                            lbltotalharga.Text = totalAll - Double.Parse(txtDiscRpAll.Text)
                            lbltotalhargaBig.Text = FormatCurrency((totalAll - Double.Parse(txtDiscRpAll.Text)) + ongkir)
                            lbltotalhargaBigHide.Text = (totalAll - Double.Parse(txtDiscRpAll.Text)) + ongkir
                            txtBiayaLainHide.Text = ongkir

                            Dim z As Double = 0
                            For baris As Integer = 0 To DGV.RowCount - 1
                                z = z + DGV.Rows(baris).Cells(9).Value
                            Next
                            lbltotaldiskon.Text = z + Double.Parse(txtDiscRpAllHide.Text)
                            txtTotalPotongan.Text = FormatCurrency(z + Double.Parse(txtDiscRpAllHide.Text))
                        End If

                    End If

                    ubahDiscRpAll = False

                End If
            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Dim ubahDiscPersenAll As Boolean = True

    Private Sub txtDiscPersenAll_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiscPersenAll.KeyPress
        If e.KeyChar = Chr(13) Then

            If ubahDiscPersenAll = True Then

                Dim hitunganDisc As Double
                Dim total As Double = 0

                If (Double.Parse(txtDiscPersenAll.Text) < 0) Or (Double.Parse(txtDiscPersenAll.Text) > 100) Or lblTotalHargaFixed.Text = "" Then

                    txtDiscPersenAll.Text = 0
                    txtDiscRpAll.Text = 0
                    txtDiscRpAllHide.Text = 0
                    Call Hitungtransaksi()

                Else

                    Dim totalAll As Double = Double.Parse(lblTotalHargaFixed.Text)
                    Dim ongkir As Integer = Integer.Parse(txtBiayaLain.Text.Replace(".", ""))

                    If txtDiscPersenAll.Text = 0 Then

                        txtDiscRpAll.Text = 0
                        txtDiscRpAllHide.Text = 0
                        Call Hitungtransaksi()
                    Else

                        hitunganDisc = Double.Parse(txtDiscPersenAll.Text) / 100
                        total = totalAll * hitunganDisc

                        txtDiscRpAll.Text = FormatCurrency(total)

                        txtDiscRpAllHide.Text = total
                        lbltotalharga.Text = totalAll - total
                        lbltotalhargaBig.Text = FormatCurrency((totalAll - total) + ongkir)
                        lbltotalhargaBigHide.Text = (totalAll - total) + ongkir
                        txtBiayaLainHide.Text = ongkir

                        Dim z As Double = 0
                        For baris As Integer = 0 To DGV.RowCount - 1
                            z = z + DGV.Rows(baris).Cells(9).Value
                        Next
                        lbltotaldiskon.Text = z + Double.Parse(txtDiscRpAllHide.Text)
                        txtTotalPotongan.Text = FormatCurrency(z + Double.Parse(txtDiscRpAllHide.Text))
                    End If

                End If

                ubahDiscPersenAll = False

            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txtDiscRpAll_TextChanged(sender As Object, e As EventArgs) Handles txtDiscRpAll.TextChanged
        ubahDiscRpAll = True
    End Sub

    Private Sub txtDiscPersenAll_TextChanged(sender As Object, e As EventArgs) Handles txtDiscPersenAll.TextChanged
        ubahDiscPersenAll = True
    End Sub

    Private Sub txtDiscRpAll_GotFocus(sender As Object, e As EventArgs) Handles txtDiscRpAll.GotFocus
        txtDiscRpAll.Text = 0
        Exit Sub
    End Sub
End Class