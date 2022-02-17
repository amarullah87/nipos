Imports MySql.Data.MySqlClient

Public Class PencarianBarangItemKeluar

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

    Private Sub DownloadBarang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()

        TXTCariBarang.Text = TransaksiItemKeluar.txtBarcode.Text
        TXTCariBarang.Focus()
        TXTCariBarang.Select()

        SetDoubleBuffered(DGV, True)

        Call GetData()
    End Sub

    Private Sub BTNTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        DGV.Rows.Clear()
        TXTCariBarang.Text = ""
        Raw = ""
        txtTotalData.Text = "Total: 0 Data"
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Me.Close()
        DownloadBarang.Show()
    End Sub

    Private Sub TXTCariBarang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCariBarang.KeyPress
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

    Private Sub DGV_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            Dim kode_item As String = DGV.Rows(e.RowIndex).Cells(0).Value

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & kode_item & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If (DR.HasRows) Then

                Dim baris As Integer = TransaksiItemKeluar.DGV.RowCount - 1
                TransaksiItemKeluar.DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("jenis"), DR.Item("hpp"), 1, DR.Item("hpp"))
                DGV.CurrentCell = DGV(4, DGV.CurrentCell.RowIndex)
                TransaksiItemKeluar.txtBarcode.Clear()
                cekClose()

                Call TransaksiItemKeluar.Hitungtransaksi()
                For barisatas As Integer = 0 To TransaksiItemKeluar.DGV.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To TransaksiItemKeluar.DGV.RowCount - 1
                        If TransaksiItemKeluar.DGV.Rows(barisbawah).Cells(0).Value = TransaksiItemKeluar.DGV.Rows(barisatas).Cells(0).Value Then

                            TransaksiItemKeluar.DGV.Rows(barisatas).Cells(5).Value = TransaksiItemKeluar.DGV.Rows(barisatas).Cells(5).Value + 1
                            TransaksiItemKeluar.DGV.Rows(barisatas).Cells(6).Value = TransaksiItemKeluar.DGV.Rows(barisatas).Cells(4).Value * TransaksiItemKeluar.DGV.Rows(barisatas).Cells(5).Value
                            TransaksiItemKeluar.DGV.Rows.RemoveAt(barisbawah)
                            SendKeys.Send("{up}")
                            Call TransaksiItemKeluar.Hitungtransaksi()
                            Exit Sub
                        End If
                    Next
                Next
            End If

            Me.Close()
            TransaksiItemKeluar.txtBarcode.Focus()
            TransaksiItemKeluar.txtBarcode.Text = ""
        End If
    End Sub
End Class