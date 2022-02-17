Public Class LaporanMasterItem
    Private Sub LaporanMasterItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim printerName As String = GetPrinterLaporan()

        If printerName = "empty" Then
            cryRpt.Load("MasterItem.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("MasterItem.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("MasterItem.rpt")
    End Sub
End Class