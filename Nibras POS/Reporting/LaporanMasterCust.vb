Public Class LaporanMasterCust
    Private Sub LaporanMasterCust_Load(sender As Object, e As EventArgs) Handles Me.Load
        'CRV.SelectionFormula = "totext({v_laporan_penjualan.tgl_jual}) >='" & DTPHarian.Text & "' AND totext({v_laporan_penjualan.tgl_jual}) <='" & DTPBulanan.Text & "' "
        Dim printerName As String = GetPrinterLaporan()

        If printerName = "empty" Then
            cryRpt.Load("MasterPelanggan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("MasterPelanggan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("MasterPelanggan.rpt")
    End Sub
End Class