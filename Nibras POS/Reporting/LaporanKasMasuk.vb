Public Class LaporanKasMasuk
    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v2_kas_masuk.tanggal} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("LaporanKasMasuk.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v2_kas_masuk.tanggal} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("LaporanKasMasuk.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub LaporanKasMasuk_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)


        If printerName = "empty" Then
            CRV.SelectionFormula = "{v2_kas_masuk.tanggal} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("LaporanKasMasuk.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v2_kas_masuk.tanggal} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("LaporanKasMasuk.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
    End Sub
End Class