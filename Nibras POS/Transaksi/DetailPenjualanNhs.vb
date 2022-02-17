Imports MySql.Data.MySqlClient

Public Class DetailPenjualanNhs
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub DetailPenjualanNhs_Load(sender As Object, e As EventArgs) Handles Me.Load
        If MainMenu.PanelKode.Text = "KASIR" Then
            btnBatal.Enabled = False
            btnSimpan.Enabled = False
        End If

        cekClose()
        SetDoubleBuffered(DGV, True)

        Call DetailData()
    End Sub

    Private Sub DetailData()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM penjualan WHERE faktur_jual = '" & HistoryPenjualan.notransaksi & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then

            Dim kodemember As String = DR.Item("kode_customer")
            Dim strArr() As String
            strArr = kodemember.Split("/")

            lblnomrofaktur.Text = DR.Item("faktur_jual")
            dtptanggal.Value = Format(DR.Item("tgl_jual"), "dd/MM/yyyy")
            If kodemember = "UMUM/UMUM/CASH" Then
                txtMember.Text = "UMUM"
                lblkodecustomer.Text = "UMUM/CASH"
            Else
                txtMember.Text = strArr(0)
                lblkodecustomer.Text = strArr(1)
            End If

            lbljumlahbarang.Text = DR.Item("item_jual")
            lblstatusjual.Text = DR.Item("cara_jual")
            lbltotalhargaBig.Text = FormatNumber(DR.Item("total_jual") + DR.Item("ongkir"), 2)
        End If
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT db.*, b.`nama_barang`, b.`satuan`, b.`jenis`, db.`qty_retur` " &
            " FROM detailjual db INNER JOIN barang_m b ON b.`kode_item` = db.`kode_barang` WHERE faktur_jual = '" & HistoryPenjualan.notransaksi & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(
                DR.Item("kode_barang"),
                DR.Item("nama_barang"),
                DR.Item("satuan"),
                DR.Item("jenis"),
                DR.Item("harga_jual"),
                DR.Item("qty_jual"),
                DR.Item("diskon"),
                DR.Item("diskon_rp"),
                DR.Item("subtotal_jual"),
                0,
                DR.Item("qty_retur")
            )
        Loop
        cekClose()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        'MsgBox("Mohon Maaf untuk sementara tidak bisa melakukan Perubahan Data, Silahkan hubungi IT.", MsgBoxStyle.Information, "Perhatian")

        If CheckReturFirst() = True Then
            UbahPenjualan.MdiParent = MainMenu
            UbahPenjualan.Show()
            UbahPenjualan.Focus()
        Else
            MsgBox("Mohon Maaf, Faktur ini tidak bisa diubah karena telah terjadi Transaksi Retur sebelumnya.", MsgBoxStyle.Exclamation, "Perhatian!")
        End If

    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If CheckReturFirst() = True Then

            If MessageBox.Show("Apakah Data Akan di Hapus?!" & vbCrLf & "Data yang sudah di hapus Tidak Dapat Dikembalikan.", "Perhatian",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

                If MessageBox.Show("Anda Yakin?!" & vbCrLf & "Data yang sudah di hapus Tidak Dapat Dikembalikan.", "Perhatian",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then

                    Dim newFaktur As String = "BTL-" + lblnomrofaktur.Text

                    Dim list As New ArrayList
                    Dim listQty As New ArrayList

                    cekOpen()
                    CMD = New MySqlCommand("SELECT * FROM detailjual WHERE faktur_jual = '" & lblnomrofaktur.Text & "'", Conn)
                    DR = CMD.ExecuteReader
                    Do While DR.Read
                        list.Add(DR.Item("kode_barang"))
                        listQty.Add(DR.Item("qty_jual"))
                    Loop
                    cekClose()

                    For i As Integer = 0 To list.Count - 1
                        Dim kurangistok As String = "UPDATE barang_m SET stok= stok + " & listQty(i).ToString & " WHERE kode_item='" & list(i).ToString & "'"
                        'MsgBox(kurangistok)
                        cekOpen()
                        CMD = New MySqlCommand(kurangistok, Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()
                    Next

                    '## Proses untuk kembalikan KAS ##'
                    cekOpen()
                    CMD = New MySqlCommand("SELECT * FROM penjualan WHERE faktur_jual = '" & lblnomrofaktur.Text & "' ", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()

                    Dim kas As Double = 0
                    Dim deposit As Double = 0
                    Dim kodeMember As String = ""
                    If DR.HasRows Then
                        kas = DR.Item("total_jual")
                        deposit = DR.Item("deposit")
                        kodeMember = DR.Item("kode_customer")
                    End If
                    cekClose()

                    cekOpen()
                    If deposit > 0 Then
                        Dim strArr() As String = kodeMember.Split("/")

                        CMD = New MySqlCommand("UPDATE member_m SET deposit = deposit + " & kas & " WHERE kode_member = '" & strArr(0) & "'", Conn)
                        CMD.ExecuteNonQuery()
                    Else
                        CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir - " & kas & " WHERE kodeacc = '1-1110'", Conn)
                        CMD.ExecuteNonQuery()
                    End If

                    CMD = New MySqlCommand("DELETE FROM arus_kas_saldo_history WHERE no_transaksi = '" & lblnomrofaktur.Text & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE detailjual SET faktur_jual = '" & newFaktur & "' WHERE faktur_jual = '" & lblnomrofaktur.Text & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("DELETE FROM jurnal WHERE nomor_transaksi = '" & lblnomrofaktur.Text & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("DELETE FROM jurnal WHERE nomor_transaksi = '" & lblnomrofaktur.Text & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("DELETE FROM history_stok WHERE no_transaksi = '" & lblnomrofaktur.Text & "' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE penjualan SET faktur_jual = '" & newFaktur & "' WHERE faktur_jual = '" & lblnomrofaktur.Text & "' ", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    Call InsertLogTrans(lblnomrofaktur.Text, "DELETE", MainMenu.PanelUser.Text, "PENJUALAN - HAPUS TRANSAKSI")

                    MsgBox("Data Berhasil di Hapus!", MsgBoxStyle.Information, "Perhatian")
                    Me.Close()
                    HistoryPenjualan.Kosongkan()
                End If

            End If

        Else
            MsgBox("Mohon Maaf, Faktur ini tidak bisa diubah karena telah terjadi Transaksi Retur sebelumnya.", MsgBoxStyle.Exclamation, "Perhatian!")
        End If
    End Sub

    Function CheckReturFirst()
        Dim lolos As Boolean = True
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM returpenjualan WHERE faktur_jual = '" & lblnomrofaktur.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            lolos = False
        End If
        cekClose()

        Return lolos
    End Function
End Class