Imports MySql.Data.MySqlClient

Public Class SaldoAwalPiutangForm
    Sub Kosongkan()
        'Call TampilSupplier()
        Call LoadItemCust()
        DGV.Rows.Clear()
        'cbSupplier.SelectedIndex = 0
        txtnofaktur.Text = ""
        txtJumlah.Text = "0"
        'Call TampilKodeAkun()
        cbAkun.SelectedIndex = 0

        Call GetFileExisting()
    End Sub

    Sub GetFileExisting()
        cekOpen()
        CMD = New MySqlCommand("SELECT no_faktur, h.kode_member, m.nama_member, tanggal, tanggal_jt, h.kodeacc, p.namaacc, total FROM piutang h INNER JOIN perkiraan p ON p.kodeacc = h.kodeacc LEFT JOIN member_m m ON m.kode_member = h.kode_member WHERE STATUS = 1", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("no_faktur") & " - " & DR.Item("kode_member"), DR.Item("tanggal"), DR.Item("tanggal_jt"), DR.Item("kodeacc") & "/" & DR.Item("namaacc"), CDec(DR.Item("total")))
        Loop
        cekClose()
    End Sub

    Sub GenerateTransactionNum()
        cekOpen()
        CMD = New MySqlCommand("select max(no_transaksi) AS no_transaksi from piutang where no_transaksi LIKE 'PT" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_transaksi")) Then
            txtNoTransaksi.Text = "PT" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtNoTransaksi.Text = "PT" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub GetDataPiutang()
        Dim kodesupplier As String = cbSupplier.Text
        Dim strArr() As String
        strArr = kodesupplier.Split("/")

        cekOpen()
        'CMD = New MySqlCommand("SELECT h.*, p.`namaacc` FROM piutang h INNER JOIN perkiraan p ON p.`kodeacc` = h.`kodeacc` WHERE kode_member = '" & strArr(0) & "' AND jenis = 'saldo_awal'", Conn)
        CMD = New MySqlCommand("SELECT h.*, p.`namaacc` FROM piutang h INNER JOIN perkiraan p ON p.`kodeacc` = h.`kodeacc` WHERE jenis = 'saldo_awal'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("no_faktur"), DR.Item("tanggal"), DR.Item("tanggal_jt"), DR.Item("kodeacc") & "/" & DR.Item("namaacc"), CDec(DR.Item("total")))
        Loop
        cekClose()
    End Sub

    Sub TampilSupplier()
        cbSupplier.Text = ""
        cbSupplier.Items.Clear()

        Dim query As String
        If MainMenu.PanelJenis.Text = "D" Then
            cekOpen()
            query = "SELECT * FROM master_nhs ORDER BY nama"
            CMD = New MySqlCommand(query, Conn)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cbSupplier.Items.Add(DR.Item("id") & "/" & DR.Item("nama"))
            Loop
            cekClose()
        Else

            cbSupplier.Items.Clear()
            If checkAgen.Checked = True Then
                cekOpen()
                query = "SELECT * FROM master_nhs ORDER BY nama"
                CMD = New MySqlCommand(query, Conn)
                DR = CMD.ExecuteReader
                Do While DR.Read
                    cbSupplier.Items.Add(DR.Item("id") & "/" & DR.Item("nama"))
                Loop
                cekClose()
            Else
                cekOpen()
                query = "SELECT * FROM member_m ORDER BY nama_member"
                CMD = New MySqlCommand(query, Conn)
                DR = CMD.ExecuteReader
                Do While DR.Read
                    cbSupplier.Items.Add(DR.Item("kode_member") & "/" & DR.Item("nama_member"))
                Loop
                cekClose()
            End If
        End If
    End Sub

    Sub TampilKodeAkun()
        Dim column As Integer = 0

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE mainparent = '1-0000' AND tipe = 'D'", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            If DR.Item("level") = 0 Then
                cbAkun.Items.Add("----------------------------------")
            Else
                If DR.Item("tipe") = "H" Then
                    cbAkun.Items.Add("")
                Else
                    cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
                End If
            End If
        Loop
        cekClose()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If cbAkun.Text = "----------------------------------" Or cbAkun.Text = "" Then
            MsgBox("Tidak Dapat Memilih Parent/ Level 0")
        Else
            DGV.Rows.Add(txtnofaktur.Text, dtptanggal.Value, dtptanggaljt.Value, cbAkun.Text, CDec(txtJumlah.Text))
            txtnofaktur.Text = ""
            txtJumlah.Text = "0"
            cbAkun.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If DGV.RowCount > 0 Then
            'For baris As Integer = 0 To DGV.RowCount - 1
            '    Dim kodeAkun As String = DGV.Rows(baris).Cells(3).Value
            '    Dim strArr() As String
            '    strArr = kodeAkun.Split("/")

            '    cekOpen()
            '    Dim simpanjurnal As String = "INSERT INTO saldo_awal_piutang (tanggal, kodeacc, namaacc, debet, kredit, tanggal_jt, nomor_transaksi, kode_customer) values ('" &
            '        Format(DGV.Rows(baris).Cells(1).Value, "yyyy-MM-dd") & "', '" & strArr(0) & "', '" & strArr(1) & "', '" & DGV.Rows(baris).Cells(4).Value & "', '0', '" & Format(DGV.Rows(baris).Cells(2).Value, "yyyy-MM-dd") & "', '" & DGV.Rows(baris).Cells(0).Value & "', '" & lookUpEdit.EditValue.ToString & "' )"
            '    CMD = New MySqlCommand(simpanjurnal, Conn)
            '    CMD.ExecuteNonQuery()
            '    cekClose()
            'Next

            Call Kosongkan()
            MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information)
        Else
            MsgBox("Oops! Tidak Ada Data yang tersimpan!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub SaldoAwalPiutangForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        Call GenerateTransactionNum()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub txtJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlah.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            If cbAkun.Text = "----------------------------------" Or cbAkun.Text = "" Then
                MsgBox("Tidak Dapat Memilih Parent/ Level 0")
            Else
                Dim kodeAkun As String = cbAkun.Text
                Dim strArr() As String
                strArr = kodeAkun.Split("/")

                Dim kodeSupplier As String = cbSupplier.Text
                Dim strArrSupp() As String
                strArrSupp = kodeSupplier.Split("/")

                cekOpen()
                Dim simpanjurnal As String = "INSERT INTO piutang (no_transaksi, no_faktur, kode_member, tanggal, tanggal_jt, kodeacc, potongan, total, keterangan, jenis, created_by, created_date) values ('" &
                        txtNoTransaksi.Text & "', '" &
                        txtnofaktur.Text & "', '" &
                        strArrSupp(0) & "', '" &
                        Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" &
                        Format(dtptanggaljt.Value, "yyyy-MM-dd") & "', '" &
                        strArr(0) & "', '0', '" &
                        txtJumlah.Text & "', '', 'saldo_awal', '" &
                        MainMenu.PanelUser.Text & "', '" &
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' )"
                CMD = New MySqlCommand(simpanjurnal, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                txtnofaktur.Text = ""
                txtJumlah.Text = "0"
                Call GetDataPiutang()
                DGV.Columns(4).DefaultCellStyle.Format = "c"
                DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        End If
    End Sub

    Private Sub checkAgen_CheckedChanged(sender As Object, e As EventArgs) Handles checkAgen.CheckedChanged
        'Call TampilSupplier()
        If checkAgen.Checked = True Then
            Call LoadItemNhs()
        Else
            Call LoadItemCust()
        End If
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        ImportSaldoPiutang.ShowDialog()
    End Sub

    Private Sub cbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupplier.SelectedIndexChanged
        DGV.Rows.Clear()
        Call GetDataPiutang()
    End Sub

    Sub LoadItemCust()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select kode_member AS kode, nama_member AS nama from member_m", Conn)
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
        DA = New MySqlDataAdapter("select id AS kode, nama AS nama from master_nhs", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama"
        lookUpEdit.Properties.ValueMember = "kode"
        cekClose()
    End Sub
End Class