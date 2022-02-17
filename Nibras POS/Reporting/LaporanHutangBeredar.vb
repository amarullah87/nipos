Public Class LaporanHutangBeredar

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        'CRV.Refresh()

        'CRV.SelectionFormula = "{v2_hutang_beredar.tanggal} IN Date('" & DTPHarian.Value & "') TO Date('" & DTPBulanan.Value & "') "
        If printerName = "empty" Then
            cryRpt.Load("LaporanHutangBeredar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("LaporanHutangBeredar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("LaporanHutangBeredar.rpt")
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub LaporanHutangBeredar_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)

        'CRV.Refresh()

        'CRV.SelectionFormula = "{v2_hutang_beredar.tanggal} IN Date('" & DTPHarian.Value & "') TO Date('" & DTPBulanan.Value & "') "
        If printerName = "empty" Then
            cryRpt.Load("LaporanHutangBeredar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("LaporanHutangBeredar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("LaporanHutangBeredar.rpt")
    End Sub
End Class