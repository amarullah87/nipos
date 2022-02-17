Imports MySql.Data.MySqlClient

Public Class DaftarPenjualan

    Public notransaksi As String = ""
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

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
        Call LoadItemMember()

        Call TampilGrid()
    End Sub

    Sub TampilGrid()

        Dim pencarian As String = ""

        If lookUpEdit.Text.ToString <> "" Then
            pencarian = String.Concat(pencarian, " AND kode_member = '" & lookUpEdit.EditValue.ToString & "' ")
        End If

        cekOpen()
        DA = New MySqlDataAdapter("SELECT faktur_jual, tanggal, CONCAT(kode_member, ' | ', nama_member) as member, qty, total, ongkir, created_by, created_date " &
                                    " FROM pending_jual WHERE tanggal BETWEEN '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTanggalAkhir.Value, "yyyy-MM-dd") & "' AND status = 1 " & pencarian &
                                    " ORDER BY `faktur_jual`, `tanggal`", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "No Faktur"
        DGV.Columns(1).HeaderText = "Tanggal"
        DGV.Columns(1).DefaultCellStyle.Format = "D"
        DGV.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(2).HeaderText = "Member"
        DGV.Columns(3).HeaderText = "Qty"
        DGV.Columns(3).DefaultCellStyle.Format = "n0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(4).HeaderText = "Total Harga"
        DGV.Columns(4).DefaultCellStyle.Format = "c"
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(5).HeaderText = "Biaya Lain/Ongkir"
        DGV.Columns(5).DefaultCellStyle.Format = "c"
        DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(6).HeaderText = "Dibuat Oleh"
        DGV.Columns(7).HeaderText = "Tgl Dibuat"

        DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub DaftarPenjualan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        SetDoubleBuffered(DGV, True)

        dtptanggal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpTanggalAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)

        Call TampilGrid()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        notransaksi = DGV.CurrentRow.Cells(0).Value

        TransaksiPenjualanNhs.MdiParent = MainMenu
        TransaksiPenjualanNhs.Show()
        TransaksiPenjualanNhs.Focus()
        TransaksiPenjualanNhs.Kosongkan()

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM pending_jual WHERE faktur_jual = '" & DGV.CurrentRow.Cells(0).Value & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            TransaksiPenjualanNhs.txtNoFakturPending.Text = DR.Item("faktur_jual")
            TransaksiPenjualanNhs.txtMember.Text = DR.Item("kode_member")
            TransaksiPenjualanNhs.lblkodecustomer.Text = DR.Item("nama_member")
            TransaksiPenjualanNhs.txtBiayaLain.Text = DR.Item("ongkir")
            TransaksiPenjualanNhs.txtBiayaLainHide.Text = DR.Item("ongkir")
        End If
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM pending_jual_detail WHERE faktur_jual = '" & DGV.CurrentRow.Cells(0).Value & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            TransaksiPenjualanNhs.DGV.Rows.Add(
                DR.Item("kode_item"),
                DR.Item("nama"),
                DR.Item("satuan"),
                DR.Item("jenis"),
                DR.Item("harga"),
                DR.Item("jumlah"),
                DR.Item("disc_p"),
                DR.Item("disc_rp"),
                DR.Item("total"),
                DR.Item("total_disc")
            )
        Loop
        cekClose()

        TransaksiPenjualanNhs.Hitungtransaksi()
    End Sub

    Private Sub cbFromNHS_CheckedChanged(sender As Object, e As EventArgs) Handles cbFromNHS.CheckedChanged
        If cbFromNHS.Checked Then
            Call LoadItemNhs()
        Else
            Call LoadItemMember()
        End If
    End Sub

    Private Sub dtptanggal_KeyDown(sender As Object, e As KeyEventArgs) Handles dtptanggal.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Call TampilGrid()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        TransaksiPenjualanNhs.MdiParent = MainMenu
        TransaksiPenjualanNhs.Show()
        TransaksiPenjualanNhs.Focus()
        TransaksiPenjualanNhs.Kosongkan()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call TampilGrid()
    End Sub

    Private Sub HapusDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusDataToolStripMenuItem.Click
        Call HapusDaftarJual()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call HapusDaftarJual()
    End Sub

    Sub HapusDaftarJual()
        If MessageBox.Show("Apakah Data Akan di Hapus?!" & vbCrLf & "Data yang sudah di hapus Tidak Dapat Dikembalikan.", "Perhatian",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

            Dim noTransaksi As String = DGV.CurrentRow.Cells(0).Value
            cekOpen()
            CMD = New MySqlCommand("DELETE FROM pending_jual WHERE faktur_jual = '" & noTransaksi & "' ", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("DELETE FROM pending_jual_detail WHERE faktur_jual = '" & noTransaksi & "' ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            MsgBox("Data Berhasil dihapus!", MsgBoxStyle.Information, "Perhatian")
            Call TampilGrid()
        End If
    End Sub
End Class