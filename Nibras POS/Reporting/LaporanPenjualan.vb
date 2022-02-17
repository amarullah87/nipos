Public Class LaporanPenjualan

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub LaporanPenjualan_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)


        'CRV.SelectionFormula = "totext({v_laporan_penjualan.tgl_jual}) >='" & DTPHarian.Text & "' AND totext({v_laporan_penjualan.tgl_jual}) <='" & DTPBulanan.Text & "' "
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "')"
            cryRpt.Load("LaporanPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "')"
            cryRpt.Load("LaporanPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("report\LaporanPenjualan.rpt")
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If cbOffline.Checked Then

            If cbFromNHS.Checked Then
                CRV.SelectionFormula = "{v_laporan_penjualan.jenis_member} <> 'Offline' AND {v_laporan_penjualan.kode_member} LIKE 'P*' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            Else
                CRV.SelectionFormula = "{v_laporan_penjualan.jenis_member} <> 'Offline' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            End If

        Else

            If cbFromNHS.Checked Then
                CRV.SelectionFormula = "{v_laporan_penjualan1.jenis_member} LIKE 'Offline*' AND {v_laporan_penjualan.kode_member} LIKE 'P*' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            Else
                CRV.SelectionFormula = "{v_laporan_penjualan.jenis_member} LIKE 'Offline*' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            End If
        End If

        If printerName = "empty" Then
            cryRpt.Load("LaporanPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("LaporanPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("report\LaporanPenjualan.rpt")
    End Sub

    Private Sub cbFromNHS_CheckedChanged(sender As Object, e As EventArgs) Handles cbFromNHS.CheckedChanged


        If cbFromNHS.Checked Then
            If cbOffline.Checked Then
                CRV.SelectionFormula = "{v_laporan_penjualan.jenis_member} <> 'Offline' AND {v_laporan_penjualan.kode_member} LIKE 'P*' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            Else
                CRV.SelectionFormula = "{v_laporan_penjualan.kode_member} LIKE 'P*' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            End If
        Else
            If cbOffline.Checked Then
                CRV.SelectionFormula = "{v_laporan_penjualan.jenis_member} <> 'Offline' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            Else
                CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            End If
        End If

        If printerName = "empty" Then
            cryRpt.Load("LaporanPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("LaporanPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("report\LaporanPenjualan.rpt")
    End Sub

    Private Sub cbOffline_CheckedChanged(sender As Object, e As EventArgs) Handles cbOffline.CheckedChanged
        If cbOffline.Checked Then

            If cbFromNHS.Checked Then
                CRV.SelectionFormula = "{v_laporan_penjualan.jenis_member} <> 'Offline' AND {v_laporan_penjualan.kode_member} LIKE 'P*' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            Else
                CRV.SelectionFormula = "{v_laporan_penjualan.jenis_member} <> 'Offline' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            End If

        Else

            If cbFromNHS.Checked Then
                CRV.SelectionFormula = "{v_laporan_penjualan1.jenis_member} LIKE 'Offline*' AND {v_laporan_penjualan.kode_member} LIKE 'P*' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            Else
                CRV.SelectionFormula = "{v_laporan_penjualan.jenis_member} LIKE 'Offline*' AND {v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            End If
        End If

        If printerName = "empty" Then
            cryRpt.Load("LaporanPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("LaporanPenjualan.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
    End Sub
End Class