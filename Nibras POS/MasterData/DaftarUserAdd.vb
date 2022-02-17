Imports MySql.Data.MySqlClient

Public Class DaftarUserAdd
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub

    Private Sub DaftarUserAdd_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim statusUbah As Boolean = DaftarUser.ubah
        txtUserID.Select()

        If statusUbah = True Then
            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM users WHERE user_id = '" & DaftarUser.DGV.CurrentRow.Cells(0).Value & "' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                Dim kelompok As String = DR.Item("akses")
                txtUserID.Text = DR.Item("user_id")
                txtNamaUser.Text = DR.Item("nama_user")
                txtPassword.Text = DR.Item("password")
                txtKonfirmasi.Text = DR.Item("password")
                cekClose()

                cbKelompok.Items.Clear()
                cbKelompok.Items.Add("ADMINISTRATOR")
                cbKelompok.Items.Add("MANAGER")
                cbKelompok.Items.Add("KASIR")

                If kelompok = "ADMINISTRATOR" Then
                    cbKelompok.SelectedIndex = 0
                ElseIf kelompok = "MANAGER" Then
                    cbKelompok.SelectedIndex = 1
                Else
                    cbKelompok.SelectedIndex = 2
                End If
            Else
                cekClose()
                MsgBox("Oops! Data Tidak Ditemukan/ Terjadi Kesalahan")
            End If

        Else
            Call Kosongkan()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txtUserID.Text = "" Or txtNamaUser.Text = "" Or txtKonfirmasi.Text = "" Then
            MsgBox("Oops! Silahkan Lengkapi data terlebih dahulu", MsgBoxStyle.Exclamation, "Perhatian")
        Else
            If txtPassword.Text <> txtKonfirmasi.Text Then

                MsgBox("Maaf, Password tidak sama silahkan perbaiki kembali.", MsgBoxStyle.Critical, "Perhatian!")

            Else

                cekOpen()
                CMD = New MySqlCommand("INSERT INTO users (user_id, password, nama_user, akses) VALUES ('" & txtUserID.Text & "', '" & txtKonfirmasi.Text & "', '" & txtNamaUser.Text & "', '" & cbKelompok.Text & "') " &
                                       " ON DUPLICATE KEY UPDATE password = '" & txtKonfirmasi.Text & "', nama_user = '" & txtNamaUser.Text & "', akses = '" & cbKelompok.Text & "' ", Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                Call InsertLogTrans("USER", "CREATE", MainMenu.PanelUser.Text, "USER | CREATE/ EDIT USER " & txtNamaUser.Text)

                MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information, "Sukses")
                Call Kosongkan()

                DaftarUser.TampilGrid()
                Me.Close()
            End If
        End If
    End Sub

    Sub Kosongkan()
        txtUserID.Text = ""
        txtNamaUser.Text = ""
        txtPassword.Text = ""
        txtKonfirmasi.Text = ""

        cbKelompok.Items.Clear()
        cbKelompok.Items.Add("ADMINISTRATOR")
        cbKelompok.Items.Add("MANAGER")
        cbKelompok.Items.Add("KASIR")
    End Sub

    Private Sub txtUserID_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus
        txtUserID.Text = UCase(txtUserID.Text)
    End Sub
End Class