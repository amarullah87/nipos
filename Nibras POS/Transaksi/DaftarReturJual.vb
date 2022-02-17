Imports MySql.Data.MySqlClient

Public Class DaftarReturJual

    Public notransaksi As String = ""
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilGrid()
        DGV.Rows.Clear()
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT r.*, p.kode_customer FROM returpenjualan r " &
                               " INNER JOIN penjualan p ON p.faktur_jual = r.faktur_jual WHERE r.tgl_retur_jual BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("no_retur_jual"), DR.Item("tgl_retur_jual"), DR.Item("faktur_jual"), DR.Item("kode_customer"), DR.Item("item_retur_jual"), CDec(DR.Item("subtotal")), DR.Item("kode_user"))
        Loop
        cekClose()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call TampilGrid()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        TransaksiReturPenjualan.MdiParent = MainMenu
        TransaksiReturPenjualan.Show()
        TransaksiReturPenjualan.Focus()
    End Sub

    Private Sub DaftarReturJual_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpAwal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)
        Call TampilGrid()
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        notransaksi = DGV.CurrentRow.Cells(0).Value
        DetailReturJual.ShowDialog()
    End Sub
End Class