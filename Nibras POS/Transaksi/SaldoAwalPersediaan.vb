Imports MySql.Data.MySqlClient

Public Class SaldoAwalPersediaan

    Sub Kosongkan()
        DGV.DataSource = Nothing
        DGV.Rows.Clear()
        txtJumlah.Text = ""

        cbAkun.SelectedIndex = 0
        'Call TampilKodeAkun()
        Call GetDataSaldo()
    End Sub

    Sub GetDataSaldo()

        cekOpen()
        CMD = New MySqlCommand("SELECT sa.*, b.`nama_barang`, b.`satuan`, b.`hpp`, (b.`hpp` * sa.`qty`) AS total FROM saldo_awal_persediaan sa INNER JOIN barang_m b ON b.`kode_item` = sa.`kode_item`", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("hpp"), CDec(DR.Item("qty")), CDec(DR.Item("total")))
        Loop
        cekClose()

        Call HitungTransaksi()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilKodeAkun()
        Dim column As Integer = 0

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            If DR.Item("level") = 0 Then
                cbAkun.Items.Add("----------------------------------")
            Else
                If DR.Item("tipe") = "H" Then
                    cbAkun.Items.Add("")
                Else
                    cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
                End If
            End If
        Loop
        cekClose()
    End Sub

    Sub HitungTransaksi()
        Dim x As Double = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(4).Value
            txtTQty.Text = FormatNumber(x, 0)
            txtTQtyHide.Text = x
        Next

        Dim y As Double = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            y = y + DGV.Rows(baris).Cells(5).Value
            txtTTot.Text = FormatCurrency(y, 0)
            txtTTotHide.Text = y
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & txtJumlah.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If (DR.HasRows) Then
            Dim baris As Integer = DGV.RowCount - 1
            Dim hpp As Double = DR.Item("hpp")
            DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("hpp"), 1, DR.Item("hpp"))
            txtJumlah.Clear()
            cekClose()

            Call HitungTransaksi()
            For barisatas As Integer = 0 To DGV.RowCount - 1
                For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                    If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                        DGV.Rows(barisatas).Cells(4).Value = DGV.Rows(barisatas).Cells(4).Value + 1
                        DGV.Rows(barisatas).Cells(5).Value = DGV.Rows(barisatas).Cells(3).Value * DGV.Rows(barisatas).Cells(4).Value
                        DGV.Rows.RemoveAt(barisbawah)
                        Call HitungTransaksi()
                        Exit Sub
                    End If
                Next
            Next
        Else
            cekClose()
            PencarianBarangPersediaan.ShowDialog()
            PencarianBarangPersediaan.TXTCariBarang.Text = txtJumlah.Text
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        SplashScreenManager1.ShowWaitForm()
        Threading.Thread.Sleep(2000)

        cekOpen()
        CMD = New MySqlCommand("SELECT DISTINCT(tanggal) FROM saldo_awal_persediaan ORDER BY tanggal ASC LIMIT 1", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            dtptanggal.Value = Format(DR.Item("tanggal"), "dd/MM/yyyy")
        End If
        cekClose()

        If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If cbAkun.Text = "" Or cbAkun.Text = "----------------------------------" Then
                MsgBox("Kode Akun Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Else

                If DGV.RowCount > 0 Then
                    Dim tqty As Integer = 0
                    Dim ttot As Double = 0

                    For baris As Integer = 0 To DGV.RowCount - 1
                        Dim kodeAkun As String = DGV.Rows(baris).Cells(3).Value
                        Dim strArr() As String
                        strArr = kodeAkun.Split("/")

                        Masuk(DGV.Rows(baris).Cells(0).Value, DGV.Rows(baris).Cells(4).Value)

                        tqty += Integer.Parse(DGV.Rows(baris).Cells(4).Value)
                        ttot += Double.Parse(DGV.Rows(baris).Cells(5).Value)
                    Next

                    MasukSaldoAwal(tqty, ttot)
                    Call Kosongkan()
                    MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information)
                Else
                    MsgBox("Oops! Tidak Ada Data yang tersimpan!", MsgBoxStyle.Critical)
                End If
            End If
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Sub Masuk(ByVal kodeitem As String, ByVal qty As Integer)
        Dim SQL As String
        Try

            cekOpen()
            SQL = "INSERT INTO saldo_awal_persediaan (tanggal, kode_item, qty) VALUES " & "('" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & kodeitem & "', '" & qty & "') ON DUPLICATE KEY UPDATE qty = '" & qty & "' "
            CMD = New MySqlCommand(SQL, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            Dim count As Integer
            cekOpen()
            CMD = New MySqlCommand("SELECT COUNT(kode_item) as kode_item FROM saldo_awal_persediaan WHERE kode_item = '" & kodeitem & "' AND tanggal = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            count = DR.Item("kode_item")
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("UPDATE barang_m SET stok = '" & qty & "' WHERE kode_item = '" & kodeitem & "' ", Conn)
            CMD.ExecuteNonQuery()

            Dim updatehistory As String = "INSERT IGNORE INTO history_stok VALUES ( '" &
                        kodeitem & "', 'SALDO_AWAL', '" &
                        Format(dtptanggal.Value, "yyyy-MM-dd") & "', 'Saldo Awal Persediaan', '0', '" &
                        qty & "', '" &
                        qty & "', '" &
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" &
                        MainMenu.PanelUser.Text & "' )"
            CMD = New MySqlCommand(updatehistory, Conn)
            CMD.ExecuteNonQuery()
            cekClose()
            'If count = 0 Then

            'End If
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Sub MasukSaldoAwal(ByVal tqty As Integer, ByVal ttot As Double)
        Dim kodeAkun As String = cbAkun.Text
        Dim strArr() As String
        strArr = kodeAkun.Split("/")

        'cekOpen()
        'CMD = New MySqlCommand("INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & strArr(0) & "', '" & strArr(1) & "', '" & ttot & "', 0) ON DUPLICATE KEY UPDATE debet = '" & ttot & "' ", Conn)
        'CMD.ExecuteNonQuery()
        'cekClose()

        cekOpen()
        CMD = New MySqlCommand("INSERT INTO history_saldo_persediaan (tanggal, qty, total, created_by, created_date) VALUES ('" &
                               Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & tqty & "', '" & ttot & "', '" & MainMenu.PanelUser.Text & "', '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "') ON DUPLICATE KEY UPDATE " &
                               "qty = '" & tqty & "', total = '" & ttot & "', created_date = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' ", Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        Call InsertLogTrans(Format(dtptanggal.Value, "yyyy-MM-dd"), "CREATE", MainMenu.PanelUser.Text, "SALDO AWAL PERSEDIAAN | QTY " & tqty & " TOTAL Rp. " & ttot)
    End Sub

    Private Sub txtJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlah.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then

            Dim namabarang As String
            If txtJumlah.Text.Contains("'") Then
                namabarang = txtJumlah.Text.Replace("'", "''")
            Else
                namabarang = txtJumlah.Text
            End If

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & namabarang & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()


            If (DR.HasRows) Then
                Dim baris As Integer = DGV.RowCount - 1
                Dim hpp As Double = DR.Item("hpp")
                DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("hpp"), 1, DR.Item("hpp"))
                txtJumlah.Clear()
                cekClose()

                Call HitungTransaksi()
                For barisatas As Integer = 0 To DGV.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                        If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                            DGV.Rows(barisatas).Cells(4).Value = DGV.Rows(barisatas).Cells(4).Value + 1
                            DGV.Rows(barisatas).Cells(5).Value = DGV.Rows(barisatas).Cells(3).Value * DGV.Rows(barisatas).Cells(4).Value
                            DGV.Rows.RemoveAt(barisbawah)
                            Call HitungTransaksi()
                            Exit Sub
                        End If
                    Next
                Next
            Else
                cekClose()
                PencarianBarangPersediaan.ShowDialog()
                PencarianBarangPersediaan.TXTCariBarang.Text = txtJumlah.Text
            End If
        End If
    End Sub

    Private Sub SaldoAwalPersediaan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()

        dtptanggal.Value = Date.Now
        Call Kosongkan()
        SetDoubleBuffered(DGV, True)

        dtptanggal.Value = Now.Date
        txtJumlah.Focus()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ImportSaldoAwalPersediaan.ShowDialog()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 3 Then
            Try
                DGV.Rows(e.RowIndex).Cells(5).Value = DGV.Rows(e.RowIndex).Cells(3).Value * DGV.Rows(e.RowIndex).Cells(4).Value
                DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{down}")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If e.ColumnIndex = 4 Then
            Try
                DGV.Rows(e.RowIndex).Cells(5).Value = DGV.Rows(e.RowIndex).Cells(3).Value * DGV.Rows(e.RowIndex).Cells(4).Value
                DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{down}")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Call HitungTransaksi()
    End Sub

    Private Sub DGV_CellContextMenuStripChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellContextMenuStripChanged

    End Sub
End Class