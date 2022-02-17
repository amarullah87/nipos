Imports System.IO
Imports MySql.Data.MySqlClient

Public Class DaftarJurnal
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub Kosongkan()
        DGV.Rows.Clear()
        Call TampilGrid()
    End Sub

    Sub TampilGrid()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM v_jurnal WHERE tgl_transaksi BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "' AND nomor_transaksi <> 'Saldo Awal'", Conn)
        DR = CMD.ExecuteReader

        Dim nomor As Integer = 1
        Dim notrans As String = ""

        If DR.HasRows Then

            'SplashScreenManager1.ShowWaitForm()
            Do While DR.Read

                If DR.Item("nomor_transaksi") = notrans Then

                    DGV.Rows.Add(
                        DR.Item("nomor_transaksi"),
                        DR.Item("tgl_transaksi"),
                        DR.Item("kode_perkiraan"),
                        DR.Item("uraian"),
                        DR.Item("keterangan"),
                        DR.Item("debet"),
                        DR.Item("kredit")
                    )
                Else
                    notrans = DR.Item("nomor_transaksi")
                    DGV.Rows.Add("- Baris ke " & nomor & " -", "", "", "", "", "", "")
                    DGV.Rows.Add(
                        DR.Item("nomor_transaksi"),
                        DR.Item("tgl_transaksi"),
                        DR.Item("kode_perkiraan"),
                        DR.Item("uraian"),
                        DR.Item("keterangan"),
                        DR.Item("debet"),
                        DR.Item("kredit")
                    )
                    nomor += 1
                End If
            Loop
            'SplashScreenManager1.CloseWaitForm()

        End If

        cekClose()

        DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        DaftarJurnalForm.MdiParent = MainMenu
        DaftarJurnalForm.Show()
    End Sub

    Private Sub DaftarJurnal_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpAwal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)
        SetDoubleBuffered(DGV, True)

        cekClose()
        Call Kosongkan()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Call TampilGrid()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        MainMenu.SplashScreenManager1.ShowWaitForm()
        Threading.Thread.Sleep(2000)

        Dim csv As String = String.Empty
        For Each column As DataGridViewColumn In DGV.Columns
            csv += column.HeaderText & ","c
        Next

        csv += vbCr & vbLf

        For Each row As DataGridViewRow In DGV.Rows
            For Each cell As DataGridViewCell In row.Cells
                csv += cell.Value.ToString().Replace(",", ";") & ","c
            Next

            csv += vbCr & vbLf
        Next

        Dim folderPath As String = "C:\NIPOS_EXPORT\"
        If (Not Directory.Exists(folderPath)) Then
            Directory.CreateDirectory(folderPath)
        End If

        Dim nameFile As String = "Jurnal_" & Format(dtpAwal.Value, "yyyy-MM-dd") & "_sd_" & Format(dtpAkhir.Value, "yyyy-MM-dd") & ".csv"

        File.WriteAllText(folderPath & nameFile, csv)

        MsgBox("Data Berhasil di Export, Silahkan Periksa pada Folder " & folderPath & nameFile, MsgBoxStyle.Information, "Berhasil!")
        MainMenu.SplashScreenManager1.CloseWaitForm()
    End Sub
End Class