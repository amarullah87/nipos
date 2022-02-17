Imports MySql.Data.MySqlClient

Public Class DetailReturJual

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilGrid()
        DGV.Rows.Clear()

        cekOpen()
        CMD = New MySqlCommand("SELECT d.*, b.nama_barang FROM detailreturjual d INNER JOIN barang_m b ON b.kode_item = d.kode_barang WHERE no_retur_jual = '" & DaftarReturJual.notransaksi & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("no_retur_jual"), DR.Item("kode_barang"), DR.Item("nama_barang"), DR.Item("qty_retur_jual"), CDec(DR.Item("harga_jual") / DR.Item("qty_retur_jual")), DR.Item("alasan_retur_jual"), CDec(DR.Item("harga_jual")))
        Loop
        cekClose()
    End Sub

    Private Sub DetailReturJual_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call TampilGrid()
    End Sub
End Class