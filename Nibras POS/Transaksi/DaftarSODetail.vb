Imports MySql.Data.MySqlClient

Public Class DaftarSODetail
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilGrid()
        cekClose()
        cekOpen()
        DA = New MySqlDataAdapter("SELECT id_barang, nama_produk, qty, qty_so, adj FROM stok_opname_berkala WHERE kode_adj = '" & txtKodeAdj.Text & "' AND qty_so > 0", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "KODE ITEM"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(1).HeaderText = "NAMA ITEM"
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

        'DGV.Columns(5).HeaderText = "NILAI SO (Rp.)"
        'DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        'DGV.Columns(5).DefaultCellStyle.Format = "c0"
        'DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 252, 252)

        cekClose()
    End Sub

    Private Sub DaftarSODetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetDoubleBuffered(DGV, True)
        Call TampilGrid()

        If MainMenu.PanelKode.Text = "MANAGER" Or MainMenu.PanelKode.Text = "ADMIN" Then
            btnBatal.Enabled = False
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        'Dim cek As Boolean = False
        'If MainMenu.PanelUser.Text.ToLower = "manager" Then
        '    cek = True
        'End If

        'If MainMenu.PanelKode.Text.ToLower = "admin" Then
        '    cek = True
        'End If

        If MainMenu.PanelUser.Text.ToLower = "manager" Or MainMenu.PanelUser.Text.ToLower = "admin" Then
            Dim result As DialogResult = MessageBox.Show("Anda yakin akan Membatalkan Transaksi Stok Opname ini?", "Perhatian!", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If result = DialogResult.Yes Then
                MsgBox("Oops! Under Construction")
            End If
        Else
            MessageBox.Show("Mohon Maaf, Pembatalan hanya bisa dilakukan oleh Admin / Manager.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        'MsgBox(MainMenu.PanelUser.Text.ToLower)
    End Sub
End Class