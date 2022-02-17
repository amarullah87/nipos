
Public Class ReportJurnal

    Dim printerName As String = GetPrinterLaporan()

    Private Sub ReportJurnal_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\JurnalUmum.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\JurnalUmum.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If

        'CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("report\JurnalUmum.rpt")

        'MsgBox("totext({v_jurnal.tgl_transaksi}) >='" & DTPHarian.Text & "' AND totext({v_jurnal.tgl_transaksi}) <='" & DTPBulanan.Text & "' ")
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim kategori As String = ""
        Select Case ListBox1.Text

            Case "Pembelian"
                kategori = "1"
            Case "Penjualan"
                kategori = "2"
            Case "Persediaan"
                kategori = "3"
            Case "Kas"
                kategori = "4"
            Case Else
                kategori = "5"

        End Select

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_jurnal.jenis} =" & kategori
            cryRpt.Load("report\JurnalUmum.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_jurnal.jenis} =" & kategori
            cryRpt.Load("report\JurnalUmum.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If

        'CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("report\JurnalUmum.rpt")
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\JurnalUmum.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\JurnalUmum.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If

        'CRV.SelectionFormula = "{v_jurnal.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("report\JurnalUmum.rpt")
    End Sub
End Class