Imports MySql.Data.MySqlClient

Public Class ReportBukuBesar
    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Dim lastday As String = DTPBulanan.Value.AddDays(1)

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\BukuBesar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\BukuBesar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("report\BukuBesar.rpt")
    End Sub

    Private Sub ReportBukuBesar_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)

        cekOpen()
        CMD = New MySqlCommand("select * from perkiraan WHERE tipe = 'D'", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            ListBox1.Items.Add(DR.Item("namaacc"))
        Loop
        cekClose()

        Dim lastday As String = DTPBulanan.Value.AddDays(1)

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\BukuBesar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\BukuBesar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("report\BukuBesar.rpt")
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_buku_besar.uraian} = '" & ListBox1.Text & "' "
            cryRpt.Load("report\BukuBesar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_buku_besar.uraian} = '" & ListBox1.Text & "' "
            cryRpt.Load("report\BukuBesar.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If

        'CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_buku_besar.uraian} = '" & ListBox1.Text & "' "
        'cryRpt.Load("report\BukuBesar.rpt")
    End Sub
End Class