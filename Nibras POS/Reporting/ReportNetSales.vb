Imports CrystalDecisions.CrystalReports.Engine

Public Class ReportNetSales

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        CRV.ReportSource = Nothing
        CRV.RefreshReport()

        'CRV.SelectionFormula = "Cstr({penjualan.tgl_jual}) ='" & DTPBulanan.Value & "' AND Cstr({returpenjualan.tgl_retur_jual}) ='" & DTPBulanan.Value & "' "
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_net_sales.tgl_transaksi} = Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("LaporanNettSales.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_net_sales.tgl_transaksi} = Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("LaporanNettSales.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_net_sales.tgl_transaksi} = Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("LaporanNettSales.rpt")
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub ReportNetSales_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPBulanan.Value = Now.Date
    End Sub
End Class