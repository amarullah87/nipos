Imports System.IO
Imports MySql.Data.MySqlClient

Public Class DaftarItem

    Sub Kosongkan()
        TXTCariBarang.Text = ""
        TXTCariBarang.Focus()
        Call TampilGrid()
    End Sub

    Sub TampilGrid()
        SetDoubleBuffered(DGV, True)

        cekOpen()

        DA = New MySqlDataAdapter("SELECT b.`kode_item`, b.`nama_barang`, b.`satuan`, k.kategori, m.nama_model, " &
                                  " b.`hpp`, b.`hpj`, b.`stok_min`, TIMESTAMPDIFF( YEAR, b.updatedate, NOW() ) as tahun, TIMESTAMPDIFF( MONTH, b.updatedate, NOW() ) % 12 as bulan, b.stok " &
                                  " FROM barang_m b  " &
                                  " LEFT JOIN mst_kategori k ON k.`kode_kategori` = b.`jenis` " &
                                  " LEFT JOIN mst_model m ON m.kode_model = b.`merek` ORDER BY stok DESC LIMIT 1000", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

        DGV.Columns(0).HeaderText = "Kode Item"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(1).HeaderText = "Nama Barang"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(2).HeaderText = "Satuan"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(3).HeaderText = "Kategori"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(4).HeaderText = "Model"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(5).HeaderText = "HPP"
        DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(5).DefaultCellStyle.Format = "c0"
        DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(6).HeaderText = "Harga Jual"
        DGV.Columns(6).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(6).DefaultCellStyle.Format = "c0"
        DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(7).HeaderText = "Stok Min"
        DGV.Columns(7).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(8).HeaderText = "Usia (Tahun)"
        DGV.Columns(8).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(9).HeaderText = "Usia (Bulan)"
        DGV.Columns(9).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(10).HeaderText = "Stok"
        DGV.Columns(10).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(10).DefaultCellStyle.Format = "n0"
        DGV.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cekClose()

    End Sub

    Sub checkStatusNonNibras()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM config_system WHERE config_name = 'item_non_nibras_button' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then

            If DR.Item("status") = 0 Then
                panelItemBaru.Visible = False
            Else
                panelItemBaru.Visible = True
            End If
        Else
            panelItemBaru.Visible = False
        End If
        cekClose()
    End Sub

    Private Sub DaftarItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                DownloadBarang.Show()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub DaftarItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call checkStatusNonNibras()
        Call Kosongkan()

        TXTCariBarang.Focus()
        TXTCariBarang.Select()
    End Sub

    Private Sub BTNTutup_Click(sender As Object, e As EventArgs) Handles BTNTutup.Click
        Me.Close()
    End Sub

    Private Sub TXTCariBarang_TextChanged(sender As Object, e As EventArgs) Handles TXTCariBarang.TextChanged

        Dim pencarian As String
        If TXTCariBarang.Text.Contains("'") Then
            pencarian = TXTCariBarang.Text.Replace("'", "''")
        Else
            pencarian = TXTCariBarang.Text
        End If

        cekOpen()
        DA = New MySqlDataAdapter("SELECT b.`kode_item`, b.`barcode`, b.`nama_barang`, b.`satuan`, k.kategori, m.nama_model, " &
                                  " b.`hpp`, b.`hpj`, b.`stok_min`, TIMESTAMPDIFF( YEAR, b.updatedate, NOW() ) as tahun, TIMESTAMPDIFF( MONTH, b.updatedate, NOW() ) % 12 as bulan, b.stok " &
                                  " FROM barang_m b  " &
                                  " LEFT JOIN mst_kategori k ON k.`kode_kategori` = b.`jenis` " &
                                  " LEFT JOIN mst_model m ON m.kode_model = b.`merek` WHERE b.nama_barang Like '%" & pencarian & "%' OR k.kategori LIKE '%" & pencarian & "%' ORDER BY stok DESC LIMIT 1000", Conn)
        'DS = New DataSet
        'DA.Fill(DS)
        'DGVX.DataSource = DS.Tables(0)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

        DGV.Columns(0).HeaderText = "Kode Item"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(1).HeaderText = "Barcode"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(2).HeaderText = "Nama Barang"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(3).HeaderText = "Satuan"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(4).HeaderText = "Kategori"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(5).HeaderText = "Model"
        DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        DGV.Columns(6).HeaderText = "HPP"
        DGV.Columns(6).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(6).DefaultCellStyle.Format = "c0"
        DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(7).HeaderText = "Harga Jual"
        DGV.Columns(7).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(7).DefaultCellStyle.Format = "c0"
        DGV.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(8).HeaderText = "Stok Min"
        DGV.Columns(8).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(9).HeaderText = "Usia (Tahun)"
        DGV.Columns(9).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(10).HeaderText = "Usia (Bulan)"
        DGV.Columns(10).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(11).HeaderText = "Stok"
        DGV.Columns(11).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGV.Columns(11).DefaultCellStyle.Format = "n0"
        DGV.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cekClose()
    End Sub

    Private Sub TXTCariBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCariBarang.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                DownloadBarang.ShowDialog()
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        TambahItem.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        DownloadBarang.ShowDialog()
    End Sub

    Private Sub DGV_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV.DataError
        Dim view As DataGridView = CType(sender, DataGridView)
        'view.Rows(e.RowIndex).ErrorText = "an error"
        view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "Ooops! Error"
        e.ThrowException = False
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        MainMenu.SplashScreenManager1.ShowWaitForm()
        Threading.Thread.Sleep(2000)

        'Build the CSV file data as a Comma separated string.
        Dim csv As String = String.Empty

        'Add the Header row for CSV file.
        For Each column As DataGridViewColumn In DGV.Columns
            csv += column.HeaderText & ","c
        Next

        'Add new line.
        csv += vbCr & vbLf

        'Adding the Rows
        For Each row As DataGridViewRow In DGV.Rows
            For Each cell As DataGridViewCell In row.Cells
                'Add the Data rows.
                csv += cell.Value.ToString().Replace(",", ";") & ","c
            Next

            'Add new line.
            csv += vbCr & vbLf
        Next

        'Exporting to Excel
        Dim folderPath As String = "C:\NIPOS_EXPORT\"
        If (Not Directory.Exists(folderPath)) Then
            Directory.CreateDirectory(folderPath)
        End If

        Dim nameFile As String = "DaftarItem_" & DateTime.Now.ToString("yyyyMMdd-HHmmss") & ".csv"

        File.WriteAllText(folderPath & nameFile, csv)

        MsgBox("Data Berhasil di Export, Silahkan Periksa pada Folder " & folderPath & nameFile, MsgBoxStyle.Information, "Berhasil!")
        MainMenu.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub btnDiscUmur_Click(sender As Object, e As EventArgs) Handles btnDiscUmur.Click
        MasterGroupUmur.ShowDialog()
    End Sub
End Class