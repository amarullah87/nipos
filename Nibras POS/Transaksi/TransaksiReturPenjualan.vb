Imports MySql.Data.MySqlClient

Public Class TransaksiReturPenjualan
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select MAX(no_retur_jual) AS no_retur_jual from returpenjualan where no_retur_jual LIKE 'RJ" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_retur_jual")) Then
            lblnomorreturjual.Text = "RJ" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_retur_jual")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            lblnomorreturjual.Text = "RJ" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If

        cekClose()
    End Sub

    Private Sub TransaksiReturPenjualan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call NomorOtomatis()
        SetDoubleBuffered(DGV, True)

        'MsgBox(NomorOtomatisDeposit)
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 7 Then
            Try
                If DGV.Rows(e.RowIndex).Cells(7).Value > DGV.Rows(e.RowIndex).Cells(3).Value Then
                    MsgBox("Jumlah retur melebihi jumlah jual")
                    DGV.Rows(e.RowIndex).Cells(7).Value = 0
                    Call Hitungtransaksi()
                    SendKeys.Send("{up}")
                    Exit Sub
                Else
                    Try
                        DGV.CurrentCell = DGV(7, DGV.CurrentCell.RowIndex)
                        SendKeys.Send("{up}")
                        Call Hitungtransaksi()
                    Catch ex As Exception
                        MsgBox("harus data angka")
                    End Try
                End If
            Catch ex As Exception
                MsgBox("harus data angka")
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(7).Value = 0
            End Try
        End If

        If e.ColumnIndex = 8 Then
            DGV.CurrentCell = DGV(8, DGV.CurrentCell.RowIndex)
        End If

        Call Hitungtransaksi()
    End Sub

    Sub Hitungtransaksi()

        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(7).Value
            lbljumlahretur.Text = x
        Next

    End Sub

    Private Sub DGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGV.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then
            DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
            Call Hitungtransaksi()
        End If
    End Sub

    Sub Kosongkan()
        cbofakturjual.Text = ""
        lbljumlahretur.Text = ""
        lblcarajual.Text = ""
        lblsisapiutang.Text = ""
        lbljatuhtempo.Text = ""
        lblstatusjual.Text = ""
        lblnamacustomer.Text = ""
        lbltanggaljual.Text = ""
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
        DGV.Columns.Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim kode_customer As String

        cekOpen()
        CMD = New MySqlCommand("SELECT kode_customer FROM penjualan WHERE faktur_jual = '" & cbofakturjual.Text & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Dim strCustArr() As String
            strCustArr = DR.Item("kode_customer").split("/")
            kode_customer = strCustArr(0)
            cekClose()

            'MsgBox(kode_customer)
            If cbofakturjual.Text = "" Or lbljumlahretur.Text = "" Or lbljumlahretur.Text = "0" Then
                MsgBox("Transaksi belum lengkap")
                Exit Sub
            Else

                Dim totalharga As Double = 0
                Dim totalhpp As Double = 0
                'MsgBox(DGV.RowCount.ToString)
                For baris As Integer = 0 To DGV.RowCount - 1
                    If DGV.Rows(baris).Cells(7).Value <> "" Then
                        If DGV.Rows(baris).Cells(7).Value > 0 Then

                            cekOpen()
                            Dim totaldetail As Double = ((100 - DGV.Rows(baris).Cells(4).Value) / 100) * DGV.Rows(baris).Cells(7).Value * DGV.Rows(baris).Cells(2).Value
                            Dim simpan2 As String = "insert into detailreturjual values ('" & lblnomorreturjual.Text & "','" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(7).Value & "','" & DGV.Rows(baris).Cells(8).Value & "', '" & totaldetail & "')"
                            CMD = New MySqlCommand(simpan2, Conn)
                            CMD.ExecuteNonQuery()
                            cekClose()

                            cekOpen()
                            CMD = New MySqlCommand("select * from barang_m where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
                            DR = CMD.ExecuteReader
                            DR.Read()
                            If DR.HasRows Then
                                Dim tambahstok As String = "update barang_m set stok=stok + '" & DGV.Rows(baris).Cells(7).Value & "' where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'"
                                Dim stokAwal As Integer = DR.Item("stok")
                                Dim stokAkhir As Integer = DGV.Rows(baris).Cells(7).Value + DR.Item("stok")
                                Dim diskon As Integer = 100 - DGV.Rows(baris).Cells(4).Value

                                totalharga += (diskon / 100) * DGV.Rows(baris).Cells(7).Value * DR.Item("hpj")
                                totalhpp += DGV.Rows(baris).Cells(7).Value * DR.Item("hpp")
                                cekClose()

                                'Update Stok
                                cekOpen()
                                CMD = New MySqlCommand(tambahstok, Conn)
                                CMD.ExecuteNonQuery()
                                cekClose()

                                'Update History Stok
                                cekOpen()
                                Dim updatehistory As String = "INSERT INTO history_stok VALUES ( '" &
                                        DGV.Rows(baris).Cells(0).Value & "', '" &
                                        lblnomorreturjual.Text & "', '" &
                                        Format(dtptanggal.Value, "yyyy-MM-dd") & "', 'Retur Jual', '" &
                                        stokAwal & "', '" &
                                        DGV.Rows(baris).Cells(7).Value & "', '" &
                                        stokAkhir & "', '" &
                                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" &
                                        MainMenu.PanelUser.Text & "' )"
                                CMD = New MySqlCommand(updatehistory, Conn)
                                CMD.ExecuteNonQuery()
                                cekClose()

                                'Update QTY Retur di Detail Penjualan
                                cekOpen()
                                Dim updateStatus As String = "UPDATE detailjual SET qty_retur = '" & DGV.Rows(baris).Cells(7).Value & "' WHERE faktur_jual = '" & cbofakturjual.Text & "' AND kode_barang = '" & DGV.Rows(baris).Cells(0).Value & "' "
                                CMD = New MySqlCommand(updateStatus, Conn)
                                CMD.ExecuteNonQuery()
                                cekClose()
                            End If

                            'MsgBox(DGV.Rows(baris).Cells(0).Value + " " + DGV.Rows(baris).Cells(7).Value)
                        End If
                    End If
                Next

                cekOpen()

                Dim simpanretur As String = "insert into returpenjualan values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "','" & cbofakturjual.Text & "','" & lbljumlahretur.Text & "','" & MainMenu.PanelUser.Text & "', '" & totalharga & "')"
                CMD = New MySqlCommand(simpanretur, Conn)
                CMD.ExecuteNonQuery()

                cekClose()

                'Dim simpanjurnal1 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd HH:mm:ss") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110','KAS KECIL', 0, '" & totalharga & "', '" & cbofakturjual.Text & "', 2, 1)"
                'CMD = New MySqlCommand(simpanjurnal1, Conn)
                'CMD.ExecuteNonQuery()

                If lblstatusjual.Text = "LUNAS" Then
                    cekOpen()
                    Dim simpanjurnal1 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1100','PENDAPATAN JUAL', '" & totalharga & "', 0, '" & cbofakturjual.Text & "', 2, 1)"
                    CMD = New MySqlCommand(simpanjurnal1, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal2 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','2-3101', 'DEPOSIT PELANGGAN', 0, '" & totalharga & "', '" & kode_customer & "', 2, 2)"
                    CMD = New MySqlCommand(simpanjurnal2, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal4 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG', '" & totalhpp & "', 0, '', 2, 3)"
                    CMD = New MySqlCommand(simpanjurnal4, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal3 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN', 0, '" & totalhpp & "', '', 2, 4)"
                    CMD = New MySqlCommand(simpanjurnal3, Conn)
                    CMD.ExecuteNonQuery()

                    'CMD = New MySqlCommand("UPDATE saldo_awal SET debet = debet - '" & totalharga & "' WHERE kodeacc = '1-1110' AND nomor_transaksi = 'Saldo Awal' ", Conn)
                    'Masuk ke Kas Deposit
                    CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + '" & totalharga & "' WHERE kodeacc = '1-1141' ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO arus_kas_saldo_history (kodeacc, namaacc, no_transaksi, jenis, nominal) VALUES ('1-1141', 'KAS DEPOSIT', '" & lblnomorreturjual.Text & "', 1, '" & totalharga & "') ", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    Dim nomor_deposit As String = NomorOtomatisDeposit()

                    cekOpen()
                    '## Masuk ke Saldo Deposit
                    Dim simpandeposit As String = "INSERT INTO member_deposit VALUES ('" &
                        nomor_deposit &
                        "','" & kode_customer &
                        "','" & Format(dtptanggal.Value, "yyyy-MM-dd") &
                        "','Masuk','" & totalharga &
                        "','" & MainMenu.PanelUser.Text &
                        "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                        "','Retur Penjualan' )"

                    CMD = New MySqlCommand(simpandeposit, Conn)
                    CMD.ExecuteNonQuery()

                    '## Update Saldo
                    CMD = New MySqlCommand("UPDATE member_m SET deposit = deposit + '" & totalharga & "' WHERE kode_member = '" & kode_customer & "' ", Conn)
                    CMD.ExecuteNonQuery()
                    'CMD = New MySqlCommand("insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1110', 'KAS KECIL', '" & totalharga & "', 0, '" & kode_customer & "', 4, 6)", Conn)
                    'CMD.ExecuteNonQuery()

                    cekClose()
                Else
                    Dim notransPiutang As String = GenerateTransactionNum()
                    Dim newDate As DateTime = DateTime.Parse(lbljatuhtempo.Text)

                    cekOpen()
                    Dim simpanjurnal As String = "INSERT INTO piutang (no_transaksi, no_faktur, kode_member, tanggal, tanggal_jt, kodeacc, potongan, total, keterangan, jenis, created_by, created_date) values ('" &
                        notransPiutang & "', '" &
                        lblnomorreturjual.Text & "', '" &
                        kode_customer & "', '" &
                        Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" &
                        Format(newDate, "yyyy-MM-dd") & "', '1-1210', '0', '" &
                        totalharga & "', '', 'saldo_awal', '" &
                        MainMenu.PanelUser.Text & "', '" &
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' )"
                    CMD = New MySqlCommand(simpanjurnal, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal1 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','4-1100','PENDAPATAN JUAL', '" & totalharga & "', 0, '" & cbofakturjual.Text & "', 2, 1)"
                    CMD = New MySqlCommand(simpanjurnal1, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal2 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1210', 'PIUTANG USAHA', 0, '" & totalharga & "', '" & kode_customer & "', 4, 2)"
                    CMD = New MySqlCommand(simpanjurnal2, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal4 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','1-1510','PERSEDIAAN BARANG', '" & totalhpp & "', 0, '', 2, 3)"
                    CMD = New MySqlCommand(simpanjurnal4, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal3 As String = "insert into jurnal values ('" & lblnomorreturjual.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "','5-1300','HARGA POKOK PENJUALAN', 0, '" & totalhpp & "', '', 2, 4)"
                    CMD = New MySqlCommand(simpanjurnal3, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()
                End If

                MsgBox("Data Berhasil Disimpan!")

                'Call Kosongkan()
                'Call NomorOtomatis()
                'DGV.Columns.Clear()
                Me.Close()

                Call InsertLogTrans(lblnomorreturjual.Text, "CREATE", MainMenu.PanelUser.Text, "PENJUALAN - RETUR JUAL Total Rp. " & totalharga)

                DaftarReturJual.TampilGrid()

            End If
        Else
            cekClose()
            MsgBox("Oops! Terjadi Kesalahan, Data Transaksi tidak ditemukan.")
        End If
        'If MessageBox.Show("cetak no_Invoice...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '    Cetakan.Show()
        '    Cetakan.CRV.ReportSource = Nothing
        '    Cetakan.CRV.ReportSource = "no_Invoice.rpt"
        '    Cetakan.CRV.RefreshReport()
        '    Cetakan.CRV.RefreshReport()
        'End If
    End Sub

    Private Function GenerateTransactionNum()
        Dim notransaksi As String

        cekOpen()
        CMD = New MySqlCommand("select max(no_transaksi) AS no_transaksi from piutang where no_transaksi LIKE 'PT" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_transaksi")) Then
            notransaksi = "PT" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            notransaksi = "PT" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()

        Return notransaksi
    End Function

    Private Sub cbofakturjual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbofakturjual.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            cekOpen()

            CMD = New MySqlCommand("select * from penjualan where faktur_Jual='" & cbofakturjual.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                lblstatusjual.Text = DR.Item("status_Jual")
                lblcarajual.Text = DR.Item("cara_Jual")
                lblsisapiutang.Text = DR.Item("sisa_piutang")
                lbljatuhtempo.Text = DR.Item("jth_tempo_Jual")
                lbltanggaljual.Text = DR.Item("tgl_Jual")
                lbljumlahretur.Text = 0
            Else
                MsgBox("Nomor faktur tidak terdaftar!")
            End If
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("SELECT p.`kode_customer`, IFNULL(c.`nama_member`, 'Non Member') AS `nama_customer` FROM penjualan p " &
                    " LEFT JOIN member_m c ON c.`kode_member` = p.`kode_customer` WHERE p.`faktur_jual` = '" & cbofakturjual.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                lblnamacustomer.Text = DR.Item("nama_customer")
            Else
                MsgBox("Nomor faktur tidak terdaftar")
            End If
            cekClose()

            DGV.Columns.Clear()
            cekOpen()

            'DA = New MySqlDataAdapter("select detailJual.kode_barang,barang_m.nama_barang,(qty_jual - qty_retur) AS qty_jual from penjualan,detailJual,barang_m where detailJual.faktur_Jual=penjualan.faktur_Jual and detailjual.kode_barang=barang_m.kode_item and detailJual.faktur_Jual= '" & cbofakturjual.Text & "'", Conn)
            DA = New MySqlDataAdapter("SELECT dj.`kode_barang` AS `Kode Item`, b.`nama_barang` AS `Nama Item`, dj.`harga_jual` AS `Harga Jual`, (dj.`qty_jual` - dj.`qty_retur`) AS `Qty Jual`, dj.`diskon` AS `Diskon`, dj.`diskon_rp` AS `Diskon Rp`, dj.`subtotal_jual` AS `Subtotal` FROM detailjual dj " &
                "LEFT JOIN barang_m b ON b.`kode_item` = dj.`kode_barang` WHERE dj.`faktur_jual` = '" & cbofakturjual.Text & "'", Conn)
            DS = New DataSet
            DA.Fill(DS)

            DGV.DataSource = DS.Tables(0)
            DGV.Columns(0).ReadOnly = True
            DGV.Columns(1).ReadOnly = True
            DGV.Columns(2).ReadOnly = True
            DGV.Columns(2).DefaultCellStyle.Format = "c0"
            DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(3).ReadOnly = True
            DGV.Columns(3).DefaultCellStyle.Format = "n0"
            DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(4).ReadOnly = True
            DGV.Columns(4).DefaultCellStyle.Format = "n0"
            DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(5).ReadOnly = True
            DGV.Columns(5).DefaultCellStyle.Format = "n0"
            DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGV.Columns(6).ReadOnly = True
            DGV.Columns(6).DefaultCellStyle.Format = "c0"
            DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'DGV.Columns(1).Width = 200
            'DGV.Columns(2).Width = 75

            DGV.Columns.Add("QTY", "Jml Retur")
            DGV.Columns.Add("Alasan", "Alasan")

            'Dim cols As New DataGridViewComboBoxColumn
            'cols.Items.Add("TUKAR BARANG")
            'cols.Items.Add("KEMBALI UANG")
            'DGV.Columns.Add(cols)
            'cols.HeaderText = "Respon"

            cekClose()

        End If
    End Sub

    Private Function NomorOtomatisDeposit()
        cekOpen()
        CMD = New MySqlCommand("select max(no_transaksi) AS no_transaksi from member_deposit where no_transaksi LIKE 'DM" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        Dim notransaksi As String

        If IsDBNull(DR.Item("no_transaksi")) Then
            notransaksi = "DM" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            notransaksi = "DM" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()

        Return notransaksi
    End Function
End Class