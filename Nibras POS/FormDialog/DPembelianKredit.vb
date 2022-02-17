Imports MySql.Data.MySqlClient

Public Class DPembelianKredit
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        TransaksiPembelian.lblKodeKredit.Text = cbAkun.Text & "/" & txtPerkiraan.Text
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        TransaksiPembelian.lblKodeKredit.Text = cbAkun.Text & "/" & txtPerkiraan.Text
        Me.Close()
    End Sub

    Sub GetAkun()
        Dim kodeacc As String = TransaksiPembelian.lblKodeKredit.Text
        Dim strArr() As String
        strArr = kodeacc.Split("/")

        cbAkun.Items.Clear()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE tipe <> 'H' ORDER BY kodeacc", Conn)
        DR = CMD.ExecuteReader

        Dim selected As Integer = 0
        Dim selectedString As String = ""
        Dim index As Integer = 0
        Do While DR.Read
            If DR.Item("kodeacc") = strArr(0) Then
                selected = index
                selectedString = DR.Item("namaacc")
            End If
            cbAkun.Items.Add(DR.Item("kodeacc"))
            index += 1
        Loop
        cekClose()

        cbAkun.SelectedIndex = selected
        txtPerkiraan.Text = selectedString
    End Sub

    Private Sub DPembelianKredit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call GetAkun()
    End Sub

    Private Sub cbAkun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAkun.SelectedIndexChanged
        cekOpen()
        CMD = New MySqlCommand("SELECT namaacc FROM perkiraan WHERE kodeacc = '" & cbAkun.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            txtPerkiraan.Text = DR.Item("namaacc")
        Else
            txtPerkiraan.Text = "ERROR! Nomor Akun Tidak Ditemukan"
        End If
        cekClose()
    End Sub
End Class