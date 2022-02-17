Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class MasterProfil

    Dim Raw As String

    Sub IDtblprofilOtomatis()
        cekOpen()
        CMD = New MySqlCommand("select idkey from tblprofil order by idkey desc", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            ID.Text = "01"
        Else
            ID.Text = "01"
        End If
        ID.Enabled = False
        cekClose()
    End Sub

    Sub Kosongkan()
        On Error Resume Next
        Nama.Clear()
        Alamat.Clear()
        Telepon.Clear()
        Fax.Clear()
        Email.Clear()
        Website.Clear()
        txtIdToko.Focus()
    End Sub
    Sub CariIdtblprofil()
        cekClose()
        cekOpen()

        CMD = New MySqlCommand("select * from tblprofil LIMIT 1", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Nama.Text = DR.Item(1)
            Alamat.Text = DR.Item(2)
            Telepon.Text = DR.Item(3)
            Fax.Text = DR.Item(4)
            Email.Text = DR.Item(5)
            Website.Text = DR.Item(6)
            txtIdToko.Text = DR.Item(7)
            jenisNHS.Text = DR.Item(8)
            'txtIdToko.Focus()

            Nama.ReadOnly = True
            Alamat.ReadOnly = True
            Telepon.ReadOnly = True
            Fax.ReadOnly = True
            Email.ReadOnly = True
            Website.ReadOnly = True
            txtIdToko.ReadOnly = True
            jenisNHS.ReadOnly = True
        End If
        cekClose()
    End Sub

    Sub EditProfile()
        Nama.ReadOnly = True
        Alamat.ReadOnly = False
        Telepon.ReadOnly = False
        Fax.ReadOnly = True
        Email.ReadOnly = True
        Website.ReadOnly = True
        txtIdToko.ReadOnly = False
        jenisNHS.ReadOnly = False
    End Sub

    Private Sub MasterProfil_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call CariIdtblprofil()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            cekOpen()
            CMD = New MySqlCommand("delete from tblprofil", Conn)
            CMD.ExecuteNonQuery()
            Dim simpan As String = "insert into tblprofil values('" & txtIdToko.Text & "','" & Nama.Text & "','" & Alamat.Text & "', '" & Telepon.Text & "', '" & Fax.Text & " ', '" & Email.Text & "', '" & Website.Text & "', '" & txtIdToko.Text & "', '" & jenisNHS.Text & "')"
            CMD = New MySqlCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
            cekClose()
            'Call Awal()
            MainMenu.PanelID.Text = ID.Text
            MainMenu.PanelJenis.Text = jenisNHS.Text

            Call InsertLogTrans("-", "UPDATE", MainMenu.PanelUser.Text, "Change Profile Toko")

            MsgBox("Data berhasil disimpan")
            Me.Close()

            MainMenu.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BTNTutup_Click(sender As Object, e As EventArgs) Handles BTNTutup.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_DoubleClick(sender As Object, e As EventArgs) Handles SimpleButton2.DoubleClick
        EditProfile()
    End Sub

    Private Sub txtIdToko_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdToko.KeyPress
        If e.KeyChar = Chr(13) Then
            If CheckForInternetConnection() Then
                Try
                    Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "findAllOutlet")
                    Request.Method = "POST"
                    Dim postbody As String = "pencarian=" + txtIdToko.Text
                    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                    Request.ContentType = "application/x-www-form-urlencoded"
                    Request.ContentLength = byteArray.Length
                    Dim dataStream As Stream = Request.GetRequestStream()
                    dataStream.Write(byteArray, 0, byteArray.Length)
                    dataStream.Close()

                    'get HTTP Response
                    Dim Response As WebResponse = Request.GetResponse()
                    Console.WriteLine((CType(Response, HttpWebResponse)).StatusDescription)

                    'read HTTP response
                    Dim Read = New StreamReader(Response.GetResponseStream())
                    Raw = ""
                    Raw = Read.ReadToEnd()
                    'Console.WriteLine(Raw)
                    Dim jsonObject As JObject = JObject.Parse(Raw)
                    If jsonObject.SelectToken("code").ToString = "200" Then

                        Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                        Dim item As JObject = JsonArray(0)
                        Nama.Text = item.SelectToken("nama").ToString
                        Alamat.Text = item.SelectToken("alamat").ToString
                        Telepon.Text = item.SelectToken("no_tlf").ToString
                        Email.Text = item.SelectToken("email").ToString
                        jenisNHS.Text = item.SelectToken("jenis_nhs").ToString
                        ID.Text = item.SelectToken("id").ToString
                        txtIdToko.Text = item.SelectToken("id").ToString
                    Else
                        MsgBox(jsonObject.SelectToken("message").ToString)
                    End If
                Catch ex As WebException
                    If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                        MsgBox(ex.Message.ToString)
                    End If
                End Try

            Else
                MsgBox(Oops_noInternet)
            End If
        End If
    End Sub
End Class