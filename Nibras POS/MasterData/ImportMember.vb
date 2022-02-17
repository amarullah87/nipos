Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class ImportMember
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Dim tblImport As DataTable

    Sub kosongkan()
        DGV.DataSource = Nothing
        DGV.Rows.Clear()
        ListBox1.Items.Clear()
        txtBrowse.Text = String.Empty
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

    Sub Masuk(ByVal kode As String, ByVal nama As String, ByVal alamat As String, ByVal kota As String, ByVal prov As String, ByVal kodepos As String, ByVal telepon As String,
              ByVal email As String, ByVal tgl_lahir As String, ByVal kontak As String, ByVal groupmember As String, ByVal tgl_daftar As String, ByVal masa_aktif As String)
        Try

            cekOpen()
            Dim simpan As String = "insert into member_m (kode_member, nama_member, alamat, kota, provinsi, kode_pos, telepon, email, tgl_lahir, kontak, group_member, tgl_daftar, masa_aktif) " &
                    " values ('" & kode & "','" & nama & "','" & alamat & "','" & kota & "','" & prov & "','" & kodepos & "','" & telepon & "', '" & email & "', '" & tgl_lahir & "', '" & kontak & "', '" & groupmember & "', '" & tgl_daftar & "', '" & masa_aktif & "' )" &
                    " ON DUPLICATE KEY UPDATE nama_member = '" & nama & "' "
            CMD = New MySqlCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If MessageBox.Show("Apakah Data Sudah Benar...?! ", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If txtBrowse.Text = "" Then
                MsgBox("Anda belum memilih File!", MsgBoxStyle.Critical)
            Else
                imgLoading.Visible = True

                For i As Integer = 0 To tblImport.Rows.Count - 1

                    If tblImport.Rows(i).Item(0).ToString <> "" Then

                        Dim daftar As DateTime = Convert.ToDateTime(tblImport.Rows(i).Item(18).ToString)
                        Dim aktif As DateTime = Convert.ToDateTime(tblImport.Rows(i).Item(19).ToString)
                        Dim lahir As DateTime = Convert.ToDateTime(tblImport.Rows(i).Item(20).ToString)
                        Dim format As String = "yyyy-MM-dd"
                        Dim strDaftar As String = daftar.ToString(format)
                        Dim strAktif As String = aktif.ToString(format)
                        Dim strLahir As String = lahir.ToString(format)

                        Masuk(
                            tblImport.Rows(i).Item(0).ToString,
                            tblImport.Rows(i).Item(1).ToString,
                            tblImport.Rows(i).Item(2).ToString,
                            tblImport.Rows(i).Item(3).ToString,
                            tblImport.Rows(i).Item(4).ToString,
                            tblImport.Rows(i).Item(6).ToString,
                            tblImport.Rows(i).Item(7).ToString,
                            tblImport.Rows(i).Item(13).ToString,
                            strLahir,
                            tblImport.Rows(i).Item(12).ToString,
                            tblImport.Rows(i).Item(17).ToString.ToUpper,
                            strDaftar,
                            strAktif
                        )
                    End If

                Next

                'MasukSaldoAwal(tqty, ttot)
                MsgBox("Proses Import Selesai!", MsgBoxStyle.Information, "Informasi")
                imgLoading.Visible = False
                Call kosongkan()
                ListDataMember.TampilGrid()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtBrowse_TextChanged(sender As Object, e As EventArgs) Handles txtBrowse.TextChanged
        btnImport.Enabled = (Len(txtBrowse.Text) > 0)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Process.Start("doc\DATA_PELANGGAN.xlsx")
    End Sub

    Private Sub ImportSaldoAwalPersediaan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call kosongkan()
    End Sub
End Class