Public Class LaporanGrafikHari

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub LaporanGrafikHari_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v2_penjualan_hari_grafik.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') "
            'CRV.SelectionFormula = "{v2_penjualan_hari_grafik.tgl_jual} = '" & DTPHarian.Value.ToString("yyyy-MM-dd") & "' "
            cryRpt.Load("GrafikPenjualanJam.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v2_penjualan_hari_grafik.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') "
            'CRV.SelectionFormula = "{v2_penjualan_hari_grafik.tgl_jual} = '" & DTPHarian.Value.ToString("yyyy-MM-dd") & "' "
            cryRpt.Load("GrafikPenjualanJam.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v2_penjualan_hari_grafik.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') "
            'CRV.SelectionFormula = "{v2_penjualan_hari_grafik.tgl_jual} = '" & DTPHarian.Value.ToString("yyyy-MM-dd") & "' "
            cryRpt.Load("GrafikPenjualanJam.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v2_penjualan_hari_grafik.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') "
            'CRV.SelectionFormula = "{v2_penjualan_hari_grafik.tgl_jual} = '" & DTPHarian.Value.ToString("yyyy-MM-dd") & "' "
            cryRpt.Load("GrafikPenjualanJam.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
    End Sub
End Class