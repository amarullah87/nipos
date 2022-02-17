Imports MySql.Data.MySqlClient

Public Class LaporanKasir

    Dim printerName As String = GetPrinterLaporan()


    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Dim lastday As String = DTPBulanan.Value.AddDays(1)
        Dim jenis As String

        If ListBox1.Text = "" Then
            jenis = " AND {v_buku_besar.uraian} = 'KAS KECIL' "
        Else
            jenis = " AND {v_buku_besar.uraian} = '" & ListBox1.Text & "' "
        End If

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') " & jenis
            cryRpt.Load("LaporanKasir.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') " & jenis
            cryRpt.Load("LaporanKasir.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub LaporanKasir_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE kodeacc IN ('1-1110','1-1120')", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            ListBox1.Items.Add(DR.Item("namaacc"))
        Loop
        cekClose()

        Dim lastday As String = DTPBulanan.Value.AddDays(1)

        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_buku_besar.uraian} = 'KAS KECIL' "
            cryRpt.Load("LaporanKasir.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_buku_besar.uraian} = 'KAS KECIL' "
            cryRpt.Load("LaporanKasir.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_buku_besar.uraian} = '" & ListBox1.Text & "' "
            cryRpt.Load("LaporanKasir.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_buku_besar.tgl_transaksi} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_buku_besar.uraian} = '" & ListBox1.Text & "' "
            cryRpt.Load("LaporanKasir.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
    End Sub
End Class