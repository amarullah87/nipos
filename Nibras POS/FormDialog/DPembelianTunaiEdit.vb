Imports MySql.Data.MySqlClient
Public Class DPembelianTunaiEdit
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        UbahPembelian.lblKodeTunai.Text = cbAkun.Text
        Me.Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        UbahPembelian.lblKodeTunai.Text = cbAkun.Text
        Me.Close()
    End Sub

    Sub GetAkun()

        Dim kodeacc As String = UbahPembelian.lblKodeTunai.Text
        Dim strArr() As String
        strArr = kodeacc.Split("/")

        cbAkun.Items.Clear()
        cekOpen()
        CMD = New MySqlCommand(qKasOnly, Conn)
        DR = CMD.ExecuteReader

        Dim selected As Integer = 0
        Dim selectedString As String = ""
        Dim index As Integer = 0
        Do While DR.Read
            If DR.Item("kodeacc") = strArr(0) Then
                selected = index
                selectedString = DR.Item("namaacc")
            End If
            cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
            index += 1
        Loop
        cekClose()

        cbAkun.SelectedIndex = selected
        txtPerkiraan.Text = selectedString
    End Sub

    Private Sub DPembelianTunai_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call GetAkun()
    End Sub

    Private Sub cbAkun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAkun.SelectedIndexChanged
        Dim kodeacc As String = cbAkun.Text
        Dim strArr() As String
        strArr = kodeacc.Split("/")

        cekOpen()
        CMD = New MySqlCommand("SELECT namaacc FROM perkiraan WHERE kodeacc = '" & strArr(0) & "'", Conn)
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