Imports MySql.Data.MySqlClient

Public Class PencarianBarangPersediaan

    Dim Raw As String
    Dim totalData As Integer

    Sub TampilGrid()
        DGV.ReadOnly = True
        'DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
    End Sub

    Private Sub PencarianBarang_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()

        TXTCariBarang.Text = SaldoAwalPersediaan.txtJumlah.Text
        TXTCariBarang.Focus()
        TXTCariBarang.Select()

        SetDoubleBuffered(DGV, True)
        Call Pencarian()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        DGV.Rows.Clear()
        TXTCariBarang.Text = ""
        Raw = ""
        txtTotalData.Text = "Total: 0 Data"
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
        DownloadBarang.Show()
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
            CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj, stok from barang_m where nama_barang like '%" & namabarang & "%' LIMIT 500 ", Conn)
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

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call Pencarian()
    End Sub

    Sub Pencarian()
        DGV.Rows.Clear()

        Dim namabarang As String
        If TXTCariBarang.Text.Contains("'") Then
            namabarang = TXTCariBarang.Text.Replace("'", "''")
        Else
            namabarang = TXTCariBarang.Text
        End If

        Dim total As Integer = 0
        cekOpen()
        CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj, stok from barang_m where nama_barang like '%" & namabarang & "%' LIMIT 500 ", Conn)
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

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then

            Dim baris As Integer = DGV.RowCount - 1
            SaldoAwalPersediaan.DGV.Rows.Add(DGV.Rows(e.RowIndex).Cells(0).Value,
                         DGV.Rows(e.RowIndex).Cells(2).Value,
                         "pcs", DGV.Rows(e.RowIndex).Cells(3).Value, 1,
                         DGV.Rows(e.RowIndex).Cells(3).Value)

            Call SaldoAwalPersediaan.HitungTransaksi()
            For barisatas As Integer = 0 To SaldoAwalPersediaan.DGV.RowCount - 1
                For barisbawah As Integer = barisatas + 1 To SaldoAwalPersediaan.DGV.RowCount - 1
                    If SaldoAwalPersediaan.DGV.Rows(barisbawah).Cells(0).Value = SaldoAwalPersediaan.DGV.Rows(barisatas).Cells(0).Value Then

                        SaldoAwalPersediaan.DGV.Rows(barisatas).Cells(4).Value = SaldoAwalPersediaan.DGV.Rows(barisatas).Cells(4).Value + 1
                        SaldoAwalPersediaan.DGV.Rows(barisatas).Cells(5).Value = SaldoAwalPersediaan.DGV.Rows(barisatas).Cells(3).Value * SaldoAwalPersediaan.DGV.Rows(barisatas).Cells(4).Value
                        SaldoAwalPersediaan.DGV.Rows.RemoveAt(barisbawah)
                        Call SaldoAwalPersediaan.HitungTransaksi()
                        Me.Close()
                    End If
                Next
            Next

            Me.Close()
            SaldoAwalPersediaan.txtJumlah.Focus()
            SaldoAwalPersediaan.txtJumlah.Text = ""
        End If
    End Sub
End Class