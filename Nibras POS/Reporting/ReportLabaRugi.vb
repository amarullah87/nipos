Public Class ReportLabaRugi

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Dim tahun As String = Format(DTPBulanan.Value, "yyyy")
        Dim bulan As String = Format(DTPBulanan.Value, "MM")
        Dim lastDate As String = Date.DaysInMonth(tahun, bulan)

        'MsgBox(lastDate)

        CRV.ReportSource = Nothing
        CRV.RefreshReport()
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_labarugi.tgl_transaksi} IN Date('01/" & bulan & "/" & tahun & "') TO Date('" & lastDate & Format(DTPBulanan.Value, "/MM/yyyy") & "') "
            cryRpt.Load("LabaRugi_v3.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_labarugi.tgl_transaksi} IN Date('01/" & bulan & "/" & tahun & "') TO Date('" & lastDate & Format(DTPBulanan.Value, "/MM/yyyy") & "') "
            cryRpt.Load("LabaRugi_v3.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_labarugi.tgl_transaksi} IN Date('01/" & bulan & "/" & tahun & "') TO Date('" & lastDate & Format(DTPBulanan.Value, "/MM/yyyy") & "') "
        'cryRpt.Load("LabaRugiNew.rpt")
        'MsgBox("totext({v_labarugi.tgl_transaksi}) >='" & tahun & "-01-01' AND totext({v_labarugi.tgl_transaksi}) <='" & Format(DTPBulanan.Value, "yyyy-MM-") & lastDate & "' ")
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub ReportLabaRugi_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tahun As String = Format(dtpYTD.Value, "yyyy")
        Dim bulan As String = Format(dtpYTD.Value, "MM")
        dtpYTD.Value = New DateTime(dtpYTD.Value.Year, dtpYTD.Value.Month, Date.DaysInMonth(tahun, bulan))
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim tahun As String = Format(dtpYTD.Value, "yyyy")
        Dim bulan As String = Format(dtpYTD.Value, "MM")

        CRV.ReportSource = Nothing
        CRV.RefreshReport()

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_labarugi.tgl_transaksi} IN Date('01/01/" & tahun & "') TO Date('" & dtpYTD.Value.ToString("dd-MM-yyyy") & "') "
            cryRpt.Load("LabaRugi_v3.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_labarugi.tgl_transaksi} IN Date('01/01/" & tahun & "') TO Date('" & dtpYTD.Value.ToString("dd-MM-yyyy") & "') "
            cryRpt.Load("LabaRugi_v3.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_labarugi.tgl_transaksi} IN Date('01/01/" & tahun & "') TO Date('" & dtpYTD.Value.ToString("dd-MM-yyyy") & "') "
        'cryRpt.Load("LabaRugiNew.rpt")
    End Sub
End Class