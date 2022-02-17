Imports MySql.Data.MySqlClient

Public Class PesananPenjualan

    Sub NomorOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select max(faktur_jual) AS faktur_jual from penjualan_order where faktur_jual LIKE 'OJ" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("faktur_jual")) Then
            lblnomrofaktur.Text = "OJ" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("faktur_jual")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            lblnomrofaktur.Text = "OJ" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub TampilCustomer()
        txtMember.Text = "00000"
        lblkodecustomer.Text = "Non Member"
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim diskon As Double = DGV.Rows(e.RowIndex).Cells(6).Value / 100
        Dim diskonRupiah As Double = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) * diskon

        If e.ColumnIndex = 0 Then

            'cegah kode barang ganda
            For barisatas As Integer = 0 To DGV.RowCount - 1
                For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                    If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                        Dim diskonEdit As Double = DGV.Rows(barisatas).Cells(6).Value / 100
                        Dim qtyEdit As Double = DGV.Rows(barisatas).Cells(5).Value + 1
                        Dim diskonRupiahEdit As Double = (DGV.Rows(barisatas).Cells(4).Value * qtyEdit) * diskonEdit

                        DGV.Rows(barisatas).Cells(5).Value = DGV.Rows(barisatas).Cells(5).Value + 1
                        DGV.Rows(barisatas).Cells(7).Value = (DGV.Rows(barisatas).Cells(4).Value * qtyEdit) - diskonRupiahEdit
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

            ''UBAH DISINI UNTUK NANTI HPJ AVERAGE!!
            If DR.HasRows Then
                DGV.Rows(e.RowIndex).Cells(1).Value = DR.Item("nama_barang")
                DGV.Rows(e.RowIndex).Cells(2).Value = DR.Item("satuan")
                DGV.Rows(e.RowIndex).Cells(3).Value = DR.Item("jenis")
                DGV.Rows(e.RowIndex).Cells(4).Value = DR.Item("hpj")
                DGV.Rows(e.RowIndex).Cells(5).Value = 1
                DGV.Rows(e.RowIndex).Cells(6).Value = 0

                DGV.Rows(e.RowIndex).Cells(7).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                DGV.CurrentCell = DGV(0, DGV.CurrentCell.RowIndex)
            Else
                MsgBox("Kode barang tidak terdaftar")
                SendKeys.Send("{up}")
            End If

            cekClose()
        End If


        If e.ColumnIndex = 5 Then
            Try
                DGV.Rows(e.RowIndex).Cells(7).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                DGV.CurrentCell = DGV(5, DGV.CurrentCell.RowIndex)
            Catch ex As Exception
                MsgBox("harus data angka")
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(5).Value = 0
                DGV.Rows(e.RowIndex).Cells(7).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
            End Try
        End If

        If e.ColumnIndex = 6 Then
            Try
                DGV.Rows(e.RowIndex).Cells(7).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
                DGV.CurrentCell = DGV(6, DGV.CurrentCell.RowIndex)
            Catch ex As Exception
                MsgBox("harus data angka")
                SendKeys.Send("{up}")
                DGV.Rows(e.RowIndex).Cells(5).Value = 0
                DGV.Rows(e.RowIndex).Cells(7).Value = (DGV.Rows(e.RowIndex).Cells(4).Value * DGV.Rows(e.RowIndex).Cells(5).Value) - diskonRupiah
            End Try
        End If
        Call Hitungtransaksi()
    End Sub

    Sub Hitungtransaksi()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(5).Value
            lbljumlahbarang.Text = x
        Next

        Dim y As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            y = y + DGV.Rows(baris).Cells(7).Value
            lbltotalharga.Text = y
            lbltotalhargaBig.Text = FormatCurrency(y)
        Next

    End Sub

    Private Sub PesananPenjualan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call NomorOtomatis()
        Call TampilCustomer()
        SetDoubleBuffered(DGV, True)
        txtBarcode.Focus()
    End Sub

    Private Sub txtdibayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdibayar.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txtdibayar.Text) = Val(lbltotalharga.Text) Then
                lblcarajual.Text = "CASH"
                lblsisahutang.Text = 0
                txttempo.Text = 0
                lblkembali.Text = 0
                txttempo.Enabled = False
                lbljatuhtempo.Text = Format(dtptanggal.Value, "yyyy-MM-dd")
                lblstatusjual.Text = "LUNAS"
                btnSimpan.Focus()
            ElseIf Val(txtdibayar.Text) > Val(lbltotalharga.Text) Then
                lblcarajual.Text = "CASH"
                lblsisahutang.Text = 0
                txttempo.Text = 0
                lblkembali.Text = Val(txtdibayar.Text) - Val(lbltotalharga.Text)
                txttempo.Enabled = False
                lbljatuhtempo.Text = Format(dtptanggal.Value, "yyyy-MM-dd")
                lblstatusjual.Text = "LUNAS"
                btnSimpan.Focus()
            Else
                lblcarajual.Text = "CREDIT"
                lblsisahutang.Text = Val(lbltotalharga.Text) - Val(txtdibayar.Text)
                lblstatusjual.Text = "BELUM LUNAS"
                lblkembali.Text = 0
                txttempo.Enabled = True
                txttempo.Focus()
            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txttempo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttempo.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim tambahhari As Integer = txttempo.Text
            lbljatuhtempo.Text = DateAdd(DateInterval.Day, tambahhari, Today)
            btnSimpan.Focus()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Sub Kosongkan()
        txtJenisNhs.Text = ""
        lbljumlahbarang.Text = ""
        lbltotalharga.Text = ""
        lblcarajual.Text = ""
        lblsisahutang.Text = ""
        lbljatuhtempo.Text = ""
        lblkembali.Text = ""
        txtdibayar.Text = ""
        txttempo.Text = ""
        lbltotalhargaBig.Text = FormatCurrency(0)

        Call TampilCustomer()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
        DGV.Rows.Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtMember.Text = "" Then
            MsgBox("Kode Member Belum diisi")
        ElseIf lbltotalharga.Text = "0" Or lbltotalharga.Text = "" Or lbljumlahbarang.Text = "" Then
            MsgBox("Transaksi masih kosong, silahkan tambah barang yang akan ditransaksikan!")
        Else
            cekOpen()
            Dim simpan1 As String = "insert into penjualan_order values ('" & lblnomrofaktur.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "','" & lbljumlahbarang.Text & "','" & lbltotalharga.Text & "','" & txtMember.Text & "','" & MainMenu.PanelUser.Text & "', 1)"
            CMD = New MySqlCommand(simpan1, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            For baris As Integer = 0 To DGV.RowCount - 2
                cekOpen()
                Dim simpan2 As String = "insert into detailjual_order values ('" & lblnomrofaktur.Text & "','" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(4).Value & "','" & DGV.Rows(baris).Cells(5).Value & "','" & DGV.Rows(baris).Cells(7).Value & "','-', '" & DGV.Rows(baris).Cells(6).Value & "', 0)"
                CMD = New MySqlCommand(simpan2, Conn)
                CMD.ExecuteNonQuery()
                cekClose()

            Next

            MsgBox("Data Berhasil Disimpan!")
            Call Kosongkan()
            Call NomorOtomatis()
            DGV.Rows.Clear()
            cekClose()
        End If
    End Sub

    Private Sub btnSimpan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnSimpan.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & txtBarcode.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If (DR.HasRows) Then

                If DR.Item("stok") < 1 Then

                    MsgBox("Barang Tidak Dapat Ditransaksikan! Stok Barang: 0")
                    txtBarcode.Clear()
                    cekClose()

                Else

                    Dim baris As Integer = DGV.RowCount - 1
                    DGV.Rows.Add(DR.Item("kode_item"), DR.Item("nama_barang"), DR.Item("satuan"), DR.Item("jenis"), DR.Item("hpj"), 1, 0)
                    txtBarcode.Clear()
                    cekClose()

                    Dim diskon As Double = DGV.Rows(baris).Cells(6).Value / 100
                    Dim diskonRupiah As Double = (DGV.Rows(baris).Cells(4).Value * DGV.Rows(baris).Cells(5).Value) * diskon
                    DGV.Rows(baris).Cells(7).Value = (DGV.Rows(baris).Cells(4).Value * DGV.Rows(baris).Cells(5).Value) - diskonRupiah

                    Call Hitungtransaksi()
                    For barisatas As Integer = 0 To DGV.RowCount - 1
                        For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                            If DGV.Rows(barisbawah).Cells(0).Value = DGV.Rows(barisatas).Cells(0).Value Then

                                Dim diskonEdit As Double = DGV.Rows(barisatas).Cells(6).Value / 100
                                Dim qtyEdit As Double = DGV.Rows(barisatas).Cells(5).Value + 1
                                Dim diskonRupiahEdit As Double = (DGV.Rows(barisatas).Cells(4).Value * qtyEdit) * diskonEdit

                                DGV.Rows(barisatas).Cells(5).Value = DGV.Rows(barisatas).Cells(5).Value + 1
                                DGV.Rows(barisatas).Cells(7).Value = (DGV.Rows(barisatas).Cells(4).Value * qtyEdit) - diskonRupiahEdit
                                DGV.Rows.RemoveAt(barisbawah)
                                Call Hitungtransaksi()
                                Exit Sub
                            End If
                        Next
                    Next

                End If

            Else
                txtBarcode.Clear()
                MsgBox("Data Barang Tidak Ditemukan!")
                cekClose()
            End If
            'cekClose()
        End If
    End Sub

    Private Sub DGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGV.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then
            DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
            Call Hitungtransaksi()
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                DownloadBarang.Show()
                e.SuppressKeyPress = True
            Case Keys.F5
                btnSimpan.PerformClick()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub txtMember_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMember.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                'DownloadOutletJual.Show()
        End Select
    End Sub

    Private Sub txtMember_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMember.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then

            If txtMember.Text = "00000" Then

                lblkodecustomer.Text = "Non Member"

            Else

                If MainMenu.PanelJenis.Text <> "D" Then
                    cekOpen()
                    CMD = New MySqlCommand("select * from member_m where kode_member='" & txtMember.Text & "'", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()

                    If DR.HasRows Then
                        lblkodecustomer.Text = DR.Item("nama_member")
                        txtJenisNhs.Text = ""
                    Else
                        MsgBox("Kode Member tidak terdaftar")
                    End If
                    cekClose()
                Else
                    cekOpen()
                    CMD = New MySqlCommand("select * from master_nhs where id='" & txtMember.Text & "'", Conn)
                    DR = CMD.ExecuteReader
                    DR.Read()

                    If DR.HasRows Then
                        lblkodecustomer.Text = DR.Item("nama")
                        txtJenisNhs.Text = DR.Item("jenis_nhs")
                    Else
                        MsgBox("Kode Member tidak terdaftar")
                    End If
                    cekClose()
                End If
            End If

            txtBarcode.Focus()
            txtBarcode.Select()
        End If
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress

    End Sub
End Class