Imports MySql.Data.MySqlClient

Public Class PenjualanMember

    Dim printerName As String = GetPrinterLaporan()

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub LoadItemNhs()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select id as kode_member, nama as nama_member, alamat, 'NHs' from master_nhs", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama_member"
        lookUpEdit.Properties.ValueMember = "kode_member"
        cekClose()
    End Sub

    Sub LoadMember()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select kode_member, nama_member, alamat, group_member from member_m", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama_member"
        lookUpEdit.Properties.ValueMember = "kode_member"
        cekClose()
    End Sub

    Private Sub PenjualanMember_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date.AddDays(-(Now.Day) + 1)
        DTPBulanan.Value = Now.Date.AddDays(-(Now.Day) + 30)
        cekClose()
        Call LoadMember()

        Dim lastday As String = DTPBulanan.Text
        'CRV.SelectionFormula = "totext({v_laporan_penjualan.tgl_jual}) >='" & DTPHarian.Text & "' AND totext({v_laporan_penjualan.tgl_jual}) <='" & lastday & "' "
        If printerName = "empty" Then
            CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\PenjualanCustomer.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
            cryRpt.Load("report\PenjualanCustomer.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        'cryRpt.Load("report\PenjualanCustomer.rpt")
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Dim lastday As String = DTPBulanan.Text

        'CRV.SelectionFormula = "totext({v_laporan_penjualan.tgl_jual}) >='" & DTPHarian.Text & "' AND totext({v_laporan_penjualan.tgl_jual}) <='" & lastday & "' "
        If lookUpEdit.Text.ToString = "" Then
            CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') "
        Else
            CRV.SelectionFormula = "{v_laporan_penjualan.tgl_jual} IN Date('" & DTPHarian.Value.ToString("yyyy-MM-dd") & "') TO Date('" & DTPBulanan.Value.ToString("yyyy-MM-dd") & "') AND {v_laporan_penjualan.kode_member} = '" & lookUpEdit.EditValue.ToString & "' "
        End If

        If printerName = "empty" Then
            cryRpt.Load("report\PenjualanCustomer.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
        Else
            cryRpt.Load("report\PenjualanCustomer.rpt")
            Call seting_laporan()
            CRV.ReportSource = cryRpt
            CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
        End If
        'cryRpt.Load("report\PenjualanCustomer.rpt")
    End Sub

    Private Sub cbFromNHS_CheckedChanged(sender As Object, e As EventArgs) Handles cbFromNHS.CheckedChanged
        If cbFromNHS.Checked Then
            Call LoadItemNhs()
        Else
            Call LoadMember()
        End If
    End Sub
End Class