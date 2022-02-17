Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ListDataMember

    Public Sub TampilGrid()
        cekOpen()

        DA = New MySqlDataAdapter("SELECT m.kode_member, m.nama_member, m.alamat, m.kota, m.provinsi, m.kode_pos, m.telepon, m.email, m.tgl_lahir, m.kontak, " &
                        "m.limit_piutang, m.limit_hari_piutang, m.jatuh_tempo, m.group_member, IF(ISNULL(p.poin), 0, SUM(p.poin)) AS poin, m.deposit, m.tgl_daftar, m.masa_aktif FROM member_m m " &
                        "LEFT JOIN member_poin p ON m.kode_member = p.kode_member GROUP BY m.kode_member", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

        DGV.Columns(0).HeaderText = "ID"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(0).HeaderCell.Style.BackColor = Color.LightGray

        'DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue
        'DGV.EnableHeadersVisualStyles = False

        DGV.Columns(1).HeaderText = "Nama Member"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(2).HeaderText = "Alamat"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(3).HeaderText = "Kota"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(4).HeaderText = "Provinsi"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(5).HeaderText = "Kode POS"
        DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(6).HeaderText = "Telepon"
        DGV.Columns(6).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(7).HeaderText = "email"
        DGV.Columns(7).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(8).HeaderText = "Tgl Lahir"
        DGV.Columns(8).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(9).HeaderText = "Kontak"
        DGV.Columns(9).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(10).Visible = False
        DGV.Columns(11).Visible = False
        DGV.Columns(12).Visible = False
        DGV.Columns(13).HeaderText = "Group"
        DGV.Columns(13).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(14).HeaderText = "Poin"
        DGV.Columns(14).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(14).DefaultCellStyle.Format = "N0"
        DGV.Columns(15).HeaderText = "Deposit"
        DGV.Columns(15).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(15).DefaultCellStyle.Format = "C0"
        DGV.Columns(16).HeaderText = "Tgl Daftar"
        DGV.Columns(16).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(17).HeaderText = "Expired"
        DGV.Columns(17).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cekClose()
    End Sub

    Private Sub BTNTutup_Click(sender As Object, e As EventArgs) Handles BTNTutup.Click
        Me.Close()
    End Sub

    Private Sub txtCariMember_TextChanged(sender As Object, e As EventArgs) Handles txtCariMember.TextChanged
        Call PencarianMember()
    End Sub

    Sub LoadItemBulan()
        LookUpEditBulan.Properties.DataSource = Nothing

        Dim ObyekList = New List(Of String)()
        ObyekList.Add("JANUARI")
        ObyekList.Add("FEBRUARI")
        ObyekList.Add("MARET")
        ObyekList.Add("APRIL")
        ObyekList.Add("MEI")
        ObyekList.Add("JUNI")
        ObyekList.Add("JULI")
        ObyekList.Add("AGUSTUS")
        ObyekList.Add("SEPTEMBER")
        ObyekList.Add("OKTOBER")
        ObyekList.Add("NOVEMBER")
        ObyekList.Add("DESEMBER")

        LookUpEditBulan.Properties.DataSource = ObyekList
    End Sub

    Sub LoadItemGroup()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT kode_group, nama_group, diskon FROM group_member", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "kode_group"
        lookUpEdit.Properties.ValueMember = "kode_group"
        cekClose()
    End Sub

    Sub PencarianMember()

        Dim bulanLahir As String = GetMonthInt(LookUpEditBulan.Text.ToString)

        cekOpen()
        DA = New MySqlDataAdapter("SELECT m.kode_member, m.nama_member, m.alamat, m.kota, m.provinsi, m.kode_pos, m.telepon, m.email, m.tgl_lahir, m.kontak, " &
                        "m.limit_piutang, m.limit_hari_piutang, m.jatuh_tempo, m.group_member, IF(ISNULL(p.poin), 0, SUM(p.poin)) AS poin, m.deposit, m.tgl_daftar, m.masa_aktif FROM member_m m " &
                        "LEFT JOIN member_poin p ON m.kode_member = p.kode_member WHERE m.nama_member Like '%" & txtCariMember.Text & "%' AND m.group_member LIKE '%" & lookUpEdit.Text.ToString & "%' AND m.tgl_lahir LIKE '%-" & bulanLahir & "-%' GROUP BY m.kode_member", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

        DGV.Columns(0).HeaderText = "ID"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(0).HeaderCell.Style.BackColor = Color.LightGray

        'DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue
        'DGV.EnableHeadersVisualStyles = False

        DGV.Columns(1).HeaderText = "Nama Member"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(2).HeaderText = "Alamat"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(3).HeaderText = "Kota"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(4).HeaderText = "Provinsi"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(5).HeaderText = "Kode POS"
        DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(6).HeaderText = "Telepon"
        DGV.Columns(6).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(7).HeaderText = "email"
        DGV.Columns(7).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(8).HeaderText = "Tgl Lahir"
        DGV.Columns(8).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(9).HeaderText = "Kontak"
        DGV.Columns(9).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(10).Visible = False
        DGV.Columns(11).Visible = False
        DGV.Columns(12).Visible = False
        DGV.Columns(13).HeaderText = "Group"
        DGV.Columns(13).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(14).HeaderText = "Poin"
        DGV.Columns(14).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(14).DefaultCellStyle.Format = "N0"
        DGV.Columns(15).HeaderText = "Deposit"
        DGV.Columns(15).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(15).DefaultCellStyle.Format = "C0"
        DGV.Columns(16).HeaderText = "Tgl Daftar"
        DGV.Columns(16).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(17).HeaderText = "Expired"
        DGV.Columns(17).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cekClose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        MasterGroup.ShowDialog()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        MasterCustomer.ShowDialog()
    End Sub

    Private Sub ListDataMember_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call PengaturanAkses()

        cekClose()
        SetDoubleBuffered(DGV, True)
        Call TampilGrid()
        Call CountMember()
        Call LoadItemGroup()
        Call LoadItemBulan()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditMember()
    End Sub

    Sub EditMember()

        MasterCustomer.Show()
        MasterCustomer.txtKodeMember.ReadOnly = True

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM member_m WHERE kode_member = '" & DGV.CurrentRow.Cells(0).Value & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            MasterCustomer.txtKodeMember.Text = CheckNull(DR.Item("kode_member"))
            MasterCustomer.txtNama.Text = CheckNull(DR.Item("nama_member"))
            MasterCustomer.txtAlamat.Text = CheckNull(DR.Item("alamat"))
            MasterCustomer.txtKota.Text = CheckNull(DR.Item("kota"))
            MasterCustomer.txtProvinsi.Text = CheckNull(DR.Item("provinsi"))
            MasterCustomer.txtTelepon.Text = CheckNull(DR.Item("telepon"))
            MasterCustomer.txtKodepos.Text = CheckNull(DR.Item("kode_pos"))
            MasterCustomer.txtEmail.Text = CheckNull(DR.Item("email"))
            MasterCustomer.txtContact.Text = CheckNull(DR.Item("kontak"))
            Dim tglLahir As String = DR.Item("tgl_lahir")
            MasterCustomer.dtpTglLahir.CustomFormat = "dd-MM-yyyy"
            MasterCustomer.dtpTglLahir.Value = tglLahir

            Dim tglDaftar As String = DR.Item("tgl_daftar")
            MasterCustomer.dtpTglDaftar.CustomFormat = "dd-MM-yyyy"
            MasterCustomer.dtpTglDaftar.Value = tglDaftar

            Dim masaAktif As String = DR.Item("masa_aktif")
            MasterCustomer.dtpMasaAktif.CustomFormat = "dd-MM-yyyy"
            MasterCustomer.dtpMasaAktif.Value = masaAktif

            MasterCustomer.txtLimitPiutang.Text = CDec(DR.Item("limit_piutang"))
            MasterCustomer.txtHariPiutang.Text = DR.Item("limit_hari_piutang")
            MasterCustomer.txtJatuhTempo.Text = DR.Item("jatuh_tempo")

            Dim group As String = DR.Item("group_member")
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM group_member ORDER BY nama_group ASC", Conn)
            DR = CMD.ExecuteReader

            Dim i As Integer = 0
            Dim cbIndex As Integer = 0

            Do While DR.Read
                If group = DR.Item("kode_group") Then
                    cbIndex = i
                End If
                i += 1
            Loop
            MasterCustomer.txtGroup.SelectedIndex = cbIndex
            cekClose()
        End If
    End Sub

    Function CheckNull(ByVal data As String)

        If IsDBNull(data) Then
            Return String.Empty
        Else
            Return data
        End If

    End Function

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SettingPoint.Show()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        ImportMember.ShowDialog()
    End Sub

    Private Sub DeleteMemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteMemberToolStripMenuItem.Click

        If DGV.CurrentRow.Cells(0).Value = "00000" Then
            MsgBox("Mohon Maaf, Data Member ini Tidak Dapat Di Hapus!", MsgBoxStyle.Information, "Perhatian!")
        Else
            Dim kodeMember As String = DGV.CurrentRow.Cells(0).Value & "/" & DGV.CurrentRow.Cells(1).Value
            If MessageBox.Show("Apakah Data Member ini Akan di Hapus...?! ", "Perhatian!", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                cekOpen()
                CMD = New MySqlCommand("SELECT faktur_jual FROM penjualan WHERE kode_customer = '" & kodeMember & "' ", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                If DR.HasRows Then
                    cekClose()
                    MsgBox("Mohon Maaf, Data Member Tidak Dapat Di Hapus Dikarenakan Ada Transaksi Penjualan Dengan Kode Member " & kodeMember, MsgBoxStyle.Critical)
                Else
                    cekClose()

                    cekOpen()
                    CMD = New MySqlCommand("DELETE FROM member_m WHERE kode_member = '" & DGV.CurrentRow.Cells(0).Value & "' ", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    MsgBox("Data Berhasil Di Hapus!", MsgBoxStyle.Information, "Informasi")
                End If

            End If

            Call TampilGrid()
        End If
    End Sub

    Sub CountMember()
        cekOpen()
        CMD = New MySqlCommand("SELECT COUNT(kode_member) AS total FROM member_m WHERE kode_member <> '00000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtTotalMember.Text = "Total Member : " & DR.Item("total")
            cekClose()

        Else
            txtTotalMember.Text = "Total Member : 0"
        End If

        cekOpen()
        CMD = New MySqlCommand("SELECT group_member, COUNT(group_member) AS total FROM member_m WHERE kode_member <> '00000' AND group_member <> '' GROUP BY group_member", Conn)
        DR = CMD.ExecuteReader

        Dim data As String = "Total Member - "
        Do While DR.Read
            data = data + DR.Item("group_member") + " : " + DR.Item("total").ToString + " | "
        Loop

        txtTotalDetail.Text = data
        cekClose()
    End Sub

    Sub PengaturanAkses()
        If MainMenu.PanelKode.Text = "KASIR" Then
            SimpleButton1.Enabled = False
            btnClear.Enabled = False
            SimpleButton2.Enabled = False
            SimpleButton3.Enabled = False
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
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

        Dim nameFile As String = "DaftarMember_" & DateTime.Now.ToString("yyyyMMdd-HHmmss") & ".csv"

        File.WriteAllText(folderPath & nameFile, csv)

        MsgBox("Data Berhasil di Export, Silahkan Periksa pada Folder " & folderPath & nameFile, MsgBoxStyle.Information, "Berhasil!")
        MainMenu.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub txtCariMember_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariMember.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                DownloadMember.ShowDialog()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub lookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles lookUpEdit.EditValueChanged
        Call PencarianMember()
    End Sub

    Private Sub LookUpEditBulan_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEditBulan.EditValueChanged
        Call PencarianMember()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Call PengaturanAkses()

        cekClose()
        SetDoubleBuffered(DGV, True)
        Call TampilGrid()
        Call CountMember()
        Call LoadItemGroup()
        Call LoadItemBulan()
    End Sub
End Class