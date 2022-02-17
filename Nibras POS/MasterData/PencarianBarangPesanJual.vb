Imports MySql.Data.MySqlClient

Public Class PencarianBarangPesanJual
    Dim Raw As String
    Dim totalData As Integer

    Sub TampilGrid()
        DGV.ReadOnly = True
        'DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
    End Sub

    Private Sub PencarianBarang_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()

        TXTCariBarang.Text = PesananPenjualan.txtBarcode.Text
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

            Dim total As Integer = 0
            cekOpen()
            CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj, stok from barang_m where nama_barang like '%" & TXTCariBarang.Text & "%' ", Conn)
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

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            Dim kode_item As String = DGV.Rows(e.RowIndex).Cells(0).Value

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & kode_item & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If (DR.HasRows) Then

                If Integer.Parse(DR.Item("stok")) > 0 Then

                    'Select Case MenuUtamaNew.PanelJenis.Text
                    '    Case "D"
                    '        minDisc = 40
                    '        maxDisc = 43
                    '    Case "M"
                    '        minDisc = 35
                    '        maxDisc = 35
                    '    Case "N"
                    '        minDisc = 35
                    '        maxDisc = 35
                    '    Case "K"
                    '        minDisc = 35
                    '        maxDisc = 35
                    '    Case "AB"
                    '        minDisc = 35
                    '        maxDisc = 35
                    '    Case "A"
                    '        minDisc = 30
                    '        maxDisc = 30
                    '    Case "R"
                    '        minDisc = 20
                    '        maxDisc = 20
                    '    Case Else
                    '        minDisc = 10
                    '        maxDisc = 10
                    'End Select

                    If TransaksiPenjualanNhs.txtJenisNhs.Text <> "" Then

                        Dim disc As Integer
                        If TransaksiPenjualanNhs.cbMemberInternal.Checked = True Then
                            disc = 30
                        Else
                            disc = TransaksiPenjualanNhs.txtDiskon.Text
                        End If

                        Dim diskon As Double = disc / 100
                        Dim diskonRupiah As Double = (DR.Item("hpj") * 1) * diskon
                        Dim total As Double = (DR.Item("hpj") * 1) - diskonRupiah
                        'MsgBox(disc)

                        TransaksiPenjualanNhs.DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("jenis"), DR.Item("hpj"), 1, disc, 0, total, diskonRupiah)
                    Else

                        Dim disc As Integer = Integer.Parse(TransaksiPenjualanNhs.txtDiskon.Text)
                        Dim diskon As Double = Double.Parse(disc) / 100
                        Dim diskonRupiah As Double = (DR.Item("hpj") * 1) * diskon
                        Dim total As Double = (DR.Item("hpj") * 1) - diskonRupiah
                        'MsgBox("B" + diskon.ToString + "/" + diskonRupiah.ToString + "/" + total.ToString)

                        TransaksiPenjualanNhs.DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("jenis"), DR.Item("hpj"), 1, TransaksiPenjualanNhs.txtDiskon.Text, 0, total, diskonRupiah)
                    End If

                    Dim baris As Integer = TransaksiPenjualanNhs.DGV.RowCount - 1
                    TransaksiPenjualanNhs.txtBarcode.Clear()
                    cekClose()

                    Call TransaksiPenjualanNhs.Hitungtransaksi()
                    For barisatas As Integer = 0 To TransaksiPenjualanNhs.DGV.RowCount - 1
                        For barisbawah As Integer = barisatas + 1 To TransaksiPenjualanNhs.DGV.RowCount - 1
                            If TransaksiPenjualanNhs.DGV.Rows(barisbawah).Cells(0).Value = TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(0).Value Then

                                Dim diskonEdit As Double = TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(6).Value / 100
                                Dim qtyEdit As Double = TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(5).Value + 1
                                Dim diskonRupiahEdit As Double = (TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(4).Value * qtyEdit) * diskonEdit

                                TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(5).Value = TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(5).Value + 1
                                TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(8).Value = (TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(4).Value * qtyEdit) - diskonRupiahEdit
                                TransaksiPenjualanNhs.DGV.Rows(barisatas).Cells(9).Value = diskonRupiahEdit
                                TransaksiPenjualanNhs.DGV.Rows.RemoveAt(barisbawah)
                                Call TransaksiPenjualanNhs.Hitungtransaksi()
                                Exit Sub
                            End If
                        Next
                    Next
                    Me.Close()
                    TransaksiPenjualanNhs.txtBarcode.Focus()
                    TransaksiPenjualanNhs.txtBarcode.Text = ""
                Else
                    Me.Close()
                    cekClose()
                    TransaksiPenjualanNhs.txtBarcode.Focus()
                    MsgBox("Stok Tidak Mencukupi!", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call Pencarian()
    End Sub

    Sub Pencarian()
        DGV.Rows.Clear()

        Dim total As Integer = 0
        cekOpen()
        CMD = New MySqlCommand("select kode_item, barcode, nama_barang, hpp, hpj, stok from barang_m where nama_barang like '%" & TXTCariBarang.Text & "%' ", Conn)
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
End Class