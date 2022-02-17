Imports MySql.Data.MySqlClient

Public Class DaftarSO

    Sub TampilGrid()
        cekClose()
        cekOpen()
        DA = New MySqlDataAdapter("SELECT sob.kode_adj AS kode,DATE_FORMAT(tanggal, '%d %M %Y') AS tanggal,SUM(sob.qty_so-sob.adj) AS qty_awal,SUM(sob.qty_so) AS qty,SUM(sob.adj) AS adj ,SUM(sob.qty_so*sob.hpp) AS nilai 
    FROM stok_opname_berkala  AS sob GROUP BY sob.kode_adj DESC LIMIT 100", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "KODE TRANSAKSI"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(1).HeaderText = "TANGGAL"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(2).HeaderText = "QTY AWAL"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(2).DefaultCellStyle.Format = "n0"
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(3).HeaderText = "QTY AKHIR"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(3).DefaultCellStyle.Format = "n0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(4).HeaderText = "ADJUSTMENT"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(4).DefaultCellStyle.Format = "n0"
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(5).HeaderText = "NILAI SO (Rp.)"
        DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(5).DefaultCellStyle.Format = "c0"
        DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 252, 252)

        cekClose()
    End Sub

    Sub CariDataGrid()
        cekClose()
        cekOpen()
        DA = New MySqlDataAdapter("SELECT sob.kode_adj AS kode,DATE_FORMAT(tanggal, '%d %M %Y') AS tanggal,SUM(sob.qty_so-sob.adj) AS qty_awal,SUM(sob.qty_so) AS qty,SUM(sob.adj) AS adj ,SUM(sob.qty_so*sob.hpp) AS nilai 
    FROM stok_opname_berkala  AS sob WHERE tanggal BETWEEN '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTanggalAkhir.Value, "yyyy-MM-dd") & "'
GROUP BY sob.kode_adj ORDER BY kode DESC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "KODE TRANSAKSI"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(1).HeaderText = "TANGGAL"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(2).HeaderText = "QTY AWAL"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(2).DefaultCellStyle.Format = "n0"
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(3).HeaderText = "QTY AKHIR"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(3).DefaultCellStyle.Format = "n0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(4).HeaderText = "ADJUSTMENT"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(4).DefaultCellStyle.Format = "n0"
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(5).HeaderText = "NILAI SO (Rp.)"
        DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(5).DefaultCellStyle.Format = "c0"
        DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 252, 252)

        cekClose()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub DaftarSO_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtptanggal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpTanggalAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)
        SetDoubleBuffered(DGV, True)
        Call TampilGrid()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call CariDataGrid()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call TampilGrid()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If MainMenu.PanelID.Text <> "" Then
            TransaksiStokOpnameNew.MdiParent = MainMenu
            TransaksiStokOpnameNew.Show()
            TransaksiStokOpnameNew.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub DetailItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailItemToolStripMenuItem.Click
        Dim kode_adj As String = DGV.CurrentRow.Cells(0).Value
        DaftarSODetail.txtKodeAdj.Text = kode_adj
        DaftarSODetail.ShowDialog()
    End Sub
End Class