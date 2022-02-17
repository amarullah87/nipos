Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class DaftarPesanan

    Dim Raw As String
    Dim totalData As Integer
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilGrid()
        DGV.Rows.Clear()

        cekOpen()
        DA = New MySqlDataAdapter("SELECT faktur_beli, tgl_beli, item_beli, total_beli, kode_user FROM pembelian_order WHERE kode_supplier = '" & TransaksiPembelian.lblkodesupplier.Text & "' AND status = 1", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "Nomor Transaksi"
        DGV.Columns(1).HeaderText = "Tanggal Dibuat"
        DGV.Columns(1).DefaultCellStyle.Format = "M"
        DGV.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(2).HeaderText = "QTY"
        DGV.Columns(2).DefaultCellStyle.Format = "n0"
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(3).HeaderText = "Total Harga"
        DGV.Columns(3).DefaultCellStyle.Format = "c0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGV.Columns(4).HeaderText = "User"
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace

        lblKodeSupp.Text = TransaksiPembelian.lblkodesupplier.Text
        lblNamaSupp.Text = TransaksiPembelian.cbosupplier.Text
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call TampilGrid()
    End Sub

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        On Error Resume Next
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            Dim nopesanan As String = DGV.Rows(e.RowIndex).Cells(0).Value
            TransaksiPembelian.txtNoPesanan.Text = nopesanan

            cekOpen()
            CMD = New MySqlCommand("SELECT kode_barang, nama_barang, harga_beli, qty_beli, diskon, subtotal_beli FROM detailbeli_order dt " &
                                      "INNER JOIN barang_m b ON b.kode_item = dt.kode_barang WHERE faktur_beli = '" & nopesanan & "' ", Conn)
            DR = CMD.ExecuteReader

            Do While DR.Read
                TransaksiPembelian.DGV.Rows.Add(
                    DR.Item("kode_barang"), DR.Item("nama_barang"), DR.Item("harga_beli"), DR.Item("qty_beli"), DR.Item("diskon"), DR.Item("subtotal_beli")
                )
            Loop
            cekClose()

            TransaksiPembelian.Hitungtransaksi()
            Me.Close()
        End If
    End Sub

    Private Sub DaftarPesanan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()
        SetDoubleBuffered(DGV, True)
    End Sub
End Class