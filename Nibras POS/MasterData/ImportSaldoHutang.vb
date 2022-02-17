Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class ImportSaldoHutang
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Dim tblImport As DataTable

    Sub GenerateTransactionNum()
        cekOpen()
        CMD = New MySqlCommand("select max(no_transaksi) AS no_transaksi from hutang where no_transaksi LIKE 'HT" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("no_transaksi")) Then
            txtNoTransaksi.Text = "HT" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("no_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtNoTransaksi.Text = "HT" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub kosongkan()
        DGV.DataSource = Nothing
        DGV.Rows.Clear()
        ListBox1.Items.Clear()
        txtBrowse.Text = String.Empty

        'Call TampilKodeAkun()
        cbAkun.SelectedIndex = 0
    End Sub

    Sub TampilKodeAkun()
        Dim column As Integer = 0

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan WHERE mainparent = '2-0000' AND tipe = 'D'", Conn)
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

        cbAkun.SelectedIndex = 0
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

    Sub Masuk(ByVal no_faktur As String, ByVal supplier As String,
              ByVal tgl As String, ByVal tgl_jth_tempo As String, ByVal total As String)
        Try
            Dim kodeAkun As String = cbAkun.Text
            Dim strArr() As String
            strArr = kodeAkun.Split("/")

            cekOpen()
            'Dim simpanjurnal As String = "INSERT INTO saldo_awal_hutang (tanggal, kodeacc, namaacc, debet, kredit, tanggal_jt, nomor_transaksi, kode_customer) values ('" &
            '        tgl & "', '" & strArr(0) & "', '" & strArr(1) & "', '0', '" & nominal & "', '" & tgl_jth_tempo & "', '" & notransaksi & "', '" & kodeSupplier & "' )"
            Dim simpanjurnal As String = "INSERT INTO hutang (no_transaksi, no_faktur, kode_supplier, tanggal, tanggal_jt, kodeacc, potongan, total, sisa, keterangan, jenis, created_by, created_date) values ('" &
                    txtNoTransaksi.Text & "', '" &
                    no_faktur & "', '" &
                    supplier & "', '" &
                    tgl & "', '" &
                    tgl_jth_tempo & "', '" &
                    strArr(0) & "', '0', '" &
                    total & "', '" &
                    total & "', '', 'saldo_awal', '" &
                    MainMenu.PanelUser.Text & "', '" &
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' )"
            CMD = New MySqlCommand(simpanjurnal, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            Call InsertLogTrans(txtNoTransaksi.Text, "CREATE", MainMenu.PanelUser.Text, "SALDO AWAL HUTANG | SUPPLIER : " & supplier & " TOTAL Rp. " & Format(total, "N0"))

        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If cbAkun.Text = "" Or cbAkun.Text = "----------------------------------" Or txtBrowse.Text = "" Then
                MsgBox("Kode Akun Tidak Boleh Kosong!", MsgBoxStyle.Critical)
            Else
                imgLoading.Visible = True

                For i As Integer = 0 To tblImport.Rows.Count - 1

                    If tblImport.Rows(i).Item(0).ToString <> "" Then
                        Dim dt As DateTime = Convert.ToDateTime(tblImport.Rows(i).Item(2).ToString)
                        Dim dtTempo As DateTime = Convert.ToDateTime(tblImport.Rows(i).Item(3).ToString)
                        Dim format As String = "yyyy-MM-dd"
                        Dim strTgl As String = dt.ToString(format)
                        Dim strTempo As String = dtTempo.ToString(format)

                        'MsgBox(strTgl & " - " & strTempo)

                        Masuk(
                            tblImport.Rows(i).Item(1).ToString,
                            tblImport.Rows(i).Item(0).ToString,
                            strTgl,
                            strTempo,
                            Double.Parse(tblImport.Rows(i).Item(4).ToString)
                        )
                    End If

                Next

                'MasukSaldoAwal(tqty, ttot)
                MsgBox("Proses Import Selesai!", MsgBoxStyle.Information, "Informasi")
                imgLoading.Visible = False
                Call kosongkan()
                SaldoAwalHutangForm.Kosongkan()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtBrowse_TextChanged(sender As Object, e As EventArgs) Handles txtBrowse.TextChanged
        btnImport.Enabled = (Len(txtBrowse.Text) > 0)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Process.Start("doc\IMPORT_SALDOAWAL_HUTANG.xls")
    End Sub

    Private Sub ImportSaldoAwalPersediaan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call kosongkan()
        Call GenerateTransactionNum()
    End Sub
End Class