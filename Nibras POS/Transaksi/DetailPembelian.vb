Imports MySql.Data.MySqlClient

Public Class DetailPembelian
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
    Private Sub DetailPembelian_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        SetDoubleBuffered(DGV, True)

        Call DetailData()
    End Sub

    Sub DetailData()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM pembelian WHERE faktur_beli = '" & HistoryPembelian.notransaksi & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtnofaktur.Text = DR.Item("faktur_beli")
            dtptanggal.Value = Format(DR.Item("tgl_beli"), "dd/MM/yyyy")
            cbosupplier.Text = DR.Item("kode_supplier")
            lblkodesupplier.Text = DR.Item("nama_supplier")
            lbljumlahbarang.Text = FormatNumber(DR.Item("item_beli"), 0)
            lbltotalharga.Text = FormatNumber(DR.Item("total_beli"), 0)
            lblcarabeli.Text = DR.Item("status_beli")

            If DR.Item("sisa_hutang") <> "0" And DR.Item("status_beli") = "LUNAS" Then
                txtdibayar.Text = FormatNumber(DR.Item("total_beli"))
                lblsisahutang.Text = "0"
                txttempo.Text = ""
                lbljatuhtempo.Text = ""
            Else
                txtdibayar.Text = Double.Parse(DR.Item("total_beli")) - Double.Parse(DR.Item("sisa_hutang"))
                lblsisahutang.Text = FormatNumber(DR.Item("sisa_hutang"))
                txttempo.Text = DR.Item("tempo_hari")
                lbljatuhtempo.Text = Format(DR.Item("jth_tempo_beli"), "dd/MM/yyyy")
            End If
        Else
                MsgBox("Oops! Tidak ada data dengan nomor faktur tersebut..", MsgBoxStyle.Critical)
        End If
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT db.`kode_barang`, b.`nama_barang`, db.`harga_beli`, db.`qty_beli`, db.`qty_real`, db.`diskon`, db.`subtotal_beli` " &
                        " FROM detailbeli db INNER JOIN barang_m b ON b.`kode_item` = db.`kode_barang` WHERE faktur_beli = '" & HistoryPembelian.notransaksi & "' ", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            DGV.Rows.Add(
                DR.Item("kode_barang"),
                DR.Item("nama_barang"),
                DR.Item("harga_beli"),
                DR.Item("qty_real"),
                DR.Item("diskon"),
                DR.Item("subtotal_beli")
            )
        Loop
        cekClose()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If MessageBox.Show("Apakah Data Akan di Hapus?!" & vbCrLf & "Data yang sudah di hapus Tidak Dapat Dikembalikan.", "Perhatian",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

            If MessageBox.Show("Anda Yakin?!" & vbCrLf & "Data yang sudah di hapus Tidak Dapat Dikembalikan.", "Perhatian",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then

                Dim newFaktur As String = "BTL-" + txtnofaktur.Text

                Dim list As New ArrayList
                Dim listQty As New ArrayList

                cekOpen()
                CMD = New MySqlCommand("select * from detailbeli where faktur_beli = '" & txtnofaktur.Text & "'", Conn)
                DR = CMD.ExecuteReader
                Do While DR.Read
                    list.Add(DR.Item("kode_barang"))
                    listQty.Add(DR.Item("qty_beli"))
                Loop
                cekClose()

                For i As Integer = 0 To list.Count - 1
                    Dim kurangistok As String = "UPDATE barang_m SET stok= stok - " & listQty(i).ToString & " WHERE kode_item='" & list(i).ToString & "'"
                    'MsgBox(kurangistok)
                    cekOpen()
                    CMD = New MySqlCommand(kurangistok, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()
                Next

                '## Proses untuk kembalikan KAS ##'
                cekOpen()
                CMD = New MySqlCommand("SELECT * FROM pembelian WHERE faktur_beli = '" & txtnofaktur.Text & "' ", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                Dim kas As Double
                Dim jenisTrans As String
                Dim kodeSupplier As String
                If DR.HasRows Then

                    If DR.Item("deposit") <> 0 Then
                        kas = DR.Item("deposit")
                        jenisTrans = "deposit"
                    ElseIf DR.Item("tunai") <> 0 Then
                        kas = DR.Item("tunai")
                        jenisTrans = "tunai"
                    Else
                        kas = DR.Item("kredit")
                        jenisTrans = "kredit"
                    End If

                    kodeSupplier = DR.Item("kode_supplier")
                Else
                    kas = DR.Item("total_beli")
                    jenisTrans = "tunai"
                    kodeSupplier = ""

                End If
                cekClose()

                Dim queryKas As String = ""
                If jenisTrans = "deposit" Then
                    queryKas = "UPDATE mst_distributor SET deposit = deposit + " & kas & " WHERE kode = '" & kodeSupplier & "'"
                ElseIf jenisTrans = "tunai" Then
                    queryKas = "UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + " & kas & " WHERE kodeacc = '1-1120'"
                Else
                    'Kredit
                    queryKas = "UPDATE arus_kas_saldo SET saldo_akhir = saldo_akhir + " & kas & " WHERE kodeacc = 'X-XXXX'"
                End If
                cekOpen()
                CMD = New MySqlCommand(queryKas, Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("DELETE FROM arus_kas_saldo_history WHERE no_transaksi = '" & txtnofaktur.Text & "' ", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("UPDATE pembelian SET faktur_beli = '" & newFaktur & "' WHERE faktur_beli = '" & txtnofaktur.Text & "' ", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("UPDATE detailbeli SET faktur_beli = '" & newFaktur & "' WHERE faktur_beli = '" & txtnofaktur.Text & "' ", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("DELETE FROM jurnal WHERE nomor_transaksi = '" & txtnofaktur.Text & "' ", Conn)
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("DELETE FROM history_stok WHERE no_transaksi = '" & txtnofaktur.Text & "' ", Conn)
                CMD.ExecuteNonQuery()
                cekClose()

                MsgBox("Data Berhasil di Hapus!", MsgBoxStyle.Information, "Perhatian")

                Call InsertLogTrans(txtnofaktur.Text, "DELETE", MainMenu.PanelUser.Text, "PEMBELIAN - HAPUS TRANSAKSI")

                Me.Close()
                HistoryPembelian.Kosongkan()
            End If

        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        UbahPembelian.MdiParent = MainMenu
        UbahPembelian.Show()
        UbahPembelian.Focus()
    End Sub
End Class