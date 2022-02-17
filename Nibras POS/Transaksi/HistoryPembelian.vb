Imports System.IO
Imports MySql.Data.MySqlClient

Public Class HistoryPembelian

    Public notransaksi As String = ""

    Sub LoadItemDb()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select kode, nama, nama_toko, domisili from mst_distributor", Conn)
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
        Call LoadItemNhs()

        Call TampilGrid()
    End Sub
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilGrid()
        Dim pencarian As String = ""

        If txtNoTransaksi.Text <> "" Then
            'pencarian = " AND faktur_beli = '" & txtNoTransaksi.Text & "' "
            pencarian = " AND (p.faktur_beli LIKE '%" & txtNoTransaksi.Text & "%' OR p.keterangan LIKE '%" & txtNoTransaksi.Text & "%' ) "
        End If

        If lookUpEdit.Text.ToString <> "" Then
            pencarian = String.Concat(pencarian, " AND kode_supplier = '" & lookUpEdit.EditValue.ToString & "' ")
        End If

        cekOpen()
        DA = New MySqlDataAdapter("SELECT p.`faktur_beli`, p.`tgl_beli`, p.`nama_supplier`, p.`item_beli` AS qty, p.`total_beli`, p.`bayar_beli`, p.`cara_beli`, p.`sisa_hutang`, p.`jth_tempo_beli`, p.`status_beli`, p.`keterangan`, p.kode_user AS `nama_user`,  " &
                                    " IF((SELECT no_retur_beli AS retur FROM returpembelian WHERE faktur_beli = p.faktur_beli) <> '', 'Ada Retur', '-') AS status_retur FROM pembelian p " &
                                    " LEFT JOIN tbluser u ON u.`nama_user` = p.`kode_user` " &
                                    " WHERE tgl_beli BETWEEN '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTanggalAkhir.Value, "yyyy-MM-dd") & "' AND faktur_beli NOT LIKE 'BTL-%' " & pencarian &
                                    " ORDER BY p.`faktur_beli`, p.`tgl_beli`", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "No Faktur"
        DGV.Columns(1).HeaderText = "Tgl Beli"
        DGV.Columns(2).HeaderText = "Supplier"
        DGV.Columns(3).HeaderText = "Qty"
        DGV.Columns(3).DefaultCellStyle.Format = "n0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(4).HeaderText = "Total Harga"
        DGV.Columns(4).DefaultCellStyle.Format = "c"
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(5).HeaderText = "Dibayar"
        DGV.Columns(5).DefaultCellStyle.Format = "c"
        DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(6).HeaderText = "Cara Beli"
        DGV.Columns(7).HeaderText = "Sisa Hutang"
        DGV.Columns(7).DefaultCellStyle.Format = "c"
        DGV.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(8).HeaderText = "Jatuh Tempo"
        DGV.Columns(9).HeaderText = "Status"
        DGV.Columns(10).HeaderText = "Keterangan"
        DGV.Columns(11).HeaderText = "User"
        DGV.Columns(12).HeaderText = "Retur"

        DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        'cekOpen()
        'CMD = New MySqlCommand("SELECT SUM(total_beli) AS total FROM pembelian WHERE tgl_beli BETWEEN '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTanggalAkhir.Value, "yyyy-MM-dd") & "' AND faktur_beli NOT LIKE 'BTL-%' " & pencarian, Conn)
        'DR = CMD.ExecuteReader
        'DR.Read()
        'If IsDBNull(DR.Item("total")) Then
        '    lblTotal.Text = "Total: Rp. 0,00"
        'Else
        '    lblTotal.Text = "Total: " & FormatCurrency(DR.Item("total"))
        'End If
        'cekClose()

        Call HitungTotal()
    End Sub

    Sub HitungTotal()
        Dim x As Double = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(4).Value
            lblTotal.Text = "Total: " & FormatCurrency(x)
        Next
    End Sub

    Private Sub HistoryPembelian_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        SetDoubleBuffered(DGV, True)

        dtptanggal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpTanggalAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)
        Call TampilGrid()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        Call TampilGrid()
        'Dim pencarian As String = ""

        'If txtNoTransaksi.Text <> "" Then
        '    pencarian = " AND faktur_beli = '" & txtNoTransaksi.Text & "' "
        'End If

        'cekOpen()
        'DA = New MySqlDataAdapter("SELECT p.`faktur_beli`, p.`tgl_beli`, p.`nama_supplier`, p.`item_beli` AS qty, p.`total_beli`, p.`bayar_beli`, p.`cara_beli`, p.`sisa_hutang`, p.`jth_tempo_beli`, p.`status_beli`, u.`nama_user`  " &
        '                            " FROM pembelian p " &
        '                            " INNER JOIN tbluser u ON u.`nama_user` = p.`kode_user` " &
        '                            " WHERE tgl_beli = '" & Format(Now, "yyyy-MM-dd") & "' " & pencarian &
        '                            " ORDER BY p.`faktur_beli`, p.`tgl_beli`", Conn)
        'DS = New DataSet
        'DA.Fill(DS)
        'DGV.DataSource = DS.Tables(0)
        'DGV.ReadOnly = True
        'cekClose()

        'DGV.Columns(0).HeaderText = "No Faktur"
        'DGV.Columns(1).HeaderText = "Tgl Beli"
        'DGV.Columns(2).HeaderText = "Supplier"
        'DGV.Columns(3).HeaderText = "Qty"
        'DGV.Columns(3).DefaultCellStyle.Format = "n0"
        'DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DGV.Columns(4).HeaderText = "Total Harga"
        'DGV.Columns(4).DefaultCellStyle.Format = "c"
        'DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DGV.Columns(5).HeaderText = "Dibayar"
        'DGV.Columns(5).DefaultCellStyle.Format = "c"
        'DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DGV.Columns(6).HeaderText = "Cara Beli"
        'DGV.Columns(7).HeaderText = "Sisa Hutang"
        'DGV.Columns(7).DefaultCellStyle.Format = "c"
        'DGV.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DGV.Columns(8).HeaderText = "Jatuh Tempo"
        'DGV.Columns(9).HeaderText = "Status"
        'DGV.Columns(10).HeaderText = "User"

        'DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        'cekOpen()
        'CMD = New MySqlCommand("SELECT SUM(total_beli) AS total FROM pembelian WHERE tgl_beli = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' ", Conn)
        'DR = CMD.ExecuteReader
        'DR.Read()

        'If IsDBNull(DR.Item("total")) Then
        '    lblTotal.Text = "Total: Rp. 0,00"
        'Else
        '    lblTotal.Text = "Total: " & FormatCurrency(DR.Item("total"))
        'End If
        'cekClose()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call Kosongkan()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        notransaksi = DGV.CurrentRow.Cells(0).Value

        DetailPembelian.MdiParent = MainMenu
        DetailPembelian.Show()
        DetailPembelian.Focus()
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

        Dim nameFile As String = "History_Pembelian_" & DateTime.Now.ToString("yyyyMMdd-HHmmss") & ".csv"

        File.WriteAllText(folderPath & nameFile, csv)

        MsgBox("Data Berhasil di Export, Silahkan Periksa pada Folder " & folderPath & nameFile, MsgBoxStyle.Information, "Berhasil!")
        MainMenu.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub cbFromNHS_CheckedChanged(sender As Object, e As EventArgs) Handles cbFromNHS.CheckedChanged
        If cbFromNHS.Checked Then
            Call LoadItemDb()
        Else
            Call LoadItemNhs()
        End If
    End Sub
End Class