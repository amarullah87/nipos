Imports System.IO
Imports System.Net
Imports System.Text
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json.Linq

Public Class TambahItem
    Private Sub BTNTutup_Click(sender As Object, e As EventArgs) Handles BTNTutup.Click
        Me.Close()
    End Sub

    Sub getMerek()
        cbMerek.Items.Clear()

        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM brand_luar ORDER BY brand ASC", Conn)
        DR = CMD.ExecuteReader
        Do While DR.Read
            cbMerek.Items.Add(DR.Item("brand"))
        Loop
        cekClose()
    End Sub

    Sub kosongkan()
        txtKodeItem.Text = ""
        txtBarcode.Text = ""
        txtNama.Text = ""
        cbSatuan.SelectedIndex = 0
        cbMerek.SelectedIndex = 0
        txtHpp.Text = "0"
        txtHpj.Text = "0"
        txtStokMin.Text = "0"
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call kosongkan()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        cekOpen()
        Dim insertQ As String = "INSERT INTO barang_m (kode_item, barcode, nama_barang, satuan, jenis, merek, hpp, hpj, hpp_avg, tipe, stok_min, stok, keterangan) VALUES " &
            "('" & txtKodeItem.Text & "', " &
            "'" & txtBarcode.Text & "', " &
            "'" & txtNama.Text & "', " &
            "'" & cbSatuan.Text & "', " &
            "NULL, " &
            "'" & cbMerek.Text & "', " &
            "'" & Val(txtHpp.Text.Replace(".", "")) & "', " &
            "'" & Val(txtHpj.Text.Replace(".", "")) & "', " &
            "'0', 'X', " &
            "'" & txtStokMin.Text & "', " &
            "'0', 'NON-NIBRAS')"
        CMD = New MySqlCommand(insertQ, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        '#Upload Item Non Nibras
        Call uploadItemNon(txtKodeItem.Text)
        MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "Perhatian")
        DaftarItem.TampilGrid()
        Me.Close()
    End Sub

    Private Sub TambahItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call getMerek()
        Call kosongkan()
    End Sub

    Private Sub txtHpp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHpp.KeyPress
        If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
        End If

        If e.KeyChar = ChrW(Keys.Return) Then
            If txtHpp.Text = "" Then
                txtHpp.Text = 0
            Else
                txtHpp.Text = FormatNumber(txtHpp.Text, 0)
            End If
        End If
    End Sub

    Private Sub txtHpp_LostFocus(sender As Object, e As EventArgs) Handles txtHpp.LostFocus
        If txtHpp.Text = "" Then
            txtHpp.Text = 0
        Else
            txtHpp.Text = FormatNumber(txtHpp.Text, 0)
        End If
    End Sub

    Private Sub txtHpj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHpj.KeyPress
        If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
        End If

        If e.KeyChar = ChrW(Keys.Return) Then
            If txtHpj.Text = "" Then
                txtHpj.Text = 0
            Else
                txtHpj.Text = FormatNumber(txtHpj.Text, 0)
            End If
        End If
    End Sub

    Private Sub txtHpj_LostFocus(sender As Object, e As EventArgs) Handles txtHpj.LostFocus
        If txtHpp.Text = "" Then
            txtHpj.Text = 0
        Else
            txtHpj.Text = FormatNumber(txtHpj.Text, 0)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim Raw As String

        If CheckForInternetConnection() Then
            Try
                Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "cekBrand")
                Request.Method = "POST"
                Dim postbody As String = "idoutlet=" + MainMenu.PanelID.Text
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                Request.ContentType = "application/x-www-form-urlencoded"
                Request.ContentLength = byteArray.Length
                Dim dataStream As Stream = Request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                'get HTTP Response
                Dim Response As WebResponse = Request.GetResponse()

                'read HTTP response
                Dim Read = New StreamReader(Response.GetResponseStream())
                Raw = ""
                Raw = Read.ReadToEnd()

                Dim jsonObject As JObject = JObject.Parse(Raw)
                If jsonObject.SelectToken("code").ToString = "200" Then

                    Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                    For Each item As JObject In JsonArray

                        cekOpen()
                        CMD = New MySqlCommand("INSERT INTO brand_luar VALUES ('" & item.SelectToken("brand").ToString & "') ON DUPLICATE KEY UPDATE brand = '" & item.SelectToken("brand").ToString & "' ", Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()

                    Next
                Else
                    MsgBox(Oops_401)
                End If

                Call getMerek()
            Catch ex As WebException
                If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                    MsgBox(ex.Message.ToString)
                End If
            End Try

        Else
            MsgBox(Oops_noInternet)
        End If
    End Sub
End Class