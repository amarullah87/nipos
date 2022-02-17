Imports MySql.Data.MySqlClient

Public Class PencarianSupplier

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

            If TransaksiPembelian.cbFromNHS.Checked = True Then
                query = "SELECT id AS kode, nama, nama AS nama_toko, alamat, '' AS domisili, no_tlf AS kontak, '0' AS deposit FROM master_nhs WHERE nama LIKE '%" & TXTCariBarang.Text & "%'"
            Else
                query = "SELECT kode, nama, nama_toko, alamat, domisili, kontak, deposit FROM mst_distributor WHERE nama LIKE '%" & TXTCariBarang.Text & "%'"
            End If


            CMD = New MySqlCommand(query, Conn)
            DR = CMD.ExecuteReader

            While DR.Read

                'If

                DGV.Rows.Add(
                    DR.Item("kode"),
                    DR.Item("nama"),
                    DR.Item("nama_toko"),
                    DR.Item("alamat") & vbNewLine & DR.Item("domisili") & vbNewLine & DR.Item("kontak"),
                    DR.Item("deposit")
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

        TXTCariBarang.Text = TransaksiPembelian.cbosupplier.Text
        TXTCariBarang.Focus()
        TXTCariBarang.Select()

        SetDoubleBuffered(DGV, True)

        Call Pencarian()
    End Sub

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            TransaksiPembelian.cbosupplier.Text = DGV.Rows(e.RowIndex).Cells(0).Value
            TransaksiPembelian.lblkodesupplier.Text = DGV.Rows(e.RowIndex).Cells(1).Value
            TransaksiPembelian.txtBarcode.Focus()
            TransaksiPembelian.txtBarcode.Text = ""
            TransaksiPembelian.txtDeposit.Text = DGV.Rows(e.RowIndex).Cells(4).Value
            TransaksiPembelian.lblDeposit.Text = DGV.Rows(e.RowIndex).Cells(4).Value
            Me.Close()
        End If
    End Sub

    Sub Pencarian()
        DGV.Rows.Clear()

        Dim total As Integer = 0
        Dim query As String

        cekOpen()

        If TransaksiPembelian.cbFromNHS.Checked = True Then
            query = "SELECT id AS kode, nama, nama AS nama_toko, alamat, '' AS domisili, no_tlf AS kontak, '0' AS deposit FROM master_nhs WHERE nama LIKE '%" & TXTCariBarang.Text & "%'"
        Else
            query = "SELECT kode, nama, nama_toko, alamat, domisili, kontak, deposit FROM mst_distributor WHERE nama LIKE '%" & TXTCariBarang.Text & "%'"
        End If


        CMD = New MySqlCommand(query, Conn)
        DR = CMD.ExecuteReader

        While DR.Read

            'If

            DGV.Rows.Add(
                DR.Item("kode"),
                DR.Item("nama"),
                DR.Item("nama_toko"),
                DR.Item("alamat") & vbNewLine & DR.Item("domisili") & vbNewLine & DR.Item("kontak"),
                DR.Item("deposit")
            )

            total += 1
        End While
        txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
        cekClose()
    End Sub
End Class