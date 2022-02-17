Imports System.IO
Imports MySql.Data.MySqlClient

Public Class DaftarKasTransfer
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call TampilGrid()
    End Sub

    Sub TampilGrid()
        DGV.Rows.Clear()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM arus_kas a WHERE a.`jenis` = 'transfer' AND tanggal BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("no_transaksi"), DR.Item("tanggal"), DR.Item("kodeacc"), DR.Item("kodeacc_tf"), DR.Item("keterangan"), CDec(DR.Item("jumlah")), DR.Item("created_by"))
        Loop
        cekClose()
    End Sub

    Private Sub DaftarKasMasuk_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()

        dtpAwal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)

        Call TampilGrid()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        TambahKasTransfer.MdiParent = MainMenu
        TambahKasTransfer.Show()
        TambahKasTransfer.Focus()
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

        Dim nameFile As String = "Daftar_Kas_Transfer_" & Format(dtpAwal.Value, "yyyy-MM-dd") & "_sd_" & Format(dtpAkhir.Value, "yyyy-MM-dd") & ".csv"

        File.WriteAllText(folderPath & nameFile, csv)

        MsgBox("Data Berhasil di Export, Silahkan Periksa pada Folder " & folderPath & nameFile, MsgBoxStyle.Information, "Berhasil!")
        MainMenu.SplashScreenManager1.CloseWaitForm()
    End Sub
End Class