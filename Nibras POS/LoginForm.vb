Imports MySql.Data.MySqlClient
Imports System.IO

Public Class LoginForm

    Dim lokasi As String = Application.StartupPath & "\Config.txt"
    Dim server As String
    Dim userServer As String
    Dim passServer As String
    Dim dbName As String
    Dim baris As String()

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormSetting.Show()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtUsername.Text = "superadmin" Then

            If txtPassword.Text = "Euleulmeudeud234" Then
                Me.Visible = False

                SplashScreen.txtKodeUser.Text = "superadmin"
                SplashScreen.txtUsername.Text = "superadmin"
                SplashScreen.txtStatus.Text = "SUPERADMIN"
                SplashScreen.Show()

            Else
                MsgBox("Maaf Login Gagal, Username/ Password Salah.", MsgBoxStyle.Exclamation, "Oops!")
                txtUsername.Text = ""
                txtPassword.Text = ""
                txtUsername.Select()
            End If

        Else
            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM users WHERE user_id = '" & txtUsername.Text.ToUpper & "' AND password ='" & txtPassword.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                Me.Visible = False

                SplashScreen.txtKodeUser.Text = DR.Item("akses")
                SplashScreen.txtUsername.Text = DR.Item("user_id")
                SplashScreen.txtStatus.Text = DR.Item("akses")
                SplashScreen.Show()

            Else
                MsgBox("Maaf Login Gagal, Username/ Password Salah.", MsgBoxStyle.Exclamation, "Oops!")
                txtUsername.Text = ""
                txtPassword.Text = ""
                txtUsername.Select()
            End If

            cekClose()
        End If
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtUsername.Select()
        cekKoneksi()

        Dim myProcesses() As Process
        myProcesses = Process.GetProcessesByName("Nibras POS Utility")

        Try

            If myProcesses.Length > 0 Then
                'For Each myProcess In myProcesses
                '    If myProcess IsNot Nothing Then
                '        myProcess.Kill()
                '    End If

                'Next
            Else
                'Dim filePath As String = IO.Path.Combine(Application.StartupPath, "POS_Utility.exe")
                Dim strPath As String = Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().CodeBase)
                'Console.WriteLine(strPath + "\POS_Utility.exe")
                Process.Start(strPath + "\Nibras POS Utility.exe")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Chr(13) Then txtPassword.Focus()
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then btnLogin.Focus()
    End Sub
End Class