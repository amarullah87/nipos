Imports System.IO
Imports MySql.Data.MySqlClient

Public Class DialogExit

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Dim mysqlLocation As String
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM config_url WHERE config_name = 'mysql'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            mysqlLocation = DR.Item("config_url")
        Else
            mysqlLocation = "C:\xampp\mysql\bin\"
        End If

        cekClose()


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
                BackupProcess.StartInfo.WorkingDirectory = mysqlLocation
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

                'MsgBox("Data Berhasil di backup!", MsgBoxStyle.Information, "NiPOS Backup")
            End If

        Catch ex As Exception
            MsgBox("Oops! Nothing to do!")
        End Try
        Application.Exit()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Application.Exit()
    End Sub
End Class