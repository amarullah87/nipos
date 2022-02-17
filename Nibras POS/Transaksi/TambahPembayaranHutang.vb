Imports MySql.Data.MySqlClient

Public Class TambahPembayaranHutang
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilSupplier()
        cbSupplier.Items.Clear()

        cekOpen()
        'Dim query As String = "SELECT kode, nama FROM mst_distributor WHERE nama NOT LIKE '%DB Online%' AND STATUS = 1 ORDER BY kode"
        'Dim query As String = "SELECT kode, nama FROM mst_distributor d INNER JOIN hutang h ON h.kode_supplier = d.kode WHERE nama NOT LIKE '%DB Online%' AND d.STATUS = 1 ORDER BY kode"
        Dim query As String = "SELECT d.kode, d.nama FROM hutang h INNER JOIN mst_distributor d ON h.kode_supplier = d.kode WHERE nama NOT LIKE '%DB Online%' AND d.STATUS = 1 UNION " &
            " SELECT m.id, m.nama FROM hutang h INNER JOIN master_nhs m ON h.`kode_supplier` = m.id ORDER BY kode"
        CMD = New MySqlCommand(query, Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            cbSupplier.Items.Add(DR.Item("kode") & "/" & DR.Item("nama"))
        Loop
        cekClose()
    End Sub

    Private Sub cbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupplier.SelectedIndexChanged
        DGV.Rows.Clear()
        Call GetDataHutang()
    End Sub

    Sub GetAkun()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc ='1-1100' ORDER BY kodeacc", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            cbAkun.Items.Add(DR.Item("kodeacc") + "/" + DR.Item("namaacc"))
        Loop
        cekClose()
    End Sub

    Sub GetDataHutang()
        Dim kodesupplier As String = cbSupplier.Text
        Dim strArr() As String
        strArr = kodesupplier.Split("/")

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM hutang WHERE kode_supplier = '" & strArr(0) & "' AND sisa <> 0", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            txtNoTransaksi.Text = DR.Item("no_transaksi")
            DGV.Rows.Add(DR.Item("no_faktur"), DR.Item("tanggal"), DR.Item("tanggal_jt"), CDec(DR.Item("sisa")), CDec(DR.Item("potongan")), CDec(DR.Item("total")), 0)
        Loop
        cekClose()
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

    Private Sub TambahPembayaranHutang_Load(sender As Object, e As EventArgs) Handles Me.Load
        DGV.Rows.Clear()
        Call TampilSupplier()
        Call GetAkun()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If cbSupplier.Text = "" Then
            MsgBox("Supplier Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf cbCaraBayar.Text = "" Then
            MsgBox("Cara Bayar Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf cbAkun.Text = "" Then
            MsgBox("Akun Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        Else
            Dim kodesupplier As String = cbSupplier.Text
            Dim strArr() As String
            strArr = kodesupplier.Split("/")

            Dim kodeAkun As String = cbAkun.Text
            Dim strArrAkun() As String
            strArrAkun = kodeAkun.Split("/")

            If DGV.RowCount > 0 Then

                Dim ttot As Double = 0
                For baris As Integer = 0 To DGV.RowCount - 1

                    If DGV.Rows(baris).Cells(6).Value <> 0 Then
                        cekOpen()
                        CMD = New MySqlCommand("UPDATE hutang SET jumlah_bayar = '" & DGV.Rows(baris).Cells(6).Value & "', cara_bayar = '" & cbCaraBayar.Text & "', sisa = sisa - '" & DGV.Rows(baris).Cells(6).Value & "' WHERE no_faktur = '" & DGV.Rows(baris).Cells(0).Value & "' AND kode_supplier = '" & strArr(0) & "'", Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()

                        ttot += DGV.Rows(baris).Cells(6).Value
                    End If
                Next

                If ttot > 0 Then
                    cekOpen()
                    Dim jurnal1 As String = "insert into jurnal values('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & strArrAkun(0) & "', '" & strArrAkun(1) & "', 0, '" & ttot & "', 'BAYAR HUTANG', 1, 1)"
                    CMD = New MySqlCommand(jurnal1, Conn)
                    CMD.ExecuteNonQuery()

                    Dim jurnal2 As String = "insert into jurnal values('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '2-1101','HUTANG USAHA', '" & ttot & "', 0, 'BAYAR HUTANG', 1, 2)"
                    CMD = New MySqlCommand(jurnal2, Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & ttot & "' WHERE kodeacc = '" & strArrAkun(0) & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    Dim newNumber As String = DateTime.Now.ToString("HHmmss")
                    CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strArrAkun(0) & "', '" & strArrAkun(1) & "', '" & txtNoTransaksi.Text & "-" & newNumber & "', 1, '" & ttot & "') ", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information)
                    DaftarPembayaranHutang.TampilGrid()

                    Call InsertLogTrans(txtNoTransaksi.Text, "CREATE", MainMenu.PanelUser.Text, "BAYAR HUTANG - Total Rp. " & ttot)

                    Me.Close()
                Else
                    MsgBox("Oops! Tidak Ada Data yang tersimpan!", MsgBoxStyle.Critical)
                End If
            Else
                    MsgBox("Oops! Tidak Ada Data yang tersimpan!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
End Class