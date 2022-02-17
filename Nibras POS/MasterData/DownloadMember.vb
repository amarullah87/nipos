Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class DownloadMember

    Dim Raw As String
    Dim totalData As Integer

    Private Sub BTNTutup_Click(sender As Object, e As EventArgs) Handles BTNTutup.Click
        Me.Close()
    End Sub

    Private Sub DownloadMember_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        TXTCariBarang.Focus()
        TXTCariBarang.Select()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        DGV.Rows.Clear()
        TXTCariBarang.Text = ""
        Raw = ""
        txtTotalData.Text = "Total: 0 Data"
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If Raw <> "" Then

            Dim jsonObject As JObject = JObject.Parse(Raw)
            If jsonObject.SelectToken("code").ToString = "200" Then

                Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                Dim totalData As Integer = JsonArray.Count
                Dim count As Integer = 0
                For Each item As JObject In JsonArray

                    cekOpen()
                    Dim simpan2 As String = "INSERT INTO `member_m` (`kode_member`,`nama_member`,`alamat`,`kota`,`provinsi`,`kode_pos`,`telepon`,`email`,`tgl_lahir`,`kontak`,`limit_piutang`,`limit_hari_piutang`,`jatuh_tempo`,`group_member`,`tipe_diskon`,`deposit`,`tgl_daftar`,`masa_aktif`,`aktif`) VALUES ('" &
                        item.SelectToken("kode_member").ToString & "', '" &
                        item.SelectToken("nama_member").ToString & "', '" &
                        item.SelectToken("alamat").ToString & "', '" &
                        item.SelectToken("kota").ToString & "', '" &
                        item.SelectToken("provinsi").ToString & "', '" &
                        item.SelectToken("kode_pos").ToString & "', '" &
                        item.SelectToken("telepon").ToString & "', '" &
                        item.SelectToken("email").ToString & "', '" &
                        item.SelectToken("tgl_lahir").ToString & "', '" &
                        item.SelectToken("kontak").ToString & "', '" &
                        item.SelectToken("limit_piutang").ToString & "', '" &
                        item.SelectToken("limit_hari_piutang").ToString & "', '" &
                        item.SelectToken("jatuh_tempo").ToString & "', '" &
                        item.SelectToken("group_member").ToString & "', '" &
                        item.SelectToken("tipe_diskon").ToString & "', '" &
                        item.SelectToken("deposit").ToString & "', '" &
                        item.SelectToken("tgl_daftar").ToString & "', '" &
                        item.SelectToken("masa_aktif").ToString & "', '1') ON DUPLICATE KEY UPDATE nama_member = '" & item.SelectToken("nama_member").ToString & "' "

                    CMD = New MySqlCommand(simpan2, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    count += 1
                Next

                If count = totalData Then
                    MsgBox("Data Sudah Tersimpan!")
                End If
            Else
                MsgBox(Oops_401)
            End If
        Else
            MsgBox("Tidak Ada Data untuk di Download!")
        End If
    End Sub

    Private Sub TXTCariBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCariBarang.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            DGV.Rows.Clear()

            If CheckForInternetConnection() Then
                Try

                    'make HTTP Request
                    'Dim Request As HttpWebRequest = HttpWebRequest.Create(uri)
                    Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "downloadMember")
                    Request.Method = "POST"
                    Dim postbody As String = "kode=" + TXTCariBarang.Text
                    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                    Request.ContentType = "application/x-www-form-urlencoded"
                    Request.ContentLength = byteArray.Length
                    Dim dataStream As Stream = Request.GetRequestStream()
                    dataStream.Write(byteArray, 0, byteArray.Length)
                    dataStream.Close()

                    'get HTTP Response
                    Dim Response As WebResponse = Request.GetResponse()
                    'Console.WriteLine((CType(Response, HttpWebResponse)).StatusDescription)

                    'read HTTP response
                    Dim Read = New StreamReader(Response.GetResponseStream())
                    Raw = ""
                    Raw = Read.ReadToEnd()
                    'Console.WriteLine(Raw)
                    'MsgBox(Raw)
                    txtResponse.Text = Raw
                    Dim jsonObject As JObject = JObject.Parse(Raw)
                    If jsonObject.SelectToken("code").ToString = "200" Then

                        Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                        totalData = JsonArray.Count
                        txtTotalData.Text = "Total: " + totalData.ToString + " Data"

                        For Each item As JObject In JsonArray

                            DGV.Rows.Add(
                                item.SelectToken("kode_member").ToString,
                                item.SelectToken("nama_outlet").ToString,
                                item.SelectToken("nama_member").ToString,
                                item.SelectToken("alamat").ToString,
                                item.SelectToken("telepon").ToString
)

                        Next
                    Else
                        MsgBox(Oops_401)
                    End If

                    DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
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