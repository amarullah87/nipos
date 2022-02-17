Imports MySql.Data.MySqlClient

Public Class PesananPembelian

    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select max(faktur_beli) AS faktur_beli from pembelian_order where faktur_beli LIKE 'OB" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("faktur_beli")) Then
            txtnofaktur.Text = "OB" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("faktur_beli")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtnofaktur.Text = "OB" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub



    Private Sub BTNTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim diskon As Double = DGV.Rows(e.RowIndex).Cells(4).Value / 100
        Dim diskonRupiah As Double = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) * diskon

        If e.ColumnIndex = 0 Then

            'cegah kode barang ganda
            For barisatas As Integer = 0 To DGV.RowCount - 1
                For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                    If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                        Dim diskonEdit As Double = DGV.Rows(barisatas).Cells(4).Value / 100
                        Dim qtyEdit As Double = DGV.Rows(barisatas).Cells(3).Value + 1
                        Dim diskonRupiahEdit As Double = (DGV.Rows(barisatas).Cells(2).Value * qtyEdit) * diskonEdit

                        DGV.Rows(barisatas).Cells(3).Value = qtyEdit
                        DGV.Rows(barisatas).Cells(5).Value = (DGV.Rows(barisatas).Cells(2).Value * qtyEdit) - diskonRupiahEdit
                        DGV.Rows.RemoveAt(barisbawah)
                        SendKeys.Send("{down}")
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
                DGV.Rows(e.RowIndex).Cells(2).Value = DR.Item("hpp")
                DGV.Rows(e.RowIndex).Cells(4).Value = 35
                DGV.Focus()
                DGV.CurrentCell = DGV(2, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{up}")
            Else
                MsgBox("Kode barang tidak terdaftar")
                SendKeys.Send("{up}")
                DownloadBarang.Show()
            End If
            cekClose()
        End If

        If e.ColumnIndex = 2 Then
            Try
                DGV.Rows(e.RowIndex).Cells(2).Value = DGV.Rows(e.RowIndex).Cells(2).Value
                DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiah
                DGV.CurrentCell = DGV(2, DGV.CurrentCell.RowIndex)
                SendKeys.Send("{up}")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If e.ColumnIndex = 3 Then
            Try
                DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiah
                DGV.CurrentCell = DGV(3, DGV.CurrentCell.RowIndex)
                Call Hitungtransaksi()
            Catch ex As Exception
                MsgBox("harus data angka")
                DGV.Rows(e.RowIndex).Cells(3).Value = 0
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(4).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
                Call Hitungtransaksi()
            End Try
        End If

        If e.ColumnIndex = 4 Then
            Try
                If DGV.Rows(e.RowIndex).Cells(4).Value >= "30" And DGV.Rows(e.RowIndex).Cells(4).Value <= "35" Then
                    DGV.Rows(e.RowIndex).Cells(5).Value = (DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value) - diskonRupiah
                    DGV.CurrentCell = DGV(4, DGV.CurrentCell.RowIndex)
                    Call Hitungtransaksi()
                Else
                    MsgBox("Diskon Melebihi Ketentuan!! (30-35%)")
                    DGV.Rows(e.RowIndex).Cells(4).Value = "35"
                End If
            Catch ex As Exception
                MsgBox("harus data angka")
                DGV.Rows(e.RowIndex).Cells(3).Value = 1
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(4).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
                Call Hitungtransaksi()
            End Try
        End If
    End Sub

    Sub Hitungtransaksi()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(3).Value
            lbljumlahbarang.Text = x
        Next

        Dim y As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            y = y + DGV.Rows(baris).Cells(5).Value
            lbltotalharga.Text = FormatNumber(y, 0)
            lbltotalhargahide.Text = y
        Next

    End Sub

    Private Sub PesananPembelian_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        txtnofaktur.Focus()
        txtnofaktur.Select()
        Call NomorOtomatis()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub txtdibayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdibayar.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txtdibayar.Text) >= Val(lbltotalhargahide.Text) Then
                lblcarabeli.Text = "TUNAI"
                lblsisahutang.Text = 0
                txttempo.Text = 0
                txttempo.Enabled = False
                'lbljatuhtempo.Text = Format(dtptanggal.value, "yyyy-MM-dd")
                lblstatusbeli.Text = "LUNAS"
                btnsimpan.Focus()
            Else
                lblcarabeli.Text = "KREDIT"
                lblsisahutang.Text = FormatNumber(Val(lbltotalhargahide.Text) - Val(txtdibayar.Text), 0)
                lblsisahutanghide.Text = Val(lbltotalhargahide.Text) - Val(txtdibayar.Text)
                lblstatusbeli.Text = "BELUM LUNAS"
                txttempo.Enabled = True
                txttempo.Focus()
            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call kOSONGKAN()
        DGV.Rows.Clear()
        DGV.Enabled = False
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtnofaktur.Text = "" Or cbosupplier.Text = "" Or lbljumlahbarang.Text = "" Or lbltotalhargahide.Text = "" Then
            MsgBox("Transaksi belum lengkap")
            Exit Sub
        End If

        Dim simpan1 As String
        cekOpen()
        simpan1 = "insert into pembelian_order values ('" & txtnofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "','" & lbljumlahbarang.Text & "','" & lbltotalhargahide.Text & "','" & txtdibayar.Text & "','" & lblcarabeli.Text & "','" & lblsisahutanghide.Text & "','" & txttempo.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "','" & lblstatusbeli.Text & "','" & lblkodesupplier.Text & "','" & MainMenu.PanelUser.Text & "', 1)"
        CMD = New MySqlCommand(simpan1, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        cekOpen()
        For baris As Integer = 0 To DGV.RowCount - 2

            cekOpen()
            Dim simpan2 As String = "insert into detailbeli_order values ('" & txtnofaktur.Text & "','" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(2).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "', '" & DGV.Rows(baris).Cells(5).Value & "', '-', 0)"
            CMD = New MySqlCommand(simpan2, Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        Next
        MsgBox("Data Berhasil Disimpan!")

        Call kOSONGKAN()
        txtnofaktur.Clear()
        DGV.Rows.Clear()
    End Sub

    Private Sub txttempo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttempo.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim tambahhari As Integer = txttempo.Text
            lbljatuhtempo.Text = DateAdd(DateInterval.Day, tambahhari, Today)
            btnSimpan.Focus()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub DGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGV.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then
            DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
            Call Hitungtransaksi()
        End If

        If e.KeyChar = Chr(13) Then
            txtdibayar.Focus()
        End If
    End Sub

    Sub kOSONGKAN()
        txtJenisNhs.Text = ""
        cbosupplier.Text = ""
        lbljumlahbarang.Text = ""
        lbltotalharga.Text = ""
        lbltotalhargahide.Text = ""
        lblcarabeli.Text = ""
        lblsisahutang.Text = ""
        lbljatuhtempo.Text = ""
        lblstatusbeli.Text = ""
        lblkodesupplier.Text = ""
        txtdibayar.Text = ""
        txttempo.Text = ""
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        'On ENTER
        If e.KeyChar = ChrW(Keys.Return) Then

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & txtBarcode.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()


            If (DR.HasRows) Then

                Dim baris As Integer = DGV.RowCount - 1
                DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("hpp"), 1, 35)
                txtBarcode.Clear()
                cekClose()

                Dim diskon As Double = DGV.Rows(baris).Cells(4).Value / 100
                Dim diskonRupiah As Double = (DGV.Rows(baris).Cells(2).Value * DGV.Rows(baris).Cells(3).Value) * diskon
                DGV.Rows(baris).Cells(5).Value = (DGV.Rows(baris).Cells(2).Value * DGV.Rows(baris).Cells(3).Value) - diskonRupiah

                Call Hitungtransaksi()
                For barisatas As Integer = 0 To DGV.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                        If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                            Dim diskonEdit As Double = DGV.Rows(barisatas).Cells(4).Value / 100
                            Dim qtyEdit As Double = DGV.Rows(barisatas).Cells(3).Value + 1
                            Dim diskonRupiahEdit As Double = (DGV.Rows(barisatas).Cells(2).Value * qtyEdit) * diskonEdit

                            DGV.Rows(barisatas).Cells(3).Value = DGV.Rows(barisatas).Cells(3).Value + 1
                            DGV.Rows(barisatas).Cells(5).Value = (DGV.Rows(barisatas).Cells(2).Value * qtyEdit) - diskonRupiahEdit
                            DGV.Rows.RemoveAt(barisbawah)
                            Call Hitungtransaksi()
                            Exit Sub
                        End If
                    Next
                Next
            Else
                cekClose()
                PencarianBarangPesanBeli.ShowDialog()
                PencarianBarangPesanBeli.TXTCariBarang.Text = txtBarcode.Text
                PencarianBarangPesanBeli.TXTCariBarang.Focus()
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

    Private Sub cbosupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles cbosupplier.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If cbosupplier.Text = "" Then
                    DGV.Enabled = False
                Else
                    DGV.Enabled = True
                End If

                cekOpen()
                CMD = New MySqlCommand("select * from supplier_m where kode_supplier ='" & cbosupplier.Text & "'", Conn)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    cbosupplier.Text = DR.Item("nama_supplier")
                    lblkodesupplier.Text = DR.Item("kode_supplier")
                    txtJenisNhs.Text = DR.Item("jenis_nhs")

                    txtBarcode.Focus()
                    txtBarcode.Select()

                    cekClose()
                Else
                    cekClose()

                    PencarianSupplierPesanBeli.Show()
                    PencarianSupplierPesanBeli.TXTCariBarang.Text = cbosupplier.Text
                    PencarianSupplierPesanBeli.TXTCariBarang.Focus()
                End If

                'Case Keys.F12
                '    DownloadOutlet.Show()
        End Select
    End Sub
End Class