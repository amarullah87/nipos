Imports MySql.Data.MySqlClient

Public Class TambahKasTransfer

    Sub GenerateTransactionNum()
        cekOpen()
        CMD = New MySqlCommand("select COUNT(no_transaksi) AS no_transaksi from arus_kas WHERE tanggal = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND no_transaksi LIKE 'KT%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Dim inc As Integer = DR.Item("no_transaksi") + 1
            txtNoTransaksi.Text = "KT" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", inc)
        Else
            Dim inc As Integer = 1
            txtNoTransaksi.Text = "KT" + Format(dtptanggal.Value, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub GenerateTransactionNumX()
        cekOpen()
        CMD = New MySqlCommand("select max(no_transaksi) AS no_transaksi from arus_kas where no_transaksi LIKE 'KT" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_transaksi")) Then
            txtNoTransaksi.Text = "KT" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtNoTransaksi.Text = "KT" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub GetAkun()
        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE parentacc = '1-1100' ORDER BY kodeacc ASC", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            If DR.Item("tipe") <> "H" Then
                cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
                cbAkun2.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
            End If
        Loop
        cekClose()
    End Sub

    Sub Kosongkan()
        Call GenerateTransactionNum()
        txtJumlah.Text = "0"
        txtSaldo.Text = "0"
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
        Call GetAkun()
    End Sub

    Private Sub cbAkun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAkun.SelectedIndexChanged
        Dim kodeAkun As String = cbAkun.Text
        Dim strArr() As String
        strArr = kodeAkun.Split("/")

        cekOpen()
        CMD = New MySqlCommand("SELECT saldo_akhir AS saldo FROM arus_kas_saldo WHERE kodeacc = '" & strArr(0) & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtSaldo.Text = FormatCurrency(DR.Item("saldo"), 0)
            txtSaldoHide.Text = DR.Item("saldo")
        Else
            txtSaldo.Text = "0"
            txtSaldoHide.Text = "0"
        End If
        cekClose()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call GenerateTransactionNum()

        If cbAkun.Text = "" Or cbAkun.Text = "----------------------------------" Then
            MsgBox("Kode Akun Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf txtJumlah.Text = 0 Or txtJumlah.Text = "" Then
            MsgBox("Jumlah Harus Di isi!", MsgBoxStyle.Critical)
            Exit Sub
        Else

            Dim kodeAkun As String = cbAkun.Text
            Dim strArr() As String
            strArr = kodeAkun.Split("/")

            Dim kodeAkun2 As String = cbAkun2.Text
            Dim strArr2() As String
            strArr2 = kodeAkun2.Split("/")

            Dim saldoKas As Double = 0
            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM arus_kas_saldo WHERE kodeacc = '" & strArr(0) & "' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                saldoKas = DR.Item("saldo_akhir")
            End If
            cekClose()

            If (saldoKas > 0) And (Double.Parse(txtJumlah.Text) <= saldoKas) Then
                If strArr(0) <> strArr2(0) Then

                    cekOpen()
                    CMD = New MySqlCommand("INSERT INTO arus_kas (no_transaksi, tanggal, kodeacc, kodeacc_tf, keterangan, jumlah, jenis, created_by, created_date) VALUES ('" &
                                                txtNoTransaksi.Text & "', '" &
                                               Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" &
                                               cbAkun.Text & "', '" &
                                               cbAkun2.Text & "', '" &
                                               txtKeterangan.Text & "', '" &
                                               txtJumlah.Text & "', 'transfer', '" &
                                               MainMenu.PanelUser.Text & "', '" &
                                               DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' ) ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO jurnal VALUES ('" & txtNoTransaksi.Text & "', '" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" &
                                               strArr(0) & "', '" & strArr(1) & "', '0', '" & txtJumlah.Text & "', '" & txtKeterangan.Text & "', '4', 1)", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO jurnal VALUES ('" & txtNoTransaksi.Text & "', '" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" &
                                               strArr2(0) & "', '" & strArr2(1) & "', '" & txtJumlah.Text & "', '0', '" & txtKeterangan.Text & "', '4', 2)", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - '" & txtJumlah.Text & "' WHERE kodeacc = '" & strArr(0) & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & txtJumlah.Text & "' WHERE kodeacc = '" & strArr2(0) & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strArr(0) & "', '" & strArr(1) & "', '" & txtNoTransaksi.Text & "', 0, '" & txtJumlah.Text & "') ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('" & strArr2(0) & "', '" & strArr2(1) & "', '" & txtNoTransaksi.Text & "', 1, '" & txtJumlah.Text & "') ", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    Call InsertLogTrans(txtNoTransaksi.Text, "CREATE", MainMenu.PanelUser.Text, "KAS TRANSFER | " & txtKeterangan.Text & " TOTAL Rp. " & txtJumlah.Text)

                    Call Kosongkan()
                    MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information)
                    DaftarKasTransfer.TampilGrid()
                    Me.Close()

                Else
                    MsgBox("Akun tujuan tidak boleh sama dengan Akun Sumber.", MsgBoxStyle.Critical, "Perhatian")
                End If
            Else
                MsgBox("Mohon Maaf Saldo " & strArr(1) & " -Kosong- Atau melebihi Saldo yang ada!", MsgBoxStyle.Critical, "Perhatian")
            End If

        End If
    End Sub

    Private Sub TambahKasTransfer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Kosongkan()
        Call GetAkun()
    End Sub

    Private Sub dtptanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtptanggal.ValueChanged
        Call GenerateTransactionNum()
    End Sub
End Class