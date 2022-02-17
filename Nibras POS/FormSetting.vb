Imports System.IO
Imports MySql.Data.MySqlClient

Public Class FormSetting

    Dim lokasi As String = Application.StartupPath & "\Config.txt"
    Dim server As String
    Dim userServer As String
    Dim passServer As String
    Dim dbName As String
    Dim baris As String()

    Private Sub FormSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
        baris = File.ReadAllLines(lokasi)

        txtServer.Text = baris(0)
        txtUsername.Text = baris(1)
        txtPassword.Text = baris(2)
        txtDatabase.Text = baris(3)
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        cekClose()

        Try
            Conn.ConnectionString = "server=" & txtServer.Text & ";user=" & txtUsername.Text & ";password=" & txtPassword.Text
            cekOpen()
            CMD = New MySqlCommand("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" & txtDatabase.Text & "' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If (DR.HasRows) Then
                cekClose()

                Conn.ConnectionString = "server=" & txtServer.Text & ";database=" & txtDatabase.Text & ";user=" &
                    txtUsername.Text & ";password=" & txtPassword.Text

                cekOpen()
                If Conn.State = ConnectionState.Open Then
                    MsgBox("Connected!")
                    LoginForm.btnLogin.Enabled = True
                Else
                    MsgBox("Oops! Terjadi Kesalahan, Silahkan hubungi tim IT")
                End If
                cekClose()

            Else
                cekClose()
                MsgBox("Maaf! Tidak Ditemukan Database dengan Nama: " & txtDatabase.Text & "!!")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim newData As String() = {txtServer.Text, txtUsername.Text, txtPassword.Text, txtDatabase.Text}
        File.WriteAllLines(lokasi, newData)

        MsgBox("Data Berhasil Disimpan!")
        Me.Close()
        Application.Restart()
    End Sub
End Class