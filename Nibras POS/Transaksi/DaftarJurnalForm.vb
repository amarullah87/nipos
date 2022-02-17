Imports DevExpress.XtraEditors.Controls
Imports MySql.Data.MySqlClient

Public Class DaftarJurnalForm

    Sub LoadAkun()
        lookUpEdit.Properties.DataSource = Nothing

        cekOpen()
        DA = New MySqlDataAdapter("SELECT kodeacc, namaacc FROM perkiraan WHERE level <> 0 AND tipe <> 'H' ORDER BY kodeacc ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        lookUpEdit.Properties.DataSource = DS.Tables(0)
        lookUpEdit.Properties.DisplayMember = "namaacc"
        lookUpEdit.Properties.ValueMember = "kodeacc"
        cekClose()
    End Sub

    Sub GenerateNumber()
        cekOpen()
        CMD = New MySqlCommand("select max(nomor_transaksi) AS nomor_transaksi from jurnal where nomor_transaksi LIKE 'JU" & Format(Now, "yyMMdd") & "%' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If IsDBNull(DR.Item("nomor_transaksi")) Then
            txtnofaktur.Text = "JU" + Format(Now, "yyMMdd") + "001"
        Else
            Dim nofaktur As String = DR.Item("nomor_transaksi")
            Dim inc As Integer = nofaktur.Substring(8, 3) + 1
            txtnofaktur.Text = "JU" + Format(Now, "yyMMdd") + String.Format("{0:000}", inc)
        End If
        cekClose()
    End Sub

    Sub Kosongkan()
        DGV.Rows.Clear()
        GenerateNumber()
        cbJenis.SelectedIndex = 0

        lblTotalDebet.Text = 0
        lblTotalKredit.Text = 0
        'Call TampilKodeAkun()
        Call LoadAkun()
    End Sub

    Sub TampilKodeAkun()
        Dim column As Integer = 0

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM perkiraan ", Conn)
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
        cbAkun.SelectedIndex = 3
    End Sub

    Private Sub DaftarJurnalForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 4 Or e.ColumnIndex = 3 Then
            DGV.Rows(e.RowIndex).Cells(3).Value = CDec(DGV.Rows(e.RowIndex).Cells(3).Value)
            DGV.Rows(e.RowIndex).Cells(4).Value = CDec(DGV.Rows(e.RowIndex).Cells(4).Value)
            Call HitungTransaksi()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub HitungTransaksi()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(3).Value
            lblTotalDebet.Text = FormatCurrency(x, 0)
            lblDebetHide.Text = x
        Next

        Dim y As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            y = y + DGV.Rows(baris).Cells(4).Value
            lblTotalKredit.Text = FormatCurrency(y, 0)
            lblKreditHide.Text = y
        Next
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If lookUpEdit.Text.ToString = "" Then
            MsgBox("Tidak Dapat Memilih Parent/ Level 0")
        Else
            DGV.Rows.Add(lookUpEdit.EditValue.ToString, lookUpEdit.Text.ToString, "", 0, 0)
        End If

        'If cbAkun.Text = "----------------------------------" Or cbAkun.Text = "" Then
        '    MsgBox("Tidak Dapat Memilih Parent/ Level 0")
        'Else
        '    Dim kodeAkun As String = cbAkun.Text
        '    Dim strArr() As String
        '    strArr = kodeAkun.Split("/")

        '    DGV.Rows.Add(strArr(0), strArr(1), "", 0, 0)
        'End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If lblDebetHide.Text = lblKreditHide.Text Then
            For baris As Integer = 0 To DGV.RowCount - 1
                Dim urutan As Integer = baris + 1

                cekOpen()
                Dim simpanjurnal As String = "INSERT INTO jurnal (nomor_transaksi, tgl_transaksi, kode_perkiraan, uraian, debet, kredit, keterangan, jenis, urutan) values ('" &
                    txtnofaktur.Text & "', '" & Format(dtptanggal.Value, "yyyy-MM-dd") & " " & DateTime.Now.ToString("HH:mm:ss") & "', '" & DGV.Rows(baris).Cells(0).Value & "', '" & DGV.Rows(baris).Cells(1).Value & "', '" &
                    DGV.Rows(baris).Cells(3).Value & "', '" & DGV.Rows(baris).Cells(4).Value & "', '" & DGV.Rows(baris).Cells(2).Value & "', 5, " & urutan & " )"
                CMD = New MySqlCommand(simpanjurnal, Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            Next

            Call Kosongkan()
            MsgBox("Data Berhasil Disimpan!", MsgBoxStyle.Information)
        Else
            MsgBox("Oops! Jurnal Tidak Balance. Silahkan Perbaiki.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lookUpEdit_Closed(sender As Object, e As ClosedEventArgs) Handles lookUpEdit.Closed
        If lookUpEdit.Text.ToString <> "" Then
            DGV.Rows.Add(lookUpEdit.EditValue.ToString, lookUpEdit.Text.ToString, "", 0, 0)
        End If
    End Sub
End Class