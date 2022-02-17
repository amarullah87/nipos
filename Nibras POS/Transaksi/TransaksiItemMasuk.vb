Imports MySql.Data.MySqlClient

Public Class TransaksiItemMasuk

    Public notransaksi As String = ""
    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("SELECT MAX(no_transaksi) AS no_transaksi FROM transaksi_barang WHERE no_transaksi LIKE 'BM" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_transaksi")) Then
            txtnofaktur.Text = "BM" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtnofaktur.Text = "BM" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If

        cekClose()
    End Sub


    Sub Kosongkan()
        cekClose()
        txtBarcode.Focus()
        txtKeterangan.Text = ""
        cbAkun.Text = ""
        DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
        DGV.Rows.Clear()

        Call CallAkun()
        Call NomorOtomatis()
    End Sub

    Sub CallAkun()
        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE parentacc != ''", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            cbAkun.Items.Add(DR.Item("kodeacc") & "-" & DR.Item("namaacc"))
        Loop
        cekClose()
    End Sub

    Private Sub TransaksiItemMasuk_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        SetDoubleBuffered(DGV, True)

        If DaftarItemMasuk.notransaksi = "" Then
            Call Kosongkan()
        Else
            Call GetDetail()
        End If

        If MainMenu.PanelID.Text = "P033-M0002" Then
            cbUbahHpp.Visible = True
        Else
            cbUbahHpp.Visible = False
        End If
    End Sub

    Sub GetDetail()
        Me.Text = "Detail Item Masuk"
        DGV.ReadOnly = True

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM transaksi_barang WHERE no_transaksi = '" & DaftarItemMasuk.notransaksi & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtnofaktur.Text = DR.Item("no_transaksi")
            dtptanggal.Value = DR.Item("tanggal")
            txtKeterangan.Text = DR.Item("keterangan")
            txtKeterangan.ReadOnly = True
            txtBarcode.ReadOnly = True

            btnSimpan.Enabled = False
            btnBatal.Enabled = False
        End If
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT bd.*, b.`nama_barang`, b.`satuan`, b.`jenis` FROM transaksi_barang_detail bd INNER JOIN barang_m b ON b.`kode_item` = bd.`kode_item` WHERE no_transaksi = '" & DaftarItemMasuk.notransaksi & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read()
            DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("jenis"), DR.Item("harga"), DR.Item("qty"), DR.Item("subtotal"))
        Loop

        Call Hitungtransaksi()
        cekClose()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 0 Then

            'cegah kode barang ganda
            For barisatas As Integer = 0 To DGV.RowCount - 1
                For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                    If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                        DGV.Rows(barisatas).Cells(5).Value = DGV.Rows(barisatas).Cells(5).Value + 1
                        DGV.Rows(barisatas).Cells(6).Value = DGV.Rows(barisatas).Cells(4).Value * DGV.Rows(barisatas).Cells(5).Value
                        DGV.Rows.RemoveAt(barisbawah)
                        SendKeys.Send("{up}")
                        Call Hitungtransaksi()
                        Exit Sub
                    End If
                Next
            Next

            cekOpen()
            CMD = New MySqlCommand("select * from barang_m where kode_item='" & DGV.Rows(e.RowIndex).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                DGV.Rows(e.RowIndex).Cells(1).Value = DR.Item("nama_barang")
                DGV.Rows(e.RowIndex).Cells(2).Value = DR.Item("satuan")
                DGV.Rows(e.RowIndex).Cells(3).Value = DR.Item("jenis")
                DGV.Rows(e.RowIndex).Cells(4).Value = DR.Item("hpp")
                DGV.Focus()
                DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{up}")
            Else
                MsgBox("Kode barang tidak terdaftar")
                SendKeys.Send("{up}")
                DownloadBarang.Show()
            End If
            cekClose()

        End If

        If MainMenu.PanelID.Text = "P033-M0002" Then
            If e.ColumnIndex = 4 Then

                If DGV.Rows(e.RowIndex).Cells(0).Value = "" And DGV.Rows(e.RowIndex).Cells(1).Value = "" And DGV.Rows(e.RowIndex).Cells(2).Value = "" Then

                    MsgBox("Mohon Lengkapi Data")
                    SendKeys.Send("{up}")
                Else

                    DGV.Rows(e.RowIndex).Cells(6).Value = DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value
                    DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
                    SendKeys.Send("{down}")
                    Call Hitungtransaksi()

                End If
            End If
        End If

        If e.ColumnIndex = 5 Then

            If DGV.Rows(e.RowIndex).Cells(0).Value = "" And DGV.Rows(e.RowIndex).Cells(1).Value = "" And DGV.Rows(e.RowIndex).Cells(2).Value = "" Then

                MsgBox("Mohon Lengkapi Data")
                SendKeys.Send("{up}")
            Else

                DGV.Rows(e.RowIndex).Cells(6).Value = DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value
                DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{down}")
                Call Hitungtransaksi()

            End If
        End If
    End Sub

    Sub Hitungtransaksi()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(6).Value
            txtTotalHarga.Text = "Total: " + FormatCurrency(x)
            txtTotal.Text = x
        Next

        Dim y As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            y = y + DGV.Rows(baris).Cells(5).Value
            txtTotalQty.Text = y
        Next
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        'On ENTER
        If e.KeyChar = ChrW(Keys.Return) Then

            Dim namabarang As String
            If txtBarcode.Text.Contains("'") Then
                namabarang = txtBarcode.Text.Replace("'", "''")
            Else
                namabarang = txtBarcode.Text
            End If

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & namabarang & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()


            If (DR.HasRows) Then

                Dim baris As Integer = DGV.RowCount - 1
                DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("jenis"), DR.Item("hpp"), 1, DR.Item("hpp"))
                DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
                txtBarcode.Clear()
                cekClose()

                Call Hitungtransaksi()
                For barisatas As Integer = 0 To DGV.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                        If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                            DGV.Rows(barisatas).Cells(5).Value = DGV.Rows(barisatas).Cells(5).Value + 1
                            DGV.Rows(barisatas).Cells(6).Value = DGV.Rows(barisatas).Cells(4).Value * DGV.Rows(barisatas).Cells(5).Value
                            DGV.Rows.RemoveAt(barisbawah)
                            SendKeys.Send("{up}")
                            Call Hitungtransaksi()
                            Exit Sub
                        End If
                    Next
                Next
            Else
                cekClose()
                PencarianBarangItemMasuk.ShowDialog()
                PencarianBarangItemMasuk.TXTCariBarang.Text = txtBarcode.Text
            End If
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                DownloadBarang.Show()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKeterangan.Text = "" Or txtTotal.Text = "" Or txtTotalQty.Text = "" Then
            MsgBox("Mohon Lengkapi Data Transaksi")
        Else
            cekOpen()
            Dim simpan1 As String = "INSERT INTO transaksi_barang VALUES ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "','5-2201','" & txtTotalQty.Text & "','" & txtTotal.Text & "', '1', '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & MainMenu.PanelUser.Text & "', '" & txtKeterangan.Text & "' )"
            CMD = New MySqlCommand(simpan1, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            ''####### INSERT JURNAL #######''
            cekOpen()
            Dim simpanjurnal2 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','5-2201','ITEM MASUK',0, '" & txtTotal.Text & "', '" & txtKeterangan.Text & "', 3, 1)"
            CMD = New MySqlCommand(simpanjurnal2, Conn)
            CMD.ExecuteNonQuery()

            Dim simpanjurnal1 As String = "insert into jurnal values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510', 'PERSEDIAAN BARANG', '" & txtTotal.Text & "', 0, '" & txtKeterangan.Text & "', 3, 2)"
            CMD = New MySqlCommand(simpanjurnal1, Conn)
            CMD.ExecuteNonQuery()
            cekClose()
            ''####### END OF JURNAL #######''

            For baris As Integer = 0 To DGV.RowCount - 2

                cekOpen()
                Dim simpan2 As String = "INSERT INTO transaksi_barang_detail values ('" & txtnofaktur.Text & "','" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(4).Value & "','" & DGV.Rows(baris).Cells(5).Value & "','" & DGV.Rows(baris).Cells(6).Value & "', 0)"
                CMD = New MySqlCommand(simpan2, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                cekOpen()
                CMD = New MySqlCommand("select * from barang_m where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    Dim tambahstok As String
                    Dim penanda As String

                    If cbUbahHpp.Checked = True Then
                        tambahstok = "update barang_m set stok='" & DR.Item("stok") + DGV.Rows(baris).Cells(5).Value & "', hpp = '" & DGV.Rows(baris).Cells(4).Value & "' where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'"
                        penanda = "[ hpp ]"
                    Else
                        tambahstok = "update barang_m set stok='" & DR.Item("stok") + DGV.Rows(baris).Cells(5).Value & "' where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'"
                        penanda = ""
                    End If

                    Dim stokAwal As Integer = DR.Item("stok")
                    Dim stokAkhir As Integer = DGV.Rows(baris).Cells(5).Value + DR.Item("stok")
                    cekClose()

                    'Update Stok
                    cekOpen()
                    CMD = New MySqlCommand(tambahstok, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    cekOpen()
                    Dim updatehistory As String = "INSERT INTO history_stok VALUES ( '" &
                            DGV.Rows(baris).Cells(0).Value & "', '" &
                            txtnofaktur.Text & "', '" &
                            Format(dtptanggal.Value, "yyyy-MM-dd") & "', 'Barang Masuk Non-Modal " & penanda & "', '" &
                            stokAwal & "', '" &
                            DGV.Rows(baris).Cells(5).Value & "', '" &
                            stokAkhir & "', '" &
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" &
                            MainMenu.PanelUser.Text & "' )"
                    CMD = New MySqlCommand(updatehistory, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()
                End If
            Next

            Call InsertLogTrans(txtnofaktur.Text, "CREATE", MainMenu.PanelUser.Text, "ITEM MASUK | " & txtKeterangan.Text & " QTY " & txtTotalQty.Text & " TOTAL Rp. " & txtTotal.Text)

            MsgBox("Data Berhasil Disimpan")
            Call Kosongkan()
            Call NomorOtomatis()
            DaftarItemMasuk.TampilGrid()
        End If
    End Sub
End Class