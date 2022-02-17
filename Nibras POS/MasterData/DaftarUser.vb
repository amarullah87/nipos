Imports MySql.Data.MySqlClient

Public Class DaftarUser

    Public ubah As Boolean = False

    Sub TampilGrid()
        cekOpen()

        DA = New MySqlDataAdapter("SELECT user_id, nama_user, akses FROM users", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

        DGV.Columns(0).HeaderText = "USER ID"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(1).HeaderText = "NAMA USER"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(2).HeaderText = "AKSES"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        cekClose()
    End Sub

    Private Sub DaftarUser_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Dim user As String = DGV.CurrentRow.Cells(0).Value

        If user = "ADMIN" Then
            MsgBox("Maaf anda tidak dapat menghapus [admin], anda hanya dapat mengubah passwordnya saja.", MsgBoxStyle.Critical, "Perhatian!")
        Else
            If user = MainMenu.PanelUser.Text Then
                MsgBox("Maaf anda tidak dapat menghapus user anda sendiri.", MsgBoxStyle.Critical, "Perhatian!")
            Else

                If MessageBox.Show("Apakah Data Akan di Hapus?!" & vbCrLf & "Data yang sudah di hapus Tidak Dapat Dikembalikan.", "Perhatian",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

                    cekOpen()
                    CMD = New MySqlCommand("DELETE FROM users WHERE user_id = '" & user & "' ", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    Call InsertLogTrans("USER", "DELETE", MainMenu.PanelUser.Text, "USER | DELETE USER " & user)

                    MsgBox("User Berhasil Di Hapus!", MsgBoxStyle.Information, "Sukses")
                    Call TampilGrid()
                End If
            End If
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ubah = True
        DaftarUserAdd.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ubah = False
        DaftarUserAdd.ShowDialog()
    End Sub
End Class