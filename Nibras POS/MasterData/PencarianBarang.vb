Imports MySql.Data.MySqlClient

Public Class PencarianBarang

    Dim Raw As String
    Dim totalData As Integer

    Sub TampilGrid()
        DGV.ReadOnly = True
        'DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
    End Sub

    Private Sub PencarianBarang_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()

        TXTCariBarang.Text = TransaksiPembelian.txtBarcode.Text
        TXTCariBarang.Focus()
        TXTCariBarang.Select()

        SetDoubleBuffered(DGV, True)

        DGV.Rows.Clear()

        Dim namabarang As String
        If TransaksiPembelian.txtBarcode.Text.Contains("'") Then
            namabarang = TransaksiPembelian.txtBarcode.Text.Replace("'", "''")
        Else
            namabarang = TransaksiPembelian.txtBarcode.Text
        End If

        Dim total As Integer = 0
        cekOpen()
        CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj from barang_m where nama_barang like '%" & namabarang & "%' LIMIT 500", Conn)
        DR = CMD.ExecuteReader

        While DR.Read
            DGV.Rows.Add(
                DR.Item("kode_item"),
                DR.Item("barcode"),
                DR.Item("nama_barang"),
                CDec(DR.Item("hpp")),
                CDec(DR.Item("hpj"))
            )

            total += 1
        End While
        txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
        cekClose()
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
            CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj from barang_m where nama_barang like '%" & namabarang & "%' LIMIT 500", Conn)
            DR = CMD.ExecuteReader

            While DR.Read
                DGV.Rows.Add(
                    DR.Item("kode_item"),
                    DR.Item("barcode"),
                    DR.Item("nama_barang"),
                    CDec(DR.Item("hpp")),
                    CDec(DR.Item("hpj"))
                )

                total += 1
            End While
            txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
            cekClose()
        End If
    End Sub

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            Dim kode_item As String = DGV.Rows(e.RowIndex).Cells(0).Value

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & kode_item & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If (DR.HasRows) Then

                Dim minDisc As Integer
                Dim maxDisc As Integer

                Select Case MainMenu.PanelJenis.Text
                    Case "D"
                        minDisc = 40
                        maxDisc = 43
                    Case "M"
                        minDisc = 35
                        maxDisc = 35
                    Case "N"
                        minDisc = 35
                        maxDisc = 35
                    Case "K"
                        minDisc = 35
                        maxDisc = 35
                    Case "AB"
                        minDisc = 35
                        maxDisc = 35
                    Case "A"
                        minDisc = 30
                        maxDisc = 30
                    Case "R"
                        minDisc = 20
                        maxDisc = 20
                    Case Else
                        minDisc = 10
                        maxDisc = 10
                End Select

                Dim baris As Integer = TransaksiPembelian.DGV.RowCount - 1
                TransaksiPembelian.DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("hpj"), 1, 1, minDisc)
                TransaksiPembelian.txtBarcode.Clear()
                cekClose()

                Dim diskon As Double = TransaksiPembelian.DGV.Rows(baris).Cells(5).Value / 100
                Dim diskonRupiah As Double = (TransaksiPembelian.DGV.Rows(baris).Cells(2).Value * TransaksiPembelian.DGV.Rows(baris).Cells(3).Value) * diskon
                TransaksiPembelian.DGV.Rows(baris).Cells(6).Value = (TransaksiPembelian.DGV.Rows(baris).Cells(2).Value * TransaksiPembelian.DGV.Rows(baris).Cells(3).Value) - diskonRupiah

                Call TransaksiPembelian.Hitungtransaksi()
                For barisatas As Integer = 0 To TransaksiPembelian.DGV.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To TransaksiPembelian.DGV.RowCount - 1
                        If TransaksiPembelian.DGV.Rows(barisbawah).Cells(0).Value = TransaksiPembelian.DGV.Rows(barisatas).Cells(0).Value Then

                            Dim diskonEdit As Double = TransaksiPembelian.DGV.Rows(barisatas).Cells(5).Value / 100
                            Dim qtyEdit As Double = TransaksiPembelian.DGV.Rows(barisatas).Cells(3).Value + 1
                            Dim diskonRupiahEdit As Double = (TransaksiPembelian.DGV.Rows(barisatas).Cells(2).Value * qtyEdit) * diskonEdit

                            TransaksiPembelian.DGV.Rows(barisatas).Cells(3).Value = TransaksiPembelian.DGV.Rows(barisatas).Cells(3).Value + 1
                            TransaksiPembelian.DGV.Rows(barisatas).Cells(6).Value = (TransaksiPembelian.DGV.Rows(barisatas).Cells(2).Value * qtyEdit) - diskonRupiahEdit
                            TransaksiPembelian.DGV.Rows.RemoveAt(barisbawah)
                            Call TransaksiPembelian.Hitungtransaksi()
                            Exit Sub
                        End If
                    Next
                Next
            End If
            cekClose()
            Call TransaksiPembelian.Hitungtransaksi()

            Me.Close()
            TransaksiPembelian.txtBarcode.Focus()
            TransaksiPembelian.txtBarcode.Text = ""
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        DGV.Rows.Clear()

        Dim namabarang As String
        If TXTCariBarang.Text.Contains("'") Then
            namabarang = TXTCariBarang.Text.Replace("'", "''")
        Else
            namabarang = TXTCariBarang.Text
        End If

        Dim total As Integer = 0
        cekOpen()
        CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj from barang_m where nama_barang like '%" & namabarang & "%' LIMIT 500", Conn)
        DR = CMD.ExecuteReader

        While DR.Read
            DGV.Rows.Add(
                DR.Item("kode_item"),
                DR.Item("barcode"),
                DR.Item("nama_barang"),
                CDec(DR.Item("hpp")),
                CDec(DR.Item("hpj"))
            )

            total += 1
        End While
        txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
        cekClose()
    End Sub
End Class