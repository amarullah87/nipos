Imports System.Data.OleDb

Public Class ImportPembelian

    Dim tblImport As DataTable

    Sub kosongkan()
        DGV.DataSource = Nothing
        DGV.Rows.Clear()
        ListBox1.Items.Clear()
        txtBrowse.Text = String.Empty
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call kosongkan()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If txtBrowse.Text = "" Then
                MsgBox("Anda belum memilih File!", MsgBoxStyle.Critical)
            Else
                imgLoading.Visible = True

                For i As Integer = 0 To tblImport.Rows.Count - 1

                    If tblImport.Rows(i).Item(0).ToString <> "" Then

                        Masuk(
                            tblImport.Rows(i).Item(0).ToString,
                            tblImport.Rows(i).Item(1).ToString,
                            tblImport.Rows(i).Item(2).ToString,
                            tblImport.Rows(i).Item(3).ToString,
                            tblImport.Rows(i).Item(4).ToString
                        )
                    End If

                Next

                'MasukSaldoAwal(tqty, ttot)
                MsgBox("Proses Import Selesai!", MsgBoxStyle.Information, "Informasi")
                imgLoading.Visible = False
                Call kosongkan()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Process.Start("CONTOH_DATA_PEMBELIAN.xls")
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        With OpenFileDialog1
            .FileName = String.Empty
            .InitialDirectory = "Documents"
            .Title = "Pilih File Excel"
            .Filter = "Excel|*.xls;*.xlsx"
        End With

        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Try
                txtBrowse.Text = OpenFileDialog1.FileName
                AmbilNamaSheet(txtBrowse.Text)
            Catch ex As Exception
                MsgBox("Error : " & ex.Message)
            End Try
        End If
    End Sub

    Public Sub AmbilNamaSheet(ByVal FileName As String)
        Dim sConn As String
        sConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"

        Dim conn As New OleDbConnection(sConn)

        conn.Open()

        Dim dtSheets As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim drSheet As DataRow

        ListBox1.Items.Clear()
        For Each drSheet In dtSheets.Rows
            ListBox1.Items.Add(drSheet("TABLE_NAME").ToString())
        Next

        TampilEcxelKeGrid(FileName, ListBox1.Items(0).ToString)

        conn.Close()
    End Sub

    Public Sub TampilEcxelKeGrid(ByVal FileName As String, ByVal SheetName As String)
        Dim exConn As OleDbConnection 'MySqlConnection
        Dim dt As DataSet
        Dim cmd As OleDbDataAdapter 'MySqlDataAdapter

        Dim sConn As String
        sConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"

        'exConn = New MySql.Data.MySqlClient.MySqlConnection(sConn)
        exConn = New OleDbConnection(sConn)
        'cmd = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from [" & SheetName & "]", exConn)
        cmd = New OleDbDataAdapter("select * from [" & SheetName & "]", exConn)
        cmd.TableMappings.Add("Table", SheetName)
        dt = New System.Data.DataSet
        cmd.Fill(dt)
        tblImport = dt.Tables(0)
        DGV.DataSource = tblImport
        'FormatGrid()
        exConn.Close()

        SetDoubleBuffered(DGV, True)
    End Sub

    Sub Masuk(ByVal kode As String, ByVal nama As String, ByVal hargabeli As Double, ByVal qty As Integer, ByVal disc As Double)
        Dim baris As Integer = TransaksiPembelianOld.DGV.RowCount - 1
        TransaksiPembelianOld.DGV.Rows.Add(kode, nama, hargabeli, qty, disc)

        Dim diskon As Double = TransaksiPembelianOld.DGV.Rows(baris).Cells(4).Value / 100
        Dim diskonRupiah As Double = (TransaksiPembelianOld.DGV.Rows(baris).Cells(2).Value * TransaksiPembelianOld.DGV.Rows(baris).Cells(3).Value) * diskon
        TransaksiPembelianOld.DGV.Rows(baris).Cells(5).Value = (TransaksiPembelianOld.DGV.Rows(baris).Cells(2).Value * TransaksiPembelianOld.DGV.Rows(baris).Cells(3).Value) - diskonRupiah

        Call TransaksiPembelianOld.Hitungtransaksi()
    End Sub

    Private Sub txtBrowse_TextChanged(sender As Object, e As EventArgs) Handles txtBrowse.TextChanged
        btnImport.Enabled = (Len(txtBrowse.Text) > 0)
    End Sub

    Private Sub ImportPembelian_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call kosongkan()
    End Sub
End Class