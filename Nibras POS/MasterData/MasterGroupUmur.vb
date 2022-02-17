Imports MySql.Data.MySqlClient

Public Class MasterGroupUmur
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilGrid()
        cekOpen()

        DA = New MySqlDataAdapter("SELECT nama_group AS `Group Umur`, diskon AS `Referensi Diskon` FROM group_usia_produk ORDER BY urutan ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)

        cekClose()
    End Sub

    Private Sub MasterGroupUmur_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()
    End Sub
End Class