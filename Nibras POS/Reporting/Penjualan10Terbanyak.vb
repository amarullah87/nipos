Public Class Penjualan10Terbanyak

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        'CRV.SelectionFormula = "totext({v_10_besar_penjualan.tgl_jual}) >='" & DTPHarian.Text & "' AND totext({v_10_besar_penjualan.tgl_jual}) <='" & DTPBulanan.Text & "' "
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_10_besar_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("10BesarPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_10_besar_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("10BesarPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_10_besar_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("10BesarPenjualan.rpt")
    End Sub

    Private Sub Penjualan10Terbanyak_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)

        'CRV.SelectionFormula = "totext({v_10_besar_penjualan.tgl_jual}) >='" & DTPHarian.Text & "' AND totext({v_10_besar_penjualan.tgl_jual}) <='" & DTPBulanan.Text & "' "
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_10_besar_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("10BesarPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_10_besar_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("10BesarPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_10_besar_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("10BesarPenjualan.rpt")
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub
End Class