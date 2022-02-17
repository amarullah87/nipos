Public Class LaporanPiutangBeredar

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        'CRV.SelectionFormula = "{v2_piutang_beredar.tanggal} IN DateTime('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO DateTime('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        If printerName = "empty" Then
            cryRpt.Load("LaporanPiutangBeredar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("LaporanPiutangBeredar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("LaporanPiutangBeredar.rpt")
    End Sub

    Private Sub LaporanPiutangBeredar_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)

        'CRV.SelectionFormula = "{v2_piutang_beredar.tanggal} IN DateTime('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO DateTime('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        If printerName = "empty" Then
            cryRpt.Load("LaporanPiutangBeredar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("LaporanPiutangBeredar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("LaporanPiutangBeredar.rpt")
    End Sub
End Class