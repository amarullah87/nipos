Imports MySql.Data.MySqlClient

Public Class SettingPoint

    Sub Kosongkan()

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM config_point LIMIT 1", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtNominal.Text = FormatCurrency(DR.Item("nominal"))
        Else
            txtNominal.Text = FormatCurrency("0")
        End If
        cekClose()
    End Sub

    Private Sub SettingPoint_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        btnTutup.Focus()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btSimpan_Click(sender As Object, e As EventArgs) Handles btSimpan.Click
        cekOpen()
        CMD = New MySqlCommand("UPDATE config_point SET nominal = '" & txtNominal.Text & "' ", Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        MsgBox("Data Berhasil di Update", MsgBoxStyle.Information)
        Me.Close()
    End Sub
End Class