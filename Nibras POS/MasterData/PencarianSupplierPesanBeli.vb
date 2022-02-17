Imports MySql.Data.MySqlClient

Public Class PencarianSupplierPesanBeli
    Dim Raw As String
    Dim totalData As Integer

    Sub TampilGrid()
        DGV.ReadOnly = True
        'DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
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

    Private Sub TXTCariBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCariBarang.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            DGV.Rows.Clear()

            Dim total As Integer = 0
            Dim query As String

            cekOpen()
            query = "SELECT kode, nama, alamat, kontak FROM mst_distributor WHERE nama LIKE '%" & TXTCariBarang.Text & "%'"

            CMD = New MySqlCommand(query, Conn)
            DR = CMD.ExecuteReader

            While DR.Read
                DGV.Rows.Add(
                    DR.Item("kode"),
                    DR.Item("nama"),
                    DR.Item("alamat"),
                    DR.Item("kontak")
                )

                total += 1
            End While
            txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
            cekClose()
        End If
    End Sub

    Private Sub PencarianSupplier_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()

        TXTCariBarang.Focus()
        TXTCariBarang.Select()

        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            PesananPembelian.cbosupplier.Text = DGV.Rows(e.RowIndex).Cells(0).Value
            PesananPembelian.lblkodesupplier.Text = DGV.Rows(e.RowIndex).Cells(1).Value
            PesananPembelian.txtBarcode.Focus()
            PesananPembelian.txtBarcode.Text = ""
            Me.Close()
        End If
    End Sub
End Class