Imports MySql.Data.MySqlClient

Public Class DaftarItemMasuk

    Public notransaksi As String = ""
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        notransaksi = ""
        TransaksiItemMasuk.MdiParent = MainMenu
        TransaksiItemMasuk.Show()
        TransaksiItemMasuk.Focus()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call TampilGrid()
    End Sub

    Sub TampilGrid()
        DGV.Rows.Clear()

        cekOpen()
        CMD = New MySqlCommand("SELECT t.*, p.`namaacc` FROM transaksi_barang t INNER JOIN perkiraan p ON p.`kodeacc` = t.`kode_akun` WHERE jenis_transaksi = 1 ORDER BY no_transaksi DESC", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("no_transaksi"), DR.Item("tanggal"), DR.Item("kode_akun") & "/" & DR.Item("namaacc"), CDec(DR.Item("qty")), CDec(DR.Item("total")), DR.Item("keterangan"), DR.Item("created_by"))
        Loop
        cekClose()
    End Sub

    Private Sub DaftarItemMasuk_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If DGV.RowCount > 0 Then
            notransaksi = DGV.CurrentRow.Cells(0).Value

            TransaksiItemMasuk.MdiParent = MainMenu
            TransaksiItemMasuk.Show()
            TransaksiItemMasuk.Focus()
            'MsgBox(DGV.CurrentRow.Cells(0).Value)
        Else
            MsgBox("Tidak Ada Data.", MsgBoxStyle.Information, "Informasi")
        End If
    End Sub
End Class