Imports System.IO
Imports MySql.Data.MySqlClient

Public Class HistoryPenjualan

    Public notransaksi As String = ""

    Sub LoadItemMember()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select kode_member as kode, nama_member as nama, nama_member as nama, alamat from member_m", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama"
        lookUpEdit.Properties.ValueMember = "kode"
        cekClose()
    End Sub

    Sub LoadItemNhs()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select id as kode, nama, nama, alamat from master_nhs", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama"
        lookUpEdit.Properties.ValueMember = "kode"
        cekClose()
    End Sub

    Sub Kosongkan()
        'DGV.Rows.Clear()
        txtNoTransaksi.Text = ""
        lblTotal.Text = "Total: Rp. 0"
        Call LoadItemMember()

        Call TampilGrid()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call Kosongkan()
    End Sub

    Sub TampilGrid()

        Dim pencarian As String = ""

        If txtNoTransaksi.Text <> "" Then
            'pencarian = " AND faktur_jual = '" & txtNoTransaksi.Text & "' "
            pencarian = " AND (p.faktur_jual LIKE '%" & txtNoTransaksi.Text & "%' OR p.keterangan LIKE '%" & txtNoTransaksi.Text & "%' OR pd.nama_barang LIKE '%" & txtNoTransaksi.Text & "%') "
        End If

        If lookUpEdit.Text.ToString <> "" Then
            pencarian = String.Concat(pencarian, " AND kode_customer LIKE '%" & lookUpEdit.EditValue.ToString & "%' ")
        End If

        cekOpen()
        DA = New MySqlDataAdapter("SELECT p.`faktur_jual`, p.`tgl_jual`, p.`kode_customer`, p.`item_jual` AS qty, p.`total_diskon`, " &
                                    " (SELECT IFNULL(rp3.subtotal, 0) As total_retur FROM returpenjualan rp3 WHERE rp3.faktur_jual = p.faktur_jual) As retur," &
                                    " (p.`total_jual` + p.`ongkir` - IF((SELECT COUNT(no_retur_jual) AS total FROM returpenjualan WHERE faktur_jual = p.faktur_jual) > 0, (SELECT rp2.subtotal AS total_retur FROM returpenjualan rp2 WHERE rp2.faktur_jual = p.faktur_jual), 0)) AS total_jual, " &
                                    " p.`bayar_jual`, p.`cara_jual`, p.`sisa_piutang`, p.`jth_tempo_jual`, If(p.`transfer` = 1, 'TRANSFER', IF(p.`debit_a` <> 0, 'EDC', IF(p.`deposit` <> 0, 'DEPOSIT', 'CASH/KREDIT'))) AS status, " &
                                    " p.keterangan" &
                                    " FROM penjualan p " &
                                    " LEFT JOIN member_m m ON m.`kode_member` = p.`kode_customer` " &
                                    " INNER JOIN detailjual d ON d.faktur_jual = p.faktur_jual " &
                                    " INNER JOIN barang_m pd ON pd.kode_item = d.kode_barang" &
                                    " WHERE p.tgl_jual BETWEEN '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTanggalAkhir.Value, "yyyy-MM-dd") & "' AND p.faktur_jual NOT LIKE 'BTL%' " & pencarian &
                                    " GROUP BY p.faktur_jual ORDER BY p.`created_date` DESC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "No Faktur"
        DGV.Columns(1).HeaderText = "Tgl Jual"
        DGV.Columns(1).DefaultCellStyle.Format = "D"
        DGV.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(2).HeaderText = "Member"
        DGV.Columns(3).HeaderText = "Qty"
        DGV.Columns(3).DefaultCellStyle.Format = "n0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(4).HeaderText = "Total Diskon"
        DGV.Columns(4).DefaultCellStyle.Format = "c"
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(5).HeaderText = "Retur"
        DGV.Columns(5).DefaultCellStyle.Format = "c"
        DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(6).HeaderText = "Total Akhir"
        DGV.Columns(6).DefaultCellStyle.Format = "c"
        DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(7).HeaderText = "Total Bayar"
        DGV.Columns(7).DefaultCellStyle.Format = "c"
        DGV.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(8).HeaderText = "Cara Jual"
        DGV.Columns(9).HeaderText = "Sisa Piutang"
        DGV.Columns(9).DefaultCellStyle.Format = "c"
        DGV.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(10).HeaderText = "Jatuh Tempo"
        DGV.Columns(11).HeaderText = "Status"
        DGV.Columns(12).HeaderText = "Keterangan"

        DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        'cekOpen()
        'CMD = New MySqlCommand("SELECT SUM(p.`total_jual`) AS total_jual " &
        '                            " FROM penjualan p " &
        '                            " LEFT JOIN member_m m ON m.`kode_member` = p.`kode_customer` " &
        '                            " INNER JOIN detailjual d ON d.faktur_jual = p.faktur_jual " &
        '                            " INNER JOIN barang_m pd ON pd.kode_item = d.kode_barang" &
        '                            " WHERE p.tgl_jual BETWEEN '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTanggalAkhir.Value, "yyyy-MM-dd") & "' AND p.faktur_jual NOT LIKE 'BTL%' " & pencarian & " ", Conn)
        'DR = CMD.ExecuteReader
        'DR.Read()
        'If IsDBNull(DR.Item("total_jual")) Then
        '    lblTotal.Text = "Total: Rp. 0,00"
        'Else
        '    lblTotal.Text = "Total: " & FormatCurrency(DR.Item("total_jual"))
        'End If
        'cekClose()

        Call HitungTotal()

    End Sub

    Sub HitungTotal()
        lblTotal.Text = "Total: Rp. 0,00"

        Dim x As Double = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(6).Value
            lblTotal.Text = "Total: " & FormatCurrency(x)
        Next
    End Sub

    Private Sub HistoryPenjualan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        dtptanggal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpTanggalAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)

        Call Kosongkan()
        SetDoubleBuffered(DGV, True)
        'Call TampilGrid()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call TampilGrid()
        'Dim pencarian As String = ""

        'If txtNoTransaksi.Text <> "" Then
        '    pencarian = " AND faktur_jual = '" & txtNoTransaksi.Text & "' "
        'End If

        'cekOpen()
        'DA = New MySqlDataAdapter("SELECT p.`faktur_jual`, p.`tgl_jual`, p.`kode_customer`, p.`item_jual` AS qty, p.`total_jual`, p.`bayar_jual`, p.`cara_jual`, p.`sisa_piutang`, p.`jth_tempo_jual`, p.`status_jual`, u.`nama_user` " &
        '                            " FROM penjualan p " &
        '                            " LEFT JOIN member_m m ON m.`kode_member` = p.`kode_customer` " &
        '                            " INNER JOIN tbluser u ON u.`kode_user` = p.`kode_user` " &
        '                            " WHERE tgl_jual = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' " & pencarian &
        '                            " ORDER BY p.`faktur_jual`, p.`tgl_jual`", Conn)
        'DS = New DataSet
        'DA.Fill(DS)
        'DGV.DataSource = DS.Tables(0)
        'DGV.ReadOnly = True
        'cekClose()

        'cekOpen()
        'CMD = New MySqlCommand("SELECT SUM(total_jual) AS total FROM penjualan WHERE tgl_jual = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' ", Conn)
        'DR = CMD.ExecuteReader
        'DR.Read()
        'If IsDBNull(DR.Item("total")) Then
        '    lblTotal.Text = "Total: Rp. 0,00"
        'Else
        '    lblTotal.Text = "Total: " & FormatCurrency(DR.Item("total"))
        'End If
        'cekClose()
    End Sub

    Private Sub btnCetakUlang_Click(sender As Object, e As EventArgs) Handles btnCetakUlang.Click
        '### Cetak Struk ###'
        Dim printerName As String = GetPrinterKasir()

        If printerName = "empty" Then
            CetakFaktur.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & DGV.CurrentRow.Cells(0).Value & "'"
            cryRpt.Load("FakturJual.rpt")
            Call seting_laporan()
            CetakFaktur.CRV.ReportSource = cryRpt
            CetakFaktur.CRV.RefreshReport()
            cryRpt.PrintToPrinter(1, True, 0, 0)
        Else
            CetakFaktur.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & DGV.CurrentRow.Cells(0).Value & "'"
            cryRpt.Load("FakturJual.rpt")
            Call seting_laporan()
            CetakFaktur.CRV.ReportSource = cryRpt
            CetakFaktur.CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
            cryRpt.PrintToPrinter(1, True, 0, 0)
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        notransaksi = DGV.CurrentRow.Cells(0).Value

        DetailPenjualanNhs.MdiParent = MainMenu
        DetailPenjualanNhs.Show()
        DetailPenjualanNhs.Focus()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        MainMenu.SplashScreenManager1.ShowWaitForm()
        Threading.Thread.Sleep(2000)

        Dim csv As String = String.Empty
        For Each column As DataGridViewColumn In DGV.Columns
            csv += column.HeaderText & ","c
        Next

        csv += vbCr & vbLf

        For Each row As DataGridViewRow In DGV.Rows
            For Each cell As DataGridViewCell In row.Cells
                csv += cell.Value.ToString().Replace(",", ";") & ","c
            Next

            csv += vbCr & vbLf
        Next

        Dim folderPath As String = "C:\NIPOS_EXPORT\"
        If (Not Directory.Exists(folderPath)) Then
            Directory.CreateDirectory(folderPath)
        End If

        Dim nameFile As String = "History_Penjualan_" & DateTime.Now.ToString("yyyyMMdd-HHmmss") & ".csv"

        File.WriteAllText(folderPath & nameFile, csv)

        MsgBox("Data Berhasil di Export, Silahkan Periksa pada Folder " & folderPath & nameFile, MsgBoxStyle.Information, "Berhasil!")
        MainMenu.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub cbFromNHS_CheckedChanged(sender As Object, e As EventArgs) Handles cbFromNHS.CheckedChanged
        If cbFromNHS.Checked Then
            Call LoadItemNhs()
        Else
            Call LoadItemMember()
        End If
    End Sub

    Private Sub btnCetakFakturBesar_Click(sender As Object, e As EventArgs) Handles btnCetakFakturBesar.Click
        '### Cetak Struk ###'
        Dim printerName As String = GetPrinterLaporan()

        If printerName = "empty" Then
            CetakFaktur.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & DGV.CurrentRow.Cells(0).Value & "'"
            cryRpt.Load("FakturJualBesar.rpt")
            Call seting_laporan()
            CetakFaktur.CRV.ReportSource = cryRpt
            CetakFaktur.CRV.RefreshReport()
            cryRpt.PrintToPrinter(1, True, 0, 0)
        Else
            CetakFaktur.CRV.SelectionFormula = "totext({v_faktur.faktur_jual}) = '" & DGV.CurrentRow.Cells(0).Value & "'"
            cryRpt.Load("FakturJualBesar.rpt")
            Call seting_laporan()
            CetakFaktur.CRV.ReportSource = cryRpt
            CetakFaktur.CRV.RefreshReport()
            cryRpt.PrintOptions.PrinterName = printerName
            cryRpt.PrintToPrinter(1, True, 0, 0)
        End If
    End Sub

    Private Sub DGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV.CellFormatting
        For Each myRow As DataGridViewRow In DGV.Rows
            If myRow.Cells(8).Value = "KREDIT" And Double.Parse(myRow.Cells(9).Value) > 0 Then
                myRow.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
    End Sub

    Private Sub dtptanggal_KeyDown(sender As Object, e As KeyEventArgs) Handles dtptanggal.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Call TampilGrid()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub txtNoTransaksi_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoTransaksi.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call TampilGrid()
        End If
    End Sub
End Class