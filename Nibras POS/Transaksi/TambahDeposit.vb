Imports DevExpress.XtraEditors.Controls
Imports MySql.Data.MySqlClient

Public Class TambahDeposit

    Sub LoadItemMember()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("select kode_member as kode, nama_member as nama, alamat from member_m", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "nama"
        lookUpEdit.Properties.ValueMember = "kode"
        cekClose()
    End Sub

    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select max(no_transaksi) AS no_transaksi from member_deposit where no_transaksi LIKE 'DM" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_transaksi")) Then
            txtNoTransaksi.Text = "DM" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtNoTransaksi.Text = "DM" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub Kosongkan()
        txtNoTransaksi.Clear()
        txtKeterangan.Clear()
        txtSaldo.Text = "0"
        txtJumlah.Text = "0"
        cbMember.Text = ""

        cbMember.Focus()
        cbMember.Select()

        Call LoadItemMember()
        Call NomorOtomatis()
    End Sub

    Sub TampilCB()
        cbJenisDeposit.SelectedIndex = 0

        'cekOpen()
        'CMD = New MySqlCommand("SELECT * FROM member_m ORDER BY nama_member ASC", Conn)
        'DR = CMD.ExecuteReader
        'Do While DR.Read
        '    cbMember.Items.Add(DR.Item("kode_member") & "#" & DR.Item("nama_member"))
        'Loop
        'cekClose()

        'cekOpen()
        'CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE kodeacc LIKE '1-11%' AND parentacc != '' AND tipe = 'D' ORDER BY namaacc ASC", Conn)
        'DR = CMD.ExecuteReader
        'Do While DR.Read
        '    cbAkun.Items.Add(DR.Item("kodeacc") & "#" & DR.Item("namaacc"))
        'Loop
        'cekClose()
        'cbAkun.SelectedIndex = 1

        LookUpEditAkun.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT kodeacc, namaacc FROM perkiraan WHERE kodeacc LIKE '1-11%' AND parentacc != '' AND tipe = 'D' ORDER BY namaacc ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        LookUpEditAkun.Properties.DataSource = DS.Tables(0)
        LookUpEditAkun.Properties.DisplayMember = "namaacc"
        LookUpEditAkun.Properties.ValueMember = "kodeacc"
        cekClose()

        'cekOpen()
        'CMD = New MySqlCommand("SELECT*FROM perkiraan", Conn)
        'DR = CMD.ExecuteReader
        'Do While DR.Read
        '    If IsDBNull(DR.Item("parentacc")) Then
        '        cbKodeAkunDeposit.Items.Add("----------------------------------")
        '    Else
        '        cbKodeAkunDeposit.Items.Add(DR.Item("kodeacc") & "#" & DR.Item("namaacc"))
        '    End If
        'Loop
        'cekClose()
        'cbKodeAkunDeposit.SelectedIndex = 54
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub TambahDeposit_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        Call TampilCB()
    End Sub

    Private Sub cbJenisDeposit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbJenisDeposit.SelectedIndexChanged
        If cbJenisDeposit.Text = "Masuk" Then
            lblAkunMasuk.Visible = True
            lblAkunKeluar.Visible = False

            lblJumlahDeposit.Visible = True
            lblJumlahKeluar.Visible = False
        Else
            lblAkunMasuk.Visible = False
            lblAkunKeluar.Visible = True

            lblJumlahDeposit.Visible = False
            lblJumlahKeluar.Visible = True
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim kodemember As String = cbMember.Text
        Dim strArr() As String
        strArr = kodemember.Split("#")

        Dim saldoKas As Double = 0
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM arus_kas_saldo WHERE kodeacc = '" & LookUpEditAkun.EditValue.ToString & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            saldoKas = DR.Item("saldo_akhir")
        End If
        cekClose()

        If txtJumlah.Text = "" Or txtJumlah.Text = "0" Or lookUpEdit.Text.ToString = "" Or LookUpEditAkun.Text.ToString = "" Then

            MsgBox("Lengkapi Data Member dan Nominal Terlebih Dahulu!", MsgBoxStyle.Critical, "NiPOS")

        Else

            If cbJenisDeposit.Text <> "Masuk" Then

                If (saldoKas > 0) And (Double.Parse(txtJumlah.Text) <= saldoKas) Then
                    cekOpen()
                    Dim simpan As String = "INSERT INTO member_deposit VALUES ('" &
                                txtNoTransaksi.Text &
                                "','" & lookUpEdit.EditValue.ToString &
                                "','" & Format(dtptanggal.Value, "yyyy-MM-dd") &
                                "','" & cbJenisDeposit.Text &
                                "','" & txtJumlah.Text &
                                "','" & MainMenu.PanelUser.Text &
                                "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                                "','" & txtKeterangan.Text & "' )"
                    CMD = New MySqlCommand(simpan, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    cekOpen()
                    Dim edit As String
                    Dim simpanjurnal1 As String
                    Dim simpanjurnal2 As String
                    Dim simpanSaldo, simpanSaldoHistory As String

                    If cbJenisDeposit.Text = "Masuk" Then
                        edit = "UPDATE member_m SET deposit= deposit + " & txtJumlah.Text & " WHERE kode_member ='" & lookUpEdit.EditValue.ToString & "'"
                        simpanjurnal2 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & LookUpEditAkun.EditValue.ToString & "', '" & LookUpEditAkun.Text.ToString & "', '" & txtJumlah.Text & "', 0, '" & cbMember.Text & "', 4, 1)"
                        simpanjurnal1 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','2-3101', 'DEPOSIT PELANGGAN', 0, '" & txtJumlah.Text & "', '" & cbMember.Text & "', 4, 2)"

                        simpanSaldo = "UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & txtJumlah.Text & "' WHERE kodeacc = '" & LookUpEditAkun.EditValue.ToString & "' "
                        simpanSaldoHistory = "INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & LookUpEditAkun.EditValue.ToString & "', '" & LookUpEditAkun.Text.ToString & "', '" & txtNoTransaksi.Text & "', 1, '" & txtJumlah.Text & "') "
                    Else
                        edit = "UPDATE member_m SET deposit= deposit - " & txtJumlah.Text & " WHERE kode_member ='" & lookUpEdit.EditValue.ToString & "'"
                        simpanjurnal2 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','2-3101', 'DEPOSIT PELANGGAN', '" & txtJumlah.Text & "', 0, '" & cbMember.Text & "', 4, 1)"
                        simpanjurnal1 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & LookUpEditAkun.EditValue.ToString & "', '" & LookUpEditAkun.Text.ToString & "', 0, '" & txtJumlah.Text & "', '" & cbMember.Text & "', 4, 2)"

                        simpanSaldo = "UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & txtJumlah.Text & "' WHERE kodeacc = '" & LookUpEditAkun.EditValue.ToString & "' "
                        simpanSaldoHistory = "INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & LookUpEditAkun.EditValue.ToString & "', '" & LookUpEditAkun.Text.ToString & "', '" & txtNoTransaksi.Text & "', 0, '" & txtJumlah.Text & "') "
                    End If

                    CMD = New MySqlCommand(edit, Conn)
                    CMD.ExecuteNonQuery()
                    CMD = New MySqlCommand(simpanjurnal1, Conn)
                    CMD.ExecuteNonQuery()
                    CMD = New MySqlCommand(simpanjurnal2, Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand(simpanSaldo, Conn)
                    CMD.ExecuteNonQuery()
                    CMD = New MySqlCommand(simpanSaldoHistory, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    Call InsertLogTrans(txtNoTransaksi.Text, "CREATE", MainMenu.PanelUser.Text, "DEPOSIT PELANGGAN " & cbJenisDeposit.Text & " | " & txtKeterangan.Text & " TOTAL Rp. " & txtJumlah.Text)

                    MsgBox("Data Berhasil Disimpan")
                    Kosongkan()
                    DepositPelanggan.TampilGrid()
                ElseIf Double.Parse(txtJumlah.Text) > saldoKas Then
                    MsgBox("Mohon Nominal yang Maaf Akun yang anda pilih tidak mempunyai saldo yang mencukupi", MsgBoxStyle.Critical, "NiPOS")
                Else
                    MsgBox("Mohon Maaf Akun yang anda pilih tidak mempunyai saldo (Nol)", MsgBoxStyle.Critical, "NiPOS")
                End If

            Else
                cekOpen()
                Dim simpan As String = "INSERT INTO member_deposit VALUES ('" &
                            txtNoTransaksi.Text &
                            "','" & lookUpEdit.EditValue.ToString &
                            "','" & Format(dtptanggal.Value, "yyyy-MM-dd") &
                            "','" & cbJenisDeposit.Text &
                            "','" & txtJumlah.Text &
                            "','" & MainMenu.PanelUser.Text &
                            "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                            "','" & txtKeterangan.Text & "' )"
                CMD = New MySqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                cekOpen()
                Dim edit As String
                Dim simpanjurnal1 As String
                Dim simpanjurnal2 As String
                Dim simpanSaldo, simpanSaldoHistory As String

                If cbJenisDeposit.Text = "Masuk" Then
                    edit = "UPDATE member_m SET deposit= deposit + " & txtJumlah.Text & " WHERE kode_member ='" & lookUpEdit.EditValue.ToString & "'"
                    simpanjurnal2 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & LookUpEditAkun.EditValue.ToString & "', '" & LookUpEditAkun.Text.ToString & "', '" & txtJumlah.Text & "', 0, '" & cbMember.Text & "', 4, 1)"
                    simpanjurnal1 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','2-3101', 'DEPOSIT PELANGGAN', 0, '" & txtJumlah.Text & "', '" & cbMember.Text & "', 4, 2)"

                    simpanSaldo = "UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & txtJumlah.Text & "' WHERE kodeacc = '" & LookUpEditAkun.EditValue.ToString & "' "
                    simpanSaldoHistory = "INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & LookUpEditAkun.EditValue.ToString & "', '" & LookUpEditAkun.Text.ToString & "', '" & txtNoTransaksi.Text & "', 1, '" & txtJumlah.Text & "') "
                Else
                    edit = "UPDATE member_m SET deposit= deposit - " & txtJumlah.Text & " WHERE kode_member ='" & lookUpEdit.EditValue.ToString & "'"
                    simpanjurnal2 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','2-3101', 'DEPOSIT PELANGGAN', '" & txtJumlah.Text & "', 0, '" & cbMember.Text & "', 4, 1)"
                    simpanjurnal1 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & LookUpEditAkun.EditValue.ToString & "', '" & LookUpEditAkun.Text.ToString & "', 0, '" & txtJumlah.Text & "', '" & cbMember.Text & "', 4, 2)"

                    simpanSaldo = "UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & txtJumlah.Text & "' WHERE kodeacc = '" & LookUpEditAkun.EditValue.ToString & "' "
                    simpanSaldoHistory = "INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & LookUpEditAkun.EditValue.ToString & "', '" & LookUpEditAkun.Text.ToString & "', '" & txtNoTransaksi.Text & "', 0, '" & txtJumlah.Text & "') "
                End If

                CMD = New MySqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanjurnal1, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanjurnal2, Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand(simpanSaldo, Conn)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand(simpanSaldoHistory, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                Call InsertLogTrans(txtNoTransaksi.Text, "CREATE", MainMenu.PanelUser.Text, "DEPOSIT PELANGGAN " & cbJenisDeposit.Text & " | " & txtKeterangan.Text & " TOTAL Rp. " & txtJumlah.Text)

                MsgBox("Data Berhasil Disimpan")
                Kosongkan()
                DepositPelanggan.TampilGrid()
            End If
        End If
    End Sub

    Private Sub lookUpEdit_Closed(sender As Object, e As ClosedEventArgs) Handles lookUpEdit.Closed
        If lookUpEdit.Text.ToString <> "" Then
            Dim kodemember As String = lookUpEdit.EditValue.ToString
            cekOpen()
            CMD = New MySqlCommand("SELECT deposit FROM member_m WHERE kode_member = '" & kodemember & "' ", Conn)
            DR = CMD.ExecuteReader

            Do While DR.Read
                txtSaldo.Text = FormatCurrency(DR.Item("deposit"))
            Loop

            cekClose()
        End If
    End Sub
End Class