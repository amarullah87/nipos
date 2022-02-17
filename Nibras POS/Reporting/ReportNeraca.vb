Public Class ReportNeraca

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Dim lastday As String = DTPBulanan.Value.AddDays(1)
        DTPHarian.Value = New DateTime(DTPHarian.Value.Year, 1, 1)

        Dim startDate As String = DTPHarian.Value.ToString("yyyy-MM-dd")
        Dim endDate As String = DTPBulanan.Value.ToString("yyyy-MM-dd")

        CRV.ReportSource = Nothing
        CRV.RefreshReport()
        Dim dateAsString As DateTime = DateTime.Now.ToString("dd/MM/yyyy")

        'CRV.SelectionFormula = "Cstr({v_neraca.tgl_transaksi}) >='" & Format(DTPHarian.Value, "dd/MM/yyyy") & "' AND Cstr({v_neraca.tgl_transaksi}) <='" & Format(DTPBulanan.Value.AddDays(1), "dd/MM/yyyy") & "' "
        'CRV.SelectionFormula = "{v_neraca.tgl_transaksi} >=" & startDate & " AND {v_neraca.tgl_transaksi} <= " & Format(txtTest.Text, "yyyy-MM-dd") & " "
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_neraca.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("NeracaDev.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_neraca.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("NeracaDev.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_neraca.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("NeracaDev.rpt")

        'MsgBox("{v_neraca.tgl_transaksi} in '" & DTPHarian.Value.ToString("yyyy-mm-dd hh:mm:ss") & "' to '" & DTPHarian.Value.ToString("yyyy-mm-dd hh:mm:ss") & "' ")
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub ReportNeraca_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPBulanan.Value = Now.Date
        DTPHarian.Value = New DateTime(DTPHarian.Value.Year, 1, 1)

        'CRV.SelectionFormula = "{v_neraca.tgl_transaksi} IN DateTime('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO DateTime('" & DTPBulanan.Value.AddDays(1).ToString("yyyy-MM-dd") & "') "

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_neraca.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("NeracaDev.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_neraca.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("NeracaDev.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_neraca.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("NeracaDev.rpt")
    End Sub
End Class