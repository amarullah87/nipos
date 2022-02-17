Imports MySql.Data.MySqlClient

Public Class DialogPembayaran
    Dim kredit As Double
    Dim totalTransaksi As Double
    Dim totalBayar As Double
    Dim totalDibayar As Double
    Dim totalDibayarSebelumKredit As Double
    Dim kembalian As Double
    Dim validasi As Boolean = True
    Dim depositMember As Double

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub GetDataDeposit()

        If TransaksiPenjualan.txtMember.Text = "00000" Then
            depositMember = 0
            txtDeposit.Text = 0
            txtDepositHide.Text = 0
        Else
            cekOpen()
            CMD = New MySqlCommand("SELECT deposit FROM member_m WHERE kode_member = '" & TransaksiPenjualan.txtMember.Text & "' ", Conn)
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
        End If
    End Sub

    Sub CallBank()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM bank_m WHERE active = 1 ORDER BY nama_bank", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            cbBankA.Items.Add(DR.Item("id_bank") & "-" & DR.Item("nama_bank"))
            cbBankB.Items.Add(DR.Item("id_bank") & "-" & DR.Item("nama_bank"))
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

    Private Sub DialogPembayaran_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Me.CenterToScreen()
        txtTunai.Focus()
        txtTunai.Select()
        totalTransaksi = TransaksiPenjualan.lbltotalharga.Text
        txtTotal.Text = FormatCurrency(totalTransaksi)

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
            totalDibayar = Format(Val(txtTunai.Text.Replace(",", "")) + Val(txtDebitA.Text.Replace(",", "")) + Val(txtDebitB.Text.Replace(",", "")) + Val(txtCC.Text.Replace(",", "")) + Val(txtEMoney.Text.Replace(",", "")) + Val(txtKredit.Text.Replace(",", "")), "0.00")
            totalDibayarSebelumKredit = Format(Val(txtTunai.Text.Replace(",", "")) + Val(txtDebitA.Text.Replace(",", "")) + Val(txtDebitB.Text.Replace(",", "")) + Val(txtCC.Text.Replace(",", "")) + Val(txtEMoney.Text.Replace(",", "")), "0.00")
            kembalian = totalDibayar - totalTransaksi

            txtDeposit.ReadOnly = True
        Else
            totalDibayar = Format(Val(txtTunai.Text.Replace(",", "")) + Val(txtDebitA.Text.Replace(",", "")) + Val(txtDebitB.Text.Replace(",", "")) + Val(txtCC.Text.Replace(",", "")) + Val(txtEMoney.Text.Replace(",", "")) + Val(txtKredit.Text.Replace(",", "")) + Val(txtDeposit.Text.Replace(",", "")), "0.00")
            totalDibayarSebelumKredit = Format(Val(txtTunai.Text.Replace(",", "")) + Val(txtDebitA.Text.Replace(",", "")) + Val(txtDebitB.Text.Replace(",", "")) + Val(txtCC.Text.Replace(",", "")) + Val(txtEMoney.Text.Replace(",", "")) + +Val(txtDeposit.Text.Replace(",", "")), "0.00")
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

        If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If Convert.ToDouble(txtKredit.Text) > 0 Then
                Call SimpanTransaksiKredit()

            Else
                Call SimpanTransaksiCash()

            End If

            '### Upload Transaksi ###'
            Call uploadPenjualan(TransaksiPenjualan.lblnomrofaktur.Text)

            '### Cetak Struk ###'
            'Cetak1.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & TransaksiPenjualan.lblnomrofaktur.Text & "'"
            'cryRpt.Load("report\FakturJual.rpt")
            'Call seting_laporan()
            'Cetak1.CRV.ReportSource = cryRpt
            'Cetak1.CRV.RefreshReport()
            'cryRpt.PrintToPrinter(1, True, 0, 0)

            TransaksiPenjualan.Kosongkan()
            TransaksiPenjualan.NomorOtomatis()
            TransaksiPenjualan.DGV.Rows.Clear()
            Me.Close()
        End If
    End Sub

    Sub CekKredit()
        If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If Convert.ToDouble(txtKredit.Text) > 0 Then
                Call SimpanTransaksiKredit()
            Else
                Call SimpanTransaksiCash()
            End If
        End If

        '### Upload Transaksi ###'
        Call uploadPenjualan(TransaksiPenjualan.lblnomrofaktur.Text)

        TransaksiPenjualan.Kosongkan()
        TransaksiPenjualan.NomorOtomatis()
        TransaksiPenjualan.DGV.Rows.Clear()
        Me.Close()
    End Sub
    Sub SimpanTransaksiCash()
        'MsgBox("CASH")
        cekOpen()
        Dim simpan1 As String = "INSERT INTO penjualan (faktur_jual, tgl_jual, item_jual, total_diskon, total_jual, bayar_jual, kembali_jual, cara_jual, sisa_piutang, jth_tempo_jual, status_jual, kode_customer, kode_user, tunai, kredit, debit_a, bank_a, kartu_a, debit_b, bank_b, kartu_b, credit_card, bank_cc, kartu_cc, emoney, bank_emoney, kartu_emoney) values ('" &
            TransaksiPenjualan.lblnomrofaktur.Text & "','" &
            Format(TransaksiPenjualan.dtptanggal.Value, "yyyy-MM-dd") & "','" &
            TransaksiPenjualan.lbljumlahbarang.Text & "','" &
            TransaksiPenjualan.lbltotaldiskon.Text & "','" &
            TransaksiPenjualan.lbltotalharga.Text & "','" &
            txtTotalBayarHide.Text & "','" &
            txtKembalianHide.Text & "', 'CASH', '0', '" & Format(Now, "yyyy-MM-dd") & "', 'LUNAS', '" &
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
            txtNoEMoney.Text & "' )"

        CMD = New MySqlCommand(simpan1, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        Dim totalhpp As Double
        For baris As Integer = 0 To TransaksiPenjualan.DGV.RowCount - 2

            cekOpen()
            Dim simpan2 As String = "insert into detailjual values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & TransaksiPenjualan.DGV.Rows(baris).Cells(0).Value & "','" & TransaksiPenjualan.DGV.Rows(baris).Cells(4).Value & "','" & TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value & "','" & TransaksiPenjualan.DGV.Rows(baris).Cells(7).Value & "','-', '" & TransaksiPenjualan.DGV.Rows(baris).Cells(6).Value & "', 0)"
            CMD = New MySqlCommand(simpan2, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("select * from barang_m where kode_item='" & TransaksiPenjualan.DGV.Rows(baris).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                Dim kurangistok As String = "update barang_m set stok='" & DR.Item("stok") - TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value & "' where kode_item='" & TransaksiPenjualan.DGV.Rows(baris).Cells(0).Value & "'"
                Dim stokAwal As Integer = DR.Item("stok")
                Dim stokAkhir As Integer = DR.Item("stok") - TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value
                totalhpp += DR.Item("hpp") * TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value
                cekClose()

                'Update Stok
                cekOpen()
                CMD = New MySqlCommand(kurangistok, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                cekOpen()
                Dim updatehistory As String = "INSERT INTO history_stok VALUES ( '" &
                        TransaksiPenjualan.DGV.Rows(baris).Cells(0).Value & "', '" &
                        TransaksiPenjualan.lblnomrofaktur.Text & "', '" &
                        Format(TransaksiPenjualan.dtptanggal.Value, "yyyy-MM-dd") & "', 'Penjualan', '" &
                        stokAwal & "', '" &
                        TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value & "', '" &
                        stokAkhir & "', '" &
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" &
                        MainMenu.PanelUser.Text & "' )"
                CMD = New MySqlCommand(updatehistory, Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            End If
        Next

        ''--------------------TRANSAKSI JURNAL--------------------''
        cekOpen()

        If Convert.ToDouble(txtDebitA.Text) > 0 Or Convert.ToDouble(txtCC.Text) > 0 Or Convert.ToDouble(txtEMoney.Text) > 0 Then
            ''Masuk Kas per-Bank-an jika dicampur dengan Pembayaran Tunai
            If txtTunai.Text <> 0 Then
                Dim simpanjurnal1 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1110','KAS KECIL', '" & txtTunai.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 1)"
                CMD = New MySqlCommand(simpanjurnal1, Conn)
                CMD.ExecuteNonQuery()

                If txtDeposit.Text <> 0 Then
                    Dim edit As String
                    Dim simpanjurnaldepo1 As String
                    Dim simpanjurnaldepo2 As String

                    edit = "UPDATE member_m SET deposit= deposit - " & txtDeposit.Text & " WHERE kode_member ='" & TransaksiPenjualan.txtMember.Text & "'"
                    simpanjurnaldepo1 = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualan.dtptanggal.Value, "yyyy-MM-dd") & "','2-3101', 'DEPOSIT PELANGGAN', '" & txtDeposit.Text & "', 0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 2)"
                    simpanjurnaldepo2 = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualan.dtptanggal.Value, "yyyy-MM-dd") & "','1-1110','KAS KECIL', 0, '" & txtDeposit.Text & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 3)"

                    CMD = New MySqlCommand(edit, Conn)
                    CMD.ExecuteNonQuery()
                    CMD = New MySqlCommand(simpanjurnaldepo1, Conn)
                    CMD.ExecuteNonQuery()
                    CMD = New MySqlCommand(simpanjurnaldepo2, Conn)
                    CMD.ExecuteNonQuery()
                End If

                Dim kodebankA As String = cbBankA.Text
                Dim kodeCC As String = cbCC.Text
                Dim kodeEmoney As String = cbEMoney.Text
                Dim strBank(), strCC(), strEmoney() As String

                If cbBankA.Text <> "" Then
                    strBank = kodebankA.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccBankA.Text & "', '" & strBank(1) & "', '" & txtDebitA.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If

                If cbCC.Text <> "" Then
                    strCC = kodeCC.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccCC.Text & "', '" & strCC(1) & "', '" & txtCC.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If

                If cbEMoney.Text <> "" Then
                    strEmoney = kodeEmoney.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccEmoney.Text & "', '" & strEmoney(1) & "', '" & txtEMoney.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"
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
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccBankA.Text & "', '" & strBank(1) & "', '" & txtDebitA.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If

                If cbCC.Text <> "" Then
                    strCC = kodeCC.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccCC.Text & "', '" & strCC(1) & "', '" & txtCC.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If

                If cbEMoney.Text <> "" Then
                    strEmoney = kodeEmoney.Split("-")
                    Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccEmoney.Text & "', '" & strEmoney(1) & "', '" & txtEMoney.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"
                    CMD = New MySqlCommand(simpanjurnalBank, Conn)
                    CMD.ExecuteNonQuery()
                End If
            End If

            Dim simpanjurnal2 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & TransaksiPenjualan.lbltotalharga.Text & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 5)"
            CMD = New MySqlCommand(simpanjurnal2, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN', '" & totalhpp & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 6)"
            CMD = New MySqlCommand(simpanjurnal3, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG', 0, '" & totalhpp & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 7)"
            CMD = New MySqlCommand(simpanjurnal4, Conn)
            CMD.ExecuteNonQuery()

        Else
            ''FULL CASH''
            Dim simpanjurnal1 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1110','KAS KECIL', '" & TransaksiPenjualan.lbltotalharga.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 1)"
            CMD = New MySqlCommand(simpanjurnal1, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal2 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & TransaksiPenjualan.lbltotalharga.Text & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 2)"
            CMD = New MySqlCommand(simpanjurnal2, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN', '" & totalhpp & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 3)"
            CMD = New MySqlCommand(simpanjurnal3, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG', 0, '" & totalhpp & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"
            CMD = New MySqlCommand(simpanjurnal4, Conn)
            CMD.ExecuteNonQuery()
        End If

        cekClose()
        ''--------------------END OF TRANSAKSI JURNAL--------------------''

        MsgBox("Data Transaksi Berhasil Disimpan!")

    End Sub

    Sub SimpanTransaksiKredit()

        Dim jatuhtempo As String = Format(DateAdd(DateInterval.Day, 7, Today), "yyyy-MM-dd")

        cekOpen()
        Dim simpan1 As String = "INSERT INTO penjualan (faktur_jual, tgl_jual, item_jual, total_diskon, total_jual, bayar_jual, kembali_jual, cara_jual, sisa_piutang, jth_tempo_jual, status_jual, kode_customer, kode_user, tunai, kredit, debit_a, bank_a, kartu_a, debit_b, bank_b, kartu_b, credit_card, bank_cc, kartu_cc, emoney, bank_emoney, kartu_emoney) values ('" &
            TransaksiPenjualan.lblnomrofaktur.Text & "','" &
            Format(TransaksiPenjualan.dtptanggal.Value, "yyyy-MM-dd") & "','" &
            TransaksiPenjualan.lbljumlahbarang.Text & "','" &
            TransaksiPenjualan.lbltotaldiskon.Text & "','" &
            TransaksiPenjualan.lbltotalharga.Text & "','" &
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
            txtNoEMoney.Text & "' )"
        CMD = New MySqlCommand(simpan1, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        Dim totalhpp As Double
        For baris As Integer = 0 To TransaksiPenjualan.DGV.RowCount - 2

            cekOpen()
            Dim simpan2 As String = "insert into detailjual values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & TransaksiPenjualan.DGV.Rows(baris).Cells(0).Value & "','" & TransaksiPenjualan.DGV.Rows(baris).Cells(4).Value & "','" & TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value & "','" & TransaksiPenjualan.DGV.Rows(baris).Cells(7).Value & "','-', '" & TransaksiPenjualan.DGV.Rows(baris).Cells(6).Value & "', 0)"
            CMD = New MySqlCommand(simpan2, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("select * from barang_m where kode_item='" & TransaksiPenjualan.DGV.Rows(baris).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                Dim kurangistok As String = "update barang_m set stok='" & DR.Item("stok") - TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value & "' where kode_item='" & TransaksiPenjualan.DGV.Rows(baris).Cells(0).Value & "'"
                Dim stokAwal As Integer = DR.Item("stok")
                Dim stokAkhir As Integer = DR.Item("stok") - TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value
                totalhpp += DR.Item("hpp") * TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value
                cekClose()

                'Update Stok
                cekOpen()
                CMD = New MySqlCommand(kurangistok, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                cekOpen()
                Dim updatehistory As String = "INSERT INTO history_stok VALUES ( '" &
                        TransaksiPenjualan.DGV.Rows(baris).Cells(0).Value & "', '" &
                        TransaksiPenjualan.lblnomrofaktur.Text & "', '" &
                        Format(TransaksiPenjualan.dtptanggal.Value, "yyyy-MM-dd") & "', 'Penjualan', '" &
                        stokAwal & "', '" &
                        TransaksiPenjualan.DGV.Rows(baris).Cells(5).Value & "', '" &
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
            Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1210','PIUTANG USAHA', '" & txtKredit.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 1)"
            CMD = New MySqlCommand(simpanjurnal3, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1110','KAS KECIL', '" & totalDibayarSebelumKredit & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 2)"
            CMD = New MySqlCommand(simpanjurnal4, Conn)
            CMD.ExecuteNonQuery()

            If txtDeposit.Text <> 0 Then
                Dim edit As String
                Dim simpanjurnaldepo1 As String
                Dim simpanjurnaldepo2 As String

                edit = "UPDATE member_m SET deposit= deposit - " & txtDeposit.Text & " WHERE kode_member ='" & TransaksiPenjualan.txtMember.Text & "'"
                simpanjurnaldepo1 = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualan.dtptanggal.Value, "yyyy-MM-dd") & "','2-3101', 'DEPOSIT PELANGGAN', '" & txtDeposit.Text & "', 0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 3)"
                simpanjurnaldepo2 = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & Format(TransaksiPenjualan.dtptanggal.Value, "yyyy-MM-dd") & "','1-1110','KAS KECIL', 0, '" & txtDeposit.Text & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"

                CMD = New MySqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanjurnaldepo1, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanjurnaldepo2, Conn)
                CMD.ExecuteNonQuery()
            End If

            Dim kodebankA As String = cbBankA.Text
            Dim kodeCC As String = cbCC.Text
            Dim kodeEmoney As String = cbEMoney.Text
            Dim strBank(), strCC(), strEmoney() As String

            If cbBankA.Text <> "" Then
                strBank = kodebankA.Split("-")
                Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccBankA.Text & "', '" & strBank(1) & "', '" & txtDebitA.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 5)"
                CMD = New MySqlCommand(simpanjurnalBank, Conn)
                CMD.ExecuteNonQuery()
            End If

            If cbCC.Text <> "" Then
                strCC = kodeCC.Split("-")
                Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccCC.Text & "', '" & strCC(1) & "', '" & txtCC.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 5)"
                CMD = New MySqlCommand(simpanjurnalBank, Conn)
                CMD.ExecuteNonQuery()
            End If

            If cbEMoney.Text <> "" Then
                strEmoney = kodeEmoney.Split("-")
                Dim simpanjurnalBank As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & txtAccEmoney.Text & "', '" & strEmoney(1) & "', '" & txtEMoney.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 5)"
                CMD = New MySqlCommand(simpanjurnalBank, Conn)
                CMD.ExecuteNonQuery()
            End If

            Dim simpanjurnal5 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & TransaksiPenjualan.lbltotalharga.Text & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 5)"
            CMD = New MySqlCommand(simpanjurnal5, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal6 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN','" & totalhpp & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 6)"
            CMD = New MySqlCommand(simpanjurnal6, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal7 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG',0, '" & totalhpp & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 7)"
            CMD = New MySqlCommand(simpanjurnal7, Conn)
            CMD.ExecuteNonQuery()

            cekClose()
        Else
            'MsgBox("HUTANG DOANG")
            cekOpen()
            Dim simpanjurnal3 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1210','PIUTANG USAHA', '" & txtKredit.Text & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 1)"
            CMD = New MySqlCommand(simpanjurnal3, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal4 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','4-1100','PENDAPATAN JUAL',0, '" & txtKredit.Text & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 2)"
            CMD = New MySqlCommand(simpanjurnal4, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal5 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN','" & totalhpp & "',0, '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 3)"
            CMD = New MySqlCommand(simpanjurnal5, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal6 As String = "insert into jurnal values ('" & TransaksiPenjualan.lblnomrofaktur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG',0, '" & totalhpp & "', '" & TransaksiPenjualan.txtNoPesanan.Text & "', 2, 4)"
            CMD = New MySqlCommand(simpanjurnal6, Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        End If

        '## Update Status Order ##'
        If TransaksiPenjualan.txtNoPesanan.Text <> "" Then
            cekOpen()
            CMD = New MySqlCommand("UPDATE penjualan_order SET status = 0 WHERE faktur_jual = '" & TransaksiPenjualan.txtNoPesanan.Text & "' ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        End If

        MsgBox("Data Transaksi Berhasil Disimpan!")

    End Sub

    Private Sub txtNoBankA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoBankA.KeyDown
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

    Private Sub txtNoBankB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoBankB.KeyDown
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

    Private Sub txtNoCC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoCC.KeyDown
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

    Private Sub txtNoEMoney_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoEMoney.KeyDown
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
        txtMember.Text = TransaksiPenjualan.txtMember.Text & "/" & TransaksiPenjualan.lblkodecustomer.Text
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
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub cbBankA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBankA.SelectedIndexChanged
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

    Private Sub cbCC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCC.SelectedIndexChanged
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

    Private Sub cbEMoney_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEMoney.SelectedIndexChanged
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

    Private Sub cbDeposit_CheckedChanged(sender As Object, e As EventArgs) Handles cbDeposit.CheckedChanged
        Call JumlahkanPembayaran()
    End Sub

    Private Sub txtDeposit_LostFocus(sender As Object, e As EventArgs) Handles txtDeposit.LostFocus
        If Convert.ToDouble(txtDeposit.Text) > depositMember Then
            MsgBox("Jumlah Melebihi dari Deposit Member")
            txtDeposit.Text = depositMember
            txtDepositHide.Text = depositMember
        End If
    End Sub

    Private Sub txtDeposit_TextChanged(sender As Object, e As EventArgs) Handles txtDeposit.TextChanged
        Call JumlahkanPembayaran()
    End Sub
End Class