
Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class SaldoAwalPerkiraan

    Sub Kosongkan()
        Call TampilGrid()
        Call TampilGridModal()

        'lblWarning.Text = "Saldo Awal akan dicatat untuk Tanggal: " & DateTime.Now.ToString("dd MMMM yyyy")
    End Sub

    Sub TampilGrid()
        cekOpen()
        DA = New MySqlDataAdapter("SELECT kodeacc, namaacc, 'IDR' AS matauang, '0' AS jumlah FROM perkiraan WHERE kelompok = 1 AND tipe = 'D' ORDER BY kodeacc ", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        Dim totalrow1 As Integer = DS.Tables(0).Rows.Count
        cekClose()

        DGV.Columns(0).HeaderText = "Kode"
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).HeaderText = "Nama Perkiraan"
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).HeaderText = "Mata Uang"
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(3).HeaderText = "Jumlah"
        DGV.Columns(3).DefaultCellStyle.Format = "n0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cekOpen()
        CMD = New MySqlCommand("SELECT kodeacc, namaacc, 'IDR' AS matauang, '0' AS jumlah FROM perkiraan WHERE kelompok = 1 AND tipe = 'D' ORDER BY kodeacc ", Conn)
        DR = CMD.ExecuteReader

        Dim data1(totalrow1) As String
        Dim i As Integer = 0
        Do While DR.Read
            data1(i) = DR.Item("kodeacc")
            'Console.WriteLine(data1(i))
            i += 1
        Loop
        cekClose()

        Dim j As Integer = 1
        For Each value As String In data1
            'Console.WriteLine("SELECT SUM(debet) AS nominal FROM jurnal WHERE kode_perkiraan = '" & value)

            If i > 0 Then
                cekOpen()
                CMD = New MySqlCommand("SELECT SUM(debet) AS nominal FROM jurnal WHERE kode_perkiraan = '" & value & "' AND nomor_transaksi = 'Saldo Awal'", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                Dim totaljurnal As Double
                If IsDBNull(DR.Item("nominal")) Then
                    totaljurnal = 0
                    'Console.WriteLine("Nope " & value)
                Else
                    totaljurnal = Double.Parse(DR.Item("nominal"))
                    'Console.WriteLine("Ada " & value)
                End If
                cekClose()

                If totaljurnal = 0 Then
                    cekOpen()
                    CMD = New MySqlCommand("SELECT SUM(total) AS nominal FROM piutang WHERE kodeacc = '" & value & "' ", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    'Console.WriteLine(data1(j))

                    If IsDBNull(DR.Item("nominal")) Then
                        DGV.Rows(j - 1).Cells(3).Value = 0
                    Else
                        DGV.Rows(j - 1).Cells(3).Style.Format = "n0"
                        DGV.Rows(j - 1).Cells(3).Value = CDec(DR.Item("nominal")).ToString("n0")
                    End If
                    cekClose()
                Else
                    DGV.Rows(j - 1).Cells(3).Style.Format = "n0"
                    DGV.Rows(j - 1).Cells(3).Value = CDec(totaljurnal).ToString("n0")
                End If

                cekOpen()
                If value = "1-1510" Then
                    CMD = New MySqlCommand("SELECT IFNULL(SUM(sp.`qty` * b.`hpp`),0) AS nominal FROM saldo_awal_persediaan sp INNER JOIN barang_m b ON b.`kode_item` = sp.`kode_item` ", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    DGV.Rows(j - 1).Cells(3).Style.Format = "n0"
                    DGV.Rows(j - 1).Cells(3).Value = CDec(DR.Item("nominal")).ToString("n0")
                End If
                i -= 1
            End If
            cekClose()

            j += 1
        Next

        Call HitungTransaksiA()

    End Sub

    Sub TampilGridModal()
        cekOpen()
        DA = New MySqlDataAdapter("SELECT kodeacc, namaacc, 'IDR' AS matauang, '0' AS jumlah FROM perkiraan WHERE kelompok IN (2,3) AND tipe = 'D' ORDER BY kodeacc ", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGVKewajiban.DataSource = DS.Tables(0)
        Dim totalrow1 As Integer = DS.Tables(0).Rows.Count
        cekClose()

        DGVKewajiban.Columns(0).HeaderText = "Kode"
        DGVKewajiban.Columns(0).ReadOnly = True
        DGVKewajiban.Columns(1).HeaderText = "Perkiraan"
        DGVKewajiban.Columns(1).ReadOnly = True
        DGVKewajiban.Columns(2).HeaderText = "Mata Uang"
        DGVKewajiban.Columns(2).ReadOnly = True
        DGVKewajiban.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVKewajiban.Columns(3).HeaderText = "Jumlah"
        DGVKewajiban.Columns(3).DefaultCellStyle.Format = "n0"
        DGVKewajiban.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cekOpen()
        CMD = New MySqlCommand("SELECT kodeacc, namaacc, 'IDR' AS matauang, '0' AS jumlah FROM perkiraan WHERE kelompok IN (2,3) AND tipe = 'D' ORDER BY kodeacc ", Conn)
        DR = CMD.ExecuteReader

        Dim data1(totalrow1) As String
        Dim i As Integer = 0
        Do While DR.Read
            data1(i) = DR.Item("kodeacc")
            Console.WriteLine(data1(i))
            i += 1
        Loop
        cekClose()

        Dim j As Integer = 1
        For Each value As String In data1

            If i > 0 Then
                cekOpen()
                CMD = New MySqlCommand("SELECT SUM(kredit) AS nominal FROM jurnal WHERE kode_perkiraan = '" & value & "'  AND nomor_transaksi = 'Saldo Awal'", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                Dim totaljurnal As Double
                If IsDBNull(DR.Item("nominal")) Then
                    totaljurnal = 0
                Else
                    totaljurnal = Double.Parse(DR.Item("nominal"))
                End If
                cekClose()
                If totaljurnal = 0 Then
                    cekOpen()
                    CMD = New MySqlCommand("SELECT SUM(total) AS nominal FROM hutang WHERE kodeacc = '" & value & "' ", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    'Console.WriteLine(data1(j))

                    If IsDBNull(DR.Item("nominal")) Then
                        DGVKewajiban.Rows(j - 1).Cells(3).Value = 0
                    Else
                        DGVKewajiban.Rows(j - 1).Cells(3).Style.Format = "n0"
                        DGVKewajiban.Rows(j - 1).Cells(3).Value = CDec(DR.Item("nominal")).ToString("n0")
                    End If
                Else
                    DGVKewajiban.Rows(j - 1).Cells(3).Style.Format = "n0"
                    DGVKewajiban.Rows(j - 1).Cells(3).Value = CDec(totaljurnal).ToString("n0")
                End If

                i -= 1
            End If
            cekClose()

            j += 1
        Next

        Call HitungTransaksiB()
    End Sub

    Private Sub SaldoAwalPerkiraan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        SetDoubleBuffered(DGV, True)
        SetDoubleBuffered(DGVKewajiban, True)
    End Sub

    Sub HitungTransaksiA()
        Dim x As Double = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(3).Value
            txtTotalA.Text = FormatCurrency(x, 0)
            txtTotalAHide.Text = x
        Next
    End Sub

    Sub HitungTransaksiB()
        Dim x As Double = 0
        For baris As Integer = 0 To DGVKewajiban.RowCount - 1
            x = x + DGVKewajiban.Rows(baris).Cells(3).Value
            txtTotalB.Text = FormatCurrency(x, 0)
            txtTotalBHide.Text = x
        Next
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtTotalAHide.Text <> txtTotalBHide.Text Then
            MsgBox("Nominal Tidak Balance!!", MsgBoxStyle.Critical)
        Else
            If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim tanggal As String = Format(dtptanggal.Value, "yyyy-MM-dd")

                For baris As Integer = 0 To DGV.RowCount - 2
                    If DGV.Rows(baris).Cells(3).Value > 0 Then

                        Dim nominal As String = DGV.Rows(baris).Cells(3).Value.ToString.Replace(".", "")

                        cekOpen()
                        CMD = New MySqlCommand("SELECT nomor_transaksi, debet FROM jurnal WHERE nomor_transaksi = 'Saldo Awal' AND kode_perkiraan = '" & DGV.Rows(baris).Cells(0).Value & "' ", Conn)
                        DR = CMD.ExecuteReader
                        DR.Read()

                        'Cek apakah saldo awal sudah pernah diinput?
                        If DR.HasRows Then
                            Dim debetAwal As Double = Double.Parse(DR.Item("debet"))
                            Dim debetAkhir As Double = Double.Parse(nominal)
                            Dim debetTotal As Double
                            Dim querySaldo As String = ""

                            'Jika Saldo Perkiraan Terakhir di Update lebih besar maka tambahkan selisih nya pada Saldo Awal
                            If debetAwal > debetAkhir Then
                                debetTotal = debetAkhir
                                querySaldo = "INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & tanggal & "', '" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '" & nominal & "', 0) " &
                                           "ON DUPLICATE KEY UPDATE debet = '" & debetTotal & "' "
                            ElseIf debetAwal = debetAkhir Then
                                debetTotal = debetAkhir
                                querySaldo = "INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & tanggal & "', '" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '" & nominal & "', 0) " &
                                           "ON DUPLICATE KEY UPDATE debet = '" & debetTotal & "' "
                            Else
                                debetTotal = debetAkhir - debetAwal
                                querySaldo = "INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & tanggal & "', '" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '" & nominal & "', 0) " &
                                           "ON DUPLICATE KEY UPDATE debet = debet + '" & debetTotal & "'"
                            End If

                            cekClose()

                            cekOpen()
                            CMD = New MySqlCommand("UPDATE jurnal SET debet = '" & nominal & "', kredit = 0 WHERE nomor_transaksi = 'Saldo Awal' AND kode_perkiraan = '" & DGV.Rows(baris).Cells(0).Value & "' ", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand(querySaldo, Conn)
                            CMD.ExecuteNonQuery()
                        Else
                            cekClose()

                            cekOpen()
                            CMD = New MySqlCommand("INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & tanggal & "', '" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '" & nominal & "', 0) ", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand("INSERT INTO jurnal (nomor_transaksi, tgl_transaksi, kode_perkiraan, uraian, debet, kredit, jenis) VALUES ('Saldo Awal', '" & tanggal & "', '" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '" & nominal & "', 0, 6) ", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand("UPDATE piutang SET status = 0 ", Conn)
                            CMD.ExecuteNonQuery()
                            CMD = New MySqlCommand("UPDATE saldo_awal_persediaan SET status = 0 ", Conn)
                            CMD.ExecuteNonQuery()
                        End If
                        cekClose()

                        If DGV.Rows(baris).Cells(0).Value.Contains("1-11") Then
                            cekOpen()
                            CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = 0 WHERE kodeacc = '" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand("DELETE FROM arus_kas_saldo_history WHERE kodeacc = '" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand("INSERT INTO arus_kas_saldo (kodeacc, namaacc, saldo_akhir) VALUES ('" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '" & nominal & "') " &
                                           "ON DUPLICATE KEY UPDATE saldo_akhir = '" & nominal & "'", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', 'Saldo_Awal', 3, '" & nominal & "') ", Conn)
                            CMD.ExecuteNonQuery()
                            cekClose()
                        End If

                    End If
                Next

                For barisx As Integer = 0 To DGVKewajiban.RowCount - 2
                    If DGVKewajiban.Rows(barisx).Cells(3).Value > 0 Then

                        Dim nominal As String = DGVKewajiban.Rows(barisx).Cells(3).Value.ToString.Replace(".", "")

                        cekOpen()
                        CMD = New MySqlCommand("SELECT nomor_transaksi, kredit FROM jurnal WHERE nomor_transaksi = 'Saldo Awal' AND kode_perkiraan = '" & DGVKewajiban.Rows(barisx).Cells(0).Value & "' ", Conn)
                        DR = CMD.ExecuteReader
                        DR.Read()

                        'Cek apakah saldo awal sudah pernah diinput?
                        If DR.HasRows Then
                            Dim debetAwal As Double = Double.Parse(DR.Item("kredit"))
                            Dim debetAkhir As Double = Double.Parse(nominal)
                            Dim debetTotal As Double
                            Dim querySaldo As String = ""

                            'Jika Saldo Perkiraan Terakhir di Update lebih besar maka tambahkan selisih nya pada Saldo Awal
                            If debetAwal > debetAkhir Then
                                debetTotal = debetAkhir
                                querySaldo = "INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & tanggal & "', '" & DGVKewajiban.Rows(barisx).Cells(0).Value & "', '" & DGVKewajiban.Rows(barisx).Cells(1).Value & "', 0, '" & nominal & "') " &
                                           "ON DUPLICATE KEY UPDATE kredit = '" & debetTotal & "' "
                            ElseIf debetAwal = debetAkhir Then
                                debetTotal = debetAkhir
                                querySaldo = "INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & tanggal & "', '" & DGVKewajiban.Rows(barisx).Cells(0).Value & "', '" & DGVKewajiban.Rows(barisx).Cells(1).Value & "', 0, '" & nominal & "') " &
                                           "ON DUPLICATE KEY UPDATE kredit = '" & debetTotal & "' "
                            Else
                                debetTotal = debetAkhir - debetAwal
                                querySaldo = "INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & tanggal & "', '" & DGVKewajiban.Rows(barisx).Cells(0).Value & "', '" & DGVKewajiban.Rows(barisx).Cells(1).Value & "', 0, '" & nominal & "') " &
                                           "ON DUPLICATE KEY UPDATE kredit = kredit + '" & debetTotal & "'"
                            End If

                            cekClose()
                            cekOpen()
                            CMD = New MySqlCommand("UPDATE jurnal SET kredit = '" & nominal & "', debet = 0 WHERE nomor_transaksi = 'Saldo Awal' AND kode_perkiraan = '" & DGVKewajiban.Rows(barisx).Cells(0).Value & "' ", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand(querySaldo, Conn)
                            CMD.ExecuteNonQuery()
                        Else

                            cekClose()

                            cekOpen()
                            CMD = New MySqlCommand("INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & tanggal & "', '" & DGVKewajiban.Rows(barisx).Cells(0).Value & "', '" & DGVKewajiban.Rows(barisx).Cells(1).Value & "', 0, '" & nominal & "') ", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand("INSERT INTO jurnal (nomor_transaksi, tgl_transaksi, kode_perkiraan, uraian, debet, kredit, jenis) VALUES ('Saldo Awal', '" & tanggal & "', '" & DGVKewajiban.Rows(barisx).Cells(0).Value & "', '" & DGVKewajiban.Rows(barisx).Cells(1).Value & "', 0, '" & nominal & "', 6) ", Conn)
                            CMD.ExecuteNonQuery()

                            CMD = New MySqlCommand("UPDATE hutang SET status = 0 ", Conn)
                            CMD.ExecuteNonQuery()
                        End If
                        cekClose()
                    End If
                Next

                Call InsertLogTrans("SALDO AWAL PERKIRAAN", "CREATE", MainMenu.PanelUser.Text, "SALDO AWAL PERKIRAAN | AKTIVA " & txtTotalA.Text & " KEWAJIBAN " & txtTotalB.Text)

                MsgBox("Data Berhasil Disimpan")
                Call Kosongkan()
            End If
        End If
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 3 Then

            DGV.Rows(e.RowIndex).Cells(3).Value = CDec(DGV.Rows(e.RowIndex).Cells(3).Value).ToString("n0")
            DGV.CurrentCell = DGV(3, DGV.CurrentCell.RowIndex)
            Call HitungTransaksiA()
        End If
    End Sub

    Private Sub DGVKewajiban_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGVKewajiban.CellEndEdit
        If e.ColumnIndex = 3 Then

            DGVKewajiban.Rows(e.RowIndex).Cells(3).Value = CDec(DGVKewajiban.Rows(e.RowIndex).Cells(3).Value).ToString("n0")
            DGVKewajiban.CurrentCell = DGVKewajiban(3, DGVKewajiban.CurrentCell.RowIndex)
            Call HitungTransaksiB()
        End If
    End Sub
End Class