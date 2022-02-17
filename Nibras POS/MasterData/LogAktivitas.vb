Imports MySql.Data.MySqlClient

Public Class LogAktivitas
    Private Sub LogAktivitas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Kosongkan()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call TampilGrid()
    End Sub

    Sub LoadItemObyek()
        Dim ObyekList = New List(Of String)()
        ObyekList.Add("SEMUA")
        ObyekList.Add("PEMBELIAN")
        ObyekList.Add("PENJUALAN")
        ObyekList.Add("SALDO AWAL PERSEDIAAN")
        ObyekList.Add("STOK OPNAME")
        ObyekList.Add("ITEM MASUK")
        ObyekList.Add("ITEM KELUAR")
        ObyekList.Add("DEPOSIT PELANGGAN")
        ObyekList.Add("DEPOSIT SUPPLIER")
        ObyekList.Add("KAS MASUK")
        ObyekList.Add("KAS KELUAR")
        ObyekList.Add("KAS TRANSFER")
        ObyekList.Add("SALDO AWAL PERKIRAAN")
        ObyekList.Add("SALDO AWAL HUTANG")
        ObyekList.Add("SALDO AWAL PIUTANG")


        lookUpEdit.Properties.DataSource = ObyekList
    End Sub

    Sub Kosongkan()
        dtptanggal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpTanggalAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)

        Call LoadItemObyek()
        lookUpEdit.SelectedText = "SEMUA"
        txtNoTransaksi.Text = ""

        Call TampilGrid()
    End Sub

    Sub TampilGrid()
        Dim pencarian As String = ""

        If txtNoTransaksi.Text <> "" Then
            pencarian = " AND no_transaksi LIKE '%" & txtNoTransaksi.Text & "%' "
        End If

        If lookUpEdit.Text.ToString <> "" Then

            If lookUpEdit.Text.ToString = "SEMUA" Then
                pencarian = String.Concat(pencarian, " AND notes LIKE '%%' ")
            Else
                pencarian = String.Concat(pencarian, " AND notes LIKE '" & lookUpEdit.EditValue.ToString & "%' ")
            End If
        End If

        cekOpen()
        DA = New MySqlDataAdapter("SELECT * FROM config_logs" &
                                    " WHERE created BETWEEN '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTanggalAkhir.Value, "yyyy-MM-dd") & "' " & pencarian &
                                    " ORDER BY created DESC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "Tanggal"
        DGV.Columns(0).DefaultCellStyle.Format = "D"
        DGV.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Segoe UI", 11)
        DGV.Columns(1).HeaderText = "Nomor Transaksi"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Segoe UI", 11)
        DGV.Columns(2).HeaderText = "Operasi"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Segoe UI", 11)
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(3).HeaderText = "Creator"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Segoe UI", 11)
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(4).HeaderText = "Keterangan"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Segoe UI", 11)

        DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call Kosongkan()
    End Sub
End Class