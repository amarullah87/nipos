Imports MySql.Data.MySqlClient

Public Class PencarianBarangSO

    Dim Raw As String
    Dim totalData As Integer

    Sub GetData()
        DGV.Rows.Clear()

        Dim namabarang As String
        If TXTCariBarang.Text.Contains("'") Then
            namabarang = TXTCariBarang.Text.Replace("'", "''")
        Else
            namabarang = TXTCariBarang.Text
        End If

        Dim total As Integer = 0
        cekOpen()
        CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj, stok from barang_m where nama_barang like '%" & namabarang & "%' LIMIT 500", Conn)
        DR = CMD.ExecuteReader

        While DR.Read
            DGV.Rows.Add(
                DR.Item("kode_item"),
                DR.Item("barcode"),
                DR.Item("nama_barang"),
                CDec(DR.Item("hpp")),
                CDec(DR.Item("hpj")),
                CDec(DR.Item("stok"))
            )

            total += 1
        End While
        txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
        cekClose()
    End Sub

    Sub TampilGrid()
        DGV.ReadOnly = True
        'DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace

    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            Dim kode_item As String = DGV.Rows(e.RowIndex).Cells(0).Value

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & kode_item & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If (DR.HasRows) Then
                Dim hpp As Double = DR.Item("hpp")
                Dim hpj As Double = DR.Item("hpj")
                Dim nama As String = DR.Item("nama_barang")
                cekClose()

                cekOpen()
                Dim simpan1 As String = "INSERT INTO  `so_temp`  (`id_barang`, `qty`, `hpj`,  `hpp`,  `tanggal`, `tanggal_time`,`nama_produk`)
VALUES ('" & kode_item & "',  1, '" & hpj & "', '" & hpp & "', NOW(), NOW(),'" & nama & "')
on duplicate key update qty = qty + 1, tanggal_time=NOW()"
                CMD = New MySqlCommand(simpan1, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

            End If

            Me.Close()
            TransaksiStokOpnameNew.txtBarcode.Focus()
            TransaksiStokOpnameNew.txtBarcode.Select()
            TransaksiStokOpnameNew.getFocus()
            TransaksiStokOpnameNew.Kosongkan()
        End If
    End Sub

    Private Sub PencarianBarangSO_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()

        TXTCariBarang.Text = TransaksiStokOpnameNew.txtBarcode.Text
        TXTCariBarang.Focus()
        TXTCariBarang.Select()

        SetDoubleBuffered(DGV, True)
        Call GetData()
    End Sub

    Private Sub TXTCariBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCariBarang.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            DGV.Rows.Clear()

            Dim namabarang As String
            If TXTCariBarang.Text.Contains("'") Then
                namabarang = TXTCariBarang.Text.Replace("'", "''")
            Else
                namabarang = TXTCariBarang.Text
            End If

            Dim total As Integer = 0
            cekOpen()
            CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj, stok from barang_m where nama_barang like '%" & namabarang & "%' LIMIT 500", Conn)
            DR = CMD.ExecuteReader

            While DR.Read
                DGV.Rows.Add(
                    DR.Item("kode_item"),
                    DR.Item("barcode"),
                    DR.Item("nama_barang"),
                    CDec(DR.Item("hpp")),
                    CDec(DR.Item("hpj")),
                    CDec(DR.Item("stok"))
                )

                total += 1
            End While
            txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
            cekClose()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        DGV.Rows.Clear()
        TXTCariBarang.Text = ""
        Raw = ""
        txtTotalData.Text = "Total: 0 Data"
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Me.Close()
        DownloadBarang.Show()
    End Sub
End Class