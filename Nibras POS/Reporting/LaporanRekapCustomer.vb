Imports MySql.Data.MySqlClient

Public Class LaporanRekapCustomer

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub LoadGroup()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT kode_group, diskon FROM group_member ORDER BY urutan ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "kode_group"
        lookUpEdit.Properties.ValueMember = "kode_group"
        cekClose()
    End Sub

    Private Sub LaporanRekapCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)

        Call LoadGroup()

        Dim lastday As String = DTPBulanan.Text
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v2_rekap_penjualan_cust.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("PenjualanCustomerRekap.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v2_rekap_penjualan_cust.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("PenjualanCustomerRekap.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v2_rekap_penjualan_cust.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("PenjualanCustomerRekap.rpt")
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Dim lastday As String = DTPBulanan.Text

        If lookUpEdit.Text.ToString = "" Then
            CRV.SelectionFormula = "{v2_rekap_penjualan_cust.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        Else
            CRV.SelectionFormula = "{v2_rekap_penjualan_cust.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v2_rekap_penjualan_cust.group_member} = '" & lookUpEdit.EditValue.ToString & "' "
        End If
        If printerName = "empty" Then
            cryRpt.Load("PenjualanCustomerRekap.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("PenjualanCustomerRekap.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("PenjualanCustomerRekap.rpt")
    End Sub
End Class