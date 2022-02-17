Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlDataReader

Public Class ImportSaldoAwalPersediaan
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Dim tblImport As DataTable

    Sub kosongkan()
        DGV.DataSource = Nothing
        DGV.Rows.Clear()
        ListBox1.Items.Clear()
        txtBrowse.Text = String.Empty
        cbAkun.SelectedIndex = 0
    End Sub

    Sub TampilKodeAkun()
        Dim column As Integer = 0

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            If DR.Item("level") = 0 Then
                cbAkun.Items.Add("----------------------------------")
            Else
                If DR.Item("tipe") = "H" Then
                    cbAkun.Items.Add("")
                Else
                    cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
                End If
            End If
        Loop
        cekClose()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call kosongkan()
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
        exConn = New System.Data.OleDb.OleDbConnection(sConn)
        'cmd = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from [" & SheetName & "]", exConn)
        cmd = New System.Data.OleDb.OleDbDataAdapter("select * from [" & SheetName & "]", exConn)
        cmd.TableMappings.Add("Table", SheetName)
        dt = New System.Data.DataSet
        cmd.Fill(dt)
        tblImport = dt.Tables(0)
        DGV.DataSource = tblImport
        'FormatGrid()
        exConn.Close()

        SetDoubleBuffered(DGV, True)
    End Sub

    Sub Masuk(ByVal kodeitem As String, ByVal qty As Integer, ByVal hpp As Double)
        Dim SQL As String
        Try
            cekOpen()
            SQL = "INSERT INTO saldo_awal_persediaan (tanggal, kode_item, qty) VALUES " & "('" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & kodeitem & "', '" & qty & "') ON DUPLICATE KEY UPDATE qty = '" & qty & "' "
            CMD = New MySqlCommand(SQL, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("UPDATE barang_m SET stok = '" & qty & "', hpp = '" & hpp & "' WHERE kode_item = '" & kodeitem & "' ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Sub MasukSaldoAwal(ByVal tqty As Integer, ByVal ttot As Double)
        Dim kodeAkun As String = cbAkun.Text
        Dim strArr() As String
        strArr = kodeAkun.Split("/")

        'cekOpen()
        'CMD = New MySqlCommand("INSERT INTO saldo_awal (tanggal, kodeacc, namaacc, debet, kredit) VALUES ('" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & strArr(0) & "', '" & strArr(1) & "', '" & ttot & "', 0) ON DUPLICATE KEY UPDATE debet = '" & ttot & "' ", Conn)
        'CMD.ExecuteNonQuery()
        'cekClose()

        cekOpen()
        CMD = New MySqlCommand("INSERT INTO history_saldo_persediaan (tanggal, qty, total, created_by, created_date) VALUES ('" &
                               Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & tqty & "', '" & ttot & "', '" & MainMenu.PanelUser.Text & "', '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "') ON DUPLICATE KEY UPDATE " &
                               "qty = '" & tqty & "', total = '" & ttot & "', created_date = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' ", Conn)
        CMD.ExecuteNonQuery()
        cekClose()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If cbAkun.Text = "" Or cbAkun.Text = "----------------------------------" Or txtBrowse.Text = "" Then
                MsgBox("Kode Akun Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Else
                imgLoading.Visible = True

                Dim tqty As Integer = 0
                Dim ttot As Double = 0

                For i As Integer = 0 To tblImport.Rows.Count - 1

                    If tblImport.Rows(i).Item(0).ToString <> "" Then
                        Masuk(
                            tblImport.Rows(i).Item(0).ToString,
                            tblImport.Rows(i).Item(1).ToString,
                            tblImport.Rows(i).Item(3).ToString
                        )

                        tqty += Integer.Parse(tblImport.Rows(i).Item(1).ToString)
                        ttot += Integer.Parse(tblImport.Rows(i).Item(1).ToString) * Double.Parse(tblImport.Rows(i).Item(3).ToString)
                    End If
                Next

                MasukSaldoAwal(tqty, ttot)
                MsgBox("Proses Import Selesai!", MsgBoxStyle.Information, "Informasi")
                imgLoading.Visible = False
                Call kosongkan()
                SaldoAwalPersediaan.Kosongkan()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtBrowse_TextChanged(sender As Object, e As EventArgs) Handles txtBrowse.TextChanged
        btnImport.Enabled = (Len(txtBrowse.Text) > 0)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Process.Start("doc\SALDO_PERSEDIAAN.xls")
    End Sub

    Private Sub ImportSaldoAwalPersediaan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call kosongkan()
    End Sub
End Class