Imports MySql.Data.MySqlClient

Public Class MasterGroup
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilGrid()
        cekOpen()

        DA = New MySqlDataAdapter("SELECT kode_group AS Kode, nama_group AS `Group`, diskon AS Diskon, level FROM group_member ORDER BY urutan ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)

        cekClose()
    End Sub

    Private Sub MasterGroup_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()
    End Sub
End Class