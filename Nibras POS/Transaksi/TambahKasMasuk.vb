Imports MySql.Data.MySqlClient

Public Class TambahKasMasuk
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub GenerateTransactionNum()
        cekOpen()
        CMD = New MySqlCommand("select COUNT(no_transaksi) AS no_transaksi from arus_kas WHERE tanggal = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND no_transaksi LIKE 'KM%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Dim inc As Integer = DR.Item("no_transaksi") + 1
            txtNoTransaksi.Text = "KM" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", inc)
        Else
            Dim inc As Integer = 1
            txtNoTransaksi.Text = "KM" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub GenerateTransactionNumX()
        cekOpen()
        CMD = New MySqlCommand("select max(no_transaksi) AS no_transaksi from arus_kas where no_transaksi LIKE 'KM" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_transaksi")) Then
            txtNoTransaksi.Text = "KM" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtNoTransaksi.Text = "KM" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub LoadItemDb()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT kodeacc, namaacc FROM perkiraan WHERE level <> 0 AND tipe <> 'H' ORDER BY kodeacc ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "namaacc"
        lookUpEdit.Properties.ValueMember = "kodeacc"
        cekClose()
    End Sub

    Sub GetAkun()
        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE parentacc = '1-1100' ORDER BY kodeacc ASC", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            If DR.Item("tipe") <> "H" Then
                cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
            End If
        Loop
        cekClose()
    End Sub

    Sub Kosongkan()
        Call GenerateTransactionNum()
        txtJumlah.Text = "0"
        txtSaldo.Text = "0"
    End Sub
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
        Call GetAkun()
        Call LoadItemDb()
        DGV.Rows.Clear()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Dim kodeAkun As String = cbAkun.Text
        Dim strArr() As String
        strArr = kodeAkun.Split("/")

        If strArr(0) <> lookUpEdit.EditValue.ToString Then

            DGV.Rows.Add(lookUpEdit.EditValue.ToString, lookUpEdit.Text.ToString, "", FormatCurrency(0))

            'Dim saldoKas As Double = 0
            'cekOpen()
            'CMD = New MySqlCommand("SELECT * FROM arus_kas_saldo WHERE kodeacc = '" & lookUpEdit.EditValue.ToString & "' ", Conn)
            'DR = CMD.ExecuteReader
            'DR.Read()
            'If DR.HasRows Then
            '    saldoKas = DR.Item("saldo_akhir")
            'End If
            'cekClose()

            'If (saldoKas > 0) And (Double.Parse(txtJumlah.Text) <= saldoKas) Then

            '    DGV.Rows.Add(lookUpEdit.EditValue.ToString, lookUpEdit.Text.ToString, "", FormatCurrency(0))
            'Else

            '    MsgBox("Mohon Maaf Saldo " & lookUpEdit.Text.ToString & " -Kosong- Atau melebihi Saldo yang ada!", MsgBoxStyle.Critical, "Perhatian")

            'End If
        Else
            MsgBox("Akun tujuan tidak boleh sama dengan Akun Sumber.", MsgBoxStyle.Critical, "Perhatian")
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call GenerateTransactionNum()

        If cbAkun.Text = "" Or cbAkun.Text = "----------------------------------" Then
            MsgBox("Kode Akun Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf txtJumlah.Text <> txtTotalHide.Text Then
            MsgBox("Jumlah dan Total Harus Sama!", MsgBoxStyle.Critical)
            Exit Sub
        Else

            If DGV.RowCount > 0 Then

                Dim kodeAkun As String = cbAkun.Text
                Dim strArr() As String
                strArr = kodeAkun.Split("/")

                cekOpen()
                CMD = New MySqlCommand("INSERT INTO arus_kas (no_transaksi, tanggal, kodeacc, keterangan, jumlah, jenis, created_by, created_date) VALUES ('" &
                                            txtNoTransaksi.Text & "', '" &
                                           Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" &
                                           cbAkun.Text & "', '" &
                                           txtKeterangan.Text & "', '" &
                                           txtJumlah.Text & "', 'masuk', '" &
                                           MainMenu.PanelUser.Text & "', '" &
                                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' ) ", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("INSERT INTO jurnal VALUES ('" & txtNoTransaksi.Text & "', '" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" &
                                           strArr(0) & "', '" & strArr(1) & "', '" & txtJumlah.Text & "', '0', '" & txtKeterangan.Text & "', '4', 1)", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & txtJumlah.Text & "' WHERE kodeacc = '" & strArr(0) & "' ", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strArr(0) & "', '" & strArr(1) & "', '" & txtNoTransaksi.Text & "', 1, '" & txtJumlah.Text & "') ", Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                For baris As Integer = 0 To DGV.RowCount - 1
                    cekOpen()
                    CMD = New MySqlCommand("INSERT INTO arus_kas_detail (no_transaksi, kodeacc, NamaAcc, Keterangan, total) VALUES ('" &
                                            txtNoTransaksi.Text & "', '" &
                                           DGV.Rows(baris).Cells(0).Value & "', '" &
                                           DGV.Rows(baris).Cells(1).Value & "', '" &
                                           DGV.Rows(baris).Cells(2).Value & "', '" &
                                           DGV.Rows(baris).Cells(3).Value & "' ) ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO jurnal VALUES ('" & txtNoTransaksi.Text & "', '" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" &
                                           DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '0', '" & DGV.Rows(baris).Cells(3).Value & "', '" & txtKeterangan.Text & "', '4', '" & baris + 2 & "' )", Conn)
                    CMD.ExecuteNonQuery()

                    If DGV.Rows(baris).Cells(0).Value = "1-1110" Or DGV.Rows(baris).Cells(0).Value = "1-1120" Then
                        CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & DGV.Rows(baris).Cells(3).Value & "' WHERE kodeacc = '" & DGV.Rows(baris).Cells(0).Value & "' ", Conn)
                        CMD.ExecuteNonQuery()
                    End If
                    cekClose()
                Next

                Call InsertLogTrans(txtNoTransaksi.Text, "CREATE", MainMenu.PanelUser.Text, "KAS MASUK | " & txtKeterangan.Text & " TOTAL Rp. " & txtJumlah.Text)

                Call Kosongkan()
                MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information)
                DaftarKasMasuk.TampilGrid()
                Me.Close()
            Else
                MsgBox("Oops! Tidak Ada Data yang tersimpan!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 3 Then
            Try
                DGV.Rows(e.RowIndex).Cells(3).Value = CDec(DGV.Rows(e.RowIndex).Cells(3).Value)
                DGV.CurrentCell = DGV(3, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{down}")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Call HitungTransaksi()
    End Sub

    Sub HitungTransaksi()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(3).Value
            txtTotal.Text = FormatCurrency(x, 0)
            txtTotalHide.Text = x
        Next
    End Sub

    Private Sub TambahKasMasuk_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Kosongkan()
        Call GetAkun()
        Call LoadItemDb()
        DGV.Rows.Clear()
    End Sub

    Private Sub cbAkun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAkun.SelectedIndexChanged
        Dim kodeAkun As String = cbAkun.Text
        Dim strArr() As String
        strArr = kodeAkun.Split("/")

        cekOpen()
        CMD = New MySqlCommand("SELECT saldo_akhir AS saldo FROM arus_kas_saldo WHERE kodeacc = '" & strArr(0) & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtSaldo.Text = FormatCurrency(DR.Item("saldo"), 0)
            txtSaldoHide.Text = DR.Item("saldo")
        Else
            txtSaldo.Text = "0"
            txtSaldoHide.Text = "0"
        End If
        cekClose()
    End Sub

    Private Sub dtptanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtptanggal.ValueChanged
        Call GenerateTransactionNum()
    End Sub
End Class