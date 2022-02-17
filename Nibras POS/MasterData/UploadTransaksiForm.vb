Public Class UploadTransaksiForm
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        SplashScreenManager1.ShowWaitForm()
        Threading.Thread.Sleep(2000)

        Dim tanggal As String = Format(dtpTanggal.Value, "yyyy-MM-dd")

        Call uploadPenjualanHari(tanggal)

        SplashScreenManager1.CloseWaitForm()

        MsgBox("Data Berhasil di Upload!", MsgBoxStyle.Information, "Perhatian!")
    End Sub
End Class