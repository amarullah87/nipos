Public Class RekapPenjualan

    Dim printerName As String = GetPrinterLaporan()

    Private Sub RekapPenjualan_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)

        'CRV.SelectionFormula = "totext({v_penjualan_rekap.tgl_jual}) >='" & DTPHarian.Text & "' AND totext({v_penjualan_rekap.tgl_jual}) <='" & DTPBulanan.Text & "' "
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_penjualan_rekap.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("RekapPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_penjualan_rekap.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("RekapPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_penjualan_rekap.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("RekapPenjualan.rpt")
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        'CRV.SelectionFormula = "totext({v_penjualan_rekap.tgl_jual}) >='" & DTPHarian.Text & "' AND totext({v_penjualan_rekap.tgl_jual}) <='" & DTPBulanan.Text & "' "
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_penjualan_rekap.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("RekapPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_penjualan_rekap.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("RekapPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_penjualan_rekap.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("RekapPenjualan.rpt")
    End Sub

    Private Sub cbFromNHS_CheckedChanged(sender As Object, e As EventArgs) Handles cbFromNHS.CheckedChanged
        If cbFromNHS.Checked Then
            CRV.SelectionFormula = "{v_penjualan_rekap.kode_member} LIKE 'P*' AND {v_penjualan_rekap.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        Else
            CRV.SelectionFormula = "{v_penjualan_rekap.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        End If

        If printerName = "empty" Then
            cryRpt.Load("RekapPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("RekapPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("RekapPenjualan.rpt")
    End Sub
End Class