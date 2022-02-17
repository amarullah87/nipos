Imports MySql.Data.MySqlClient

Public Class PencarianBarangPesanBeli
    Dim Raw As String
    Dim totalData As Integer

    Sub TampilGrid()
        DGV.ReadOnly = True
        'DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
    End Sub

    Private Sub PencarianBarang_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()

        TXTCariBarang.Text = PesananPembelian.txtBarcode.Text
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

    Sub Pencarian()
        DGV.Rows.Clear()

        Dim total As Integer = 0
        cekOpen()
        CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj from barang_m where nama_barang like '%" & TXTCariBarang.Text & "%'", Conn)
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

    Private Sub TXTCariBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCariBarang.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Call Pencarian()
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

                Dim baris As Integer = PesananPembelian.DGV.RowCount - 1
                PesananPembelian.DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("hpj"), 1, minDisc)
                PesananPembelian.txtBarcode.Clear()
                cekClose()

                Dim diskon As Double = PesananPembelian.DGV.Rows(baris).Cells(4).Value / 100
                Dim diskonRupiah As Double = (PesananPembelian.DGV.Rows(baris).Cells(2).Value * PesananPembelian.DGV.Rows(baris).Cells(3).Value) * diskon
                PesananPembelian.DGV.Rows(baris).Cells(5).Value = (PesananPembelian.DGV.Rows(baris).Cells(2).Value * PesananPembelian.DGV.Rows(baris).Cells(3).Value) - diskonRupiah

                Call PesananPembelian.Hitungtransaksi()
                For barisatas As Integer = 0 To PesananPembelian.DGV.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To PesananPembelian.DGV.RowCount - 1
                        If PesananPembelian.DGV.Rows(barisbawah).Cells(0).Value = PesananPembelian.DGV.Rows(barisatas).Cells(0).Value Then

                            Dim diskonEdit As Double = PesananPembelian.DGV.Rows(barisatas).Cells(4).Value / 100
                            Dim qtyEdit As Double = PesananPembelian.DGV.Rows(barisatas).Cells(3).Value + 1
                            Dim diskonRupiahEdit As Double = (PesananPembelian.DGV.Rows(barisatas).Cells(2).Value * qtyEdit) * diskonEdit

                            PesananPembelian.DGV.Rows(barisatas).Cells(3).Value = PesananPembelian.DGV.Rows(barisatas).Cells(3).Value + 1
                            PesananPembelian.DGV.Rows(barisatas).Cells(5).Value = (PesananPembelian.DGV.Rows(barisatas).Cells(2).Value * qtyEdit) - diskonRupiahEdit
                            PesananPembelian.DGV.Rows.RemoveAt(barisbawah)
                            Call PesananPembelian.Hitungtransaksi()
                            Exit Sub
                        End If
                    Next
                Next
            End If
            cekClose()
            Me.Close()
            PesananPembelian.txtBarcode.Focus()
            PesananPembelian.txtBarcode.Text = ""
        End If
    End Sub
End Class