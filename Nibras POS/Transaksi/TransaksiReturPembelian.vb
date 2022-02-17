Imports MySql.Data.MySqlClient

Public Class TransaksiReturPembelian

    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select MAX(no_retur_beli) AS no_retur_beli from returpembelian where no_retur_beli LIKE 'RB" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_retur_beli")) Then
            lblnomorretur.Text = "RB" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_retur_beli")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            lblnomorretur.Text = "RB" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If

        cekClose()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 3 Then
            Try
                If DGV.Rows(e.RowIndex).Cells(3).Value > DGV.Rows(e.RowIndex).Cells(2).Value Then
                    MsgBox("Jumlah retur melebihi jumlah beli")
                    DGV.Rows(e.RowIndex).Cells(3).Value = 0
                    Call Hitungtransaksi()
                    SendKeys.Send("{up}")
                    Exit Sub
                Else
                    Try
                        DGV.CurrentCell = DGV(3, DGV.CurrentCell.RowIndex)
                        SendKeys.Send("{up}")
                        Call Hitungtransaksi()
                    Catch ex As Exception
                        MsgBox("harus data angka")
                    End Try
                End If
            Catch ex As Exception
                MsgBox("harus data angka")
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(3).Value = 0
            End Try
        End If

        If e.ColumnIndex = 4 Then
            DGV.CurrentCell = DGV(4, DGV.CurrentCell.RowIndex)
        End If
        Call Hitungtransaksi()
    End Sub

    Sub Hitungtransaksi()

        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(3).Value
            lbljumlahretur.Text = x
        Next

    End Sub

    Private Sub TransaksiReturPembelian_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call NomorOtomatis()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub DGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGV.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then
            DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
            Call Hitungtransaksi()
        End If
    End Sub

    Sub Kosongkan()
        cbofakturbeli.Text = ""
        lbljumlahretur.Text = ""
        lblcarabeli.Text = ""
        lblsisahutang.Text = ""
        lbljatuhtempo.Text = ""
        lblstatusbeli.Text = ""
        lblnamasupplier.Text = ""
        lbltanggalbeli.Text = ""
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
        DGV.Columns.Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If cbofakturbeli.Text = "" Or lbljumlahretur.Text = "" Then
            MsgBox("Transaksi belum lengkap")
            Exit Sub
        Else
            cekOpen()

            Dim simpan1 As String = "insert into returpembelian values ('" & lblnomorretur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "','" & cbofakturbeli.Text & "','" & lbljumlahretur.Text & "','" & MainMenu.PanelUser.Text & "')"
            CMD = New MySqlCommand(simpan1, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            Dim totalharga As Double = 0
            For baris As Integer = 0 To DGV.RowCount - 2

                If DGV.Rows(baris).Cells(3).Value <> "" And DGV.Rows(baris).Cells(3).Value > 0 Then

                    cekOpen()
                    CMD = New MySqlCommand("select * from barang_m where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()

                    If DR.HasRows Then
                        Dim tambahstok As String = "update barang_m set stok='" & DR.Item("stok") - DGV.Rows(baris).Cells(3).Value & "' where kode_item='" & DGV.Rows(baris).Cells(0).Value & "'"
                        Dim stokAwal As Integer = DR.Item("stok")
                        Dim stokAkhir As Integer = DR.Item("stok") - DGV.Rows(baris).Cells(3).Value

                        totalharga += DGV.Rows(baris).Cells(3).Value * DR.Item("hpp")
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
                                lblnomorretur.Text & "', '" &
                                Format(dtptanggal.Value, "yyyy-MM-dd") & "', 'Retur Beli', '" &
                                stokAwal & "', '" &
                                DGV.Rows(baris).Cells(3).Value & "', '" &
                                stokAkhir & "', '" &
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" &
                                MainMenu.PanelUser.Text & "' )"
                        CMD = New MySqlCommand(updatehistory, Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()

                        'Update QTY Retur di Detail Pembelian
                        cekOpen()
                        Dim updateStatus As String = "UPDATE detailbeli SET qty_retur = '" & DGV.Rows(baris).Cells(3).Value & "' WHERE faktur_beli = '" & cbofakturbeli.Text & "' AND kode_barang = '" & DGV.Rows(baris).Cells(0).Value & "' "
                        CMD = New MySqlCommand(updateStatus, Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()

                        cekOpen()
                        Dim simpan2 As String = "insert into detailreturbeli values ('" & lblnomorretur.Text & "','" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "')"
                        CMD = New MySqlCommand(simpan2, Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()
                    End If
                End If

            Next

            If lblcarabeli.Text = "KREDIT" Then
                cekOpen()
                Dim simpanjurnal2 As String = "insert into jurnal values ('" & lblnomorretur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','2-1101','HUTANG USAHA', '" & totalharga & "', 0, '', 1, 1)"
                CMD = New MySqlCommand(simpanjurnal2, Conn)
                CMD.ExecuteNonQuery()

                Dim simpanjurnal1 As String = "insert into jurnal values ('" & lblnomorretur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1510', 'PERSEDIAAN BARANG', 0, '" & totalharga & "', '', 1, 2)"
                CMD = New MySqlCommand(simpanjurnal1, Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            Else

                cekOpen()
                CMD = New MySqlCommand("SELECT * FROM pembelian WHERE faktur_beli = '" & cbofakturbeli.Text & "' ", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                Dim deposit As Double = 0
                Dim kodeSupplier As String = ""
                If DR.HasRows Then
                    deposit = DR.Item("deposit")
                    kodeSupplier = DR.Item("kode_supplier")
                End If
                cekClose()

                cekOpen()
                If deposit > 0 Then
                    Dim simpanjurnal2 As String = "insert into jurnal values ('" & lblnomorretur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','2-3101','DEPOSIT PELANGGAN', '" & deposit & "', 0, '', 1, 1)"
                    CMD = New MySqlCommand(simpanjurnal2, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal1 As String = "insert into jurnal values ('" & lblnomorretur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1510', 'PERSEDIAAN BARANG', 0, '" & deposit & "', '', 1, 2)"
                    CMD = New MySqlCommand(simpanjurnal1, Conn)
                    CMD.ExecuteNonQuery()
                    '#Update Deposit
                    CMD = New MySqlCommand("UPDATE mst_distributor SET deposit = deposit - '" & deposit & "' WHERE kode = '" & kodeSupplier & "' ", Conn)
                    CMD.ExecuteNonQuery()
                Else

                    Dim simpanjurnal2 As String = "insert into jurnal values ('" & lblnomorretur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1120','KAS BESAR', '" & totalharga & "', 0, '', 1, 1)"
                    CMD = New MySqlCommand(simpanjurnal2, Conn)
                    CMD.ExecuteNonQuery()

                    Dim simpanjurnal1 As String = "insert into jurnal values ('" & lblnomorretur.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','1-1510', 'PERSEDIAAN BARANG', 0, '" & totalharga & "', '', 1, 2)"
                    CMD = New MySqlCommand(simpanjurnal1, Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE saldo_awal SET debet = debet + '" & totalharga & "' WHERE kodeacc = '1-1120' AND nomor_transaksi = '" & cbofakturbeli.Text & "' ", Conn)
                    CMD.ExecuteNonQuery()
                End If
                cekClose()
            End If

            MsgBox("Data Berhasil Disimpan!")

            Call InsertLogTrans(lblnomorretur.Text, "CREATE", MainMenu.PanelUser.Text, "RETUR BELI - Total Rp. " & totalharga)

            Call Kosongkan()
            Call NomorOtomatis()
            DGV.Columns.Clear()

        End If
        'If MessageBox.Show("cetak no_Invoice...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '    Cetakan.Show()
        '    Cetakan.CRV.ReportSource = Nothing
        '    Cetakan.CRV.ReportSource = "no_Invoice.rpt"
        '    Cetakan.CRV.RefreshReport()
        '    Cetakan.CRV.RefreshReport()
        'End If
    End Sub

    Private Sub cbofakturbeli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbofakturbeli.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            cekOpen()

            CMD = New MySqlCommand("select * from pembelian where faktur_beli='" & cbofakturbeli.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                lblstatusbeli.Text = DR.Item("status_beli")
                lblcarabeli.Text = DR.Item("cara_beli")
                lblsisahutang.Text = DR.Item("sisa_hutang")
                lbljatuhtempo.Text = DR.Item("jth_tempo_beli")
                lbltanggalbeli.Text = DR.Item("tgl_beli")
                lbljumlahretur.Text = 0
            Else
                MsgBox("Nomor faktur tidak terdaftar", MsgBoxStyle.Critical)
            End If
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("SELECT nama_supplier FROM pembelian WHERE faktur_beli='" & cbofakturbeli.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                lblnamasupplier.Text = DR.Item("nama_supplier")
            Else
                MsgBox("Nomor faktur tidak terdaftar")
            End If
            cekClose()

            DGV.Columns.Clear()
            cekOpen()
            DA = New MySqlDataAdapter("select detailBeli.kode_barang,barang_m.nama_Barang, (qty_beli - qty_retur) AS qty_beli from pembelian,detailbeli,barang_m where detailbeli.faktur_beli=pembelian.faktur_beli and detailbeli.kode_barang=barang_m.kode_item and detailbeli.faktur_beli= '" & cbofakturbeli.Text & "'", Conn)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
            DGV.Columns(0).ReadOnly = True
            DGV.Columns(1).ReadOnly = True
            DGV.Columns(2).ReadOnly = True

            DGV.Columns(1).Width = 200
            DGV.Columns(2).Width = 75

            DGV.Columns.Add("QTY", "Jml Retur") 'kolom 3
            DGV.Columns.Add("Alasan", "Alasan") 'kolom 4

            'Dim cols As New DataGridViewComboBoxColumn
            'cols.Items.Add("TUKAR BARANG")
            'cols.Items.Add("KEMBALI UANG")
            'DGV.Columns.Add(cols)
            'cols.HeaderText = "Respon"

            DGV.MultiSelect = False

            cekClose()
        End If
    End Sub
End Class