Imports MySql.Data.MySqlClient

Public Class DaftarPembayaranHutang
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call TampilGrid()
    End Sub

    Sub TampilGrid()
        DGV.Rows.Clear()

        cekOpen()
        CMD = New MySqlCommand("SELECT no_transaksi, tanggal, tanggal_jt, sisa, potongan, total, jumlah_bayar, created_by  FROM hutang WHERE jumlah_bayar <> 0 GROUP BY kode_supplier", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("no_transaksi"), DR.Item("tanggal"), DR.Item("tanggal_jt"), CDec(DR.Item("sisa")), CDec(DR.Item("potongan")), CDec(DR.Item("total")), CDec(DR.Item("jumlah_bayar")), DR.Item("created_by"))
        Loop
        cekClose()
    End Sub

    Private Sub DaftarKasMasuk_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        TambahPembayaranHutang.MdiParent = MainMenu
        TambahPembayaranHutang.Show()
        TambahPembayaranHutang.Focus()
    End Sub
End Class