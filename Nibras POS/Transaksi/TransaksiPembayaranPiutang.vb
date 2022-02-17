Imports MySql.Data.MySqlClient

Public Class TransaksiPembayaranPiutang

    Sub NomorOtomatis()
        txtNoTransaksi.Text = Format(dtptanggal.Value, "yyyyMMddHHmmss")
    End Sub
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilSupplier()
        cbSupplier.Text = ""
        cbSupplier.Items.Clear()

        Dim query As String
        If MainMenu.PanelJenis.Text = "D" Then
            cekOpen()
            query = "SELECT * FROM master_nhs ORDER BY nama"
            CMD = New MySqlCommand(query, Conn)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cbSupplier.Items.Add(DR.Item("id") & "/" & DR.Item("nama"))
            Loop
            cekClose()
        Else

            cbSupplier.Items.Clear()
            If checkAgen.Checked = True Then
                cekOpen()
                query = "SELECT * FROM master_nhs ORDER BY nama"
                CMD = New MySqlCommand(query, Conn)
                DR = CMD.ExecuteReader
                Do While DR.Read
                    cbSupplier.Items.Add(DR.Item("id") & "/" & DR.Item("nama"))
                Loop
                cekClose()
            Else
                cekOpen()
                query = "SELECT * FROM member_m ORDER BY nama_member"
                CMD = New MySqlCommand(query, Conn)
                DR = CMD.ExecuteReader
                Do While DR.Read
                    cbSupplier.Items.Add(DR.Item("kode_member") & "/" & DR.Item("nama_member"))
                Loop
                cekClose()
            End If
        End If
    End Sub

    Sub LoadItemDb()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select kode_member AS kode, nama_member AS nama, alamat from member_m", Conn)
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
        DA = New MySqlDataAdapter("select id as kode, nama, alamat from master_nhs", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama"
        lookUpEdit.Properties.ValueMember = "kode"
        cekClose()
    End Sub

    Private Sub checkAgen_CheckedChanged(sender As Object, e As EventArgs) Handles checkAgen.CheckedChanged
        If checkAgen.Checked = True Then
            Call LoadItemNhs()
        Else
            Call LoadItemDb()
        End If
    End Sub

    Sub GetDataPiutang()
        DGV.Rows.Clear()
        'txtNoTransaksi.Text = ""
        'Dim kodesupplier As String = cbSupplier.Text
        'Dim strArr() As String
        'strArr = kodesupplier.Split("/")

        cekOpen()
        CMD = New MySqlCommand("SELECT no_transaksi, no_faktur, tanggal, tanggal_jt, sisa, potongan, total FROM piutang WHERE kode_member = '" & lookUpEdit.EditValue.ToString & "' AND status_lunas = 0 UNION " &
                               " SELECT faktur_jual AS no_transaksi, faktur_jual, tgl_jual AS tanggal, jth_tempo_jual AS tanggal_jt, sisa_piutang AS sisa, 0 AS potongan, total_jual AS total FROM penjualan " &
                               " WHERE kode_customer Like '" & lookUpEdit.EditValue.ToString & "%' AND status_jual = 'BELUM LUNAS' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            'txtNoTransaksi.Text = DR.Item("no_transaksi")
            DGV.Rows.Add(DR.Item("no_faktur"), DR.Item("tanggal"), DR.Item("tanggal_jt"), CDec(DR.Item("sisa")), CDec(DR.Item("potongan")), CDec(DR.Item("total")), 0, DR.Item("no_transaksi"))
        Loop
        cekClose()
    End Sub

    Private Sub cbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupplier.SelectedIndexChanged
        DGV.Rows.Clear()
        Call GetDataPiutang()
    End Sub

    Sub GetAkun()
        cbAkun.Items.Clear()

        Dim query As String

        If cbCaraBayar.Text = "Deposit" Then
            query = "SELECT * FROM perkiraan WHERE kodeacc ='2-3101'"
        Else
            query = qKasOnly
        End If
        cekOpen()
        CMD = New MySqlCommand(query, Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            cbAkun.Items.Add(DR.Item("kodeacc") + "/" + DR.Item("namaacc"))
        Loop
        cekClose()

        cbAkun.SelectedIndex = 0
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 6 Then
            Try
                DGV.Rows(e.RowIndex).Cells(6).Value = CDec(DGV.Rows(e.RowIndex).Cells(6).Value)
                DGV.CurrentCell = DGV(6, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{down}")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TransaksiPembayaranPiutang_Load(sender As Object, e As EventArgs) Handles Me.Load
        DGV.Rows.Clear()
        'Call TampilSupplier()
        Call LoadItemDb()
        'Call GetAkun()
        Call NomorOtomatis()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If lookUpEdit.Text.ToString = "" Then
            MsgBox("Member Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf cbCaraBayar.Text = "" Then
            MsgBox("Cara Bayar Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf cbAkun.Text = "" Then
            MsgBox("Kode Akun Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        Else

            Dim kodeAkun As String = cbAkun.Text
            Dim strArrAkun() As String
            strArrAkun = kodeAkun.Split("/")

            Dim ttot As Double = 0
            Dim ttotx As Double = 0
            If DGV.RowCount > 0 Then

                If cbCaraBayar.Text = "Deposit" Then

                    For barisx As Integer = 0 To DGV.RowCount - 1
                        ttotx = ttotx + Double.Parse(DGV.Rows(barisx).Cells(6).Value)
                    Next

                    If Double.Parse(ttotx) > Double.Parse(lblDepositHide.Text) Then
                        MsgBox("Maaf, Saldo Deposit Tidak Mencukupi!", MsgBoxStyle.Critical, "Perhatian")
                    Else
                        cekOpen()
                        CMD = New MySqlCommand("UPDATE member_m SET deposit = deposit - '" & ttotx & "' WHERE kode_member = '" & lookUpEdit.EditValue.ToString & "' ", Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()
                    End If
                End If

                For baris As Integer = 0 To DGV.RowCount - 1

                    If Double.Parse(DGV.Rows(baris).Cells(6).Value) > 0 Then
                        'MsgBox(DGV.Rows(baris).Cells(6).Value)
                        Dim sisaPembayaran As Double = Double.Parse(DGV.Rows(baris).Cells(5).Value) - Double.Parse(DGV.Rows(baris).Cells(6).Value)
                        Dim status As Integer
                        Dim statusLunas As String

                        If sisaPembayaran > 0 Then
                            status = 0
                            statusLunas = "BELUM LUNAS"
                        Else
                            status = 1
                            statusLunas = "LUNAS"
                        End If

                        Dim query As String
                        Dim nofaktur As String = DGV.Rows(baris).Cells(0).Value
                        If nofaktur.Contains("FJ") = True Then
                            query = "UPDATE penjualan SET status_jual = '" & statusLunas & "', sisa_piutang='" & sisaPembayaran & "' WHERE faktur_jual = '" & DGV.Rows(baris).Cells(0).Value & "'"
                        Else
                            query = "UPDATE piutang SET jumlah_bayar = jumlah_bayar + '" & DGV.Rows(baris).Cells(6).Value & "', cara_bayar = '" & cbCaraBayar.Text & "', status_lunas = " & status & ", sisa = " & sisaPembayaran & " WHERE no_faktur = '" & DGV.Rows(baris).Cells(0).Value & "' AND kode_member = '" & lookUpEdit.EditValue.ToString & "'"
                        End If
                        Console.WriteLine(query)

                        cekOpen()
                        CMD = New MySqlCommand(query, Conn)
                        CMD.ExecuteNonQuery()

                        CMD = New MySqlCommand("INSERT IGNORE INTO pembayaran_hp (no_faktur, total, diskon, sisa, jenis, status) VALUES " &
                                               "('" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(6).Value & "', '" & DGV.Rows(baris).Cells(4).Value & "', '" & sisaPembayaran & "', 'PIUTANG', '" & status & "')", Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()
                    End If

                    ttot = ttot + Double.Parse(DGV.Rows(baris).Cells(6).Value)
                Next

                'MsgBox("Total: " & ttot)

                If ttot > 0 Then

                    cekOpen()
                    Dim jurnal1 As String = "insert into jurnal values('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & strArrAkun(0) & "', '" & strArrAkun(1) & "', '" & ttot & "', 0, 'PEMBAYARAN PIUTANG', 1, 1)"
                    CMD = New MySqlCommand(jurnal1, Conn)
                    CMD.ExecuteNonQuery()

                    Dim jurnal2 As String = "insert into jurnal values('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '1-1210','PIUTANG USAHA', 0, '" & ttot & "', '', 1, 2)"
                    CMD = New MySqlCommand(jurnal2, Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & ttot & "' WHERE kodeacc = '" & strArrAkun(0) & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    Dim newNumber As String = DateTime.Now.ToString("HHmmss")
                    CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strArrAkun(0) & "', '" & strArrAkun(1) & "', '" & txtNoTransaksi.Text & "-" & newNumber & "', 1, '" & ttot & "')", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    Call InsertLogTrans(txtNoTransaksi.Text, "CREATE", MainMenu.PanelUser.Text, "PENJUALAN - BAYAR PIUTANG Total Rp. " & Format(ttot, "N0"))

                    MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information)
                    DaftarPembayaranPiutang.TampilGrid()
                    Me.Close()
                Else
                    MsgBox("Jumlah Pembayaran Tidak Boleh Kosong!", MsgBoxStyle.Critical, "Perhatian")
                End If

                ttot = 0
            Else
                MsgBox("Oops! Tidak Ada Data yang tersimpan!", MsgBoxStyle.Critical, "Perhatian")
            End If
        End If
    End Sub

    Private Sub lookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles lookUpEdit.EditValueChanged
        Call GetDataPiutang()
    End Sub

    Private Sub cbCaraBayar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCaraBayar.SelectedIndexChanged
        Call GetAkun()

        If cbCaraBayar.Text = "Deposit" Then

            If lookUpEdit.Text.ToString = "" Then
                MsgBox("Silahkan pilih Member Terlebih Dahulu.", MsgBoxStyle.Information, "Perhatian")
                cbCaraBayar.SelectedIndex = 0
            Else
                cekOpen()
                CMD = New MySqlCommand("SELECT deposit FROM member_m WHERE kode_member = '" & lookUpEdit.EditValue.ToString & "' ", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                If DR.HasRows Then
                    lblDeposit.Text = "Jumlah Deposit: " & FormatCurrency(DR.Item("deposit"), 0)
                    lblDepositHide.Text = DR.Item("deposit")
                Else
                    lblDeposit.Text = "Jumlah Deposit: Rp. 0"
                    lblDepositHide.Text = "0"
                End If
                cekClose()
            End If
        Else
            lblDeposit.Text = ""
            lblDepositHide.Text = "0"
        End If
    End Sub
End Class