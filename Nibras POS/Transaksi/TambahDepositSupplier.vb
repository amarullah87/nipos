Imports MySql.Data.MySqlClient

Public Class TambahDepositSupplier
    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select max(no_transaksi) AS no_transaksi from supplier_deposit where no_transaksi LIKE 'DS" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_transaksi")) Then
            txtNoTransaksi.Text = "DS" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtNoTransaksi.Text = "DS" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
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

        Call TampilCB()
        Call NomorOtomatis()
        Call LoadItemDb()
    End Sub

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

    Sub TampilCB()
        cbJenisDeposit.SelectedIndex = 1

        'cekOpen()
        'CMD = New MySqlCommand("SELECT * FROM mst_distributor WHERE nama NOT LIKE '%DB Online%' AND STATUS = 1 ORDER BY nama ASC", Conn)
        'DR = CMD.ExecuteReader
        'Do While DR.Read
        '    cbMember.Items.Add(DR.Item("kode") & "/" & DR.Item("nama"))
        'Loop
        'cekClose()

        cekOpen()
        CMD = New MySqlCommand(qKasOnly, Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            If DR.Item("level") = 0 Then
                cbAkun.Items.Add("----------------------------------")
            Else
                If DR.Item("tipe") <> "H" Then
                    cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
                End If
            End If
        Loop
        cekClose()
        cbAkun.SelectedIndex = 0

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE kodeacc LIKE '1-11%' AND parentacc != ''", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            If IsDBNull(DR.Item("parentacc")) Then
                cbKodeAkunDeposit.Items.Add("----------------------------------")
            Else
                cbKodeAkunDeposit.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
            End If
        Loop
        cekClose()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
        'MsgBox(txtJumlah2.Text)
    End Sub

    Private Sub TambahDeposit_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        Call LoadItemDb()
    End Sub

    Private Sub cbMember_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMember.SelectedIndexChanged
        Dim kodemember As String = cbMember.Text
        Dim strArr() As String

        strArr = kodemember.Split("/")
        cekOpen()
        CMD = New MySqlCommand("SELECT deposit FROM mst_distributor WHERE kode = '" & strArr(0) & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            txtSaldo.Text = FormatCurrency(DR.Item("deposit"))
        Loop

        cekClose()
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

        If cbMember.Text <> "" Or txtJumlah.Text <> "0" Then
            Dim kodeakun As String = cbAkun.Text
            Dim strAkun() As String
            strAkun = kodeakun.Split("/")

            cekOpen()
            Dim simpan As String = "INSERT INTO supplier_deposit VALUES ('" &
                        txtNoTransaksi.Text &
                        "','" & lookUpEdit.EditValue.ToString &
                        "','" & Format(dtptanggal.Value, "yyyy-MM-dd") &
                        "','" & cbJenisDeposit.Text &
                        "','" & Val(txtJumlah.Text.Replace(".", "")) &
                        "','" & MainMenu.PanelUser.Text &
                        "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' )"
            CMD = New MySqlCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            Dim edit As String
            Dim simpanjurnal1 As String
            Dim simpanjurnal2 As String
            Dim simpanSaldo, simpanSaldoHistory As String

            If cbJenisDeposit.Text = "Masuk" Then
                edit = "UPDATE mst_distributor SET deposit= deposit - " & Val(txtJumlah.Text.Replace(".", "")) & " WHERE kode ='" & lookUpEdit.EditValue.ToString & "'"
                simpanjurnal2 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & strAkun(0) & "', '" & strAkun(1) & "', '" & Val(txtJumlah.Text.Replace(".", "")) & "', 0, '" & lookUpEdit.EditValue.ToString & "/" & lookUpEdit.Text.ToString & "', 4, 1)"
                simpanjurnal1 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1801', 'DANA DEPOSIT DI SUPLIER', 0, '" & Val(txtJumlah.Text.Replace(".", "")) & "', '', 4, 2)"

                simpanSaldo = "UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & txtJumlah.Text & "' WHERE kodeacc = '" & strAkun(0) & "' "
                simpanSaldoHistory = "INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strAkun(0) & "', '" & strAkun(1) & "', '" & txtNoTransaksi.Text & "', 1, '" & txtJumlah.Text & "') "
            Else
                edit = "UPDATE mst_distributor SET deposit= deposit + " & Val(txtJumlah.Text.Replace(".", "")) & " WHERE kode ='" & lookUpEdit.EditValue.ToString & "'"
                simpanjurnal2 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1801', 'DANA DEPOSIT DI SUPLIER', '" & Val(txtJumlah.Text.Replace(".", "")) & "', 0, '" & lookUpEdit.EditValue.ToString & "/" & lookUpEdit.Text.ToString & "', 4, 1)"
                simpanjurnal1 = "insert into jurnal values ('" & txtNoTransaksi.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & strAkun(0) & "','" & strAkun(1) & "', 0, '" & Val(txtJumlah.Text.Replace(".", "")) & "', '', 4, 2)"

                simpanSaldo = "UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & txtJumlah.Text & "' WHERE kodeacc = '" & strAkun(0) & "' "
                simpanSaldoHistory = "INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strAkun(0) & "', '" & strAkun(1) & "', '" & txtNoTransaksi.Text & "', 0, '" & txtJumlah.Text & "') "
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

            Call InsertLogTrans(txtNoTransaksi.Text, "CREATE", MainMenu.PanelUser.Text, "DEPOSIT SUPPLIER " & cbJenisDeposit.Text & " | " & txtKeterangan.Text & " TOTAL Rp. " & txtJumlah.Text)

            MsgBox("Data Berhasil Disimpan")
            Kosongkan()
        Else
            MsgBox("Silahkan Lengkapi Data!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles lookUpEdit.EditValueChanged
        cekOpen()
        CMD = New MySqlCommand("SELECT deposit FROM mst_distributor WHERE kode = '" & lookUpEdit.EditValue.ToString & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            txtSaldo.Text = FormatCurrency(DR.Item("deposit"))
        Loop

        cekClose()
    End Sub

    Private Sub txtJumlah_LostFocus(sender As Object, e As EventArgs) Handles txtJumlah.LostFocus
        If txtJumlah.Text = "" Then
            txtJumlah.Text = 0
        Else
            txtJumlah.Text = FormatNumber(txtJumlah.Text, 0)
        End If
    End Sub
End Class