Imports System.Reflection
Imports MySql.Data.MySqlClient

Public Class Home
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles Me.Load
        TimerUpMember.Start()

        If MainMenu.PanelJenis.Text = "M" Then
            PictureBox1.Image = Image.FromFile("main_bg_db.jpg")
        Else
            PictureBox1.Image = Image.FromFile("main_bg.jpg")
        End If
    End Sub

    Private Sub Home_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim bgfile = Me.BackgroundImage
        Me.SuspendLayout()
        Me.BackgroundImage = Nothing
        Me.BackgroundImage = bgfile
        Me.ResumeLayout()
    End Sub

    Private Sub TimerUpMember_Tick(sender As Object, e As EventArgs) Handles TimerUpMember.Tick

        Dim hour As Integer = DateTime.Now.TimeOfDay.Hours
        Dim minute As Integer = DateTime.Now.TimeOfDay.Minutes
        Dim second As Integer = DateTime.Now.TimeOfDay.Seconds

        If CheckForInternetConnection() Then

            If hour = 12 And minute = 30 And second = 1 Then
                Call uploadMembers()
            End If

            cekClose()
            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM config_system WHERE config_name = 'upload_member'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            Dim status As Integer = 0
            If DR.HasRows Then
                'Console.WriteLine(DR.Item("status"))
                status = DR.Item("status")
                cekClose()
            End If

            If status = 1 Then
                Call uploadMembers()

                cekOpen()
                CMD = New MySqlCommand("UPDATE config_system SET status = 0 WHERE config_name = 'upload_member'", Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            End If

        End If
    End Sub
End Class