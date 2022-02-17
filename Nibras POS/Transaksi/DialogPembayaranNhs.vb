Imports System.Text
Imports MySql.Data.MySqlClient

Public Class DialogPembayaranNhs

    Dim kredit As Double
    Dim totalTransaksi As Double
    Dim totalBayar As Double
    Dim totalDibayar As Double
    Dim totalDibayarSebelumKredit As Double
    Dim kembalian As Double
    Dim validasi As Boolean = True
    Dim depositMember As Double
    Dim transfer As Integer = 0
    Dim ItemKosong As StringBuilder = New StringBuilder()

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub GetDataDeposit()

        'If TransaksiPenjualanNhs.txtMember.Text = "00000" Then
        '    depositMember = 0
        '    txtDeposit.Text = 0
        '    txtDepositHide.Text = 0
        'Else
        cekOpen()
        CMD = New MySqlCommand("SELECT deposit FROM member_m WHERE kode_member = '" & TransaksiPenjualanNhs.txtMember.Text & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtDeposit.Text = DR.Item("deposit")
            txtDepositHide.Text = DR.Item("deposit")
            depositMember = Convert.ToDouble(DR.Item("deposit"))
        Else
            depositMember = 0
        End If
        cekClose()
        'End If
    End Sub

    Sub CallBank()

        cbBankA.Items.Clear()
        cbCC.Items.Clear()
        cbEMoney.Items.Clear()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM bank_m WHERE active = 1 ORDER BY nama_bank", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            cbBankA.Items.Add(DR.Item("id_bank") & "-" & DR.Item("nama_bank"))
            'cbBankB.Items.Add(DR.Item("id_bank") & "-" & DR.Item("nama_bank"))
            cbCC.Items.Add(DR.Item("id_bank") & "-" & DR.Item("nama_bank"))
            cbEMoney.Items.Add(DR.Item("id_bank") & "-" & DR.Item("nama_bank"))
        Loop
        cekClose()
    End Sub

    Private Sub DialogPembayaran_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub DialogPembayaranNhs_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Me.CenterToScreen()
        txtKredit.Text = TransaksiPenjualanNhs.lbltotalhargaBigHide.Text

        txtTunai.Focus()
        txtTunai.Select()
        totalTransaksi = TransaksiPenjualanNhs.lbltotalhargaBigHide.Text
        txtTotal.Text = FormatCurrency(totalTransaksi)

        Call JumlahkanPembayaran()
        Call Kosongkan()
        Call GetDataDeposit()
    End Sub

    Sub JumlahkanPembayaran()
        Dim deposit As Double
        If txtDeposit.Text = "" Then
            deposit = 0
        Else
            deposit = txtDeposit.Text
        End If

        If cbDeposit.Checked = False Then
            totalDibayar = Format(Val(txtTunai.Text.Replace(".", "")) + Val(txtDebitA.Text.Replace(".", "")) + Val(txtDebitB.Text.Replace(".", "")) + Val(txtCC.Text.Replace(".", "")) + Val(txtEMoney.Text.Replace(".", "")) + Val(txtKredit.Text.Replace(".", "")), "0,00")
            totalDibayarSebelumKredit = Format(Val(txtTunai.Text.Replace(".", "")) + Val(txtDebitA.Text.Replace(".", "")) + Val(txtDebitB.Text.Replace(".", "")) + Val(txtCC.Text.Replace(".", "")) + Val(txtEMoney.Text.Replace(".", "")), "0,00")
            kembalian = totalDibayar - totalTransaksi

            txtDeposit.ReadOnly = True
        Else
            totalDibayar = Format(Val(txtTunai.Text.Replace(".", "")) + Val(txtDebitA.Text.Replace(".", "")) + Val(txtDebitB.Text.Replace(".", "")) + Val(txtCC.Text.Replace(".", "")) + Val(txtEMoney.Text.Replace(".", "")) + Val(txtKredit.Text.Replace(".", "")) + Val(txtDeposit.Text.Replace(".", "")), "0,00")
            totalDibayarSebelumKredit = Format(Val(txtTunai.Text.Replace(".", "")) + Val(txtDebitA.Text.Replace(".", "")) + Val(txtDebitB.Text.Replace(".", "")) + Val(txtCC.Text.Replace(".", "")) + Val(txtEMoney.Text.Replace(".", "")) + +Val(txtDeposit.Text.Replace(".", "")), "0,00")
            kembalian = totalDibayar - totalTransaksi

            txtDeposit.ReadOnly = False
        End If

        txtTotalBayar.Text = FormatCurrency(totalDibayar)
        txtTotalBayarHide.Text = totalDibayar

        If kembalian >= 0 Then
            lblKembalian.Visible = True
            lblKurang.Visible = False
        Else
            lblKurang.Visible = True
            lblKembalian.Visible = False
        End If

        txtKembalian.Text = FormatCurrency(kembalian)
        txtKembalianHide.Text = kembalian
    End Sub

    Private Sub txtDebitA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDebitA.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtDebitA_TextChanged(sender As Object, e As EventArgs) Handles txtDebitA.TextChanged
        Call JumlahkanPembayaran()
    End Sub

    Private Sub txtDebitB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDebitB.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtDebitB_TextChanged(sender As Object, e As EventArgs) Handles txtDebitB.TextChanged
        Call JumlahkanPembayaran()
    End Sub

    Private Sub txtCC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCC.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtCC_TextChanged(sender As Object, e As EventArgs) Handles txtCC.TextChanged
        Call JumlahkanPembayaran()
    End Sub

    Private Sub txtEMoney_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEMoney.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtEMoney_TextChanged(sender As Object, e As EventArgs) Handles txtEMoney.TextChanged
        Call JumlahkanPembayaran()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        If totalDibayar < totalTransaksi Then
            MsgBox("Total Pembayaran lebih kecil dari Nilai Transaksi")
            validasi = False
        End If

        If Convert.ToDouble(txtDebitA.Text) > 0 And cbBankA.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbBankA.Focus()
            cbBankA.Select()
            validasi = False
        End If

        If Convert.ToDouble(txtCC.Text) > 0 And cbCC.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbCC.Focus()
            cbCC.Select()
            validasi = False
        End If

        If Convert.ToDouble(txtEMoney.Text) > 0 And cbEMoney.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbEMoney.Focus()
            cbEMoney.Select()
            validasi = False
        End If

        If validasi = True Then
            CekKredit()
        End If
    End Sub

    Private Sub btnSimpanCetak_Click(sender As Object, e As EventArgs) Handles btnSimpanCetak.Click
        'Cetak1.Show()
        Dim printerName As String = GetPrinterKasir()

        If totalDibayar < totalTransaksi Then
            MsgBox("Total Pembayaran lebih kecil dari Nilai Transaksi")
            validasi = False
            'Exit Sub
        Else
            validasi = True
        End If

        If Convert.ToDouble(txtDebitA.Text) > 0 And cbBankA.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbBankA.Focus()
            cbBankA.Select()
            validasi = False
            'Exit Sub
        End If

        If Convert.ToDouble(txtCC.Text) > 0 And cbCC.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbCC.Focus()
            cbCC.Select()
            validasi = False
            'Exit Sub
        End If

        If Convert.ToDouble(txtEMoney.Text) > 0 And cbEMoney.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbEMoney.Focus()
            cbEMoney.Select()
            validasi = False
            'Exit Sub
        End If

        If validasi = True Then
            Call TransaksiPenjualanNhs.NomorOtomatis()

            If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                If CheckStokFirst() = True Then
                    'SplashScreenManager1.ShowWaitForm()

                    If Convert.ToDouble(txtKredit.Text) > 0 Then
                        Call SimpanTransaksiKredit()

                    Else
                        Call SimpanTransaksiCash()

                    End If

                    '### Upload Transaksi ###'
                    Call uploadPenjualan(TransaksiPenjualanNhs.lblnomrofaktur.Text)

                    '### Cetak Struk ###'
                    If printerName = "empty" Then
                        CetakFaktur.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "'"
                        cryRpt.Load("FakturJual.rpt")
                        Call seting_laporan()
                        CetakFaktur.CRV.ReportSource = cryRpt
                        CetakFaktur.CRV.RefreshReport()
                        cryRpt.PrintToPrinter(1, True, 0, 0)
                    Else
                        CetakFaktur.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "'"
                        cryRpt.Load("FakturJual.rpt")
                        Call seting_laporan()
                        CetakFaktur.CRV.ReportSource = cryRpt
                        CetakFaktur.CRV.RefreshReport()
                        cryRpt.PrintOptions.PrinterName = printerName
                        cryRpt.PrintToPrinter(1, True, 0, 0)
                    End If

                    TransaksiPenjualanNhs.Kosongkan()
                    TransaksiPenjualanNhs.NomorOtomatis()
                    TransaksiPenjualanNhs.DGV.Rows.Clear()
                    Call HapusDaftarJual()

                    'SplashScreenManager1.CloseWaitForm()
                    Me.Close()
                Else
                    MsgBox("Mohon Maaf, terdapat penjualan yang melebihi Stok! Silahkan periksa kembali item yang di jual." + vbNewLine + vbNewLine + ItemKosong.ToString, MsgBoxStyle.Critical, "Perhatian!")
                End If
            End If
        End If
    End Sub

    Sub CekKredit()
        Call TransaksiPenjualanNhs.NomorOtomatis()

        If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            'SplashScreenManager1.ShowWaitForm()

            If CheckStokFirst() = True Then
                If Convert.ToDouble(txtKredit.Text) > 0 Then
                    Call SimpanTransaksiKredit()
                Else
                    Call SimpanTransaksiCash()
                End If

                '### Upload Transaksi ###'
                Call uploadPenjualan(TransaksiPenjualanNhs.lblnomrofaktur.Text)

                TransaksiPenjualanNhs.Kosongkan()
                TransaksiPenjualanNhs.NomorOtomatis()
                TransaksiPenjualanNhs.DGV.Rows.Clear()
                Call HapusDaftarJual()

                'SplashScreenManager1.CloseWaitForm()
                Me.Close()
            Else
                MsgBox("Mohon Maaf, terdapat penjualan yang melebihi Stok! Silahkan periksa kembali item yang di jual." + vbNewLine + vbNewLine + ItemKosong.ToString, MsgBoxStyle.Critical, "Perhatian!")
            End If
        End If
    End Sub
    Sub SimpanTransaksiCash()
        'MsgBox("CASH")
        Call TransaksiPenjualanNhs.NomorOtomatis()

        'Penanda dia Debit tapi dibayar Transfer
        If cbTransfer.Checked = True Then
            transfer = 1
        Else
            transfer = 0
        End If

        Dim ongkir As Double = Double.Parse(TransaksiPenjualanNhs.txtBiayaLainHide.Text)
        Dim valueDeposit As Double = 0

        If cbDeposit.Checked = True Then
            valueDeposit = Double.Parse(txtDeposit.Text)
        End If

        cekOpen()
        Dim simpan1 As String = "INSERT INTO penjualan (faktur_jual, tgl_jual, item_jual, total_diskon, total_jual, bayar_jual, kembali_jual, diskon_all, diskon_all_rp, cara_jual, sisa_piutang, jth_tempo_jual, status_jual, kode_customer, kode_user, tunai, kredit, debit_a, bank_a, kartu_a, debit_b, bank_b, kartu_b, credit_card, bank_cc, kartu_cc, emoney, bank_emoney, kartu_emoney, transfer, ongkir, deposit, keterangan, jenis_member) values ('" &
            TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" &
            Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & "','" &
            TransaksiPenjualanNhs.lbljumlahbarang.Text & "','" &
            TransaksiPenjualanNhs.lbltotaldiskon.Text & "','" &
            TransaksiPenjualanNhs.lbltotalharga.Text & "','" &
            txtTotalBayarHide.Text & "','" &
            txtKembalianHide.Text & "','" &
            TransaksiPenjualanNhs.txtDiscPersenAll.Text & "','" &
            TransaksiPenjualanNhs.txtDiscRpAllHide.Text & "', 'CASH', '0', '" & Format(Now, "yyyy-MM-dd") & "', 'LUNAS', '" &
            txtMember.Text & "','" &
            MainMenu.PanelUser.Text & "','" &
            txtTunai.Text & "','" &
            txtKredit.Text & "','" &
            txtDebitA.Text & "','" &
            cbBankA.Text & "','" &
            txtNoBankA.Text & "','" &
            txtDebitB.Text & "','" &
            cbBankB.Text & "','" &
            txtNoBankB.Text & "','" &
            txtCC.Text & "','" &
            cbCC.Text & "','" &
            txtNoCC.Text & "','" &
            txtEMoney.Text & "','" &
            cbEMoney.Text & "','" &
            txtNoEMoney.Text & "', " & transfer & ", " & TransaksiPenjualanNhs.txtBiayaLainHide.Text & ", '" & valueDeposit & "', '" & TransaksiPenjualanNhs.txtKeterangan.Text & "', '" & TransaksiPenjualanNhs.lookUpEdit.EditValue.ToString & "' )"

        CMD = New MySqlCommand(simpan1, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        Dim totalhpp As Double
        For baris As Integer = 0 To TransaksiPenjualanNhs.DGV.RowCount - 2

            cekOpen()
            Dim simpan2 As String = "insert into detailjual values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "','" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(4).Value & "','" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value & "','" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(8).Value & "','-', '" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(6).Value & "', '" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(7).Value & "', 0)"
            CMD = New MySqlCommand(simpan2, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("select * from barang_m where kode_item='" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                Dim kurangistok As String = "update barang_m set stok= stok - " & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value & " where kode_item='" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "'"
                Dim stokAwal As Integer = DR.Item("stok")
                Dim stokAkhir As Integer = DR.Item("stok") - TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value
                totalhpp += DR.Item("hpp") * TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value
                cekClose()

                cekOpen()
                Dim updatehistory As String = "INSERT INTO history_stok VALUES ( '" &
                        TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "', '" &
                        TransaksiPenjualanNhs.lblnomrofaktur.Text & "', '" &
                        Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & "', 'Penjualan', '" &
                        stokAwal & "', '" &
                        TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value & "', '" &
                        stokAkhir & "', '" &
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" &
                        MainMenu.PanelUser.Text & "' )"
                CMD = New MySqlCommand(updatehistory, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                'Update Stok
                cekOpen()
                CMD = New MySqlCommand(kurangistok, Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            End If
        Next

        ''--------------------TRANSAKSI POINT MEMBER--------------------''
        If TransaksiPenjualanNhs.txtMember.Text <> "00000" Then

            Dim poin As Double
            Dim belanja As Double = TransaksiPenjualanNhs.lbltotalharga.Text
            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM config_point LIMIT 1", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                poin = DR.Item("nominal")
            End If
            cekClose()

            If poin > 0 Then
                Dim perhitunganPoin As Double = Math.Floor(belanja / poin)
                cekOpen()
                CMD = New MySqlCommand("INSERT INTO member_poin (kode_member, no_transaksi, kelipatan, total_transaksi, poin) VALUES ('" & TransaksiPenjualanNhs.txtMember.Text & "', '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "', " & poin & ", " & belanja & ", " & perhitunganPoin & ") ", Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            End If
        End If
        ''--------------------END OF POINT MEMBER--------------------''

        ''--------------------TRANSAKSI JURNAL--------------------''
        cekOpen()

        If Convert.ToDouble(txtDebitA.Text) > 0 Or Convert.ToDouble(txtCC.Text) > 0 Or Convert.ToDouble(txtEMoney.Text) > 0 Then
            ''Masuk Kas per-Bank-an jika dicampur dengan Pembayaran Tunai

            Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN', '" & totalhpp & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 1)"
            CMD = New MySqlCommand(simpanjurnal3, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG', 0, '" & totalhpp & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 2)"
            CMD = New MySqlCommand(simpanjurnal4, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal2 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & TransaksiPenjualanNhs.lbltotalharga.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 4)"
            CMD = New MySqlCommand(simpanjurnal2, Conn)
            CMD.ExecuteNonQuery()

            If txtTunai.Text <> 0 Then
                Dim totalWDeposit As Double
                If cbDeposit.Checked = True Then
                    totalWDeposit = Double.Parse(TransaksiPenjualanNhs.lbltotalharga.Text) - Double.Parse(txtDeposit.Text)
                Else
                    totalWDeposit = Double.Parse(TransaksiPenjualanNhs.lbltotalharga.Text)
                End If

                Dim uangJuarnal As Double = Double.Parse(TransaksiPenjualanNhs.txtBiayaLainHide.Text) + totalWDeposit
                Dim uangMasuk As Double = Double.Parse(txtTunai.Text) - Double.Parse(TransaksiPenjualanNhs.txtBiayaLainHide.Text)

                Dim simpanjurnal1 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', '" & uangJuarnal & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 3)"
                CMD = New MySqlCommand(simpanjurnal1, Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & uangMasuk & "' WHERE kodeacc = '1-1110' ", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('1-1110', 'KAS KECIL', '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "', 1, '" & txtTunai.Text & "') 
ON DUPLICATE KEY UPDATE nominal = '" & uangMasuk & "' ", Conn)

                CMD.ExecuteNonQuery()

                Dim kodebankA As String = cbBankA.Text
                Dim kodeCC As String = cbCC.Text
                Dim kodeEmoney As String = cbEMoney.Text
                Dim strBank(), strCC(), strEmoney() As String

                If cbBankA.Text <> "" Then
                    strBank = kodebankA.Split(" - ")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd" & " " & DateTime.Now.ToString("HH:mm:ss")) & "','" & txtAccBankA.Text & "', '" & strBank(1) & "', '" & txtDebitA.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If

                If cbCC.Text <> "" Then
                    strCC = kodeCC.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & txtAccCC.Text & "', '" & strCC(1) & "', '" & txtCC.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If

                If cbEMoney.Text <> "" Then
                    strEmoney = kodeEmoney.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & txtAccEmoney.Text & "', '" & strEmoney(1) & "', '" & txtEMoney.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If
            Else
                ''Masuk Kas per-Bank-an jika semua Debit/ Kartu
                Dim kodebankA As String = cbBankA.Text
                Dim kodeCC As String = cbCC.Text
                Dim kodeEmoney As String = cbEMoney.Text
                Dim strBank(), strCC(), strEmoney() As String

                If cbBankA.Text <> "" Then
                    strBank = kodebankA.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & txtAccBankA.Text & "', '" & strBank(1) & "', '" & txtDebitA.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If

                If cbCC.Text <> "" Then
                    strCC = kodeCC.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & txtAccCC.Text & "', '" & strCC(1) & "', '" & txtCC.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If

                If cbEMoney.Text <> "" Then
                    strEmoney = kodeEmoney.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & txtAccEmoney.Text & "', '" & strEmoney(1) & "', '" & txtEMoney.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If
            End If

            If cbDeposit.Checked = True And txtDeposit.Text <> "0" Then
                Dim edit As String
                Dim simpanjurnaldepo1 As String
                'Dim simpanjurnaldepo2 As String

                edit = "UPDATE member_m SET deposit= deposit - " & txtDeposit.Text & " WHERE kode_member ='" & TransaksiPenjualanNhs.txtMember.Text & "'"
                simpanjurnaldepo1 = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','2-3101', 'DEPOSIT PELANGGAN', '" & txtDeposit.Text & "', 0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 3)"
                'simpanjurnaldepo2 = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & "','1-1110','KAS KECIL', 0, '" & txtDeposit.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 3)"
                '##Update Kas Kecil jika menggunakan Deposit
                'simpanjurnaldepo2 = "UPDATE jurnal SET debet = debet + '" & txtDeposit.Text & "' WHERE nomor_transaksi = '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "' AND kode_perkiraan = '1-1110' "

                CMD = New MySqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanjurnaldepo1, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand("INSERT INTO member_deposit VALUES ('" &
                    TransaksiPenjualanNhs.lblnomrofaktur.Text &
                    "','" & TransaksiPenjualanNhs.txtMember.Text &
                    "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") &
                    "','Keluar','" & txtDeposit.Text &
                    "','" & MainMenu.PanelUser.Text &
                    "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                    "','Transaksi Penjualan' )", Conn)
                CMD.ExecuteNonQuery()
            End If

            If TransaksiPenjualanNhs.txtBiayaLainHide.Text <> 0 Then
                Dim simpanjurnal22 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','6-1106','BIAYA PENGIRIMAN KE PELANGGAN',0, '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 6)"
                CMD = New MySqlCommand(simpanjurnal22, Conn)
                CMD.ExecuteNonQuery()

                '21Okt2020 Dihapus Revisi pa Zaki, biaya Ongkir jangan langsung masuk sekarang. nanti keluarinnya di Kas Keluar
                'Dim jurnalOngkir As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1700','BIAYA', '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', 0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                'CMD = New MySqlCommand(jurnalOngkir, Conn)
                'CMD.ExecuteNonQuery()

                'Dim simpanjurnal11 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', 0, '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 6)"
                'CMD = New MySqlCommand(simpanjurnal11, Conn)
                'CMD.ExecuteNonQuery()
            End If

        Else
            ''FULL CASH''
            Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN', '" & totalhpp & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 1)"
            CMD = New MySqlCommand(simpanjurnal3, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG', 0, '" & totalhpp & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 2)"
            CMD = New MySqlCommand(simpanjurnal4, Conn)
            CMD.ExecuteNonQuery()

            If cbDeposit.Checked = True And txtDeposit.Text <> "0" Then
                Dim edit As String
                Dim simpanjurnaldepo1 As String
                'Dim simpanjurnaldepo2 As String

                Dim totalWDeposit As Double = Double.Parse(TransaksiPenjualanNhs.lbltotalharga.Text) - Double.Parse(txtDeposit.Text)
                Dim uangJuarnal As Double = Double.Parse(TransaksiPenjualanNhs.txtBiayaLainHide.Text) + totalWDeposit

                CMD = New MySqlCommand("insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', '" & uangJuarnal & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 3)", Conn)
                CMD.ExecuteNonQuery()

                edit = "UPDATE member_m SET deposit= deposit - " & txtDeposit.Text & " WHERE kode_member ='" & TransaksiPenjualanNhs.txtMember.Text & "'"
                simpanjurnaldepo1 = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','2-3101', 'DEPOSIT PELANGGAN', '" & txtDeposit.Text & "', 0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 4)"
                'simpanjurnaldepo2 = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & "','1-1110','KAS KECIL', 0, '" & txtDeposit.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 3)"
                '##Update Kas Kecil jika menggunakan Deposit
                'simpanjurnaldepo2 = "UPDATE jurnal SET debet = debet + '" & txtDeposit.Text & "' WHERE nomor_transaksi = '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "' AND kode_perkiraan = '1-1110' "

                CMD = New MySqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanjurnaldepo1, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand("INSERT INTO member_deposit VALUES ('" &
                    TransaksiPenjualanNhs.lblnomrofaktur.Text &
                    "','" & TransaksiPenjualanNhs.txtMember.Text &
                    "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") &
                    "','Keluar','" & txtDeposit.Text &
                    "','" & MainMenu.PanelUser.Text &
                    "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                    "','Transaksi Penjualan' )", Conn)
                CMD.ExecuteNonQuery()
            Else
                Dim uangJurnalFullCash As Double = Double.Parse(TransaksiPenjualanNhs.txtBiayaLainHide.Text) + Double.Parse(TransaksiPenjualanNhs.lbltotalharga.Text)

                CMD = New MySqlCommand("insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', '" & uangJurnalFullCash & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 3)", Conn)
                CMD.ExecuteNonQuery()
            End If

            Dim simpanjurnal2 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & TransaksiPenjualanNhs.lbltotalharga.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
            CMD = New MySqlCommand(simpanjurnal2, Conn)
            CMD.ExecuteNonQuery()

            If TransaksiPenjualanNhs.txtBiayaLainHide.Text <> 0 Then
                Dim simpanjurnal22 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','6-1106','BIAYA PENGIRIMAN KE PELANGGAN',0, '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 6)"
                CMD = New MySqlCommand(simpanjurnal22, Conn)
                CMD.ExecuteNonQuery()

                '21Okt2020 Dihapus Revisi pa Zaki, biaya Ongkir jangan langsung masuk sekarang. nanti keluarinnya di Kas Keluar
                'Dim jurnalOngkir As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1700','BIAYA', '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', 0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 4)"
                'CMD = New MySqlCommand(jurnalOngkir, Conn)
                'CMD.ExecuteNonQuery()

                'Dim simpanjurnal11 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', 0, '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                'CMD = New MySqlCommand(simpanjurnal11, Conn)
                'CMD.ExecuteNonQuery()
            End If

            'Dim uangMasuk As Double = Double.Parse(txtTunai.Text) - Double.Parse(TransaksiPenjualanNhs.txtBiayaLainHide.Text)
            Dim uangMasuk As Double = TransaksiPenjualanNhs.lbltotalharga.Text
            CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & uangMasuk & "' WHERE kodeacc = '1-1110' ", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('1-1110', 'KAS KECIL', '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "', 1, '" & uangMasuk & "') 
ON DUPLICATE KEY UPDATE nominal = '" & uangMasuk & "' ", Conn)

            CMD.ExecuteNonQuery()
        End If

        cekClose()
        ''--------------------END OF TRANSAKSI JURNAL--------------------''

        Call InsertLogTrans(TransaksiPenjualanNhs.lblnomrofaktur.Text, "CREATE", MainMenu.PanelUser.Text, "PENJUALAN - CASH Total Rp. " & TransaksiPenjualanNhs.lbltotalharga.Text)

        MsgBox("Data Transaksi Berhasil Disimpan!")
        Call ClearTransaksiPending()

    End Sub

    Sub SimpanTransaksiKredit()
        Call TransaksiPenjualanNhs.NomorOtomatis()

        Dim jatuhtempo As String = Format(DateAdd(DateInterval.Day, 7, Today), "yyyy-MM-dd")
        'Penanda dia Debit tapi dibayar Transfer
        If cbTransfer.Checked = True Then
            transfer = 1
        Else
            transfer = 0
        End If

        Dim ongkir As Double = Double.Parse(TransaksiPenjualanNhs.txtBiayaLainHide.Text)
        Dim valueDeposit As Double = 0

        If cbDeposit.Checked = True Then
            valueDeposit = Double.Parse(txtDeposit.Text)
        End If

        cekOpen()
        Dim simpan1 As String = "INSERT INTO penjualan (faktur_jual, tgl_jual, item_jual, total_diskon, total_jual, bayar_jual, kembali_jual, cara_jual, sisa_piutang, jth_tempo_jual, status_jual, kode_customer, kode_user, tunai, kredit, debit_a, bank_a, kartu_a, debit_b, bank_b, kartu_b, credit_card, bank_cc, kartu_cc, emoney, bank_emoney, kartu_emoney, transfer, ongkir, deposit, keterangan, jenis_member) values ('" &
            TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" &
            Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & "','" &
            TransaksiPenjualanNhs.lbljumlahbarang.Text & "','" &
            TransaksiPenjualanNhs.lbltotaldiskon.Text & "','" &
            TransaksiPenjualanNhs.lbltotalharga.Text & "','" &
            totalDibayarSebelumKredit & "','" &
            txtKembalianHide.Text & "', 'KREDIT', '" &
            txtKredit.Text & "', '" & jatuhtempo & "', 'BELUM LUNAS', '" &
            txtMember.Text & "','" &
            MainMenu.PanelUser.Text & "','" &
            txtTunai.Text & "','" &
            txtKredit.Text & "','" &
            txtDebitA.Text & "','" &
            cbBankA.Text & "','" &
            txtNoBankA.Text & "','" &
            txtDebitB.Text & "','" &
            cbBankB.Text & "','" &
            txtNoBankB.Text & "','" &
            txtCC.Text & "','" &
            cbCC.Text & "','" &
            txtNoCC.Text & "','" &
            txtEMoney.Text & "','" &
            cbEMoney.Text & "','" &
            txtNoEMoney.Text & "', " & transfer & ", " & TransaksiPenjualanNhs.txtBiayaLainHide.Text & ", '" & valueDeposit & "', '" & TransaksiPenjualanNhs.txtKeterangan.Text & "', '" & TransaksiPenjualanNhs.lookUpEdit.EditValue.ToString & "' )"

        CMD = New MySqlCommand(simpan1, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        Dim totalhpp As Double
        For baris As Integer = 0 To TransaksiPenjualanNhs.DGV.RowCount - 2

            cekOpen()
            Dim simpan2 As String = "insert into detailjual values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "','" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(4).Value & "','" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value & "','" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(8).Value & "','-', '" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(6).Value & "', '" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(7).Value & "', 0)"
            CMD = New MySqlCommand(simpan2, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("select * from barang_m where kode_item='" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                Dim kurangistok As String = "update barang_m set stok= stok - '" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value & "' where kode_item='" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "'"
                Dim stokAwal As Integer = DR.Item("stok")
                Dim stokAkhir As Integer = DR.Item("stok") - TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value
                totalhpp += DR.Item("hpp") * TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value
                cekClose()

                'Update Stok
                cekOpen()
                CMD = New MySqlCommand(kurangistok, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                cekOpen()
                Dim updatehistory As String = "INSERT INTO history_stok VALUES ( '" &
                        TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "', '" &
                        TransaksiPenjualanNhs.lblnomrofaktur.Text & "', '" &
                        Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & "', 'Penjualan', '" &
                        stokAwal & "', '" &
                        TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value & "', '" &
                        stokAkhir & "', '" &
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" &
                        MainMenu.PanelUser.Text & "' )"
                CMD = New MySqlCommand(updatehistory, Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            End If
        Next

        If Convert.ToDouble(txtTunai.Text) > 0 Or Convert.ToDouble(txtDebitA.Text) > 0 Or Convert.ToDouble(txtCC.Text) > 0 Or Convert.ToDouble(txtEMoney.Text) > 0 Then
            ''------------MsgBox("CASH + HUTANG")------------''
            ''DENGAN DEBIT/ PerKartuan
            cekOpen()
            Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1210','PIUTANG USAHA', '" & txtKredit.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 2)"
            CMD = New MySqlCommand(simpanjurnal3, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', '" & totalDibayarSebelumKredit & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 3)"
            CMD = New MySqlCommand(simpanjurnal4, Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & totalDibayarSebelumKredit & "' WHERE kodeacc = '1-1110' ", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('1-1110', 'KAS KECIL', '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "', 1, '" & totalDibayarSebelumKredit & "')
ON DUPLICATE KEY UPDATE nominal = '" & totalDibayarSebelumKredit & "' ", Conn)
            CMD.ExecuteNonQuery()

            If txtDeposit.Text <> 0 Then
                Dim edit As String
                Dim simpanjurnaldepo1 As String
                Dim simpanjurnaldepo2 As String

                edit = "UPDATE member_m SET deposit= deposit - " & txtDeposit.Text & " WHERE kode_member ='" & TransaksiPenjualanNhs.txtMember.Text & "'"
                simpanjurnaldepo1 = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','2-3101', 'DEPOSIT PELANGGAN', '" & txtDeposit.Text & "', 0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 4)"
                simpanjurnaldepo2 = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', 0, '" & txtDeposit.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"

                CMD = New MySqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanjurnaldepo1, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanjurnaldepo2, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand("INSERT INTO member_deposit VALUES ('" &
                    TransaksiPenjualanNhs.lblnomrofaktur.Text &
                    "','" & TransaksiPenjualanNhs.txtMember.Text &
                    "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") &
                    "','Keluar','" & txtDeposit.Text &
                    "','" & MainMenu.PanelUser.Text &
                    "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                    "','Transaksi Penjualan' )", Conn)
                CMD.ExecuteNonQuery()
            End If

            Dim kodebankA As String = cbBankA.Text
            Dim kodeCC As String = cbCC.Text
            Dim kodeEmoney As String = cbEMoney.Text
            Dim strBank(), strCC(), strEmoney() As String

            If cbBankA.Text <> "" Then
                strBank = kodebankA.Split("-")
                Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & txtAccBankA.Text & "', '" & strBank(1) & "', '" & txtDebitA.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 6)"
                CMD = New MySqlCommand(simpanjurnalBank, Conn)
                CMD.ExecuteNonQuery()
            End If

            If cbCC.Text <> "" Then
                strCC = kodeCC.Split("-")
                Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & txtAccCC.Text & "', '" & strCC(1) & "', '" & txtCC.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 7)"
                CMD = New MySqlCommand(simpanjurnalBank, Conn)
                CMD.ExecuteNonQuery()
            End If

            If cbEMoney.Text <> "" Then
                strEmoney = kodeEmoney.Split("-")
                Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & txtAccEmoney.Text & "', '" & strEmoney(1) & "', '" & txtEMoney.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 8)"
                CMD = New MySqlCommand(simpanjurnalBank, Conn)
                CMD.ExecuteNonQuery()
            End If

            Dim simpanjurnal5 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & TransaksiPenjualanNhs.lbltotalharga.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 1)"
            CMD = New MySqlCommand(simpanjurnal5, Conn)
            CMD.ExecuteNonQuery()

            If TransaksiPenjualanNhs.txtBiayaLainHide.Text <> 0 Then
                Dim simpanjurnal22 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','6-1106','BIAYA PENGIRIMAN KE PELANGGAN',0, '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 9)"
                CMD = New MySqlCommand(simpanjurnal22, Conn)
                CMD.ExecuteNonQuery()

                'Dim jurnalOngkir As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1700','BIAYA', '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', 0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 10)"
                'CMD = New MySqlCommand(jurnalOngkir, Conn)
                'CMD.ExecuteNonQuery()

                'Dim simpanjurnal11 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', 0, '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 11)"
                'CMD = New MySqlCommand(simpanjurnal11, Conn)
                'CMD.ExecuteNonQuery()
            End If

            Dim simpanjurnal6 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN','" & totalhpp & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 12)"
            CMD = New MySqlCommand(simpanjurnal6, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal7 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG',0, '" & totalhpp & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 13)"
            CMD = New MySqlCommand(simpanjurnal7, Conn)
            CMD.ExecuteNonQuery()

            cekClose()
        Else
            'MsgBox("HUTANG DOANG")
            cekOpen()
            If TransaksiPenjualanNhs.txtBiayaLainHide.Text <> 0 Then

                Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1210','PIUTANG USAHA', '" & txtKredit.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 1)"
                CMD = New MySqlCommand(simpanjurnal3, Conn)
                CMD.ExecuteNonQuery()

                Dim simpanjurnal22 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & TransaksiPenjualanNhs.lbltotalharga.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 2)"
                CMD = New MySqlCommand(simpanjurnal22, Conn)
                CMD.ExecuteNonQuery()

                Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','6-1106','BIAYA PENGIRIMAN KE PELANGGAN',0, '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 3)"
                CMD = New MySqlCommand(simpanjurnal4, Conn)
                CMD.ExecuteNonQuery()

                'Dim jurnalOngkir As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1700','BIAYA', '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', 0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 4)"
                'CMD = New MySqlCommand(jurnalOngkir, Conn)
                'CMD.ExecuteNonQuery()

                'Dim simpanjurnal11 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', 0, '" & TransaksiPenjualanNhs.txtBiayaLainHide.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 5)"
                'CMD = New MySqlCommand(simpanjurnal11, Conn)
                'CMD.ExecuteNonQuery()

            Else
                Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1210','PIUTANG USAHA', '" & txtKredit.Text & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 1)"
                CMD = New MySqlCommand(simpanjurnal3, Conn)
                CMD.ExecuteNonQuery()

                Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & txtKredit.Text & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 2)"
                CMD = New MySqlCommand(simpanjurnal4, Conn)
                CMD.ExecuteNonQuery()
            End If

            Dim simpanjurnal5 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN','" & totalhpp & "',0, '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 6)"
            CMD = New MySqlCommand(simpanjurnal5, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal6 As String = "insert into jurnal values ('" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualanNhs.dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG',0, '" & totalhpp & "', '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "', 2, 7)"
            CMD = New MySqlCommand(simpanjurnal6, Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        End If

        '## Update Status Order ##'
        If TransaksiPenjualanNhs.txtNoPesanan.Text <> "" Then
            cekOpen()
            CMD = New MySqlCommand("UPDATE penjualan_order SET status = 0 WHERE faktur_jual = '" & TransaksiPenjualanNhs.txtNoPesanan.Text & "' ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        End If

        Call InsertLogTrans(TransaksiPenjualanNhs.lblnomrofaktur.Text, "CREATE", MainMenu.PanelUser.Text, "PENJUALAN - KREDIT/CASH Total Rp. " & TransaksiPenjualanNhs.lbltotalharga.Text)

        MsgBox("Data Transaksi Berhasil Disimpan!")
        Call ClearTransaksiPending()

    End Sub

    Sub ClearTransaksiPending()

        If TransaksiPenjualanNhs.txtNoFakturPending.Text <> "" Then
            cekClose()
            cekOpen()
            CMD = New MySqlCommand("UPDATE pending_jual SET status = 0 WHERE faktur_jual = '" & TransaksiPenjualanNhs.txtNoFakturPending.Text & "' ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        End If

        Call DaftarPenjualan.TampilGrid()
    End Sub

    Private Sub txtNoBankA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoBankA.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtNoBankB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoBankB.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtNoCC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoCC.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtNoEMoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoEMoney.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Sub Kosongkan()
        CallBank()
        txtMember.Text = TransaksiPenjualanNhs.txtMember.Text & "/" & TransaksiPenjualanNhs.lblkodecustomer.Text
        txtTunai.Text = "0"
        txtKredit.Text = "0"
        txtDebitA.Text = "0"
        txtDebitB.Text = "0"
        txtCC.Text = "0"
        txtEMoney.Text = "0"
        txtNoBankA.Text = ""
        txtNoBankB.Text = ""
        txtNoCC.Text = ""
        txtNoEMoney.Text = ""
        cbDeposit.Checked = False
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub cbBankA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBankA.SelectedIndexChanged
        Dim kodeBankA As String = cbBankA.Text
        Dim strArr() As String

        strArr = kodeBankA.Split("-")
        cekOpen()
        CMD = New MySqlCommand("SELECT kodeacc FROM bank_m WHERE id_bank = '" & strArr(0) & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        txtAccBankA.Text = DR.Item("kodeacc")
        cekClose()
    End Sub

    Private Sub cbCC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCC.SelectedIndexChanged
        Dim kodeCC As String = cbCC.Text
        Dim strArr() As String

        strArr = kodeCC.Split("-")
        cekOpen()
        CMD = New MySqlCommand("SELECT kodeacc FROM bank_m WHERE id_bank = '" & strArr(0) & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        txtAccCC.Text = DR.Item("kodeacc")
        cekClose()
    End Sub

    Private Sub cbEMoney_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEMoney.SelectedIndexChanged
        Dim kodEmoney As String = cbEMoney.Text
        Dim strArr() As String

        strArr = kodEmoney.Split("-")
        cekOpen()
        CMD = New MySqlCommand("SELECT kodeacc FROM bank_m WHERE id_bank = '" & strArr(0) & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        txtAccEmoney.Text = DR.Item("kodeacc")
        cekClose()
    End Sub

    Private Sub cbDeposit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDeposit.CheckedChanged
        Call JumlahkanPembayaran()
    End Sub

    Private Sub txtDeposit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeposit.LostFocus
        If Convert.ToDouble(txtDeposit.Text) > depositMember Then
            MsgBox("Jumlah Melebihi dari Deposit Member")
            txtDeposit.Text = depositMember
            txtDepositHide.Text = depositMember
        End If
    End Sub

    Private Sub txtDeposit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeposit.TextChanged
        Call JumlahkanPembayaran()
    End Sub

    Private Sub txtTunai_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTunai.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtTunai_TextChanged(sender As Object, e As EventArgs) Handles txtTunai.TextChanged
        Call JumlahkanPembayaran()
    End Sub

    Private Sub txtKredit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKredit.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Me.btnSimpan.PerformClick()
                e.Handled = False
            Case Keys.F9
                Me.btnSimpanCetak.PerformClick()
                e.Handled = False
            Case Keys.Escape
                Me.btnTutup.PerformClick()
                e.Handled = False
        End Select
    End Sub

    Private Sub txtKredit_TextChanged(sender As Object, e As EventArgs) Handles txtKredit.TextChanged
        Call JumlahkanPembayaran()
    End Sub

    Function CheckStokFirst()
        ItemKosong.Clear()

        Dim lolos As Boolean = True
        For baris As Integer = 0 To TransaksiPenjualanNhs.DGV.RowCount - 2

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item='" & TransaksiPenjualanNhs.DGV.Rows(baris).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                If TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value > DR.Item("stok") Then
                    ItemKosong.AppendLine(DR.Item("nama_barang") + " | Qty Jual : " + TransaksiPenjualanNhs.DGV.Rows(baris).Cells(5).Value.ToString + " | Stok : " + DR.Item("stok").ToString)
                    lolos = False
                End If
            End If
            cekClose()
        Next

        Return lolos
    End Function

    Private Sub btnFakturBesar_Click(sender As Object, e As EventArgs) Handles btnFakturBesar.Click
        'Cetak1.Show()
        Dim printerName As String = GetPrinterLaporan()

        If totalDibayar < totalTransaksi Then
            MsgBox("Total Pembayaran lebih kecil dari Nilai Transaksi")
            validasi = False
            'Exit Sub
        Else
            validasi = True
        End If

        If Convert.ToDouble(txtDebitA.Text) > 0 And cbBankA.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbBankA.Focus()
            cbBankA.Select()
            validasi = False
            'Exit Sub
        End If

        If Convert.ToDouble(txtCC.Text) > 0 And cbCC.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbCC.Focus()
            cbCC.Select()
            validasi = False
            'Exit Sub
        End If

        If Convert.ToDouble(txtEMoney.Text) > 0 And cbEMoney.Text = "" Then
            MsgBox("Silahkan Pilih Bank")
            cbEMoney.Focus()
            cbEMoney.Select()
            validasi = False
            'Exit Sub
        End If

        If validasi = True Then
            Call TransaksiPenjualanNhs.NomorOtomatis()

            If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                If CheckStokFirst() = True Then
                    'SplashScreenManager1.ShowWaitForm()

                    If Convert.ToDouble(txtKredit.Text) > 0 Then
                        Call SimpanTransaksiKredit()

                    Else
                        Call SimpanTransaksiCash()

                    End If

                    '### Upload Transaksi ###'
                    Call uploadPenjualan(TransaksiPenjualanNhs.lblnomrofaktur.Text)

                    '### Cetak Struk ###'
                    If printerName = "empty" Then
                        CetakFaktur.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "'"
                        cryRpt.Load("FakturJualBesar.rpt")
                        Call seting_laporan()
                        CetakFaktur.CRV.ReportSource = cryRpt
                        CetakFaktur.CRV.RefreshReport()
                        cryRpt.PrintToPrinter(1, True, 0, 0)
                    Else
                        CetakFaktur.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & TransaksiPenjualanNhs.lblnomrofaktur.Text & "'"
                        cryRpt.Load("FakturJualBesar.rpt")
                        Call seting_laporan()
                        CetakFaktur.CRV.ReportSource = cryRpt
                        CetakFaktur.CRV.RefreshReport()
                        cryRpt.PrintOptions.PrinterName = printerName
                        cryRpt.PrintToPrinter(1, True, 0, 0)
                    End If

                    TransaksiPenjualanNhs.Kosongkan()
                    TransaksiPenjualanNhs.NomorOtomatis()
                    TransaksiPenjualanNhs.DGV.Rows.Clear()
                    Call HapusDaftarJual()

                    'SplashScreenManager1.CloseWaitForm()
                    Me.Close()
                Else
                    MsgBox("Mohon Maaf, terdapat penjualan yang melebihi Stok! Silahkan periksa kembali item yang di jual." + vbNewLine + vbNewLine + ItemKosong.ToString, MsgBoxStyle.Critical, "Perhatian!")
                End If
            End If
        End If
    End Sub

    Sub HapusDaftarJual()
        cekOpen()
        CMD = New MySqlCommand("UPDATE pending_jual SET status = 0 WHERE faktur_jual = '" & TransaksiPenjualanNhs.txtNoFakturPending.Text & "' ", Conn)
        CMD.ExecuteNonQuery()
        cekClose()
    End Sub
End Class