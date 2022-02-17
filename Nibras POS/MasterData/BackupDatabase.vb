Imports System.IO
Imports MySql.Data.MySqlClient

Public Class BackupDatabase
    Public AsalMenu As Boolean = False

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        If AsalMenu Then
            Application.Exit()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Try
                txtBrowse.Text = FolderBrowserDialog1.SelectedPath
            Catch ex As Exception
                MsgBox("Error : " & ex.Message)
            End Try
        End If
    End Sub

    Sub GetConfigMysql()
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM config_url WHERE config_name = 'mysql'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            txtBrowse.Text = DR.Item("config_url")
        Else
            txtBrowse.Text = "C:\xampp\mysql\bin\"
        End If

        cekClose()
    End Sub

    Private Sub BackupDatabase_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call GetConfigMysql()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim dbFile As String
        Try
            SaveFileDialog1.Filter = "SQL Backup File (*.sql)|*.sql|All Files (*.*)|*.*"
            SaveFileDialog1.FileName = "NiPOS Database Backup " + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".sql"

            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                cekOpen()
                dbFile = SaveFileDialog1.FileName
                Dim BackupProcess As New Process
                BackupProcess.StartInfo.FileName = "cmd.exe"
                BackupProcess.StartInfo.UseShellExecute = False
                BackupProcess.StartInfo.WorkingDirectory = txtBrowse.Text.ToString
                'BackupProcess.StartInfo.WorkingDirectory = "C:\xampp5.6\mysql\bin\"
                BackupProcess.StartInfo.RedirectStandardInput = True
                BackupProcess.StartInfo.RedirectStandardOutput = True
                BackupProcess.Start()

                Dim BackupStream As StreamWriter = BackupProcess.StandardInput
                Dim myStream As StreamReader = BackupProcess.StandardOutput
                BackupStream.WriteLine("mysqldump --user=root --password= -h localhost --databases db_pos > """ + dbFile + """")

                BackupStream.Close()
                BackupProcess.WaitForExit()
                BackupProcess.Close()
                cekClose()

                MsgBox("Data Berhasil di backup!", MsgBoxStyle.Information, "NiPOS Backup")
            End If

            cekOpen()
            Dim newAddress As String = txtBrowse.Text.Replace("\", "\\")
            CMD = New MySqlCommand("UPDATE config_url SET config_url = '" & newAddress & "' WHERE config_name = 'mysql' ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()

        Catch ex As Exception
            MsgBox("Oops! Nothing to do!")
        End Try
    End Sub
End Class